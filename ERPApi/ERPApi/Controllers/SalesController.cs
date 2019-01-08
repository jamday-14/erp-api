using AutoMapper;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERPApi.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ILoggerManager _logger;
        private ISalesService _service;
        private IMapper _mapper;

        public SalesController(
            ILoggerManager logger,
            ISalesService service,
            IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        #region Sales Order
        [HttpGet, Route("orders")]
        [ActionName("Sales.SalesOrder")]
        [Produces(typeof(IList<TblSalesOrders>))]
        public ActionResult GetSalesOrders()
        {
            var records = _service.SalesOrderRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("orders/{id:int}")]
        [ActionName("SalesOrder.Open")]
        [Produces(typeof(TblSalesOrders))]
        public ActionResult GetSalesOrder(int id)
        {
            var record = _service.SalesOrderRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("orders")]
        [ActionName("SalesOrder.New")]
        [ProducesResponseType(201)]
        public ActionResult PostSalesOrder(TblSalesOrders request)
        {
            //var so = _mapper.Map<TblSalesOrders>(request);
            //var sods = _mapper.Map<List<TblSalesOrderDetails>>(request.Details);

            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = System.DateTime.UtcNow;
            request.LastEditedDate = System.DateTime.UtcNow;
            request.IsDr = false;
            request.IsInvoice = false;
            request.Closed = false;
            request.Void = false;
            request.SystemNo = $"SO-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _service.SalesOrderRepo.Create(request);

            _service.Save();

            return Created("sales/orders", new { id = request.Id });
        }

        [HttpPost, Route("order/detail")]
        [ActionName("SalesOrder.New")]
        [ProducesResponseType(201)]
        public ActionResult PostSalesOrderDetail(TblSalesOrderDetails request)
        {
            request.QtyDr = 0;
            request.QtyInvoice = 0;
            request.QtyOnHand = 0;
            request.Closed = false;

            _service.SalesOrderDetailRepo.Create(request);
            _service.Save();

            return Created($"sales/orders/{request.SalesOrderId}/{request.Id}", new { id = request.Id });
        }

        [HttpGet, Route("orders/{customerId:int}/pending")]
        [ActionName("Sales.SalesOrder")]
        [Produces(typeof(IList<TblSalesOrders>))]
        public ActionResult GetPendingSalesOrdersByCustomer(int customerId)
        {
            var records = _service.GetPendingSalesOrdersByCustomer(customerId);

            return Ok(records);
        }

        [HttpGet, Route("orders/{id:int}/details")]
        [ActionName("Sales.SalesOrder")]
        [Produces(typeof(IList<TblSalesOrderDetails>))]
        public ActionResult GetSalesOrderDetails(int id)
        {
            var records = _service.GetSalesOrderDetails(id);

            return Ok(records);
        }

        #endregion

        #region Sales Invoice
        [HttpGet, Route("invoices")]
        [ActionName("Sales.SalesInvoice")]
        [Produces(typeof(IList<TblSalesInvoices>))]
        public ActionResult GetSalesInvoices()
        {
            var records = _service.SalesInvoiceRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("invoices/{id:int}")]
        [ActionName("SalesInvoice.Open")]
        [Produces(typeof(TblSalesInvoices))]
        public ActionResult GetSalesInvoice(int id)
        {
            var record = _service.SalesInvoiceRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("invoices")]
        [ActionName("SalesInvoice.New")]
        [ProducesResponseType(201)]
        public ActionResult PostSalesInvoice(TblSalesInvoices request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Closed = false;
            request.Void = false;
            request.SystemNo = $"SI-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _service.SalesInvoiceRepo.Create(request);
            _service.Save();

            return Created("sales/invoices", new { id = request.Id });
        }

        [HttpPost, Route("invoices/detail")]
        [ActionName("SalesInvoice.New")]
        [ProducesResponseType(201)]
        public ActionResult PostSalesInvoiceDetail(TblSalesInvoiceDetails request)
        {
            request.QtyOnHand = 0;
            request.Closed = false;

            _service.SalesInvoiceDetailRepo.Create(request);

            if (request.DrdetailId != null && request.Drid != null)
            {
                var drDetail = _service.DeliveryReceiptDetailRepo.FindByCondition(x => x.Id == request.DrdetailId && x.DeliveryReceiptId == request.Drid).FirstOrDefault();
                drDetail.QtyInvoice += request.Qty;

                if(drDetail.Soid != null && drDetail.SodetailId != null)
                {
                    var soDetail = _service.SalesOrderDetailRepo.FindByCondition(x => x.Id == drDetail.SodetailId && x.SalesOrderId == drDetail.Soid).FirstOrDefault();
                    soDetail.QtyInvoice += request.Qty;
                }
            }

            _service.Save();

            return Created($"sales/invoices/{request.SalesInvoiceId}/{request.Id}", new { id = request.Id });
        }
        #endregion

        #region Sales Return
        [HttpGet, Route("returns")]
        [ActionName("Sales.SalesReturn")]
        [Produces(typeof(IList<TblSalesReturns>))]
        public ActionResult GetSalesReturns()
        {
            var records = _service.SalesReturnRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("returns/{id:int}")]
        [ActionName("SalesReturn.Open")]
        [Produces(typeof(TblSalesInvoices))]
        public ActionResult GetSalesReturn(int id)
        {
            var record = _service.SalesReturnRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("returns")]
        [ActionName("SalesReturn.New")]
        [ProducesResponseType(201)]
        public ActionResult PostSalesReturn(TblSalesReturns request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Void = false;
            request.SystemNo = $"SR-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _service.SalesReturnRepo.Create(request);
            _service.Save();

            return Created("sales/returns", new { id = request.Id });
        }

        [HttpPost, Route("returns/detail")]
        [ActionName("SalesReturn.New")]
        [ProducesResponseType(201)]
        public ActionResult PostSalesReturnDetail(TblSalesReturnDetails request)
        {
            request.QtyOnHand = 0;

            _service.SalesReturnDetailRepo.Create(request);

            if (request.DrdetailId != null && request.Drid != null)
            {
                var drDetail = _service.DeliveryReceiptDetailRepo.FindByCondition(x => x.Id == request.DrdetailId && x.DeliveryReceiptId == request.Drid).FirstOrDefault();
                drDetail.QtyReturn += request.Qty;
            }

            _service.Save();

            return Created($"sales/returns/{request.SalesReturnId}/{request.Id}", new { id = request.Id });
        }
        #endregion

        #region Delivery Receipts
        [HttpGet, Route("delivery-receipts")]
        [ActionName("Sales.DeliveryReceipt")]
        [Produces(typeof(IList<TblDeliveryReceipts>))]
        public ActionResult GetDeliveryReceipts()
        {
            var records = _service.DeliveryReceiptRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("delivery-receipts/{id:int}")]
        [ActionName("DeliveryReceipt.Open")]
        [Produces(typeof(TblDeliveryReceipts))]
        public ActionResult GetDeliveryReceipt(int id)
        {
            var record = _service.DeliveryReceiptRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("delivery-receipts")]
        [ActionName("DeliveryReceipt.New")]
        [ProducesResponseType(201)]
        public ActionResult PostDeliveryReceipt(TblDeliveryReceipts request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.IsInvoice = false;
            request.Closed = false;
            request.Void = false;
            request.SystemNo = $"DR-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _service.DeliveryReceiptRepo.Create(request);
            _service.Save();

            return Created("sales/delivery-receipts", new { id = request.Id });
        }

        [HttpGet, Route("delivery-receipts/{customerId:int}/pending")]
        [ActionName("Sales.DeliveryReceipt")]
        [Produces(typeof(IList<TblDeliveryReceipts>))]
        public ActionResult GetPendingDeliveryReceiptsByCustomer(int customerId)
        {
            var records = _service.GetPendingDeliveryReceiptsByCustomer(customerId);

            return Ok(records);
        }

        [HttpGet, Route("customers/{customerId:int}/delivery-receipts")]
        [ActionName("Sales.DeliveryReceipt")]
        [Produces(typeof(IList<TblDeliveryReceipts>))]
        public ActionResult GetDeliveryReceiptsByCustomer(int customerId)
        {
            var records = _service.GetDeliveryReceiptsByCustomer(customerId);

            return Ok(records);
        }

        [HttpGet, Route("delivery-receipts/{id:int}/details")]
        [ActionName("Sales.DeliveryReceipt")]
        [Produces(typeof(IList<TblDeliveryReceiptDetails>))]
        public ActionResult GetDeliveryReceiptDetails(int id)
        {
            var records = _service.GetDeliveryReceiptDetails(id);

            return Ok(records);
        }

        [HttpGet, Route("delivery-receipts/{id:int}/details/pending")]
        [ActionName("Sales.DeliveryReceipt")]
        [Produces(typeof(IList<TblDeliveryReceiptDetails>))]
        public ActionResult GetDeliveryReceiptDetailsPendingInvoice(int id)
        {
            var records = _service.GetDeliveryReceiptDetailsPendingInvoice(id);

            return Ok(records);
        }


        [HttpPost, Route("delivery-receipts/detail")]
        [ActionName("DeliveryReceipt.New")]
        [ProducesResponseType(201)]
        public ActionResult PostDeliveryReceiptDetail(TblDeliveryReceiptDetails request)
        {
            request.QtyInvoice = 0;
            request.QtyOnHand = 0;
            request.QtyReturn = 0;
            request.Closed = false;

            _service.DeliveryReceiptDetailRepo.Create(request);

            if(request.SodetailId != null && request.Soid != null)
            {
                var salesOrderDetail = _service.SalesOrderDetailRepo.FindByCondition(x => x.Id == request.SodetailId && x.SalesOrderId == request.Soid).FirstOrDefault();
                salesOrderDetail.QtyDr += request.Qty;
            }

            _service.Save();

            return Created($"sales/delivery-receipts/{request.DeliveryReceiptId}/{request.Id}", new { id = request.Id });
        }
        #endregion


    }
}
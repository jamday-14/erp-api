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
            var records = _service.SalesOrderRepo.FindAll().OrderByDescending(x => x.Date);

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
            var records = _service.SalesOrderRepo.GetPendingByCustomer(customerId).ToList();

            return Ok(records);
        }

        [HttpGet, Route("orders/{id:int}/details")]
        [ActionName("Sales.SalesOrder")]
        [Produces(typeof(IList<TblSalesOrderDetails>))]
        public ActionResult GetSalesOrderDetails(int id)
        {
            var records = _service.SalesOrderDetailRepo.GetByOrderId(id).ToList();

            return Ok(records);
        }

        [HttpGet, Route("orders/{id:int}/details/pending")]
        [ActionName("Sales.SalesOrder")]
        [Produces(typeof(IList<TblSalesOrderDetails>))]
        public ActionResult GetSalesOrderDetailsPendingDR(int id)
        {
            var records = _service.SalesOrderDetailRepo.GetByPendingDeliveryReceipt(id).ToList();

            return Ok(records);
        }

        [HttpDelete, Route("orders/{soId:int}/details/{sodId:int}")]
        [ActionName("SalesOrder.Edit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeleteSalesOrderDetail(int soId, int sodId)
        {
            var record = _service.SalesOrderDetailRepo.FindByCondition(x => x.Id == sodId && x.SalesOrderId == soId).FirstOrDefault();

            if (record == null)
                return NotFound();

            _service.SalesOrderDetailRepo.Delete(record);

            _service.Save();

            return NoContent();
        }

        [HttpPatch, Route("orders/{id:int}")]
        [ActionName("SalesOrder.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateSalesOrder(int id, TblSalesOrders request)
        {
            var record = _service.SalesOrderRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (record == null)
                return NotFound();

            record.Address = request.Address;
            record.Amount = request.Amount;
            record.Comments = request.Comments;
            record.ContactPerson = request.ContactPerson;
            record.Date = request.Date;
            record.FaxNo = request.FaxNo;
            record.RefNo = request.RefNo;
            record.TelNo = request.TelNo;
            record.TermId = request.TermId;

            record.LastEditedById = Statics.LoggedInUser.userId;
            record.LastEditedDate = System.DateTime.UtcNow;

            _service.Save();

            return Ok(record);
        }

        [HttpPatch, Route("orders/{soId:int}/details/{sodId:int}")]
        [ActionName("SalesOrder.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateSalesOrderDetail(int soId, int sodId, TblSalesOrderDetails request)
        {
            var record = _service.SalesOrderDetailRepo.FindByCondition(x => x.Id == sodId && x.SalesOrderId == soId).FirstOrDefault();

            if (record == null)
                return NotFound();

            record.Discount = request.Discount;
            record.ItemId = request.ItemId;
            record.Qty = request.Qty;
            record.Remarks = request.Remarks;
            record.SubTotal = request.SubTotal;
            record.UnitId = request.UnitId;
            record.UnitPrice = request.UnitPrice;

            _service.Save();

            return Ok(record);
        }

        #endregion

        #region Delivery Receipts
        [HttpGet, Route("delivery-receipts")]
        [ActionName("Sales.DeliveryReceipt")]
        [Produces(typeof(IList<TblDeliveryReceipts>))]
        public ActionResult GetDeliveryReceipts()
        {
            var records = _service.DeliveryReceiptRepo.FindAll().OrderByDescending(x => x.Date);

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
            var records = _service.DeliveryReceiptRepo.GetPendingByCustomer(customerId);

            return Ok(records);
        }

        [HttpGet, Route("customers/{customerId:int}/delivery-receipts")]
        [ActionName("Sales.DeliveryReceipt")]
        [Produces(typeof(IList<TblDeliveryReceipts>))]
        public ActionResult GetDeliveryReceiptsByCustomer(int customerId)
        {
            var records = _service.DeliveryReceiptRepo.GetByCustomer(customerId);

            return Ok(records);
        }

        [HttpGet, Route("delivery-receipts/{id:int}/details")]
        [ActionName("Sales.DeliveryReceipt")]
        [Produces(typeof(IList<TblDeliveryReceiptDetails>))]
        public ActionResult GetDeliveryReceiptDetails(int id)
        {
            var records = _service.DeliveryReceiptDetailRepo.GetByDeliveryReceiptId(id).ToList();

            return Ok(records);
        }

        [HttpGet, Route("delivery-receipts/{id:int}/details/pending")]
        [ActionName("Sales.DeliveryReceipt")]
        [Produces(typeof(IList<TblDeliveryReceiptDetails>))]
        public ActionResult GetDeliveryReceiptDetailsPendingInvoice(int id)
        {
            var records = _service.DeliveryReceiptDetailRepo.GetByPendingInvoice(id).ToList();

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

            if (request.SodetailId != null && request.Soid != null)
            {
                var salesOrderDetail = _service.SalesOrderDetailRepo.FindByCondition(x => x.Id == request.SodetailId && x.SalesOrderId == request.Soid).FirstOrDefault();
                salesOrderDetail.QtyDr += request.Qty;
            }

            _service.Save();

            return Created($"sales/delivery-receipts/{request.DeliveryReceiptId}/{request.Id}", new { id = request.Id });
        }

        [HttpPatch, Route("delivery-receipts/{id:int}")]
        [ActionName("DeliveryReceipt.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateDeliveryReceipt(int id, TblDeliveryReceipts request)
        {
            var record = _service.DeliveryReceiptRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (record == null)
                return NotFound();

            record.Address = request.Address;
            record.Amount = request.Amount;
            record.Comments = request.Comments;
            record.ContactPerson = request.ContactPerson;
            record.Date = request.Date;
            record.FaxNo = request.FaxNo;
            record.RefNo = request.RefNo;
            record.TelNo = request.TelNo;
            record.TermId = request.TermId;

            record.LastEditedById = Statics.LoggedInUser.userId;
            record.LastEditedDate = System.DateTime.UtcNow;

            _service.Save();

            return Ok(record);
        }

        [HttpPatch, Route("delivery-receipts/{drId:int}/details/{drdId:int}")]
        [ActionName("DeliveryReceipt.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateDeliveryReceiptDetail(int drId, int drdId, TblDeliveryReceiptDetails request)
        {
            var record = _service.DeliveryReceiptDetailRepo.FindByCondition(x => x.Id == drdId && x.DeliveryReceiptId == drId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (request.SodetailId != null && request.Soid != null)
            {
                var salesOrderDetail = _service.SalesOrderDetailRepo.FindByCondition(x => x.Id == request.SodetailId && x.SalesOrderId == request.Soid).FirstOrDefault();
                salesOrderDetail.QtyDr -= record.Qty;
                salesOrderDetail.QtyDr += request.Qty;
            }

            record.Discount = request.Discount;
            record.ItemId = request.ItemId;
            record.Qty = request.Qty;
            record.Remarks = request.Remarks;
            record.SubTotal = request.SubTotal;
            record.UnitId = request.UnitId;
            record.UnitPrice = request.UnitPrice;
            record.WarehouseId = request.WarehouseId;
            record.SorefNo = request.SorefNo;

            _service.Save();

            return Ok(record);
        }

        [HttpDelete, Route("delivery-receipts/{drId:int}/details/{drdId:int}")]
        [ActionName("DeliveryReceipt.Edit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeleteDeliveryReceiptDetail(int drId, int drdId)
        {
            var record = _service.DeliveryReceiptDetailRepo.FindByCondition(x => x.Id == drdId && x.DeliveryReceiptId == drId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (record.SodetailId != null && record.Soid != null)
            {
                var salesOrderDetail = _service.SalesOrderDetailRepo.FindByCondition(x => x.Id == record.SodetailId && x.SalesOrderId == record.Soid).FirstOrDefault();
                salesOrderDetail.QtyDr -= record.Qty;
            }

            _service.DeliveryReceiptDetailRepo.Delete(record);

            _service.Save();

            return NoContent();
        }
        #endregion

        #region Sales Invoice
        [HttpGet, Route("invoices")]
        [ActionName("Sales.SalesInvoice")]
        [Produces(typeof(IList<TblSalesInvoices>))]
        public ActionResult GetSalesInvoices()
        {
            var records = _service.SalesInvoiceRepo.FindAll().OrderByDescending(x => x.Date);

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

                if (drDetail.Soid != null && drDetail.SodetailId != null)
                {
                    var soDetail = _service.SalesOrderDetailRepo.FindByCondition(x => x.Id == drDetail.SodetailId && x.SalesOrderId == drDetail.Soid).FirstOrDefault();
                    soDetail.QtyInvoice += request.Qty;
                }
            }

            _service.Save();

            return Created($"sales/invoices/{request.SalesInvoiceId}/{request.Id}", new { id = request.Id });
        }

        [HttpGet, Route("invoices/{id:int}/details")]
        [ActionName("Sales.SalesInvoice")]
        [Produces(typeof(IList<TblSalesInvoiceDetails>))]
        public ActionResult GetSalesInvoiceDetails(int id)
        {
            var records = _service.SalesInvoiceDetailRepo.GetByInvoiceId(id).ToList();

            return Ok(records);
        }

        [HttpPatch, Route("invoices/{id:int}")]
        [ActionName("SalesInvoice.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateSalesInvoice(int id, TblSalesInvoices request)
        {
            var record = _service.SalesInvoiceRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (record == null)
                return NotFound();

            record.Address = request.Address;
            record.Amount = request.Amount;
            record.Comments = request.Comments;
            record.ContactPerson = request.ContactPerson;
            record.Date = request.Date;
            record.FaxNo = request.FaxNo;
            record.RefNo = request.RefNo;
            record.TelNo = request.TelNo;
            record.TermId = request.TermId;

            record.LastEditedById = Statics.LoggedInUser.userId;
            record.LastEditedDate = System.DateTime.UtcNow;

            _service.Save();

            return Ok(record);
        }

        [HttpPatch, Route("invoices/{siId:int}/details/{sidId:int}")]
        [ActionName("SalesInvoice.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateSalesInvoiceDetail(int siId, int sidId, TblSalesInvoiceDetails request)
        {
            var record = _service.SalesInvoiceDetailRepo.FindByCondition(x => x.Id == sidId && x.SalesInvoiceId == siId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (request.DrdetailId != null && request.Drid != null)
            {
                var drDetail = _service.DeliveryReceiptDetailRepo.FindByCondition(x => x.Id == request.DrdetailId && x.DeliveryReceiptId == request.Drid).FirstOrDefault();
                drDetail.QtyInvoice -= record.Qty;
                drDetail.QtyInvoice += request.Qty;
            }

            record.Discount = request.Discount;
            record.ItemId = request.ItemId;
            record.Qty = request.Qty;
            record.SubTotal = request.SubTotal;
            record.UnitId = request.UnitId;
            record.UnitPrice = request.UnitPrice;
            record.WarehouseId = request.WarehouseId;
            record.DrrefNo = request.DrrefNo;

            _service.Save();

            return Ok(record);
        }

        [HttpDelete, Route("invoices/{siId:int}/details/{sidId:int}")]
        [ActionName("SalesInvoice.Edit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeleteSalesInvoiceDetail(int siId, int sidId)
        {
            var record = _service.SalesInvoiceDetailRepo.FindByCondition(x => x.Id == sidId && x.SalesInvoiceId == siId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (record.DrdetailId != null && record.Drid != null)
            {
                var drDetail = _service.DeliveryReceiptDetailRepo.FindByCondition(x => x.Id == record.DrdetailId && x.DeliveryReceiptId == record.Drid).FirstOrDefault();
                drDetail.QtyInvoice -= record.Qty;
            }

            _service.SalesInvoiceDetailRepo.Delete(record);

            _service.Save();

            return NoContent();
        }

        [HttpGet, Route("customers/{customerId:int}/sales-invoices")]
        [ActionName("Sales.SalesInvoice")]
        [Produces(typeof(IList<TblSalesInvoices>))]
        public ActionResult GetSalesInvoicesByCustomer(int customerId)
        {
            var records = _service.SalesInvoiceRepo.GetByCustomer(customerId);

            return Ok(records);
        }
        #endregion

        #region Sales Return
        [HttpGet, Route("returns")]
        [ActionName("Sales.SalesReturn")]
        [Produces(typeof(IList<TblSalesReturns>))]
        public ActionResult GetSalesReturns()
        {
            var records = _service.SalesReturnRepo.FindAll().OrderByDescending(x => x.Date);

            return Ok(records);
        }

        [HttpGet, Route("returns/{id:int}")]
        [ActionName("SalesReturn.Open")]
        [Produces(typeof(TblSalesReturns))]
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

            if (request.ReferenceDetailId != null && request.ReferenceId != null && request.ReferenceTypeId ==3)
            {
                var drDetail = _service.DeliveryReceiptDetailRepo.FindByCondition(x => x.Id == request.ReferenceDetailId && x.DeliveryReceiptId == request.ReferenceId).FirstOrDefault();
                drDetail.QtyReturn += request.Qty;
            }

            if (request.ReferenceDetailId != null && request.ReferenceId != null && request.ReferenceTypeId == 4)
            {
                var siDetail = _service.SalesInvoiceDetailRepo.FindByCondition(x => x.Id == request.ReferenceDetailId && x.SalesInvoiceId == request.ReferenceId).FirstOrDefault();
                siDetail.QtyReturn += request.Qty;
            }

            _service.Save();

            return Created($"sales/returns/{request.SalesReturnId}/{request.Id}", new { id = request.Id });
        }

        [HttpGet, Route("returns/{id:int}/details")]
        [ActionName("Sales.SalesReturn")]
        [Produces(typeof(IList<TblSalesReturnDetails>))]
        public ActionResult GetSalesReturnDetails(int id)
        {
            var records = _service.SalesReturnDetailRepo.GetBySalesReturnId(id).ToList();

            return Ok(records);
        }

        [HttpPatch, Route("returns/{id:int}")]
        [ActionName("SalesReturn.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateSalesReturn(int id, TblSalesReturns request)
        {
            var record = _service.SalesReturnRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (record == null)
                return NotFound();

            record.RefNo = request.RefNo;
            record.Remarks = request.Remarks;
            record.WarehouseId = request.WarehouseId;
            record.Date = request.Date;
            record.RefNo = request.RefNo;
            record.LastEditedById = Statics.LoggedInUser.userId;
            record.LastEditedDate = System.DateTime.UtcNow;

            _service.Save();

            return Ok(record);
        }

        [HttpPatch, Route("returns/{srId:int}/details/{srdId:int}")]
        [ActionName("SalesReturn.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateSalesReturnDetail(int srId, int srdId, TblSalesReturnDetails request)
        {
            var record = _service.SalesReturnDetailRepo.FindByCondition(x => x.Id == srdId && x.SalesReturnId == srId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (request.ReferenceDetailId != null && request.ReferenceId != null && request.ReferenceTypeId == 3)
            {
                var drDetail = _service.DeliveryReceiptDetailRepo.FindByCondition(x => x.Id == request.ReferenceDetailId && x.DeliveryReceiptId == request.ReferenceId).FirstOrDefault();
                drDetail.QtyReturn -= record.Qty;
                drDetail.QtyReturn += request.Qty;
            }

            if (request.ReferenceDetailId != null && request.ReferenceId != null && request.ReferenceTypeId == 4)
            {
                var siDetail = _service.SalesInvoiceDetailRepo.FindByCondition(x => x.Id == request.ReferenceDetailId && x.SalesInvoiceId == request.ReferenceId).FirstOrDefault();
                siDetail.QtyReturn -= record.Qty;
                siDetail.QtyReturn += request.Qty;
            }

            record.Discount = request.Discount;
            record.ItemId = request.ItemId;
            record.Qty = request.Qty;
            record.SubTotal = request.SubTotal;
            record.UnitId = request.UnitId;
            record.UnitPrice = request.UnitPrice;
            record.WarehouseId = request.WarehouseId;
            record.ReferenceNo = request.ReferenceNo;
            record.ReferenceId = request.ReferenceId;
            record.ReferenceDetailId = request.ReferenceDetailId;

            _service.Save();

            return Ok(record);
        }

        [HttpDelete, Route("returns/{srId:int}/details/{srdId:int}")]
        [ActionName("SalesReturn.Edit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeleteSalesReturnDetail(int srId, int srdId)
        {
            var record = _service.SalesReturnDetailRepo.FindByCondition(x => x.Id == srdId && x.SalesReturnId == srId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (record.ReferenceDetailId != null && record.ReferenceId != null && record.ReferenceTypeId == 3)
            {
                var drDetail = _service.DeliveryReceiptDetailRepo.FindByCondition(x => x.Id == record.ReferenceDetailId && x.DeliveryReceiptId == record.ReferenceId).FirstOrDefault();
                drDetail.QtyReturn -= record.Qty;
            }

            if (record.ReferenceDetailId != null && record.ReferenceId != null && record.ReferenceTypeId == 4)
            {
                var siDetail = _service.SalesInvoiceDetailRepo.FindByCondition(x => x.Id == record.ReferenceDetailId && x.SalesInvoiceId == record.ReferenceId).FirstOrDefault();
                siDetail.QtyReturn -= record.Qty;
            }

            _service.SalesReturnDetailRepo.Delete(record);

            _service.Save();

            return NoContent();
        }
        #endregion


    }
}
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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

        public SalesController(ILoggerManager logger, ISalesService service)
        {
            _logger = logger;
            _service = service;
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
            _service.SalesOrderRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("SalesOrder.Open", new { id = request.Id });
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
            _service.SalesInvoiceRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("SalesInvoice.Open", new { id = request.Id });
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
            _service.SalesReturnRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("SalesReturn.Open", new { id = request.Id });
        }
        #endregion

        #region Sales Return
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
            _service.DeliveryReceiptRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("DeliveryReceipt.Open", new { id = request.Id });
        }
        #endregion
    }
}
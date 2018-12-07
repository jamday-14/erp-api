using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERPApi.Controllers
{
    [Route("api/accounting")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private ILoggerManager _logger;
        private IAccountingService _service;

        public AccountingController(ILoggerManager logger, IAccountingService service)
        {
            _logger = logger;
            _service = service;
        }

        #region Bill Payment
        [HttpGet, Route("bill-payments")]
        [ActionName("Accounting.BillPayment")]
        [Produces(typeof(IList<TblBillPayments>))]
        public ActionResult GetBillPayments()
        {
            var records = _service.BillPaymentRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("bill-payments/{id:int}")]
        [ActionName("BillPayment.Open")]
        [Produces(typeof(TblBillPayments))]
        public ActionResult GetBillPayment(int id)
        {
            var record = _service.BillPaymentRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("bill-payments")]
        [ActionName("BillPayment.New")]
        [ProducesResponseType(201)]
        public ActionResult PostBillPayment(TblBillPayments request)
        {
            _service.BillPaymentRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("BillPayment.Open", new { id = request.Id });
        }
        #endregion

        #region Sales Invoice Payment
        [HttpGet, Route("sales-invoice-payments")]
        [ActionName("Accounting.SalesInvoicePayment")]
        [Produces(typeof(IList<TblSalesInvoicePayments>))]
        public ActionResult GetSalesInvoicePayments()
        {
            var records = _service.SalesInvoicePaymentRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("sales-invoice-payments/{id:int}")]
        [ActionName("SalesInvoicePayment.Open")]
        [Produces(typeof(TblSalesInvoicePayments))]
        public ActionResult GetSalesInvoicePayment(int id)
        {
            var record = _service.SalesInvoicePaymentRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("sales-invoice-payments")]
        [ActionName("SalesInvoicePayment.New")]
        [ProducesResponseType(201)]
        public ActionResult PostSalesInvoicePayment(TblSalesInvoicePayments request)
        {
            _service.SalesInvoicePaymentRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("SalesInvoicePayment.Open", new { id = request.Id });
        }
        #endregion
    }
}
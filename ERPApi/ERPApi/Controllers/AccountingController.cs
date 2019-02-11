using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var records = _service.BillPaymentRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);
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
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Void = false;
            request.SystemNo = $"BP-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _service.BillPaymentRepo.Create(request);
            _service.Save();

            return Created("accounting/bill-payments", new { id = request.Id });
        }
        #endregion

        #region Sales Invoice Payment
        [HttpGet, Route("sales-invoice-payments")]
        [ActionName("Accounting.SalesInvoicePayment")]
        [Produces(typeof(IList<TblSalesInvoicePayments>))]
        public ActionResult GetSalesInvoicePayments()
        {
            var records = _service.SalesInvoicePaymentRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);

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
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Void = false;
            request.SystemNo = $"BP-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _service.SalesInvoicePaymentRepo.Create(request);
            _service.Save();

            return Created("accounting/sales-invoice-payments", new { id = request.Id });
        }
        #endregion

        #region ChartOfAccounts
        [HttpGet, Route("chart-of-accounts")]
        [ActionName("Accounting.BillPayment")]
        [Produces(typeof(IList<TblAccounts>))]
        public ActionResult GetAccounts()
        {
            var records = _service.AccountRepo.FindAll()
                .OrderByDescending(x => x.Code).ThenBy(x=> x.Name);
            return Ok(records);
        }

        [HttpGet, Route("chart-of-accounts/{id:int}")]
        [ActionName("BillPayment.Open")]
        [Produces(typeof(TblAccounts))]
        public ActionResult GetAccount(int id)
        {
            var record = _service.AccountRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("chart-of-accounts")]
        [ActionName("BillPayment.New")]
        [ProducesResponseType(201)]
        public ActionResult PostAccount(TblAccounts request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.ModifiedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.ModificationDate = DateTime.UtcNow;
            request.CompanyId = Statics.LoggedInUser.companyId;
            request.Active = true;

            _service.AccountRepo.Create(request);
            _service.Save();

            return Created("accounting/chart-of-accounts", new { id = request.Id });
        }
        #endregion
    }
}
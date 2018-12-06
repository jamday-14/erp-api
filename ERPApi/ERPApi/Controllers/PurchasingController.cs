using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERPApi.Controllers
{
    [Route("api/purchasing")]
    [ApiController]
    public class PurchasingController : ControllerBase
    {
        private ILoggerManager _logger;
        private IPurchasingService _service;

        public PurchasingController(ILoggerManager logger, IPurchasingService service)
        {
            _logger = logger;
            _service = service;
        }

        #region Purchase Order
        [HttpGet, Route("orders")]
        [ActionName("Purchasing.PurchaseOrder")]
        [Produces(typeof(IList<TblPurchaseOrders>))]
        public ActionResult GetPurchaseOrders()
        {
            var records = _service.PurchaseOrderRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("orders/{id:int}")]
        [ActionName("PurchaseOrder.Open")]
        [Produces(typeof(TblPurchaseOrders))]
        public ActionResult GetPurchaseOrder(int id)
        {
            var record = _service.PurchaseOrderRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("orders")]
        [ActionName("PurchaseOrder.New")]
        [ProducesResponseType(201)]
        public ActionResult PostPurchaseOrder(TblPurchaseOrders request)
        {
            _service.PurchaseOrderRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("PurchaseOrder.Open", new { id = request.Id });
        }
        #endregion

        #region Purchase Return
        [HttpGet, Route("returns")]
        [ActionName("Purchasing.PurchaseReturn")]
        [Produces(typeof(IList<TblPurchaseReturns>))]
        public ActionResult GetPurchaseReturns()
        {
            var records = _service.PurchaseReturnRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("returns/{id:int}")]
        [ActionName("PurchaseReturn.Open")]
        [Produces(typeof(TblPurchaseReturns))]
        public ActionResult GetPurchaseReturn(int id)
        {
            var record = _service.PurchaseReturnRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("returns")]
        [ActionName("PurchaseReturn.New")]
        [ProducesResponseType(201)]
        public ActionResult PostPurchaseReturn(TblPurchaseReturns request)
        {
            _service.PurchaseReturnRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("PurchaseReturn.Open", new { id = request.Id });
        }
        #endregion

        #region Bill
        [HttpGet, Route("bills")]
        [ActionName("Purchasing.Bill")]
        [Produces(typeof(IList<TblBills>))]
        public ActionResult GetBills()
        {
            var records = _service.BillRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("bills/{id:int}")]
        [ActionName("Bill.Open")]
        [Produces(typeof(TblBills))]
        public ActionResult GetBill(int id)
        {
            var record = _service.BillRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("bills")]
        [ActionName("Bill.New")]
        [ProducesResponseType(201)]
        public ActionResult PostBill(TblBills request)
        {
            _service.BillRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("Bill.Open", new { id = request.Id });
        }
        #endregion

        #region Receiving Report
        [HttpGet, Route("receiving-reports")]
        [ActionName("Purchasing.ReceivingReport")]
        [Produces(typeof(IList<TblReceivingReportDetails>))]
        public ActionResult GetReceivingReports()
        {
            var records = _service.ReceivingReportRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("receiving-reports/{id:int}")]
        [ActionName("ReceivingReport.Open")]
        [Produces(typeof(TblReceivingReportDetails))]
        public ActionResult GetReceivingReport(int id)
        {
            var record = _service.ReceivingReportRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("receiving-reports")]
        [ActionName("ReceivingReport.New")]
        [ProducesResponseType(201)]
        public ActionResult PostReceivingReport(TblReceivingReportDetails request)
        {
            _service.ReceivingReportRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("ReceivingReport.Open", new { id = request.Id });
        }
        #endregion
    }
}
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
    [Route("api/purchasing")]
    [ApiController]
    public class PurchasingController : ControllerBase
    {
        private ILoggerManager _logger;
        private IPurchasingService _purchasingService;
        private IInventoryService _inventoryService;
        private IMapper _mapper;

        public PurchasingController(
            ILoggerManager logger,
            IPurchasingService purchasingService,
            IInventoryService inventoryService,
            IMapper mapper)
        {
            _logger = logger;
            _purchasingService = purchasingService;
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        #region Purchase Order
        [HttpGet, Route("orders")]
        [ActionName("Purchasing.PurchaseOrder")]
        [Produces(typeof(IList<TblPurchaseOrders>))]
        public ActionResult GetPurchaseOrders()
        {
            var records = _purchasingService.PurchaseOrderRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);

            return Ok(records);
        }

        [HttpGet, Route("orders/{id:int}")]
        [ActionName("PurchaseOrder.Open")]
        [Produces(typeof(TblPurchaseOrders))]
        public ActionResult GetPurchaseOrder(int id)
        {
            var record = _purchasingService.PurchaseOrderRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("orders")]
        [ActionName("PurchaseOrder.New")]
        [ProducesResponseType(201)]
        public ActionResult PostPurchaseOrder(TblPurchaseOrders request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = System.DateTime.UtcNow;
            request.LastEditedDate = System.DateTime.UtcNow;
            request.IsReceived = false;
            request.IsBilled = false;
            request.Closed = false;
            request.Void = false;
            request.SystemNo = $"PO-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _purchasingService.PurchaseOrderRepo.Create(request);

            _purchasingService.Save();

            return Created("purchasing/orders", new { id = request.Id });
        }

        [HttpPost, Route("order/detail")]
        [ActionName("PurchaseOrder.New")]
        [ProducesResponseType(201)]
        public ActionResult PostPurchaseOrderDetail(TblPurchaseOrderDetails request)
        {
            request.QtyBilled = 0;
            request.QtyLeft = 0;
            request.QtyReceived = 0;
            request.QtyOnHand = 0;
            request.Closed = false;

            _purchasingService.PurchaseOrderDetailRepo.Create(request);
            _purchasingService.Save();

            return Created($"purchasing/orders/{request.PurchaseOrderId}/{request.Id}", new { id = request.Id });
        }

        [HttpGet, Route("orders/{vendorId:int}/pending")]
        [ActionName("Purchasing.PurchaseOrder")]
        [Produces(typeof(IList<TblPurchaseOrders>))]
        public ActionResult GetPendingPurchaseOrdersByVendor(int vendorId)
        {
            var records = _purchasingService.PurchaseOrderRepo.GetPendingByVendor(vendorId).ToList();

            return Ok(records);
        }

        [HttpGet, Route("orders/{id:int}/details")]
        [ActionName("Purchasing.PurchaseOrder")]
        [Produces(typeof(IList<TblPurchaseOrderDetails>))]
        public ActionResult GetPurchaseOrderDetails(int id)
        {
            var records = _purchasingService.PurchaseOrderDetailRepo.GetByOrderId(id).ToList();

            return Ok(records);
        }

        [HttpGet, Route("orders/{id:int}/details/pending")]
        [ActionName("Purchasing.PurchaseOrder")]
        [Produces(typeof(IList<TblPurchaseOrderDetails>))]
        public ActionResult GetPurchaseOrderDetailsPendingRR(int id)
        {
            var records = _purchasingService.PurchaseOrderDetailRepo.GetByPendingReceivingReport(id).ToList();

            return Ok(records);
        }

        [HttpDelete, Route("orders/{poId:int}/details/{podId:int}")]
        [ActionName("PurchaseOrder.Edit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeletePurchaseOrderDetail(int poId, int podId)
        {
            var record = _purchasingService.PurchaseOrderDetailRepo.FindByCondition(x => x.Id == podId && x.PurchaseOrderId == poId).FirstOrDefault();

            if (record == null)
                return NotFound();

            _purchasingService.PurchaseOrderDetailRepo.Delete(record);

            _purchasingService.Save();

            return NoContent();
        }

        [HttpPatch, Route("orders/{id:int}")]
        [ActionName("PurchaseOrder.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdatePurchaseOrder(int id, TblPurchaseOrders request)
        {
            var record = _purchasingService.PurchaseOrderRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (record == null)
                return NotFound();

            record.Address = request.Address;
            record.Amount = request.Amount;
            record.ContactPerson = request.ContactPerson;
            record.Date = request.Date;
            record.FaxNo = request.FaxNo;
            record.RefNo = request.RefNo;
            record.TelNo = request.TelNo;
            record.TermId = request.TermId;

            record.LastEditedById = Statics.LoggedInUser.userId;
            record.LastEditedDate = System.DateTime.UtcNow;

            _purchasingService.Save();

            return Ok(record);
        }

        [HttpPatch, Route("orders/{soId:int}/details/{sodId:int}")]
        [ActionName("PurchaseOrder.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdatePurchasingOrderDetail(int poId, int podId, TblPurchaseOrderDetails request)
        {
            var record = _purchasingService.PurchaseOrderDetailRepo.FindByCondition(x => x.Id == podId && x.PurchaseOrderId == poId).FirstOrDefault();

            if (record == null)
                return NotFound();

            record.Discount = request.Discount;
            record.ItemId = request.ItemId;
            record.Qty = request.Qty;
            record.Remarks = request.Remarks;
            record.SubTotal = request.SubTotal;
            record.UnitId = request.UnitId;
            record.UnitPrice = request.UnitPrice;

            _purchasingService.Save();

            return Ok(record);
        }
        #endregion

        #region Receiving Report
        [HttpGet, Route("receiving-reports")]
        [ActionName("Purchasing.ReceivingReport")]
        [Produces(typeof(IList<TblReceivingReports>))]
        public ActionResult GetReceivingReports()
        {
            var records = _purchasingService.ReceivingReportRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);

            return Ok(records);
        }

        [HttpGet, Route("receiving-reports/{id:int}")]
        [ActionName("ReceivingReport.Open")]
        [Produces(typeof(TblReceivingReportDetails))]
        public ActionResult GetReceivingReport(int id)
        {
            var record = _purchasingService.ReceivingReportRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("receiving-reports")]
        [ActionName("ReceivingReport.New")]
        [ProducesResponseType(201)]
        public ActionResult PostReceivingReport(TblReceivingReports request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.IsBill = false;
            request.IsReturn = false;
            request.Closed = false;
            request.Void = false;
            request.SystemNo = $"RR-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _purchasingService.ReceivingReportRepo.Create(request);
            _purchasingService.Save();

            return Created("purchasing/receiving-reports", new { id = request.Id });
        }

        [HttpGet, Route("receiving-reports/{vendorId:int}/pending")]
        [ActionName("Purchasing.ReceivingReport")]
        [Produces(typeof(IList<TblReceivingReports>))]
        public ActionResult GetPendingReceivingReportsByVendor(int vendorId)
        {
            var records = _purchasingService.ReceivingReportRepo.GetPendingByVendor(vendorId);

            return Ok(records);
        }

        [HttpGet, Route("vendors/{vendorId:int}/receiving-reports")]
        [ActionName("Purchasing.ReceivingReport")]
        [Produces(typeof(IList<TblReceivingReports>))]
        public ActionResult GetReceivingReportsByVendor(int vendorId)
        {
            var records = _purchasingService.ReceivingReportRepo.GetByVendor(vendorId);

            return Ok(records);
        }

        [HttpGet, Route("receiving-reports/{id:int}/details")]
        [ActionName("Purchasing.ReceivingReport")]
        [Produces(typeof(IList<TblReceivingReportDetails>))]
        public ActionResult GetReceivingReportDetails(int id)
        {
            var records = _purchasingService.ReceivingReportDetailRepo.GetByReceivingReportId(id).ToList();

            return Ok(records);
        }

        [HttpGet, Route("receiving-reports/{id:int}/details/pending")]
        [ActionName("Purchasing.ReceivingReport")]
        [Produces(typeof(IList<TblReceivingReportDetails>))]
        public ActionResult GetReceivingReportDetailsPendingBill(int id)
        {
            var records = _purchasingService.ReceivingReportDetailRepo.GetByPendingInvoice(id).ToList();

            return Ok(records);
        }


        [HttpPost, Route("receiving-reports/detail")]
        [ActionName("ReceivingReport.New")]
        [ProducesResponseType(201)]
        public ActionResult PostReceivingReportDetail(TblReceivingReportDetails request)
        {
            request.QtyBill = 0;
            request.QtyOnHand = 0;
            request.QtyReturn = 0;
            request.Closed = false;

            _purchasingService.ReceivingReportDetailRepo.Create(request);

            if (request.PodetailId != null && request.Poid != null)
            {
                var purchasingOrderDetail = _purchasingService.PurchaseOrderDetailRepo.FindByCondition(x => x.Id == request.PodetailId && x.PurchaseOrderId == request.Poid).FirstOrDefault();
                purchasingOrderDetail.QtyReceived += request.Qty;
            }

            _inventoryService.PostInventory(request.WarehouseId, request.ItemId, request.Qty, request.UnitPrice.Value, false);

            _purchasingService.Save();

            return Created($"purchasing/receiving-reports/{request.ReceivingReportId}/{request.Id}", new { id = request.Id });
        }

        [HttpPatch, Route("receiving-reports/{id:int}")]
        [ActionName("ReceivingReport.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateReceivingReport(int id, TblReceivingReports request)
        {
            var record = _purchasingService.ReceivingReportRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (record == null)
                return NotFound();

            record.Amount = request.Amount;
            record.Comments = request.Comments;
            record.Date = request.Date;
            record.RefNo = request.RefNo;

            record.LastEditedById = Statics.LoggedInUser.userId;
            record.LastEditedDate = System.DateTime.UtcNow;

            _purchasingService.Save();

            return Ok(record);
        }

        [HttpPatch, Route("receiving-reports/{rrId:int}/details/{rrdId:int}")]
        [ActionName("ReceivingReport.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateReceivingReportDetail(int rrId, int rrdId, TblReceivingReportDetails request)
        {
            var record = _purchasingService.ReceivingReportDetailRepo.FindByCondition(x => x.Id == rrdId && x.ReceivingReportId == rrId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (request.PodetailId != null && request.Poid != null)
            {
                var purchasingOrderDetail = _purchasingService.PurchaseOrderDetailRepo.FindByCondition(x => x.Id == request.PodetailId && x.PurchaseOrderId == request.Poid).FirstOrDefault();
                purchasingOrderDetail.QtyReceived -= record.Qty;
                purchasingOrderDetail.QtyReceived += request.Qty;
            }

            record.Discount = request.Discount;
            record.ItemId = request.ItemId;
            record.Qty = request.Qty;
            record.Remarks = request.Remarks;
            record.SubTotal = request.SubTotal;
            record.UnitId = request.UnitId;
            record.UnitPrice = request.UnitPrice;
            record.WarehouseId = request.WarehouseId;
            record.PorefNo = request.PorefNo;

            _purchasingService.Save();

            return Ok(record);
        }

        [HttpDelete, Route("receiving-reports/{rrId:int}/details/{rrdId:int}")]
        [ActionName("ReceivingReport.Edit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeleteReceivingReportDetail(int rrId, int rrdId)
        {
            var record = _purchasingService.ReceivingReportDetailRepo.FindByCondition(x => x.Id == rrdId && x.ReceivingReportId == rrId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (record.PodetailId != null && record.Poid != null)
            {
                var purchasingOrderDetail = _purchasingService.PurchaseOrderDetailRepo.FindByCondition(x => x.Id == record.PodetailId && x.PurchaseOrderId == record.Poid).FirstOrDefault();
                purchasingOrderDetail.QtyReceived -= record.Qty;
            }

            _purchasingService.ReceivingReportDetailRepo.Delete(record);

            _purchasingService.Save();

            return NoContent();
        }
        #endregion

        #region Bill
        [HttpGet, Route("bills")]
        [ActionName("Purchasing.Bill")]
        [Produces(typeof(IList<TblBills>))]
        public ActionResult GetBills()
        {
            var records = _purchasingService.BillRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);

            return Ok(records);
        }

        [HttpGet, Route("bills/{id:int}")]
        [ActionName("Bill.Open")]
        [Produces(typeof(TblBills))]
        public ActionResult GetBill(int id)
        {
            var record = _purchasingService.BillRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("bills")]
        [ActionName("Bill.New")]
        [ProducesResponseType(201)]
        public ActionResult PostBill(TblBills request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Closed = false;
            request.Void = false;
            request.SystemNo = $"BILL-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _purchasingService.BillRepo.Create(request);
            _purchasingService.Save();

            return Created("purchasing/bills", new { id = request.Id });
        }

        [HttpPost, Route("bills/detail")]
        [ActionName("Bill.New")]
        [ProducesResponseType(201)]
        public ActionResult PostBillDetail(TblBillDetails request)
        {
            request.QtyOnHand = 0;
            request.QtyReturn = 0;
            request.Closed = false;

            _purchasingService.BillDetailRepo.Create(request);

            if (request.RrdetailId != null && request.Rrid != null)
            {
                var drDetail = _purchasingService.ReceivingReportDetailRepo.FindByCondition(x => x.Id == request.RrdetailId && x.ReceivingReportId == request.Rrid).FirstOrDefault();
                drDetail.QtyBill += request.QtyOnHand;

                if (drDetail.Poid != null && drDetail.PodetailId != null)
                {
                    var soDetail = _purchasingService.PurchaseOrderDetailRepo.FindByCondition(x => x.Id == drDetail.PodetailId && x.PurchaseOrderId == drDetail.Poid).FirstOrDefault();
                    soDetail.QtyBilled += request.QtyOnHand;
                }
            }

            _purchasingService.Save();

            return Created($"sales/bills/{request.BillId}/{request.Id}", new { id = request.Id });
        }

        [HttpGet, Route("bills/{id:int}/details")]
        [ActionName("Purchasing.Bill")]
        [Produces(typeof(IList<TblBillDetails>))]
        public ActionResult GetBillDetails(int id)
        {
            var records = _purchasingService.BillDetailRepo.GetByBillId(id).ToList();

            return Ok(records);
        }

        [HttpPatch, Route("bills/{id:int}")]
        [ActionName("Bill.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateBill(int id, TblBills request)
        {
            var record = _purchasingService.BillRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

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

            _purchasingService.Save();

            return Ok(record);
        }

        [HttpPatch, Route("bills/{bId:int}/details/{bdId:int}")]
        [ActionName("Bill.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdateBillDetail(int bId, int bdId, TblBillDetails request)
        {
            var record = _purchasingService.BillDetailRepo.FindByCondition(x => x.Id == bdId && x.BillId == bId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (request.RrdetailId != null && request.Rrid != null)
            {
                var drDetail = _purchasingService.ReceivingReportDetailRepo.FindByCondition(x => x.Id == request.RrdetailId && x.ReceivingReportId == request.Rrid).FirstOrDefault();
                drDetail.QtyBill -= record.QtyOnHand;
                drDetail.QtyBill += request.QtyOnHand;
            }

            record.Discount = request.Discount;
            record.ItemId = request.ItemId;
            record.Qty = request.Qty;
            record.SubTotal = request.SubTotal;
            record.UnitId = request.UnitId;
            record.UnitPrice = request.UnitPrice;
            //record.WarehouseId = request.WarehouseId;
            record.RrrefNo = request.RrrefNo;

            _purchasingService.Save();

            return Ok(record);
        }

        [HttpDelete, Route("bills/{bId:int}/details/{bdId:int}")]
        [ActionName("Bill.Edit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeleteBillDetail(int bId, int bdId)
        {
            var record = _purchasingService.BillDetailRepo.FindByCondition(x => x.Id == bdId && x.BillId == bId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (record.RrdetailId != null && record.Rrid != null)
            {
                var drDetail = _purchasingService.ReceivingReportDetailRepo.FindByCondition(x => x.Id == record.RrdetailId && x.ReceivingReportId == record.Rrid).FirstOrDefault();
                drDetail.QtyBill -= record.QtyOnHand;
            }

            _purchasingService.BillDetailRepo.Delete(record);

            _purchasingService.Save();

            return NoContent();
        }

        [HttpGet, Route("vendors/{vendorId:int}/bills")]
        [ActionName("Purchasing.Bill")]
        [Produces(typeof(IList<TblBills>))]
        public ActionResult GetBillsByVendor(int vendorId)
        {
            var records = _purchasingService.BillRepo.GetByVendor(vendorId);

            return Ok(records);
        }

        [HttpGet, Route("vendors/{vendorId:int}/bills/available")]
        [ActionName("Purchasing.Bill")]
        [Produces(typeof(IList<TblBills>))]
        public ActionResult GetAvailableBillsByVendor(int vendorId)
        {
            var records = _purchasingService.BillRepo.GetAvailableByVendor(vendorId);

            return Ok(records);
        }

        [HttpGet, Route("bills/{id:int}/details/available")]
        [ActionName("Purchasing.Bill")]
        [Produces(typeof(IList<TblBillDetails>))]
        public ActionResult GetAvailableBillDetails(int id)
        {
            var records = _purchasingService.BillDetailRepo.GetAvailableByBillId(id);

            return Ok(records);
        }
        #endregion

        #region Purchase Return
        [HttpGet, Route("returns")]
        [ActionName("Purchasing.PurchaseReturn")]
        [Produces(typeof(IList<TblPurchaseReturns>))]
        public ActionResult GetPurchaseReturns()
        {
            var records = _purchasingService.PurchaseReturnRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);

            return Ok(records);
        }

        [HttpGet, Route("returns/{id:int}")]
        [ActionName("PurchaseReturn.Open")]
        [Produces(typeof(TblPurchaseReturns))]
        public ActionResult GetPurchaseReturn(int id)
        {
            var record = _purchasingService.PurchaseReturnRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("returns")]
        [ActionName("PurchaseReturn.New")]
        [ProducesResponseType(201)]
        public ActionResult PostPurchaseReturn(TblPurchaseReturns request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Void = false;
            request.SystemNo = $"PR-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _purchasingService.PurchaseReturnRepo.Create(request);
            _purchasingService.Save();

            return Created("purchasing/returns", new { id = request.Id });
        }



        [HttpPost, Route("returns/detail")]
        [ActionName("PurchaseReturn.New")]
        [ProducesResponseType(201)]
        public ActionResult PostPurchaseReturnDetail(TblPurchaseReturnDetails request)
        {
            request.QtyOnHand = 0;

            _purchasingService.PurchaseReturnDetailRepo.Create(request);

            if (request.ReferenceDetailId != null && request.ReferenceId != null && request.ReferenceTypeId == 8)
            {
                var drDetail = _purchasingService.ReceivingReportDetailRepo.FindByCondition(x => x.Id == request.ReferenceDetailId && x.ReceivingReportId == request.ReferenceId).FirstOrDefault();
                drDetail.QtyReturn += request.Qty;
            }

            if (request.ReferenceDetailId != null && request.ReferenceId != null && request.ReferenceTypeId == 9)
            {
                var siDetail = _purchasingService.BillDetailRepo.FindByCondition(x => x.Id == request.ReferenceDetailId && x.BillId == request.ReferenceId).FirstOrDefault();
                siDetail.QtyReturn += request.Qty;
            }

            _purchasingService.Save();

            return Created($"sales/returns/{request.PurchaseReturnId}/{request.Id}", new { id = request.Id });
        }

        [HttpGet, Route("returns/{id:int}/details")]
        [ActionName("Purchasing.PurchaseReturn")]
        [Produces(typeof(IList<TblPurchaseReturnDetails>))]
        public ActionResult GetPurchaseReturnDetails(int id)
        {
            var records = _purchasingService.PurchaseReturnDetailRepo.GetByPurchaseReturnId(id).ToList();

            return Ok(records);
        }

        [HttpPatch, Route("returns/{id:int}")]
        [ActionName("PurchaseReturn.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdatePurchaseReturn(int id, TblPurchaseReturns request)
        {
            var record = _purchasingService.PurchaseReturnRepo.FindByCondition(x => x.Id == id).FirstOrDefault();

            if (record == null)
                return NotFound();

            record.RefNo = request.RefNo;
            record.Remarks = request.Remarks;
            record.WarehouseId = request.WarehouseId;
            record.Date = request.Date;
            record.RefNo = request.RefNo;
            record.LastEditedById = Statics.LoggedInUser.userId;
            record.LastEditedDate = System.DateTime.UtcNow;

            _purchasingService.Save();

            return Ok(record);
        }

        [HttpPatch, Route("returns/{prId:int}/details/{prdId:int}")]
        [ActionName("PurchaseReturn.Edit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult UpdatePurchaseReturnDetail(int prId, int prdId, TblPurchaseReturnDetails request)
        {
            var record = _purchasingService.PurchaseReturnDetailRepo.FindByCondition(x => x.Id == prdId && x.PurchaseReturnId == prId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (request.ReferenceDetailId != null && request.ReferenceId != null && request.ReferenceTypeId == 8)
            {
                var drDetail = _purchasingService.ReceivingReportDetailRepo.FindByCondition(x => x.Id == request.ReferenceDetailId && x.ReceivingReportId == request.ReferenceId).FirstOrDefault();
                drDetail.QtyReturn -= record.Qty;
                drDetail.QtyReturn += request.Qty;
            }

            if (request.ReferenceDetailId != null && request.ReferenceId != null && request.ReferenceTypeId == 9)
            {
                var siDetail = _purchasingService.BillDetailRepo.FindByCondition(x => x.Id == request.ReferenceDetailId && x.BillId == request.ReferenceId).FirstOrDefault();
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
            record.Remarks = request.Remarks;

            _purchasingService.Save();

            return Ok(record);
        }

        [HttpDelete, Route("returns/{prId:int}/details/{prdId:int}")]
        [ActionName("PurchaseReturn.Edit")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult DeletePurchaseReturnDetail(int prId, int prdId)
        {
            var record = _purchasingService.PurchaseReturnDetailRepo.FindByCondition(x => x.Id == prdId && x.PurchaseReturnId == prId).FirstOrDefault();

            if (record == null)
                return NotFound();

            if (record.ReferenceDetailId != null && record.ReferenceId != null && record.ReferenceTypeId == 8)
            {
                var drDetail = _purchasingService.ReceivingReportDetailRepo.FindByCondition(x => x.Id == record.ReferenceDetailId && x.ReceivingReportId == record.ReferenceId).FirstOrDefault();
                drDetail.QtyReturn -= record.Qty;
            }

            if (record.ReferenceDetailId != null && record.ReferenceId != null && record.ReferenceTypeId == 9)
            {
                var siDetail = _purchasingService.BillDetailRepo.FindByCondition(x => x.Id == record.ReferenceDetailId && x.BillId == record.ReferenceId).FirstOrDefault();
                siDetail.QtyReturn -= record.Qty;
            }

            _purchasingService.PurchaseReturnDetailRepo.Delete(record);

            _purchasingService.Save();

            return NoContent();
        }
        #endregion



    }
}
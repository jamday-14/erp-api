using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERPApi.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private ILoggerManager _logger;
        private IInventoryService _inventoryService;
        private IMaintenanceService _maintenanceService;

        public InventoryController(ILoggerManager logger, IInventoryService service, IMaintenanceService maintenanceService)
        {
            _logger = logger;
            _inventoryService = service;
            _maintenanceService = maintenanceService;
        }

        #region Item Entry
        [HttpGet, Route("item-entries")]
        [ActionName("Inventory.ItemEntry")]
        [Produces(typeof(IList<TblItemEntries>))]
        public ActionResult GetItemEntries()
        {
            var records = _inventoryService.ItemEntryRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);

            return Ok(records);
        }

        [HttpGet, Route("item-entries/{id:int}")]
        [ActionName("ItemEntry.Open")]
        [Produces(typeof(TblItemEntries))]
        public ActionResult GetItemEntry(int id)
        {
            var record = _inventoryService.ItemEntryRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("item-entries")]
        [ActionName("ItemEntry.New")]
        [ProducesResponseType(201)]
        public ActionResult PostItemEntry(TblItemEntries request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Void = false;
            request.SystemNo = $"IE-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _inventoryService.ItemEntryRepo.Create(request);
            _inventoryService.Save();

            return Created("inventory/item-entries", new { id = request.Id });
        }

        [HttpGet, Route("item-entries/{id:int}/details")]
        [ActionName("Inventory.ItemEntry")]
        [Produces(typeof(IList<TblItemEntryDetails>))]
        public ActionResult GetItemEntryDetails(int id)
        {
            var records = _inventoryService.ItemEntryDetailRepo.GetByItemEntryId(id).ToList();
            return Ok(records);
        }

        [HttpPost, Route("item-entries/warehouse/{warehouseId:int}/details")]
        [ActionName("ItemEntry.New")]
        [ProducesResponseType(201)]
        public ActionResult PostItemEntryDetail(int warehouseId, TblItemEntryDetails request)
        {
            request.QtyOnHand = 0;

            _inventoryService.ItemEntryDetailRepo.Create(request);
            _inventoryService.PostInventory(warehouseId, request.ItemId, request.Qty, 0, false);
            _inventoryService.Save();

            return Created($"inventory/item-entries/{request.ItemEntryId}/{request.Id}", new { id = request.Id });
        }
        #endregion

        #region Item Release
        [HttpGet, Route("item-releases")]
        [ActionName("Inventory.ItemRelease")]
        [Produces(typeof(IList<TblItemReleases>))]
        public ActionResult GetItemReleases()
        {
            var records = _inventoryService.ItemReleaseRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);

            return Ok(records);
        }

        [HttpGet, Route("item-releases/{id:int}")]
        [ActionName("ItemRelease.Open")]
        [Produces(typeof(TblItemReleases))]
        public ActionResult GetItemRelease(int id)
        {
            var record = _inventoryService.ItemReleaseRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("item-releases")]
        [ActionName("ItemRelease.New")]
        [ProducesResponseType(201)]
        public ActionResult PostItemRelease(TblItemReleases request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Void = false;
            request.SystemNo = $"IR-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _inventoryService.ItemReleaseRepo.Create(request);
            _inventoryService.Save();

            return Created("inventory/item-releases", new { id = request.Id });
        }

        [HttpGet, Route("item-releases/{id:int}/details")]
        [ActionName("Inventory.ItemRelease")]
        [Produces(typeof(IList<TblItemReleaseDetails>))]
        public ActionResult GetItemReleaseDetails(int id)
        {
            var records = _inventoryService.ItemReleaseDetailRepo.GetByItemReleaseId(id).ToList();
            return Ok(records);
        }

        [HttpPost, Route("item-releases/warehouse/{warehouseId:int}/details")]
        [ActionName("ItemRelease.New")]
        [ProducesResponseType(201)]
        public ActionResult PostItemReleaseDetail(int warehouseId, TblItemReleaseDetails request)
        {
            request.QtyOnHand = 0;

            _inventoryService.ItemReleaseDetailRepo.Create(request);
            _inventoryService.PostInventory(warehouseId, request.ItemId, request.Qty, 0, true);
            _inventoryService.Save();

            return Created($"inventory/item-releases/{request.ItemReleaseId}/{request.Id}", new { id = request.Id });
        }
        #endregion

        #region Goods Transfer
        [HttpGet, Route("goods-transfers")]
        [ActionName("Inventory.GoodsTransfer")]
        [Produces(typeof(IList<TblGoodsTransfers>))]
        public ActionResult GetGoodsTransfers()
        {
            var records = _inventoryService.GoodsTransferRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);

            return Ok(records);
        }

        [HttpGet, Route("goods-transfers/{id:int}")]
        [ActionName("GoodsTransfer.Open")]
        [Produces(typeof(TblGoodsTransfers))]
        public ActionResult GetGoodsTransfer(int id)
        {
            var record = _inventoryService.GoodsTransferRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("goods-transfers")]
        [ActionName("GoodsTransfer.New")]
        [ProducesResponseType(201)]
        public ActionResult PostGoodsTransfer(TblGoodsTransfers request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Void = false;
            request.SystemNo = $"GT-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _inventoryService.GoodsTransferRepo.Create(request);
            _inventoryService.Save();

            return Created("inventory/goods-transfers", new { id = request.Id });
        }

        [HttpGet, Route("goods-transfers/{id:int}/details")]
        [ActionName("Inventory.GoodsTransfer")]
        [Produces(typeof(IList<TblGoodsTransferDetails>))]
        public ActionResult GetGoodsTransferDetails(int id)
        {
            var records = _inventoryService.GoodsTransferDetailRepo.GetByGoodsTransferId(id).ToList();
            return Ok(records);
        }

        [HttpPost, Route("goods-transfers/{id:int}/details")]
        [ActionName("GoodsTransfer.New")]
        [ProducesResponseType(201)]
        public ActionResult PostGoodsTransferDetail(int id, TblGoodsTransferDetails request)
        {
            request.QtyOnHand = 0;

            var parent = _inventoryService.GoodsTransferRepo.FindByCondition(x => x.Id == request.GoodsTransferId).FirstOrDefault();

            _inventoryService.GoodsTransferDetailRepo.Create(request);
            _inventoryService.PostInventory(parent.FromWarehouseId, request.ItemId, request.Qty, 0, true);
            _inventoryService.Save();

            return Created($"inventory/goods-transfers/{request.GoodsTransferId}/{request.Id}", new { id = request.Id });
        }

        [HttpGet, Route("goods-transfers/{warehouseId:int}/pending")]
        [ActionName("Inventory.GoodsTransfer")]
        [Produces(typeof(IList<TblGoodsTransfers>))]
        public ActionResult GetGoodsTransferPendingReceiptsByWarehouse(int warehouseId)
        {
            var records = _inventoryService.GoodsTransferRepo.GetPendingByWarehouse(warehouseId);

            return Ok(records);
        }

        [HttpGet, Route("goods-transfers/{id:int}/details/pending")]
        [ActionName("Inventory.GoodsTransfer")]
        [Produces(typeof(IList<TblGoodsTransferDetails>))]
        public ActionResult GetGoodsTransferDetailsPendingReceipt(int id)
        {
            var records = _inventoryService.GoodsTransferDetailRepo.GetByPendingReceipt(id).ToList();

            return Ok(records);
        }
        #endregion

        #region Goods Transfer Receive
        [HttpGet, Route("goods-transfer-receives")]
        [ActionName("Inventory.GoodsTransferReceive")]
        [Produces(typeof(IList<TblGoodsTransferReceived>))]
        public ActionResult GetGoodsTransferReceives()
        {
            var records = _inventoryService.GoodsTransferReceivedRepo.FindAll()
                .OrderByDescending(x => x.Date).ThenByDescending(x => x.SystemNo);

            return Ok(records);
        }

        [HttpGet, Route("goods-transfer-receives/{id:int}")]
        [ActionName("GoodsTransferReceive.Open")]
        [Produces(typeof(TblGoodsTransferReceived))]
        public ActionResult GetGoodsTransferReceive(int id)
        {
            var record = _inventoryService.GoodsTransferReceivedRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("goods-transfer-receives")]
        [ActionName("GoodsTransferReceive.New")]
        [ProducesResponseType(201)]
        public ActionResult PostGoodsTransferReceive(TblGoodsTransferReceived request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = DateTime.UtcNow;
            request.LastEditedDate = DateTime.UtcNow;
            request.Void = false;
            request.SystemNo = $"GTR-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            _inventoryService.GoodsTransferReceivedRepo.Create(request);
            _inventoryService.Save();

            return Created("inventory/goods-transfer-receives", new { id = request.Id });
        }

        [HttpGet, Route("goods-transfer-receives/{id:int}/details")]
        [ActionName("Inventory.GoodsTransferReceive")]
        [Produces(typeof(IList<TblGoodsTransferReceivedDetails>))]
        public ActionResult GetGoodsTransferReceivedDetails(int id)
        {
            var records = _inventoryService.GoodsTransferReceivedDetailRepo.GetByGoodsTransferReceivedId(id).ToList();
            return Ok(records);
        }

        [HttpPost, Route("goods-transfer-receives/{id:int}/details")]
        [ActionName("GoodsTransferReceive.New")]
        [ProducesResponseType(201)]
        public ActionResult PostGoodsTransferReceivedDetail(int id, TblGoodsTransferReceivedDetails request)
        {
            request.QtyOnHand = 0;

            var parent = _inventoryService.GoodsTransferReceivedRepo.FindByCondition(x => x.Id == request.GoodTransferReceivedId).FirstOrDefault();

            _inventoryService.GoodsTransferReceivedDetailRepo.Create(request);

            if (request.GtdetailId != 0 && request.Gtid != 0)
            {
                var gtDetail = _inventoryService.GoodsTransferDetailRepo.FindByCondition(x => x.Id == request.GtdetailId && x.GoodsTransferId == request.Gtid).FirstOrDefault();
                gtDetail.QtyReceived += request.Qty;
            }

            _inventoryService.PostInventory(parent.WarehouseId, request.ItemId, request.Qty, 0, false);
            _inventoryService.Save();

            return Created($"inventory/goods-transfer-receives/{request.GoodTransferReceivedId}/{request.Id}", new { id = request.Id });
        }

        #endregion

    }
}
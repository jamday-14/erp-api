using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERPApi.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private ILoggerManager _logger;
        private IInventoryService _service;

        public InventoryController(ILoggerManager logger, IInventoryService service)
        {
            _logger = logger;
            _service = service;
        }

        #region Item Entry
        [HttpGet, Route("item-entries")]
        [ActionName("Inventory.ItemEntry")]
        [Produces(typeof(IList<TblItemEntries>))]
        public ActionResult GetItemEntries()
        {
            var records = _service.ItemEntryRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("item-entries/{id:int}")]
        [ActionName("ItemEntry.Open")]
        [Produces(typeof(TblItemEntries))]
        public ActionResult GetItemEntry(int id)
        {
            var record = _service.ItemEntryRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("item-entries")]
        [ActionName("ItemEntry.New")]
        [ProducesResponseType(201)]
        public ActionResult PostItemEntry(TblItemEntries request)
        {
            _service.ItemEntryRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("ItemEntry.Open", new { id = request.Id });
        }
        #endregion

        #region Item Release
        [HttpGet, Route("item-releases")]
        [ActionName("Inventory.ItemRelease")]
        [Produces(typeof(IList<TblItemReleases>))]
        public ActionResult GetItemReleases()
        {
            var records = _service.ItemReleaseRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("item-releases/{id:int}")]
        [ActionName("ItemRelease.Open")]
        [Produces(typeof(TblItemReleases))]
        public ActionResult GetItemRelease(int id)
        {
            var record = _service.ItemReleaseRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("item-releases")]
        [ActionName("ItemRelease.New")]
        [ProducesResponseType(201)]
        public ActionResult PostItemRelease(TblItemReleases request)
        {
            _service.ItemReleaseRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("ItemRelease.Open", new { id = request.Id });
        }
        #endregion

        #region Goods Transfer
        [HttpGet, Route("goods-transfers")]
        [ActionName("Inventory.GoodsTransfer")]
        [Produces(typeof(IList<TblGoodsTransfers>))]
        public ActionResult GetGoodsTransfers()
        {
            var records = _service.GoodsTransferRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("goods-transfers/{id:int}")]
        [ActionName("GoodsTransfer.Open")]
        [Produces(typeof(TblGoodsTransfers))]
        public ActionResult GetGoodsTransfer(int id)
        {
            var record = _service.GoodsTransferRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("goods-transfers")]
        [ActionName("GoodsTransfer.New")]
        [ProducesResponseType(201)]
        public ActionResult PostGoodsTransfer(TblGoodsTransfers request)
        {
            _service.GoodsTransferRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("GoodsTransfer.Open", new { id = request.Id });
        }
        #endregion

        #region Goods Transfer Receive
        [HttpGet, Route("goods-transfer-receives")]
        [ActionName("Inventory.GoodsTransferReceive")]
        [Produces(typeof(IList<TblGoodsTransferReceived>))]
        public ActionResult GetGoodsTransferReceives()
        {
            var records = _service.GoodsTransferReceivedRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("goods-transfer-receives/{id:int}")]
        [ActionName("GoodsTransferReceive.Open")]
        [Produces(typeof(TblGoodsTransferReceived))]
        public ActionResult GetGoodsTransferReceive(int id)
        {
            var record = _service.GoodsTransferReceivedRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("goods-transfer-receives")]
        [ActionName("GoodsTransferReceive.New")]
        [ProducesResponseType(201)]
        public ActionResult PostGoodsTransferReceive(TblGoodsTransferReceived request)
        {
            _service.GoodsTransferReceivedRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("GoodsTransferReceive.Open", new { id = request.Id });
        }
        #endregion

    }
}
using CodeZoneTask.Contracts.Repositories;
using CodeZoneTask.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeZoneTask.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IItemRepository _itemRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository, IStockRepository stockRepository, IItemRepository itemRepository)
        {
            _purchaseRepository = purchaseRepository;
            _stockRepository = stockRepository;
            _itemRepository = itemRepository;
        }


        public async Task<IActionResult> Index()
        {
            var items = await _itemRepository.GetAsync();
            var stocks = await _stockRepository.GetAsync();
            ViewBag.Items = new SelectList(items, "Id", "Name");
            ViewBag.Stocks = new SelectList(stocks, "Id", "Name");
            return View();
        }


        // POST: Purchase/Purchase
        [HttpPost]
        public async Task<IActionResult> Purchase(Purchase purchase)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _purchaseRepository.CreateAsync(purchase);
                    TempData["SuccessMessage"] = "Purchase added successfully!";
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex.ToString());
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> GetItemQuantity(int stockId, int itemID)
        {
            //get total quantiy of item in stock
            decimal quantity = 0;
            if (stockId != 0 && itemID != 0)
            {
                quantity = await _purchaseRepository.GetItemQuantit(stockId, itemID);
            }
            return Content(quantity.ToString());
        }
    }
}

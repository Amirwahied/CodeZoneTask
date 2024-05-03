using CodeZoneTask.Contracts.Repositories;
using CodeZoneTask.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTask.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockRepository _repository;

        public StockController(IStockRepository repository)
        {
            _repository = repository;
        }


        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAsync());
        }

        // POST: Stocks/Create
        [HttpPost]
        public async Task<IActionResult> Create(Stock stock)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //to prevent saving stock with same name
                    if (!await _repository.IsStockNameExistsAsync(stock.Name))
                    {
                        await _repository.CreateAsync(stock);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex.ToString());
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Stocks/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Stock stock)
        {
            if (id != stock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    #region TODO: prevent saving stock with same name
                    //to prevent saving stock with same name

                    //var currentStock = await _repository.GetByIdAsync(id);

                    //if (currentStock == null)
                    //{
                    //    return NotFound();
                    //}

                    ////check if stock new name is same as old name
                    //if (stock.Name == currentStock.Name)
                    //{
                    //    return BadRequest("New stock name is the same as the current name.");
                    //}

                    ////check if new stock name exist in database
                    //if (!await _repository.IsStockNameExistsAsync(stock.Name))
                    //{
                    //    return BadRequest("An stock with the same name already exists.");
                    //}
                    #endregion

                    await _repository.UpdateAsync(stock);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while processing the request." + ex.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            return Ok();
        }


        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var stock = await _repository.GetByIdAsync(id);
                if (stock != null)
                {
                    await _repository.DeleteAsync(stock);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex.ToString());
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StockExistsAsync(int id)
        {
            return await _repository.IsStockExists(id);
        }
    }
}

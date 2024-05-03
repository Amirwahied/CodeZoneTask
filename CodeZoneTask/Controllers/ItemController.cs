using CodeZoneTask.Contracts.Repositories;
using CodeZoneTask.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeZoneTask.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _repository;
        //private readonly ILogger _logger;

        public ItemController(IItemRepository repo)
        {
            _repository = repo;
        }


        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAsync());
        }

        // POST: Items/Create
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //to prevent saving itm with same name
                    if (await _repository.IsItemNameExistsAsync(item.Name))
                    {
                        TempData["UniqueName"] = "An item with the same name already exists.";

                        //return BadRequest("");
                    }
                    await _repository.CreateAsync(item);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex.ToString());
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Items/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    #region TODO: prevent saving itm with same name
                    //to prevent saving itm with same name


                    ////get item before edit
                    //var currentItem = await _repository.GetByIdAsync(id);

                    //if (currentItem == null)
                    //{
                    //    return NotFound();
                    //}

                    ////check if item new name is same as old name
                    //if (item.Name == currentItem.Name)
                    //{
                    //    return BadRequest("New item name is the same as the current name.");
                    //}

                    ////check if new item name exist in database
                    //if (!await _repository.IsItemNameExistsAsync(item.Name))
                    //{
                    //    TempData["UniqueName"] = "An item with the same name already exists.";
                    //    return Ok();
                    //}
                    #endregion

                    await _repository.UpdateAsync(item);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while processing the request." + ex.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            return Ok();
        }


        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                if (item != null)
                {
                    await _repository.DeleteAsync(item);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request." + ex.ToString());
            }
        }

    }
}

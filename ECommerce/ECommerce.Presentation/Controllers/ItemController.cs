using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Requests;
using ECommerce.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        public async Task<IActionResult> Index()
        {
            var items =  await _itemService.GetAllItemsAsync();

            return View(items);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ItemRequest itemRequest)
        {
            if(ModelState.IsValid)
            {
                await _itemService.AddItemAsync(itemRequest);

                return RedirectToAction("Index", "Item");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ItemRequest itemRequest)
        {
            if (ModelState.IsValid)
            {
                await _itemService.UpdateItemAsync(id, itemRequest);

                return RedirectToAction("Index", "Item");
            }
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);

            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ItemDTO itemDto)
        {
            if (ModelState.IsValid)
            {
                await _itemService.DeleteItemAsync(itemDto.ID);

                return RedirectToAction("Index", "Item");
            }

            return View();
        }
    }
}

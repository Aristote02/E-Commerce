using ECommerce.BusinessLogic.DTO_s;
using ECommerce.BusinessLogic.Requests;
using ECommerce.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    public class ItemVariationController : Controller
    {
        private readonly IItemVariationService _itemVariationService;

        public ItemVariationController(IItemVariationService itemVariationService)
        {
            _itemVariationService = itemVariationService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _itemVariationService.GetAllItemsVariationAsync();

            return View(items);
        }

        [HttpGet]
        public IActionResult AddVariation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVariation(ItemVariationRequest itemVariationRequest)
        {
            if(ModelState.IsValid)
            {
                await _itemVariationService.AddItemVariationAsync(itemVariationRequest);

                return RedirectToAction("Index", "ItemVariation");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditItemVariation(int id)
        {
            var itemVr = await _itemVariationService.GetItemVariationByIdAsync(id);
            return View(itemVr);
        }

        [HttpPost]
        public async Task<IActionResult> EditItemVariation(int id, ItemVariationRequest itemVariationRequest)
        {
            if(ModelState.IsValid)
            {
                await _itemVariationService.UpdateItemVariationAsync(id, itemVariationRequest);

                return RedirectToAction("Index", "ItemVariation");
            }
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteItemVariation(int id)
        {
            var item = await _itemVariationService.GetItemVariationByIdAsync(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItemVariation(ItemVariationDTO itemVariationDto)
        {
            
            if (ModelState.IsValid)
            {
                await _itemVariationService.DeleteItemVariationAsync(itemVariationDto.Id);

                return RedirectToAction("Index", "ItemVariation");
            }

            return View();
        }
    }
}

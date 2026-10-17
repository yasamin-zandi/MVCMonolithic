using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMonolithic.ApplicationService.ApplicationService.Contracts;
using MvcMonolithic.ApplicationService.ApplicationService.Services;
using MvcMonolithic.ApplicationService.Dtos;
using MvcMonolithic.Models.DomainModels.ProductAggregates;

namespace MvcMonolithic.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;
        private readonly ICategoryApplicationService _categoryApplicationService;

        #region Ctor
        public ProductController(IProductApplicationService productApplicationService, ICategoryApplicationService categoryApplicationService)
        {
            _productApplicationService = productApplicationService;
            _categoryApplicationService = categoryApplicationService;
        } 
        #endregion

        #region Create

        // GET: Product/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // دریافت لیست دسته‌بندی‌ها از دیتابیس
            var categories = await _categoryApplicationService.GetCategoriesSelectList();

            // فرستادن به صورت SelectList به ویو
            ViewBag.Categories = new SelectList(categories, "Id", "Title");

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostProductDto postProductDto)
        {
            if (!ModelState.IsValid)
            {
                // در صورت خطا، دوباره باید دراپ‌داون پر بشه تا صفحه کرش نکنه
                var categories = await _categoryApplicationService.GetCategoriesSelectList();
                ViewBag.Categories = new SelectList(categories, "Id", "Title", postProductDto.CategoryId);
                return View(postProductDto);
            }

           

            await _productApplicationService.PostProduct(postProductDto);

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productApplicationService.GetProductbyId(id);
            if (product == null)
            {
                return NotFound();
            }

            var EditProductDto = new EditProductDto()
            {
                Id = product.Id,
                Title = product.Title,
                Count = product.Count,
                CategoryId = product.CategoryId
         };
          
            var categories = await _categoryApplicationService.GetCategoriesSelectList();

        
            ViewBag.Categories = new SelectList(categories, "Id", "Title", product.CategoryId);

            return View(EditProductDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                // اینجا هم اگه مدل نامعتبر بود، اول لیست رو می‌گیریم:
                var categories = await _categoryApplicationService.GetCategoriesSelectList();
                ViewBag.Categories = new SelectList(categories, "Id", "Title", dto.CategoryId);

                return View(dto);
            }

            await _productApplicationService.EditProduct(dto);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _productApplicationService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        } 
        #endregion

        #region Detail

        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productApplicationService.GetProductbyId(id);
            if (product == null)
            {
                return NotFound();
            }

            // ۱. اول لیست رو از سرویس می‌گیریم:
            var categories = await _categoryApplicationService.GetCategoriesSelectList();

            // ۲. حالا می‌ریزیمش تو ViewBag (با انتخاب پیش‌فرض آیتم فعلی محصول):
            ViewBag.Categories = new SelectList(categories, "Id", "Title", product.CategoryId);

            return View(product);

        }

        #endregion

        #region GetAll
        public async Task<IActionResult> Index()
        {
            var Products = await _productApplicationService.GetAllProducts();
            return View(Products);
        } 
        #endregion
    }
}

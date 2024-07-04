using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Services;
using NorthwindMVC.Services.DTOs;

namespace NorthwindMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        // GET: ProductController
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllProductsAsync());
        }

        // GET: ProductController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ProductController/Create
        public IActionResult Create()
        {
            // 新增商品資料介面
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDto newProduct)
        {
            // 呼叫Service幫忙新增Product
            try
            {
                await _productService.AddProductsAsync(newProduct);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // 秀出選中的資料，若找不到則拋出 404 Error
            try
            {
                ProductDto current = await _productService.GetProductsByIdAsync(id);
                return View(current);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductDto productDto)
        {
            try
            {
                // 呼叫Service幫忙修改資料
                await _productService.UpdateProductsAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            // 呼叫Service執行刪除業務邏輯，若拋錯則回傳 400 error
            try
            {
                await _productService.DeleteProductsAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: ProductController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

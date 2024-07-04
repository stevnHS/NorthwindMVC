using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Services;
using System;

namespace NorthwindMVC.Controllers
{
    public class ApiController : Controller
    {
        private readonly IProductService _productService;
        public ApiController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ActionResult> OffProduct(int id)
        {
            // 改變Product Status，並回傳204
            await _productService.ChangeProductStatusAsync(id);
            return NoContent();
        }
    }
}

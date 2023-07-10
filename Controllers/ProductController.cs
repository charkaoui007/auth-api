using AuthenticationAndAuthorization.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAndAuthorization.Controllers
{

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDataContext _context;

        public ProductController(ProductDataContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_context.TblProducts.ToList());
        }
        [Authorize]
        [HttpGet]
        [Route("GetProductByCode")]
        public IActionResult GetProductByCode(string productCode)
        {
            var product = _context.TblProducts.FirstOrDefault(e => e.ProductCode == productCode);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}

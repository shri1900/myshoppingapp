using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MyShopping.API.Models;
using MyShopping.Client.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductContext context, ILogger<ProductController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }
    }
}

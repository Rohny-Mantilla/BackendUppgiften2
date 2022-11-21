using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Inlämningsuppgift.nosql.Data;
using Inlämningsuppgift.nosql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inlämningsuppgift.nosql.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCatalog productCatalog)
        {
            try
            {
                _context.Add(productCatalog);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return new OkObjectResult(await _context.Products.ToListAsync());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return new OkObjectResult(await _context.Products.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ProductCatalog productCatalog)
        {
            try
            {
                var _productCatalog = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (_productCatalog != null)
                {
                    _productCatalog.Name = productCatalog.Name;
                    _productCatalog.Price = productCatalog.Price;
                    _productCatalog.Description = productCatalog.Description;


                    _context.Update(_productCatalog);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var _productCatalog = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (_productCatalog != null)
                {
                    _context.Remove(_productCatalog);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    } 
}


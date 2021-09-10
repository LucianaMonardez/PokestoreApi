using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaPokestoreApi.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaPokestoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaPokestoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Products> Get()
        {
            //usamos EF para traer a las personas
            return _context.Product.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Products> Get(int id)
        {
            //usamos EF para traer a las personas
            return _context.Product.Find(id);
        }
        [HttpPost("{id}")]
        public ActionResult Post(Products Product)
        {
            _context.Product.Add(Product);
            _context.SaveChanges();

            //return Ok();
            return new CreatedAtRouteResult("ObtenerProducto", new { id = Product.id }, Product);

        }

        [HttpGet("TraerProducto/{id}", Name = "ObtenerProducto")]
        public ActionResult<Products> ObtenerPersona(int id)
        {
            return _context.Product.Find(id);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Products Product)
        {
            if (id != Product.id)
            {
                return BadRequest();

            }

            _context.Entry(Product).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult<Products> Delete(int id)
        {
            var products = _context.Product.Find(id);
            if (products == null)
            {
                return NotFound();
            }
            _context.Product.Remove(products);
            _context.SaveChanges();

            return products;
        }

    }
}

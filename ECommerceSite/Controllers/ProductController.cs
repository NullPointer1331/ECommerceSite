﻿using ECommerceSite.Data;
using ECommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly PetStoreContext _context;

        public ProductController(PetStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                ViewData["Message"] = $"Product {product.Name} added successfully!";
                return View();
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{product.Name} updated successfully!";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                TempData["Message"] = "You attempted to delete something that doesn't exist";
            }
            else
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{product.Name} deleted successfully!";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using martins_aleogho_IntroToLinqAndAsp.netLab1.Models;

namespace martins_aleogho_IntroToLinqAndAsp.netLab1.Controllers {
    public class ProductController : Controller {
        public static List<Product> _products = new List<Product>();
        private static List<Inventory> _inventory = new List<Inventory>();
        public static int _nextId = 1;
        public IActionResult Index() {
            return View(_products);
        }
        public IActionResult InventoryIndex() {
            var productInventoryViewModels = _products.Select(p => new ProductInventoryViewModel {
                ProductId = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = _inventory.FirstOrDefault(i => i.ProductId == p.Id)?.StockQuantity ?? 0
            }).ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Create() {

           return View();
        }

        [HttpPost]
        public IActionResult Create(Product product) {
            if (ModelState.IsValid) {
                product.Id = _nextId++;
                _products.Add(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete (int? id) {
            if (id == null) {
                return NotFound();
            }
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null) {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed (int id) {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if ( product != null) {
                _products.Remove(product);
            }
            return RedirectToAction("Index");
           
        }
    }
}
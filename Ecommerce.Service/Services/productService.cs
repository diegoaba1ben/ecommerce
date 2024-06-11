using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ecommerce.Core.Entities;
using Ecommerce.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        //Genera el código o serial si no existe
        public async Task<Product> CreateProductAsync(Product product, bool generateSerialNumber = false)
        {
            if (generateSerialNumber)
            {
                product.SerialNumber = GenerateSerialNumber();
            }
            else if (string.IsNullOrEmpty(product.SerialNumber))
            {
                throw new ArgumentException("El número de serie no puede estar vacío si no se genera automáticamente.");
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // CRUD adicional para los productos por ID
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

    //Obtiene una lista de todos los productos.
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

    // Permite actualizar un producto existente
        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

    // Permite eliminar un producto po Id
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new ArgumentException("Producto no encontrado.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        private string GenerateSerialNumber()
        {
            return Guid.NewGuid().ToString().Substring(0, 10).ToUpper();
        }
    }
}

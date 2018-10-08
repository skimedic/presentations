using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore_HOL.DAL.EfStructures;
using SpyStore_HOL.DAL.Exceptions;
using SpyStore_HOL.DAL.Repos.Base;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.Models.Entities;
using SpyStore_HOL.Models.ViewModels;

namespace SpyStore_HOL.DAL.Repos
{
    public class ShoppingCartRepo : RepoBase<ShoppingCartRecord>, IShoppingCartRepo
    {
        private readonly IProductRepo _productRepo;
        public ShoppingCartRepo(IProductRepo productRepo) : base()
        {
            _productRepo = productRepo;
        }
        public ShoppingCartRepo(StoreContext context, IProductRepo productRepo) : base(context)
        {
            _productRepo = productRepo;
        }
        public override IList<ShoppingCartRecord> GetAll()
            => Table.OrderByDescending(x => x.DateCreated).ToList();
        public ShoppingCartRecord Find(int customerId, int productId)
            => Table.FirstOrDefault(x => x.CustomerId == customerId && x.ProductId == productId);
        public override int Update(ShoppingCartRecord entity, bool persist = true)
            => Update(entity, _productRepo.Find(entity.ProductId)?.UnitsInStock, persist);
        public int Update(ShoppingCartRecord entity, int? quantityInStock, bool persist = true)
        {
            if (entity.Quantity <= 0)
            {
                return Delete(entity, persist);
            }
            if (entity.Quantity > quantityInStock)
            {
                throw new InvalidQuantityException("Can't add more product than available in stock");
            }
            return base.Update(entity, persist);
        }
        public override int Add(ShoppingCartRecord entity, bool persist = true)
            => Add(entity, _productRepo.Find(entity.ProductId)?.UnitsInStock, persist);

        public int Add(ShoppingCartRecord entity, int? quantityInStock, bool persist = true)
        {
            var item = Find(entity.CustomerId, entity.ProductId);
            if (item == null)
            {
                if (quantityInStock != null && entity.Quantity > quantityInStock.Value)
                {
                    throw new InvalidQuantityException("Can't add more product than available in stock");
                }
                return base.Add(entity, persist);
            }
            item.Quantity += entity.Quantity;
            return item.Quantity <= 0 ? Delete(item, persist) : Update(item, quantityInStock, persist);
        }
        internal CartRecordWithProductInfo GetRecord(
            int customerId, ShoppingCartRecord scr, Product p, Category c)
            => new CartRecordWithProductInfo
            {
                Id = scr.Id,
                DateCreated = scr.DateCreated,
                CustomerId = customerId,
                Quantity = scr.Quantity,
                ProductId = scr.ProductId,
                Description = p.Description,
                ModelName = p.ModelName,
                ModelNumber = p.ModelNumber,
                ProductImage = p.ProductImage,
                ProductImageLarge = p.ProductImageLarge,
                ProductImageThumb = p.ProductImageThumb,
                CurrentPrice = p.CurrentPrice,
                UnitsInStock = p.UnitsInStock,
                CategoryName = c.CategoryName,
                LineItemTotal = scr.Quantity * p.CurrentPrice,
                TimeStamp = scr.TimeStamp
            };
        public CartRecordWithProductInfo GetShoppingCartRecord(int customerId, int productId) => Table
            .Where(x => x.CustomerId == customerId && x.ProductId == productId)
            .Include(x => x.Product).ThenInclude(p => p.Category)
            .Select(x => GetRecord(customerId, x, x.Product, x.Product.Category))
            .FirstOrDefault();
        public IEnumerable<CartRecordWithProductInfo> GetShoppingCartRecords(int customerId) => Table
            .Where(x => x.CustomerId == customerId)
            .Include(x => x.Product).ThenInclude(p => p.Category).OrderBy(x => x.Product.ModelName)
            .Select(x => GetRecord(customerId, x, x.Product, x.Product.Category));

    }
}
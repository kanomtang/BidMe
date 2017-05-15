using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionSystem.Entities;


namespace AuctionSystem.Models
{
    public class ProductRepository : IIUserRepository
    {
        AuctionDBEntities1 db = new AuctionDBEntities1();
        public List<Product> GetAllProduct()
        {
            List<Product> productList = new List<Product>();
            var products = from p in db.Products select p;
            foreach (var x in products)
            {
                Models.Product product = new Models.Product();
                product.ProductName = x.ProductName;
                product.price = x.ProductPrice;
                product.description = x.ProductDescription;
                //product.image = x.ProductImage;
                productList.Add(product);
            }
            return productList;
        }
        public void AddItem(Product product) {
            /* Implement me */
           
        }
        
        public List<Entities.Product> FetchByID(int productID) {
            /* Implement me */     
            var products = db.Products.Where(x => x.ProductID==productID).ToList();
            return products;
        }

        public IList<Product> ListItems(int pageSize, int pageIndex) {
            /* Implement me */
            return null;
        }
        public void SubmitChanges(){
            /* Implement me */
        }

        public void AddMember(User member)
        {
            throw new NotImplementedException();
        }

        public User FetchByLoginName(string loginName)
        {
            throw new NotImplementedException();
        }
    }
}
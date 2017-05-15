using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitMe.Models;
using System.Web;
using System.Drawing;
using BitMe.Models.Repositories;

namespace BitMe.Entities
{
    public class ProductRepository
    {
        BidMeDBnewEntities3 db = new BidMeDBnewEntities3();

        public void addItem(Item i, HttpPostedFileBase p)
        {
            var a = i.ProductName;
            var b = ConvertToBytes(p);
 
        }
        
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(image, typeof(byte[]));
        }

        public int checkingDuplicateUsername(User u)
        {

            // var b =db.RetrievAllUsername();
            var a = db.checkDuplicateName(u.UName).Count();
            if (a<1)
            {
                return 1;
            }
            return 0 ;
        }

        public void RegisterNewUser(User u)
        {

            db.RegisterNewUser(u.UName, u.UPassword, u.UEmail, u.UAdress);
        }

        public int login(User u)
        {
            var a = db.login(u.UName, u.UPassword).Count();
            
            if (a == 1)
            {
                return 1;

            }
            return 0;
        }

        public List<Models.Repositories.AuctionProductTable> FetchByID(int productID)
        {
            /* Implement me */
            var products = db.AuctionProductTables.Where(x => x.ProductID == productID).ToList();
            return products;
        }

        public List<Models.Repositories.AuctionProductTable> GetAllProduct()
        {
            
                List<Item> productList = new List<Item>();
                var products = from p in db.AuctionProductTables select p;
                foreach (var x in products)
                {
                    Item product = new Item();
                    product.ProductName = x.ProductName;
                   // product.ProductPrice = x.ProductPrice;
                    product.ProductDescription = x.ProductDescription;
                    
                    productList.Add(product);
                }
               

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitMe.Models;
using System.Web;
using System.Drawing;
using BitMe.Models.Repositories;
using System.IO;

namespace BitMe.Entities
{
    public class ProductRepository
    {
        BidMeDBnewEntities3 db = new BidMeDBnewEntities3();

        public void addItem(Item i, HttpPostedFileBase pic)
        {
           // var a = i.ProductName;
            //var b = ConvertToBytes(pic);

            var products = from p in db.AuctionProductTables select p;
            var newId = GetAllProduct().Count() + 1;
            
            db.AuctionProductTables.Add(new AuctionProductTable
            {
                ProductID = newId,
                ProductName = i.ProductName,
                ProductDescription = i.ProductDescription,
                ProductPrice = i.ProductPrice,
                
            });
            
            db.SaveChanges();


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

        public List<Item> GetAllProduct()
        {   
                List<Item> productList = new List<Item>();
                var products = from p in db.AuctionProductTables select p;
                foreach (var x in products)
                {
                    Item product = new Item();
                    product.ProductID = x.ProductID;
                    product.ProductName = x.ProductName;
                    product.TempWinner = x.BuyerName;
                    product.ProductCategory = x.ProductCatagory;
                    //product.bidDeadline = x.BidEndTime;
                    //product.ProductPrice = x.ProductPrice;
                    //product.image = x.ProductImage;
                    productList.Add(product);
                }
               

            return productList;
        }

        public static Image ByteArrayToImagebyMemoryStream(byte[] imageByte)
        {
            MemoryStream ms = new MemoryStream(imageByte);
            Image image = Image.FromStream(ms);
            return image;
        }

        public void EditUserProfile(User u)
        {
            var user = db.UserTables.Where(x => x.UName == u.UName).ToList();
            //Update in db 
        }

        public void Auction(Bid bidProduct)
        {
            var AuctionProduct = from p in db.AuctionProductTables select p;
            foreach (var x in AuctionProduct)
            {
                x.ProductID = bidProduct.product.ProductID;
                x.ProductName = bidProduct.product.ProductName;
                x.ProductDescription = bidProduct.product.ProductDescription;
                x.BuyerName = bidProduct.user.UName;
                x.ProductPrice = bidProduct.product.ProductPrice;
                x.BidStartTime = DateTime.Now;

            }
            
        }
    }
}

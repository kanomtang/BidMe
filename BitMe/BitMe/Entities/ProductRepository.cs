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
            var d =db.UserTables.Find(u.UName);
            if(d.Equals(true)){
                return 1;
            }
            return 0 ;
        }

        public List<Item> GetAllProduct()
        {
            List<Item> productList = new List<Item>();
            var items = from p in db.Products select p;
            foreach (var x in (dynamic)items)
            {

                items.ProductName = x.ProductName;
                items.ProductPrice = x.ProductPrice;
                items.ProductCategory = x.ProductCategory;
                items.ProductDescription = x.ProductDescription;
                productList.Add(items);
            }
            return productList;
        }

        public void RegisterNewUser(User u)
        {
            
             db.RegisterNewUser(u.UName, u.UPassword, u.UEmail, u.UAdress);
        }
        public int login(User u )
        {
         var a =  db.UserTables.Where(x=>x.UName==u.UName);
          

            return 0;
        }
    }
}

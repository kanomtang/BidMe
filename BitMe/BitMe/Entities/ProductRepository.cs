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
        //BidMeDatabaseEntities1 db = new BidMeDatabaseEntities1();
        //above line for create instace of database 
        BidMeDBEntities db = new BidMeDBEntities();

        public void addItem(Item i, HttpPostedFileBase p)
        {
            var a = i.ProductName;
            var b = ConvertToBytes(p);
            //db.AddAP(a, b);
            //above line for adding product to database
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
            if(d.Equals(true){
                return 1;
            }
            return 0 ;
        }

        public void RegisterNewUser(User u)
        {
            db.RegisterNewUser(u.UName, u.UPassword, u.UEmail, u.UAdress);
        }
    }
}

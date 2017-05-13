using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitMe.Models;
using System.Web;
using System.Drawing;

namespace BitMe.Entities
{
    interface ProductRepository
    {
        //BidMeDatabaseEntities1 db = new BidMeDatabaseEntities1();
        //above line for create instace of database 


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

    }
}

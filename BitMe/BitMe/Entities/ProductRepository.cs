using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitMe.Models;

namespace BitMe.Entities
{
    interface ProductRepository
    {
        IQueryable<Item> Products { get; }
    }
}

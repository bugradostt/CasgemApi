using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casgem.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public ObjectId _id { get; set; }
        public string CategoryName { get; set; }
        public List<Product>? Products{ get; set; }
    }
}

using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casgem.EntityLayer.Concrete
{
    public class User
    {
        public ObjectId _id { get; set; }

        public string UserName { get; set; } 

        public string UserPassword { get; set; }
    }
}

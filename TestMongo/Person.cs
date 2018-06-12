using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace TestMongo
{
   public class Person
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public int Age { get; set; }
        public List<string> Interests {get;set;}

        public Person()
        { }
    }
}

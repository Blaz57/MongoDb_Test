using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Import de l'espace de nom MongoDB
using MongoDB.Driver;

namespace TestMongo
{
    class Program
    {
        static Person staticPerson = new Person()
        {
            FirstName = "Alex",
            LasttName = "BLAZ",
            Age = 35,
            Interests = new List<string>() { "qi chong", "marche" }
        };

        static List<Person> staticPeople = new List<Person>()
        {
            new Person(){FirstName="Piere",LasttName="PONCE", Age=36, Interests= new List<string>() {"velo","tir"} },
            new Person(){FirstName="Tatiane",LasttName="RINEKICOULE", Age=36, Interests= new List<string>() {"velo","tir"} }

        };

        //Création d'une instance du client MongoDB
        static MongoClient client = new MongoClient("mongodb://localhost:27017");

        //Chagement de la base de donnée "people"
        //Si la base de données n'existe pas, elle est automatiquement créée
        static  IMongoDatabase db = client.GetDatabase("people");


        static void Main(string[] args)
        {
            // Permet de vider la collection
            db.DropCollection("personnes");

           
            //Chargement de la collection personnes depuis la base de données people
            //Si la collection n'existe pas elle est automatiquement crée
            IMongoCollection<Person> collection = db.GetCollection<Person>("personnes");


            //Insertion d'un élément
            collection.InsertOne(staticPerson);

            //Insertion de plusieurs éléments
            collection.InsertMany(staticPeople);


            List<Person> result = collection.Find<Person>(x => x.FirstName == "Alex").ToList();

            Console.WriteLine(result.Count().ToString() + "personne(s) trouvée(s)");

            foreach (Person p in result)
            {
                Console.WriteLine(p.FirstName + " " + p.LasttName + " " + p.Age.ToString());
            }

            Console.ReadKey();
        }

        static void Test()
        {
            Person pers = staticPeople.Find(
                person => ( person.FirstName=="Alex")
                );

            // équivalent à

            foreach (Person person in staticPeople)
            {
                if (person.FirstName == "Alex")
                {
                    //
                }
            }
        }
    }
}

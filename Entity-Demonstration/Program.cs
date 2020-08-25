using Entity_Demonstration.Data;
using Entity_Demonstration.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace Entity_Demonstration
{
    class Program
    {
        static void Main(string[] args)
        {
           //Do Nothing
        }

        static void AddProductsToDatabase()
        {
            using PetStoreContext context = new PetStoreContext();
            {
                Product squeakyBone = new Product()
                {
                    Name = "Squeaky Dog Bone",
                    Price = 4.99M
                };

                //We have the option of explicitly adding the object to its associated table.  This is not necessary (see below)
                context.Products.Add(squeakyBone);

                Product tennisBalls = new Product()
                {
                    Name = "Tennis Ball 3-Pack",
                    Price = 9.99M
                };

                //Here, we add the object only to the context.  Entity will recognize the object and assign it to the correct table.
                context.Add(tennisBalls);

                //Commit the changes to the context.
                context.SaveChanges();

            }
        }

        static void ReadInformationFromDatabase()
        {
            //Query the database using Fluent API; this means using extensions to chain methods together.  Here, we 
            //also use lambda expressions to consolidate the verbiage. 
            using PetStoreContext context = new PetStoreContext();
            {

                //The lines below can also be written as a LINQ query: 
                //var products = from product in context.Products
                //               where product.Price > 5.00m
                //               orderby product.Name
                //               select product;

                var products = context.Products
                    .Where(p => p.Price >= 5.00m)
                    .OrderBy(p => p.Name);


                foreach (Product p in products)
                {
                    Console.WriteLine($"Id:     {p.Id}");
                    Console.WriteLine($"Name:   {p.Name}");
                    Console.WriteLine($"Price:  {p.Price}");
                    Console.WriteLine(new string('-', 20));
                }
            }


        }

        static void EditExistingRecord()
        {
            //To edit a record, we first need to get a reference to it; this requires querying the table.
            using PetStoreContext context = new PetStoreContext();
            {
                var squeakyBone = context.Products.Where(p => p.Name == "Squeaky Dog Bone")
                    .FirstOrDefault();

                //check that a non null object was returned.
                if(squeakyBone is Product)
                {
                    //Modify the object's data.
                    squeakyBone.Price = 7.99m;
                }

                //Commit the changes.
                context.SaveChanges();

            }
        }

        static void DeleteExistingRecord()
        {
            //To edit a record, we first need to get a reference to it; this requires querying the table.
            using PetStoreContext context = new PetStoreContext();
            {
                var squeakyBone = context.Products.Where(p => p.Name == "Squeaky Dog Bone")
                    .FirstOrDefault();

                //check that a non null object was returned.
                if (squeakyBone is Product)
                {
                    //Remove the object
                    context.Remove(squeakyBone);
                    Console.WriteLine("removed object.");
                }

                //Commit the changes.
                context.SaveChanges();

            }
        }

    }
}

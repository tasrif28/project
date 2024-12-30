using Project.Factories;
using Project.Model;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DITests
{
    public class TestClass
    {
        IRepoFactory factory;

        public TestClass(IRepoFactory factory) { this.factory = factory; }
        public void Run()
        {
            IRepo<Category> repoC = factory.CreateRepo<Category>();
            repoC.AddRange(new Category[] {
                new Category{ Id=1, Name="Laptop"},
                new Category{ Id=2, Name="Monitor"},
                new Category{ Id=3, Name="Keyboard"},
                new Category{ Id=4, Name="Mouse"},
                new Category{ Id=5, Name="SSD"}
            });
            //GetAll 
            Console.WriteLine("GetAll");
            repoC.GetAll().ToList()
                .ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}"));
            //Get by id 
            Console.WriteLine("Get");
            var cat = repoC.Get(3);
            Console.WriteLine($"Id: {cat.Id}, Name: {cat.Name}");
            //Update 
            Console.WriteLine("Update");
            cat.Name = "Keyboard";
            repoC.Update(cat);
            repoC.GetAll().ToList()
               .ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}"));
            //Delete 
            Console.WriteLine("Delete");
            repoC.Delete(3);
            repoC.GetAll().ToList()
              .ForEach(c => Console.WriteLine($"Id: {c.Id}, Name: {c.Name}"));
            Console.WriteLine("******************");
            IRepo<Product> repoB = factory.CreateRepo<Product>();
            repoB.AddRange(new Product[]
            {
                new Product{ Id=1, Name="HP 15-fd0290TU Core i5 13th Gen 15.6\" FHD Laptop", Price=72300.00M, Stock=50, CategoryId=1},
                 new Product{ Id=2, Name="Xiaomi A22i 21.45\" 75Hz FHD Monitor", Price=7900.00M, Stock=70, CategoryId=2},
                  new Product{ Id=3, Name="Micropack M101 Optical USB Mouse", Price=350.00M, Stock=100, CategoryId=4},
                   new Product{ Id=4, Name="TEAM GX2 2.5\" SATA 128GB SSD", Price=1700.00M, Stock=70,CategoryId=5}
            });
            //GetAll 
            Console.WriteLine("GetAll");
            repoB.GetAll().ToList()
                .ForEach(c => Console.WriteLine($"Id:{c.Id}, Name: {c.Name}, Price: {c.Price},Stock: { c.Stock}")); 
            //Get 
            Console.WriteLine("Get");
            var product = repoB.Get(2);
            Console.WriteLine($"Id:{product.Id}, Name: {product.Name}, Price: {product.Price},Stock: {product.Stock}"); 
            //Update 
            Console.WriteLine("Update");
            product.Price = 1900;
            repoB.Update(product);
            repoB.GetAll().ToList()
               .ForEach(p => Console.WriteLine($"Id:{p.Id}, Name: {p.Name}, Price: {p.Price},Stock: { p.Stock}")); 
            //Delete 
            Console.WriteLine("Delete");
            repoB.Delete(2);
            repoB.GetAll().ToList()
               .ForEach(p => Console.WriteLine($"Id:{p.Id}, Name: {p.Name}, Price: {p.Price},Stock: { p.Stock}")); 
        }

    }
}

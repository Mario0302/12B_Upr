﻿using DbProductsORM.Buisness;
using DbProductsORM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProductsORM.Presentation
{
    public class Display
    {
        private int closeOperationId = 6;
        private ProductBusiness productBusiness = new ProductBusiness();


        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18)+"MENU"+new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update new entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;

                }
            } while (operation != closeOperationId);
        }

        public Display()
        {
            Input();
        }

        private void Add()
        {
            Product product = new Product();
            Console.WriteLine("Entry name: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("Entry price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter stock: ");
            product.Stock = int.Parse(Console.ReadLine());
            productBusiness.Add(product);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16)+"PRODUCTS"+ new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var products = productBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Name, item.Price, item.Stock);
            }
        }

        private void Update()
        {
            Console.WriteLine("Entry ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine("Entry name: ");
                product.Name = Console.ReadLine();
                Console.WriteLine("Entry price: ");
                product.Price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Entry stock: ");
                product.Stock = int.Parse(Console.ReadLine());
                productBusiness.Update(product);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Entry ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: "+product.Id);
                Console.WriteLine("Name: "+product.Name);
                Console.WriteLine("Price: "+product.Price);
                Console.WriteLine("Stock: "+product.Stock);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Delete()
        {
            Console.WriteLine("Entry ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            productBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}

using System;
using System.Collections.Generic;

namespace Masma.Lab3.ProductRepository
{
    public static class ProductRepostory
    {
        public static int RandomProduct()
        {
            return new Random().Next(1, 4);
        }

        public static List<Product> GetMyProducts(string providerName)
        {
            return Values[providerName];
        }

        private static readonly Dictionary<string, List<Product>> Values = new Dictionary<string, List<Product>>
        {
            {
                "Provider_1", new List<Product>
                {
                    new Product
                    {
                        Name = "PRD_01",
                        Id = 1,
                        Price = 12
                    },
                    new Product
                    {
                        Name = "PRD_02",
                        Id = 2,
                        Price = 11
                    },
                    new Product
                    {
                        Name = "PRD_03",
                        Id = 3,
                        Price = 14
                    },
                    new Product
                    {
                        Name = "PRD_04",
                        Id = 4,
                        Price = 17
                    }
                }
            },
            {
                "Provider_2", new List<Product>
                {
                    new Product
                    {
                        Name = "PRD_01",
                        Id = 1,
                        Price = 25
                    },
                    new Product
                    {
                        Name = "PRD_02",
                        Id = 2,
                        Price = 24
                    },
                    new Product
                    {
                        Name = "PRD_03",
                        Id = 3,
                        Price = 1
                    }
                }
            },
            {
                "Provider_3", new List<Product>
                {
                    new Product
                    {
                        Name = "PRD_01",
                        Id = 1,
                        Price = 9
                    },
                    new Product
                    {
                        Name = "PRD_02",
                        Id = 2,
                        Price = 1
                    },
                    new Product
                    {
                        Name = "PRD_03",
                        Id = 3,
                        Price = 99
                    }
                }
            }
        };
    }
}
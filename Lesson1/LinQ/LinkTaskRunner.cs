using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.LinQ
{

    public class LinkTaskRunner
    {
        /// <summary>
        /// Товар 
        /// </summary>
        private class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Product(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        /// <summary>
        /// Сделка
        /// </summary>
        private class Deal
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public double Price { get; set; }
            public int Count { get; set; }
        }
        public static void Run()
        {
            //Создать перечень продуктов из 10 товаров
            var listProduct = new List<Product>() {
                new Product(1, "Lemon"),
                new Product(2, "Apple"),
                new Product(3, "Pen"),
                new Product(4, "Carrot"),
                new Product(5, "Pineapple"),
                new Product(6, "Potato"),
                new Product(7, "Butter"),
                new Product(8, "Book"),
                new Product(9, "Lamp"),
                new Product(10, "Pencil")
            };
            //Создать перечень сделок 20 шт
            var listDeal = new List<Deal>()
            {
                new Deal(){Id = 1, ProductId = 1, Price = 2, Count = 23},
                new Deal(){Id = 2, ProductId = 2, Price = 10, Count = 12},
                new Deal(){Id = 3, ProductId = 3, Price = 1, Count = 155},
                new Deal(){Id = 4, ProductId = 4, Price = 23, Count = 20},
                new Deal(){Id = 5, ProductId = 5, Price = 65, Count = 10},
                new Deal(){Id = 6, ProductId = 1, Price = 12, Count = 10},
                new Deal(){Id = 7, ProductId = 2, Price = 54, Count = 10},
                new Deal(){Id = 8, ProductId = 3, Price = 22, Count = 19},
                new Deal(){Id = 9, ProductId = 4, Price = 25, Count = 10},
                new Deal(){Id = 10, ProductId = 5, Price = 1, Count = 10},
                new Deal(){Id = 11, ProductId = 6, Price = 32, Count = 10},
                new Deal(){Id = 12, ProductId = 7, Price = 10, Count = 10},
                new Deal(){Id = 13, ProductId = 8, Price = 22, Count = 10},
                new Deal(){Id = 14, ProductId = 9, Price = 1, Count = 10},
                new Deal(){Id = 15, ProductId = 10, Price = 21, Count = 10},
                new Deal(){Id = 16, ProductId = 10, Price = 20, Count = 10},
                new Deal(){Id = 17, ProductId = 1, Price = 12, Count = 11},
                new Deal(){Id = 18, ProductId = 2, Price = 12, Count = 16},
                new Deal(){Id = 19, ProductId = 3, Price = 25, Count = 21},
                new Deal(){Id = 20, ProductId = 4, Price = 323, Count = 1},
            };
            //Выбрать все сделки, которые были дороже 50
            //переделать, тут должен список выводиться
            var answer1 = listDeal.Where(x => x.Price * x.Count > 50).ToList();
            //Console.WriteLine(answer1);
            //Вывести первые 10 сделок, отсортированных по коду товара и цене
            //переделать GroupBy не подходит, сортируем по коду товара через
            //    Order by, потом берем через Take
            var answer2 = listDeal
                .OrderBy(x => x.ProductId)
                .ThenBy(x => x.Price)
                .Take(10)
                .ToList(); ;
            //Console.WriteLine(answer2);
            //Вывести первые 3 сделки, цена которых между 30 и 70




            //убрать return true\false, первые 3 сделки только
            var answer3 = listDeal
                .Where(x =>
                {
                    var price = x.Price * x.Count;
                    return price > 29 && price < 71;
                })
                .Take(3)
                .ToList();
            Console.WriteLine(answer3);
            //Создать второй список сделок 10 шт
            var listDeal2 = new List<Deal>()
            {
                new Deal(){Id = 1, ProductId = 1, Price = 20, Count = 13},
                new Deal(){Id = 2, ProductId = 2, Price = 10, Count = 12},
                new Deal(){Id = 3, ProductId = 6, Price = 12, Count = 15},
                new Deal(){Id = 4, ProductId = 4, Price = 43, Count = 28},
                new Deal(){Id = 5, ProductId = 5, Price = 65, Count = 16},
                new Deal(){Id = 6, ProductId = 3, Price = 62, Count = 10},
                new Deal(){Id = 7, ProductId = 2, Price = 54, Count = 13},
                new Deal(){Id = 8, ProductId = 9, Price = 12, Count = 19},
                new Deal(){Id = 9, ProductId = 14, Price = 75, Count = 15},
                new Deal(){Id = 10, ProductId = 9, Price = 15, Count = 56}
            };
            //Найти пересечение продуктов из двух списков сделок
            //переделать! ПРОДУКТОВ: сначала выбираем продукты, потом их пересекаем
            var res1 = listDeal
                .Select(x => x.ProductId)
                .Distinct()
                .Intersect(listDeal2
                          .Select(x => x.ProductId)
                          .Distinct());
            //разницу
            //переделать! ПРОДУКТОВ: сначала выбираем продукты
            var res2 = listDeal
                .Select(x => x.ProductId)
                .Distinct()
                .Except(listDeal2
                          .Select(x => x.ProductId)
                          .Distinct());
            //объединение
            //переделать! ПРОДУКТОВ: сначала выбираем продукты
            var res3 = listDeal
                .Select(x => x.ProductId)
                .Distinct()
                .Union(listDeal2
                          .Select(x => x.ProductId)
                          .Distinct());
            //Вывести самую дорогую сделку
            var res4 = listDeal.Max(x => (x.Price * x.Count));
            //Вывести среднюю стоимость сделки
            var res5 = listDeal.Average(x => (x.Price * x.Count));
            //Посчитать количество сделок с суммой 50
            var res6 = listDeal.Count(x => (x.Price * x.Count) == 50);

            //Сгруппировать сделки по продуктам и вывести 
            var res7 = listDeal
                .GroupBy(x => x.ProductId);
            //код продукта, количество сделок, среднюю стоимость
            var res8 = listDeal
                .GroupBy(x => x.ProductId)
                .Select(x => new
                {
                    x.Key,
                    DealCount = x.Count(),
                    AveragePrice = x.Average(y => y.Price * y.Count)
                });
            //Вывести сделки, соединив со справочником продуктов:
            //Наименование продукта, цена
            var res9 = listProduct.Join(listDeal,
                prod => prod.Id,
                deal => deal.ProductId,
                (prod, deal) => new { prod.Name, deal.Price });
            //Проверить наличие продукта с кодом 4
            var res10 = listProduct.Any(x => x.Id == 4);
            //Проверить, все ли сделки дороже 20
            var res11 = listDeal.All(x => x.Count * x.Price > 20);
        }
    }
}



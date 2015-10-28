using System;
using System.CodeDom.Compiler;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace LINQ
{
    internal class Program
    {
        /* Practice your LINQ!
         * You can use the methods in Data Loader to load products, customers, and some sample numbers
         * 
         * NumbersA, NumbersB, and NumbersC contain some ints
         * 
         * The product data is flat, with just product information
         * 
         * The customer data is hierarchical as customers have zero to many orders
         */

        private static void Main()
        {
            // PrintOutOfStock();
            // PrintInStock3();
            //PrintWashingtonCustomers();
            // PrintProductNames();
            //PrintIncreasedPrice();
            //PrintProductNamesUpper();
            //PrintProductsWithEvenUnits();
            // PrintNewSequenceProductCategoryPrice();
            //PrintOrdersLess500();
            //PrintFirst3FromA();
            //PrintFirst3WashingtonOrders();
            //SkipFirst3FromA();
            //SkipFirst2WashingtonOrders();
            //TakeNumbersUntilGreater6();
            //TakeNumbersUntilGreaterThanPosition();
            //ReturnFromCStartingAtDivisible3();
            //OrderProductsbyName();
            //OrderProductsbyUnitsInStock();
            //SortProductsByCategoryUnitPrice();
            //ReverseC();
            //NumbersCGroupedByRemainder();
            // NumbersCGroupedByRemainder();
            // DisplayProductsByCategory();
            //GroupCustomerOrdersByYearByMonth();
            //GetUniqueProductCategories();
            //GetUniqueValuesFromAAndB();
            //GetSharedValuesFromAAndB();
            //GetValuesInANotInB();
            //GetProductId12();
            //DoesProduct789Exist();
            //CategoriesWhere1ProductOutOfStock();
            //DoesNumbersBContainNumbersLessThan9();
            DoesProductsHaveAllInStock();
            //CountOddsInA();
            //PrintListCustomerIdsCountOrders();
            //PrintListCategoriesCountProducts();
            //TotalUnitsInStock();
            //LowestPriceInCategory();
            //HightestPriceInCategory();
            //PrintListCategoriesAverageCostProducts();

            Console.ReadLine();
        }

        //1. Find all products that are out of stock.
        private static void PrintOutOfStock()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitsInStock == 0);

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        //2. Find all products that are in stock and cost more than 3.00 per unit.
        private static void PrintInStock3()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                where (p.UnitsInStock != 0) && ((decimal) p.UnitPrice) > (decimal) 3.00
                select p;

            foreach (var result in results)
            {
                Console.WriteLine("{0} - {1} - {2}", result.ProductName, result.UnitPrice, result.UnitsInStock);
            }
        }

        //3. Find all customers in Washington, print their name then their orders. (Region == "WA")
        private static void PrintWashingtonCustomers()
        {
            var customers = DataLoader.LoadCustomers();

            var results = from c in customers
                where c.Region == "WA"
                select c;
            // select new Customer {Orders = }
            foreach (var result in results)
            {
                Console.WriteLine("{0}", result.CompanyName);
                foreach (var order in result.Orders)
                {
                    Console.WriteLine("\t{0} - {1} - {2}", order.OrderID, order.OrderDate, order.Total);
                }
            }
        }

        //4. Create a new sequence with just the names of the products.
        private static void PrintProductNames()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                select p.ProductName;

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        //5. Create a new sequence of products and unit prices where the unit prices are increased by 25%
        private static void PrintIncreasedPrice()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                select new {Price = p.UnitPrice + (p.UnitPrice*(decimal) .25), p.ProductName, p.UnitPrice};

            foreach (var r in results)
            {
                Console.WriteLine("{0} - Original Price: {1} - Increased Price: {2}", r.ProductName, r.UnitPrice,
                    r.Price);
            }

        }

        //6. Create a new sequence of just product names in all upper case.
        private static void PrintProductNamesUpper()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                select p.ProductName.ToUpper();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        //7. Create a new sequence with products with even numbers of units in stock.
        private static void PrintProductsWithEvenUnits()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                where p.UnitPrice%2 == 0
                select p;

            foreach (var r in results)
            {
                Console.WriteLine("{0} - {1}", r.ProductName, r.UnitPrice);
            }
        }

        //8. Create a new sequence of products with ProductName, Category, and rename UnitPrice to Price.
        private static void PrintNewSequenceProductCategoryPrice()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                select new {p.ProductName, p.Category, Price = p.UnitPrice};

            foreach (var r in results)
            {
                Console.WriteLine("{0} - {1} - {2}", r.ProductName, r.Category, r.Price);
            }
        }

        /*9. Make a query that returns all pairs of numbers from both arrays such that the number from numbersB is less 
        than the number from numbersC. */

        private static void PrintPairsFromBAndC()
        {
            //per dave this has to be done with lambda terminology, no solution with sql syntax
            var B = DataLoader.NumbersB;
            var C = DataLoader.NumbersC;

           // var results = B.Where(b=> C.)

            var results = B.Select((num, index) => new
            {
                b = num,
                c = C[index]
            }).Where(item => item.b < item.c);
        }

        //10. Select CustomerID, OrderID, and Total where the order total is less than 500.00
        private static void PrintOrdersLess500()
        {
            var customers = DataLoader.LoadCustomers();
            var results = from c in customers
                from order in c.Orders
                where order.Total < 500
               select new {c.CustomerID, order.OrderID, order.Total};

            foreach (var r in results)
            {
                Console.WriteLine("{0} - {1} - {2}", r.CustomerID, r.OrderID, r.Total);
            }

        }

        //11. Write a query to take only the first 3 elements from NumbersA.
        private static void PrintFirst3FromA()
        {
            var results = DataLoader.NumbersA.Take(3); //take will take the number of elements in the collection

            foreach (var number in results)
            {
                Console.WriteLine(number);
            }
        }

        //12. Get only the first 3 orders from customers in Washington
        private static void PrintFirst3WashingtonOrders()
        {
            var customers = DataLoader.LoadCustomers();

            //var results = from c in customers
            //              from orders in customers
            //              where c.Region == "WA"
            //              select c;

            var results = customers.Where(i => i.Region == "WA");

            // select new Customer {Orders = }
            foreach (var result in results)
            {
                Console.WriteLine("{0}", result.CompanyName);
                foreach (var order in result.Orders.Take(3))
                {
                    Console.WriteLine("\t{0} - {1} - {2}", order.OrderID, order.OrderDate, order.Total);
                }
            }
        }

        //13. Skip the first 3 elements of NumbersA.
        private static void SkipFirst3FromA()
        {
            var results = DataLoader.NumbersA.Skip(3);
            foreach (var number in results)
            {
                Console.WriteLine(number);
            }

        }

        //14. Get all except the first two orders from customers in Washington.
        private static void SkipFirst2WashingtonOrders()
        {
            var customers = DataLoader.LoadCustomers();

            var results = customers.Where(i => i.Region == "WA");

            // select new Customer {Orders = }
            foreach (var result in results)
            {
                Console.WriteLine("{0}", result.CompanyName);
                foreach (var order in result.Orders.Skip(2))
                {
                    Console.WriteLine("\t{0} - {1} - {2}", order.OrderID, order.OrderDate, order.Total);
                }
            }
        }

        //15. Get all the elements in NumbersC from the beginning until an element is greater or equal to 6.
        private static void TakeNumbersUntilGreater6()
        {
            var results = DataLoader.NumbersC.TakeWhile(i => i < 6);
            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
        }

        //16. Return elements starting from the beginning of NumbersC until a number is hit that is less than its position in the array.
        private static void TakeNumbersUntilGreaterThanPosition()
        {
            var results = DataLoader.NumbersC.TakeWhile((r, index) => r > index);
            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
        }

        //17. Return elements from NumbersC starting from the first element divisible by 3.
        private static void ReturnFromCStartingAtDivisible3()
        {
            var results = DataLoader.NumbersC.SkipWhile(i => i%3 != 0);
            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
        }

        //18. Order products alphabetically by name.
        private static void OrderProductsbyName()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                orderby p.ProductName
                select p;

            foreach (var r in results)
            {
                Console.WriteLine("{0}", r.ProductName);
            }
        }

        //19. Order products by UnitsInStock descending.
        private static void OrderProductsbyUnitsInStock()
        {
            var products = DataLoader.LoadProducts();
            var results = products.OrderByDescending(r => r.UnitsInStock);

            foreach (var r in results)
            {
                Console.WriteLine("{0} - {1}", r.ProductName, r.UnitsInStock);
            }
        }

        //20. Sort the list of products, first by category, and then by unit price, from highest to lowest.
        private static void SortProductsByCategoryUnitPrice()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                orderby p.Category, p.UnitPrice descending
                select p;
            foreach (var r in results)
            {
                Console.WriteLine("{0} - {1} - {2}", r.ProductName, r.Category, r.UnitPrice);
            }
        }

        //21. Reverse NumbersC
        private static void ReverseC()
        {
            var results = DataLoader.NumbersC.Reverse();

            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
        }

        //22. Display the elements of NumbersC grouped by their remainder when divided by 5.
        private static void NumbersCGroupedByRemainder()
        {
            // var results = DataLoader.NumbersC.GroupBy(r => r%5);

            //rlf - the key is the thing we are grouping by, whereas in normal sql this would be a column
            // here we are grouping by the remainder, the display under the key would normally be the rest of the 
            //columns in a normal group by, but here we dont' have columns, we just have numbers, 
            //so we have to create a new anonymous type with the numbers to represent what would be the 
            //columns in sql, so our new g(group), is a listing of a key (the remainder), and the values for that
            //key, which are the rest of the numbers, in sql, the key we are grouping by would be whatever column,
            // the values would be the other columns

            var results = from r in DataLoader.NumbersC
                group r by r%5
                into newGroup
                select new {Remainder = newGroup.Key, Numbers = newGroup};

            foreach (var g in results)
            {
                Console.WriteLine("Remainder: {0}", g.Remainder);
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine("Numbers: {0}", n);
                }
            }
        }

        //23. Display products by Category
        private static void DisplayProductsByCategory()
        {
            var products = DataLoader.LoadProducts();
            var results = from p in products
                group p by p.Category;

            foreach (var r in results)
            {
                Console.WriteLine("Category: {0}", r.Key);
                foreach (Product p in r)
                {
                    Console.WriteLine("\tProducts: {0}", p.ProductName);
                }
            }

        }

        //24. Group customer orders by year, then by month.
        private static void GroupCustomerOrdersByYearByMonth()
        {
            var customers = DataLoader.LoadCustomers();
            var results = from customer in customers
                from order in customer.Orders
                orderby order.OrderDate descending
                group order by new {year = order.OrderDate.Year, month = order.OrderDate.Month}
                into newGroup
                select new {key = newGroup.Key, value = newGroup};

            foreach (var o in results)
            {
                Console.WriteLine("Year: {0}", o.key.year);
                Console.WriteLine("Month: {0}", o.key.month);

                foreach (var i in o.value)
                {
                    Console.WriteLine("OrderID: {0}", i.OrderID);
                }
            }

            //foreach(var byYear in customers.GroupBy(y => y.Orders.))

            //    var results = from customer in customers
            //        from order in customer.Orders
            //        group order by order.OrderDate
            //        into newGroup1
            //        from newGroup2 in
            //            (from order in newGroup1
            //                group order by order.OrderDate.Year)
            //        group newGroup2 by newGroup1.Key;


            //var results = from customer in customers
            //    from order in customer.Orders
            //    group order by order.OrderDate.Year
            //    into newGroup
            //    select new
            //    {
            //        newGroup.Key,
            //        count = newGroup.Count(),
            //        subgroup = from order in newGroup
            //            group order by order.OrderDate.Month
            //            into newGroup2
            //            select newGroup2
            //    };

            //select new {orderName = order.OrderID, orderYear = order.OrderDate.Year, orderMonth = order.OrderDate.Month}

        }

        //25. Create a list of unique product category names.
        private static void GetUniqueProductCategories()
        {
            var products = DataLoader.LoadProducts();
            var results = (from p in products
                           orderby p.Category descending 
                select p.Category).Distinct(); //have to have the parenthesis

            foreach (var result in results)
            {
                Console.WriteLine(result);

            }
        }

        //26. Get a list of unique values from NumbersA and NumbersB.
        private static void GetUniqueValuesFromAAndB()
        {
            var results =
                DataLoader.NumbersA.Union(DataLoader.NumbersB)
                    .Except(DataLoader.NumbersA.Intersect(DataLoader.NumbersB));

            foreach (var num in results)
            {
                Console.WriteLine(num);
            }
        }

        // 27. Get a list of the shared values from NumbersA and NumbersB.
        private static void GetSharedValuesFromAAndB()
        {
            var results = DataLoader.NumbersA.Intersect(DataLoader.NumbersB);

            foreach (var num in results)
            {
                Console.WriteLine(num);
            }
        }

        //28. Get a list of values in NumbersA that are not also in NumbersB.
        private static void GetValuesInANotInB()
        {
            var results = DataLoader.NumbersA.Except(DataLoader.NumbersB);

            foreach (var num in results)
            {
                Console.WriteLine(num);
            }
        }

        //29. Select only the first product with ProductID = 12 (not a list).
        private static void GetProductId12()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                where product.ProductID == 12
                select product;

            //Console.WriteLine(results.Count());
            foreach (var r in results)
            {
                Console.WriteLine("{0} - {1} - {2}", r.ProductID, r.ProductName, r.UnitPrice);
            }
        }

        //30. Write code to check if ProductID 789 exists.
        private static void DoesProduct789Exist()
        {
            var products = DataLoader.LoadProducts();

            //any returns a boolean based on if the query contains any items
            var results = (from product in products
                where product.ProductID == 789
                select product).Any();

            //first or default checks the collection for null, if the collection is not null, it will
            //return the first item at position[0], otherwise it will return the default, for an object, is null
            //var results = (from product in products
            //               where product.ProductID == 789
            //               select product).FirstOrDefault() != null;

            Console.WriteLine("Does Product 789 Exist: {0}", results);
        }

        //31. Get a list of categories that have at least one product out of stock.
        private static void CategoriesWhere1ProductOutOfStock()
        {
            var products = DataLoader.LoadProducts();

            var results = (from product in products
                where product.UnitsInStock == 0
                select product.Category).Distinct();

           // results = products.Where(p => p.UnitsInStock == 0).Select(x => x.Category).Distinct();
            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
        }

        //32. Determine if NumbersB contains only numbers less than 9.
        private static void DoesNumbersBContainNumbersLessThan9()
        {

            //var results = !(from result in DataLoader.NumbersB
            //              where result >= 9
            //              select result).Any();

            var results = DataLoader.NumbersB.All(r => r < 9);
            Console.WriteLine("Does NumbersB only contain items < 9: {0}", results);
        }

        //33. Get a grouped a list of products only for categories that have all of their products in stock.
        private static void DoesProductsHaveAllInStock()
        {
            var products = DataLoader.LoadProducts();
            //var results = from result in products
            //    group result by result.UnitsInStock > 0
            //    into newGroup
            //    select newGroup;

            var results = products.GroupBy(x => x.UnitsInStock > 0);

            foreach (var r in results)
            {
              Console.WriteLine("Products in Stock: {0}", r.Key);
                foreach (var x in r)
                {
                    Console.WriteLine("\t{0} - {1} ",x.ProductName, x.UnitsInStock);
                }
            }
        }

        //34. Count the number of odds in NumbersA.
        private static void CountOddsInA()
        {
            var A = DataLoader.NumbersA;

            var results = (from a in A
                where a%2 != 0
                select a).Count();

            results = A.Count(a => a%2 != 0);

            Console.WriteLine(results);
        }

        //35. Display a list of CustomerIDs and only the count of their orders.
        private static void PrintListCustomerIdsCountOrders()
        {
            var customers = DataLoader.LoadCustomers();

            var results = from customer in customers
               select new {id = customer.CustomerID, count = customer.Orders.Count()};

           // results = customers.Select(c => new {id = c.CustomerID, count = c.Orders.Count()});
            foreach (var r in results)
            {
                Console.WriteLine("Customer ID: {0}, OrderCount: {1}", r.id, r.count);
            }
        }

        //36. Display a list of categories and the count of their products.
        private static void PrintListCategoriesCountProducts()
        {
            var products = DataLoader.LoadProducts();

            var results = from product in products
                group product by product.Category
                into newGroup
                    // select new { Key = newGroup.Key, count = newGroup.Count() };  //rlf instead of this, can just select newGroup, then take a count of the products in the write line
                select newGroup;

           results = products.GroupBy(p => p.Category);
            foreach (var r in results)
            {
                //Console.WriteLine("{0}, Product Count: {1}", r.Key, r.count);
                Console.WriteLine("{0}, Product Count: {1}", r.Key, r.Count());
            }
        }

        //37. Display the total units in stock for each category.
        private static void TotalUnitsInStock()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                group product by product.Category
                into newGroup
               // select new {key = newGroup.Key, value = newGroup.Sum(p => p.UnitsInStock)};
                select newGroup;

            results = products.GroupBy(p => p.Category);  //produces a list of groups

            foreach (var r in results)
            {

               Console.WriteLine("{0}, Total Units in Stock: {1}", r.Key, r.Sum(p => p.UnitsInStock));
            }
        }

        //38. Display the lowest priced product in each category
        private static void LowestPriceInCategory()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                group product by product.Category
                into ProductsByCategory
                select new
                {
                    Category = ProductsByCategory.Key,
                    LowestPriceProduct = (from products2 in ProductsByCategory
                                          where products2.UnitPrice == ProductsByCategory.Min(p3 => p3.UnitPrice)
                                          select products2).FirstOrDefault()
                };



            // results = products.GroupBy(p=> p.Category).OrderBy(g => g.Key).Select()
            //result.Min(p => p.UnitPrice)

            foreach (var result in results)
            {
                Console.WriteLine("{0}, \nLowest Priced Product: {1} {2:C} ", result.Category, result.LowestPriceProduct.ProductName, result.LowestPriceProduct.UnitPrice);
            }
        }

        //39. Display the highest priced product in each category.
        private static void HightestPriceInCategory()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                          group product by product.Category
                into ProductsByCategory
                          select new
                          {
                              Category = ProductsByCategory.Key,
                              HighestPriceProduct = (from products2 in ProductsByCategory
                                                    where products2.UnitPrice == ProductsByCategory.Max(p3 => p3.UnitPrice)
                                                    select products2).FirstOrDefault()
                          };
            
            foreach (var result in results)
            {
                Console.WriteLine("{0}, \nHighest Priced Product: {1} {2:C} ", result.Category, result.HighestPriceProduct.ProductName, result.HighestPriceProduct.UnitPrice);
            }
        }

        //40. Show the average price of product for each category.
        private static void PrintListCategoriesAverageCostProducts()
        {
            var products = DataLoader.LoadProducts();

            //var results = from product in products
            //              group product by product.Category
            //    into ProductbyCategory
            //              select ProductbyCategory;

            //var results = from product in products
            //              group product by product.Category
            //    into ProductbyCategory
            //              select new
            //              {
            //                  category = ProductbyCategory.Key,
            //                  avgPriceProduct = (from x in ProductbyCategory
            //                                    select x.UnitPrice).Average()

            //              };


            var results = products.GroupBy(p => p.Category);
            foreach (var r in results)
            {
                //Console.WriteLine("{0}, Product Count: {1}", r.Key, r.count);
                Console.WriteLine("{0}, Average Price: {1:C}", r.Key, r.Average(p => p.UnitPrice));
            }


        }
    }
}
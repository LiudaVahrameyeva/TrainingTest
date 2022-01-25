using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Discounts;

namespace TestProject1
{
    public class Tests
    {
        Discount_1 discount1 = new Discount_1();
        Discount_5 discount5 = new Discount_5();
            
        ValueCalculator calculator = new ValueCalculator();

        private  Product[] products =  {
            new Product {ProductID = 1, Name = "Socks", Price = 20},
            new Product {ProductID = 2, Name = "Hennessey", Price = 100}};


        private decimal test1ExpectedResult;
        

        [Test]
        [Category("ShoppingCartTests")]
        public void VerifyTotalSumForDiscount1()
        {
            test1ExpectedResult = decimal.Parse("118.8");
            try
            {
                ShoppingCart cart1 = new ShoppingCart(discount1, calculator) {Products = products};
                Console.WriteLine(cart1.CalculateTotal());

                Assert.IsTrue(cart1.CalculateTotal() == test1ExpectedResult, "Incorrect total sum for Discount 1");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        [Category("ShoppingCartTests")]
        public void VerifyTotalSumForDiscount5()
            {
                test1ExpectedResult = decimal.Parse("114");
                try
                {
                    ShoppingCart cart1 = new ShoppingCart(discount5, calculator) {Products = products};
                    Console.WriteLine(cart1.CalculateTotal());

                    Assert.IsTrue(cart1.CalculateTotal() == test1ExpectedResult, "Incorrect total sum for Discount 5");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        
        [Test]
        [Category("ValueCalculatorTests")]
        public void VerifySumOfPricesOfProducts()
        {
            test1ExpectedResult = decimal.Parse("120");
            try
            {
   
                Console.WriteLine(calculator.ValueCalc(products));

                Assert.IsTrue(calculator.ValueCalc(products) == test1ExpectedResult, "Incorrect sum of prices of products");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [Test]
        [Category("DiscountTests")]
        public void VerifyPercentageValueDiscount1()
        {
            test1ExpectedResult = decimal.Parse("118.8");
            try
            {
                Console.WriteLine(discount1.PercentageValue(calculator.ValueCalc(products)));

                Assert.IsTrue(discount1.PercentageValue(calculator.ValueCalc(products)) == test1ExpectedResult, "Incorrect percentage value or discount 1");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
           
        [Test]
        [Category("DiscountTests")]
        public void VerifyPercentageValueDiscount5()
        {
            test1ExpectedResult = decimal.Parse("114");
            try
            {
                Console.WriteLine(discount5.PercentageValue(calculator.ValueCalc(products)));

                Assert.IsTrue(discount5.PercentageValue(calculator.ValueCalc(products)) == test1ExpectedResult, "Incorrect percentage value or discount 5");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
     
        [Test]
        [Category("ProductTests")]
        public void ProductComparisonTrue()
        {
            string prod1 = "Product ID: 1, Name: Socks, Price: 20";
            string prod2 = "Product ID: 1, Name: Socks, Price: 20";
            try
            {
               
                    Assert.IsTrue(prod1.Equals(prod2),"Products are not equal" );

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [Test] 
        [Category("ProductTests")]
        public void ProductComparisonFalse()
                {
                    string prod1 = "Product ID: 1, Name: Socks, Price: 20";
                    string prod2 = "Product ID: 1, Name: Socks, Price: 25";
                    try
                    {
                       
                            Assert.IsFalse(prod1.Equals(prod2),"Products are equal" );
        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
        
        [Test]
        [Category("ProductTests")]
        public void HashCodeTrue()
        {
            string prod1 = "Product ID: 1, Name: Socks, Price: 20";
            string prod2 = "Product ID: 1, Name: Socks, Price: 20";
            try
            {
               
                Assert.IsTrue(prod1.GetHashCode()==prod2.GetHashCode(),"Hash Code values are not equal" );

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [Test] 
        [Category("ProductTests")]
        public void HashCodeFalse()
        {
            string prod1 = "Product ID: 1, Name: Socks, Price: 20";
            string prod2 = "Product ID: 1, Name: Socks, Price: 25";
            try
            {

                Assert.IsFalse(prod1.GetHashCode()==prod2.GetHashCode(),"Hash Code values are equal" );
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
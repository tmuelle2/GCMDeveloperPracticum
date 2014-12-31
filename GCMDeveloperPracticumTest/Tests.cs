using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCMDeveloperPracticum;

namespace GCMDeveloperPracticumTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void MorningBasicTest()
        {
            var meal = new Meal("morning, 1, 2, 3");
            Assert.AreEqual(meal.ToString(), "eggs, toast, coffee");
        }

        [TestMethod]
        public void MorningOrderTest()
        {
            var meal = new Meal("morning, 2, 1, 3");
            Assert.AreEqual(meal.ToString(), "eggs, toast, coffee");
        }

        [TestMethod]
        public void MorningErrorTest()
        {
            try
            {
                var meal = new Meal("morning, 1, 2, 3, 4");
            }            
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "eggs, toast, coffee, error");
            }   
        }

        [TestMethod]
        public void MorningMultiTest()
        {
            var meal = new Meal("morning, 1, 2, 3, 3, 3");
            Assert.AreEqual(meal.ToString(), "eggs, toast, coffee(x3)");
        }

        [TestMethod]
        public void NightBasicTest()
        {
            var meal = new Meal("night, 1, 2, 3, 4");
            Assert.AreEqual(meal.ToString(), "steak, potato, wine, cake");
        }

        [TestMethod]
        public void NightMultiTest()
        {
            var meal = new Meal("night, 1, 2, 2, 4");
            Assert.AreEqual(meal.ToString(), "steak, potato(x2), cake");
        }

        [TestMethod]
        public void NightErrorTest1()
        {
            try 
            {
                var meal = new Meal("night, 1, 2, 3, 5");
            }            
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "steak, potato, wine, error");
            }            
        }

        [TestMethod]
        public void NightErrorTest2()
        {
            try
            {
                var meal = new Meal("night, 1, 1, 2, 3, 5");
            }            
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "steak, error");
            }   
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using Lab02_Variant03;

namespace Lab02_Unit_Tests
{
    [TestClass]
    public class LogicAdvancedTests
    {

        // КОНВЕРТЕР ТЕМПЕРАТУР

        [TestMethod]
        public void CelsiusToFahrenheit_Negative_Test()
        {
            double result = Logic.CelsiusToFahrenheit(-40);
            Assert.AreEqual(-40, result); // -40°C = -40°F
        }

        [TestMethod]
        public void FahrenheitToCelsius_Negative_Test()
        {
            double result = Logic.FahrenheitToCelsius(-40);
            Assert.AreEqual(-40, result); // -40°F = -40°C
        }

        // ФИБОНАЧЧИ

        [TestMethod]
        public void Fibonacci_OneElement_Test()
        {
            var result = Logic.GenerateFibonacci(1);
            CollectionAssert.AreEqual(new List<int> { 1 }, result);
        }

        [TestMethod]
        public void Fibonacci_InvalidInput_Test()
        {
            try
            {
                Logic.GenerateFibonacci(0);
                Assert.Fail("Ожидалось исключение ArgumentException");
            }
            catch (ArgumentException)
            {
                // тест пройден
            }
        }

        [TestMethod]
        public void Fibonacci_LargeN_Test()
        {
            int n = 10;
            var result = Logic.GenerateFibonacci(n);
            CollectionAssert.AreEqual(new List<int> { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 }, result);
        }


        // ТРЕУГОЛЬНИК

        [TestMethod]
        public void TriangleExists_Fails_Test()
        {
            bool exists = Logic.TriangleExists(1, 2, 3);
            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void TriangleType_Equilateral_Test()
        {
            string type = Logic.GetTriangleType(5, 5, 5);
            Assert.AreEqual("равносторонний", type);
        }

        [TestMethod]
        public void TriangleType_Isosceles_Test()
        {
            string type = Logic.GetTriangleType(5, 5, 8);
            Assert.AreEqual("равнобедренный", type);
        }

        [TestMethod]
        public void TriangleType_Scalene_Test()
        {
            string type = Logic.GetTriangleType(3, 4, 5);
            Assert.AreEqual("разносторонний", type);
        }

        [TestMethod]
        public void TrianglePoints_NotNull_Test()
        {
            var points = Logic.GetTrianglePoints(3, 4, 5, 200, 200);
            Assert.IsNotNull(points);
        }

        [TestMethod]
        public void TrianglePoints_Count_Test()
        {
            var points = Logic.GetTrianglePoints(3, 4, 5, 200, 200);
            Assert.AreEqual(3, points.Length);
        }

        [TestMethod]
        public void TrianglePoints_PositiveCoordinates_Test()
        {
            var points = Logic.GetTrianglePoints(3, 4, 5, 200, 200);
            foreach (var p in points)
            {
                Assert.IsTrue(p.X >= 0);
                Assert.IsTrue(p.Y >= 0);
            }
        }

        [TestMethod]
        public void TrianglePoints_Scaling_Test()
        {
            var pointsSmall = Logic.GetTrianglePoints(1, 1, 1, 100, 100);
            var pointsLarge = Logic.GetTrianglePoints(10, 10, 10, 200, 200);
            // Проверяем, что треугольник с большими сторонами больше по координатам
            Assert.IsTrue(pointsLarge[1].X > pointsSmall[1].X);
        }
    }
}

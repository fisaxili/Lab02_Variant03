using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lab02_Variant03; 

namespace Lab02_Tests
{
    [TestClass]
    public class LogicTests
    {
        // КОНВЕРТЕР ТЕМПЕРАТУР

        [TestMethod]
        public void CelsiusToFahrenheit_Test()
        {
            double result = Logic.CelsiusToFahrenheit(0);
            Assert.AreEqual(32, result); // 0°C = 32°F
        }

        [TestMethod]
        public void FahrenheitToCelsius_Test()
        {
            double result = Logic.FahrenheitToCelsius(212);
            Assert.AreEqual(100, result); // 212°F = 100°C
        }

        // ФИБОНАЧЧИ

        [TestMethod]
        public void Fibonacci_Test()
        {
            var result = Logic.GenerateFibonacci(5);
            CollectionAssert.AreEqual(new List<int> { 1, 1, 2, 3, 5 }, result);
        }

        // Проверка генерации первого числа
        [TestMethod]
        public void Fibonacci_OneElement_Test()
        {
            var result = Logic.GenerateFibonacci(1);
            CollectionAssert.AreEqual(new List<int> { 1 }, result);
        }

        // ТРЕУГОЛЬНИК

        [TestMethod]
        public void TriangleExists_Test()
        {
            bool result = Logic.TriangleExists(3, 4, 5);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TriangleNotExists_Test()
        {
            bool result = Logic.TriangleExists(1, 2, 3); // не существует
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TriangleType_Test()
        {
            Assert.AreEqual("равносторонний", Logic.GetTriangleType(3, 3, 3));
            Assert.AreEqual("равнобедренный", Logic.GetTriangleType(3, 3, 4));
            Assert.AreEqual("разносторонний", Logic.GetTriangleType(3, 4, 5));
        }

        // КООРДИНАТЫ ТРЕУГОЛЬНИКА

        [TestMethod]
        public void TrianglePoints_Count_Test()
        {
            var points = Logic.GetTrianglePoints(3, 4, 5, 200, 200);
            Assert.AreEqual(3, points.Length); // должно быть 3 точки
        }
    }
}
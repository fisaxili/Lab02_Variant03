using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab02_Variant03
{
    /// <summary>
    /// Статический класс с бизнес-логикой для трех задач
    /// </summary>
    public static class Logic
    {
        // КОНВЕРТЕР ТЕМПЕРАТУР

        /// <summary>Перевод из Цельсия в Фаренгейт</summary>
        public static double CelsiusToFahrenheit(double c)
        {
            return c * 9 / 5 + 32;
        }

        /// <summary>Перевод из Фаренгейта в Цельсий</summary>
        public static double FahrenheitToCelsius(double f)
        {
            return (f - 32) * 5 / 9;
        }

        // ФИБОНАЧЧИ

        /// <summary>Генерация первых n чисел Фибоначчи</summary>
        /// <exception cref="ArgumentException">n ≤ 0</exception>
        public static List<int> GenerateFibonacci(int n)
        {
            if (n <= 0)
                throw new ArgumentException("n должно быть больше 0");

            List<int> result = new List<int>();

            int a = 1;
            int b = 1;

            result.Add(a);
            if (n > 1)
                result.Add(b);

            for (int i = 3; i <= n; i++)
            {
                int c = a + b;
                result.Add(c);
                a = b;
                b = c;
            }

            return result;
        }

        // ТРЕУГОЛЬНИК

        /// <summary>Проверка существования треугольника по трем сторонам</summary>
        public static bool TriangleExists(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        /// <summary>Определение типа треугольника</summary>
        public static string GetTriangleType(double a, double b, double c)
        {
            if (a == b && b == c)
                return "равносторонний";
            if (a == b || a == c || b == c)
                return "равнобедренный";
            return "разносторонний";
        }

        // КООРДИНАТЫ ТРЕУГОЛЬНИКА

        /// <summary>Вычисление координат вершин для отрисовки</summary>
        public static PointF[] GetTrianglePoints(double a, double b, double c, int width, int height)
        {
            double maxSide = Math.Max(a, Math.Max(b, c));
            double scale = (width - 80) / maxSide;

            double scaledA = a * scale;
            double scaledB = b * scale;
            double scaledC = c * scale;

            PointF p1 = new PointF(40, height - 40);
            PointF p2 = new PointF(40 + (float)scaledA, height - 40);

            double x = (scaledC * scaledC - scaledB * scaledB + scaledA * scaledA) / (2 * scaledA);
            double y = Math.Sqrt(scaledC * scaledC - x * x);

            PointF p3 = new PointF(40 + (float)x, height - 40 - (float)y);

            return new[] { p1, p2, p3 };
        }
    }
}
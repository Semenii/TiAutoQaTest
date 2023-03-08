using System;

namespace TriangleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] pointA = ReadPoint("A");
            double[] pointB = ReadPoint("B");
            double[] pointC = ReadPoint("C");

            double lengthAB = CalculateDistance(pointA, pointB);
            double lengthBC = CalculateDistance(pointB, pointC);
            double lengthAC = CalculateDistance(pointA, pointC);

            Console.WriteLine($"Length of AB is '{lengthAB:F3}'");
            Console.WriteLine($"Length of BC is '{lengthBC:F3}'");
            Console.WriteLine($"Length of AC is '{lengthAC:F3}'");

            bool isEquilateral = lengthAB == lengthBC && lengthBC == lengthAC;
            bool isIsosceles = lengthAB == lengthBC || lengthBC == lengthAC || lengthAC == lengthAB;
            bool isRight = IsRightTriangle(lengthAB, lengthBC, lengthAC);

            if (isEquilateral)
            {
                Console.WriteLine("Triangle is 'Equilateral'");
            }
            else
            {
                Console.WriteLine("Triangle is NOT 'Equilateral'");
            }

            if (isIsosceles)
            {
                Console.WriteLine("Triangle is 'Isosceles'");
            }
            else
            {
                Console.WriteLine("Triangle is NOT 'Isosceles'");
            }

            if (isRight)
            {
                Console.WriteLine("Triangle is 'Right'");
            }
            else
            {
                Console.WriteLine("Triangle is NOT 'Right'");
            }

            double perimeter = lengthAB + lengthBC + lengthAC;
            Console.WriteLine($"Perimeter: '{perimeter:F3}'");

            Console.WriteLine("Parity numbers in range from 0 to triangle perimeter:");
            for (int i = 0; i <= (int)perimeter; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static double[] ReadPoint(string pointName)
        {
            Console.WriteLine($"Enter coordinate x of dot {pointName}:");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine($"Enter coordinate y of dot {pointName}:");
            double y = double.Parse(Console.ReadLine());

            return new double[] { x, y };
        }

        static double CalculateDistance(double[] point1, double[] point2)
        {
            double xDiff = point1[0] - point2[0];
            double yDiff = point1[1] - point2[1];
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        static bool IsRightTriangle(double a, double b, double c)
        {
            double[] lengths = { a, b, c };
            Array.Sort(lengths);
            return Math.Abs(lengths[0] * lengths[0] + lengths[1] * lengths[1] - lengths[2] * lengths[2]) < 0.0001;
        }
    }
}


using System;
using static System.Math;

namespace RównanieKwadratowe
{
	internal class Program
	{
		private static void PierwiastkiRownania(double a, double b, double c)
		{
			if (a == 0 && b == 0 && c == 0)
			{
				Console.WriteLine("Równanie tożsamościowe - nieskończenie wiele rozwiązań.");
			}
			else if (a == 0 && b == 0 && c != 0)
			{
				Console.WriteLine("Równanie sprzeczne - brak rozwiązań.");
			}
			else if (a == 0 && b != 0)
			{
				var rozwiazanie = (-c) / (b);
				Console.WriteLine($"Równanie jest liniowe - jego rozwiązaniem jest liczba {Round(rozwiazanie, 4)}");
			}
			else
			{
				var delta = b * b - 4 * a * c;

				if (delta < 0)
				{
					Console.WriteLine("Delta ujemna - brak rozwiązań w zbiorze liczb rzeczywistych.");
				}
				else if (delta == 0)
				{
					var rozwiazanie = (-b) / (2 * a);
					Console.WriteLine($"Delta równa zero - rozwiązaniem jest liczba {Round(rozwiazanie, 4)}.");
				}
				else
				{
					var rozwiazanie1 = (-b - Sqrt(delta)) / (2 * a);
					var rozwiazanie2 = (-b + Sqrt(delta)) / (2 * a);
					Console.WriteLine($"Delta dodatnia - rozwiązaniami są liczby {Round(rozwiazanie1, 4)} oraz {Round(rozwiazanie2, 4)}.");
				}
			}
		}

		private static void Main()
		{
			double a, b, c;

			Console.WriteLine("Witaj w programie wyznaczającym rzeczywiste rozwiązania równania kwadratowego!");
			Console.WriteLine("ax² + bx + c = 0");
			Console.WriteLine("Podaj dowolne wartości parametrów a, b, c: ");

			a = double.Parse(Console.ReadLine());
			b = double.Parse(Console.ReadLine());
			c = double.Parse(Console.ReadLine());

			PierwiastkiRownania(a, b, c);
		}
	}
}

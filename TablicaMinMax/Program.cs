using System;

namespace TablicaMinMax
{
	internal class Program
	{
		private static void ZnajdzMinMax(int[] tab)
		{
			var min = tab[0];
			var max = tab[0];

			Console.WriteLine("Zawartość tablicy: ");
			foreach (var liczba in tab)
			{
				Console.Write(liczba.ToString() + " ");
			}
			Console.WriteLine();

			for (int i = 1; i < tab.Length; i++)
			{
				if (tab[i] < min)
				{
					min = tab[i];
				}
				else if (tab[i] > max)
				{
					max = tab[i];
				}
			}

			Console.WriteLine($"Najmniejsza liczba w tej tablicy jest równa: {min}");
			Console.WriteLine($"Największa liczba w tej tablicy jest równa: {max}");
		}

		private static void Main()
		{
			var tab = new int[] { 1, 4, -5, 12, 123, 0, -44, 0 };
			ZnajdzMinMax(tab);
		}
	}
}

using System;
using System.Linq;

namespace AlgorytmySortowania
{
	internal class Program
	{
		private static void Wypisz(int[] tab)
		{
			foreach (int elem in tab)
			{
				Console.Write(elem + " ");
			}
			Console.WriteLine();
		}

		private static void Zamien(int[] tab, int a, int b)
		{
			int pom = tab[a];
			tab[a] = tab[b];
			tab[b] = pom;
		}

		private static int[] BubbleSort(int[] tab)
		{
			bool czyZamiana = true;
			int i = 0;

			while (czyZamiana)
			{
				czyZamiana = false;
				for (int j = 1; j < tab.Length - i; j++)
				{
					if (tab[j - 1] > tab[j])
					{
						Zamien(tab, j - 1, j);
						czyZamiana = true;
					}
				}
				i++;
			}

			return tab;
		}

		private static void Merge(int[] tab, int l, int m, int r)
		{
			int i, j, k;
			int n1 = m - l + 1;
			int n2 = r - m;

			int[] L = new int[n1];
			int[] R = new int[n2];

			for (i = 0; i < n1; i++)
			{
				L[i] = tab[l + i];
			}

			for (j = 0; j < n2; j++)
			{
				R[j] = tab[m + 1 + j];
			}

			i = 0;
			j = 0;
			k = l; while (i < n1 && j < n2)
			{
				if (L[i] <= R[j])
				{
					tab[k] = L[i];
					i++;
				}
				else
				{
					tab[k] = R[j];
					j++;
				}
				k++;
			}

			while (i < n1)
			{
				tab[k] = L[i];
				i++;
				k++;
			}

			while (j < n2)
			{
				tab[k] = R[j];
				j++;
				k++;
			}
		}

		private static void MergeSort(int[] tab, int l, int r)
		{
			if (r > l)
			{
				int m = (l + r) / 2;
				MergeSort(tab, l, m);
				MergeSort(tab, m + 1, r);
				Merge(tab, l, m, r);
			}
		}

		private static int Partition(int[] tablica, int p, int r)
		{
			int x = tablica[p];
			int i = p, j = r, w;
			while (true)
			{
				while (tablica[j] > x)
				{
					j--;
				}

				while (tablica[i] < x)
				{
					i++;
				}

				if (i < j)
				{
					w = tablica[i];
					tablica[i] = tablica[j];
					tablica[j] = w;
					i++;
					j--;
				}
				else
				{
					return j;
				}
			}
		}

		private static void QuickSort(int[] tab, int p, int r)
		{
			int q;
			if (p < r)
			{
				q = Partition(tab, p, r);
				QuickSort(tab, p, q);
				QuickSort(tab, q + 1, r);
			}
		}

		private static void RadixSort(int[] tab, int exp)
		{
			int i;
			int[] output = new int[tab.Length];
			int[] count = new int[10];

			for (i = 0; i < 10; i++)
			{
				count[i] = 0;
			}

			for (i = 0; i < tab.Length; i++)
			{
				count[(tab[i] / exp) % 10]++;
			}

			for (i = 1; i < 10; i++)
			{
				count[i] += count[i - 1];
			}

			for (i = tab.Length - 1; i >= 0; i--)
			{
				output[count[(tab[i] / exp) % 10] - 1] = tab[i];
				count[(tab[i] / exp) % 10]--;
			}

			for (i = 0; i < tab.Length; i++)
			{
				tab[i] = output[i];
			}
		}

		private static void Pomieszaj(int[] tab)
		{
			var random = new Random();

			for (int i = 0; i < tab.Length; i++)
			{
				int j = random.Next(0, tab.Length);
				Zamien(tab, i, j);
			}
		}

		private static bool BogoSort(int[] tab)
		{
			int[] posortowana = BubbleSort(tab);

			for (int i = 0; i < 10000; i++)
			{
				Pomieszaj(tab);
				bool czy = true;

				for (int j = 0; j < tab.Length; j++)
				{
					if (tab[j] != posortowana[j])
					{
						czy = false;
					}
				}
				if (czy)
				{
					Wypisz(tab);
					return true;
				}
			}
			return false;
		}

		private static void Main()
		{
			int[] tab = new int[] { 3, 4, 0, -5, 12, 7 };
			Console.WriteLine("Nieposortowana tablica: ");
			Wypisz(tab);

			Console.WriteLine("Bubble Sort: ");
			BubbleSort(tab);
			Wypisz(tab);

			tab = new int[] { 3, 4, 0, -5, 12, 7 };
			Console.WriteLine("Merge Sort: ");
			MergeSort(tab, 0, tab.Length - 1);
			Wypisz(tab);

			tab = new int[] { 3, 4, 0, -5, 12, 7 };
			Console.WriteLine("Quick Sort: ");
			QuickSort(tab, 0, tab.Length - 1);
			Wypisz(tab);

			tab = new int[] { 3, 4, 0, 55, 12, 7 };
			Console.WriteLine("Radix Sort: ");
			int max = tab.Max();
			for (int exp = 1; max / exp > 0; exp *= 10)
			{
				RadixSort(tab, exp);
			}
			Wypisz(tab);

			tab = new int[] { 3, 5, 2, 0 };
			Console.WriteLine("Bogo Sort (dla 4 elementów, 10000 prób): ");
			if (BogoSort(tab))
			{
				Console.WriteLine("Udało się!");
			}
			else
			{
				Console.WriteLine("Nie udało się.");
			}
		}
	}
}
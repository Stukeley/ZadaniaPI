using static System.Console;

namespace Tablice2D
{
	internal class Program
	{
		// Ta metoda odpowiada za sumowanie i wypisanie sum poszczególnych wierszy
		private static void SumowanieWierszy(int[,] tab, uint rozmiar)
		{
			int sumaWiersza;

			for (int i = 0; i < rozmiar; i++)
			{
				sumaWiersza = 0;
				for (int j = 0; j < rozmiar; j++)
				{
					sumaWiersza += tab[i, j];
				}
				WriteLine($"Suma wiersza numer {i + 1} wynosi {sumaWiersza}.");
			}
		}

		// Ta metoda odpowiada za sumowanie i wypisanie sum poszczególnych kolumn
		private static void SumowanieKolumn(int[,] tab, uint rozmiar)
		{
			int sumaKolumny;

			for (int i = 0; i < rozmiar; i++)
			{
				sumaKolumny = 0;
				for (int j = 0; j < rozmiar; j++)
				{
					sumaKolumny += tab[j, i];
				}
				WriteLine($"Suma kolumny numer {i + 1} wynosi {sumaKolumny}.");
			}
		}

		// Ta metoda odpowiada za sumowanie i wypisanie sum obu przekątnych
		private static void SumowaniePrzekatnych(int[,] tab, uint rozmiar)
		{
			int sumaPrzekatnej1 = 0, sumaPrzekatnej2 = 0;

			for (int i = 0; i < rozmiar; i++)
			{
				sumaPrzekatnej1 += tab[i, i];
				sumaPrzekatnej2 += tab[i, rozmiar - i - 1];
			}
			WriteLine($"Suma przekatnej [lewy gorny - prawy dolny] wynosi {sumaPrzekatnej1}.");
			WriteLine($"Suma przekatnej [prawy gorny - lewy dolny] wynosi {sumaPrzekatnej2}.");
		}

		// Ta metoda odpowiada za sumowanie połówek uwzględniając obie przekątne
		// suma1Polowki1 - Suma polowki nad przekątną [lewy gorny - prawy dolny]
		// suma2Polowki1 - Suma połówki pod przekątną [lewy górny - prawy dolny]
		// suma1Polowki2 - Suma połówki nad przekątną [prawy górny - lewy dolny]
		// suma2Polowki2 - Suma połówki pod przekątną [prawy górny - lewy dolny]
		private static void SumowaniePolowek(int[,] tab, uint rozmiar)
		{
			int suma1Polowki1 = 0, suma2Polowki1 = 0, suma1Polowki2 = 0, suma2Polowki2 = 0;

			for (int i = 0; i < rozmiar; i++)
			{
				for (int j = 0; j < rozmiar; j++)
				{
					if (j > i)
					{
						suma1Polowki1 += tab[i, j];
					}
					if (j < i)
					{
						suma2Polowki1 += tab[i, j];
					}
					if (j < rozmiar - i - 1)
					{
						suma1Polowki2 += tab[i, j];
					}
					if (j > rozmiar - i - 1)
					{
						suma2Polowki2 += tab[i, j];
					}
				}
			}

			WriteLine($"Suma polowki nad przekątną [lewy gorny - prawy dolny] wynosi {suma1Polowki1}.");
			WriteLine($"Suma połówki pod przekątną [lewy górny - prawy dolny] wynosi {suma2Polowki1}.");

			WriteLine($"Suma połówki nad przekątną [prawy górny - lewy dolny] wynosi {suma1Polowki2}.");
			WriteLine($"Suma połówki pod przekątną [prawy górny - lewy dolny] wynosi {suma2Polowki2}.");
		}

		private static void Main()
		{
			bool czy, czy2;
			uint rozmiar;

			WriteLine("\nWitamy. Podaj rozmiar N tablicy (musi być ona kwadratowa, czyli NxN):");
			while (!(czy = uint.TryParse(ReadLine(), out rozmiar)))
			{
				WriteLine("Podaj rozmiar, który jest liczbą całkowitą dodatnią!");
			}

			int[,] tablica = new int[rozmiar, rozmiar];

			WriteLine();

			for (int i = 0; i < rozmiar; i++)
			{
				Write($"Wprowadź wiersz ({i + 1}): ");

				for (int j = 0; j < rozmiar; j++)
				{
					while (!(czy2 = int.TryParse(ReadLine(), out tablica[i, j])))
					{
						WriteLine("Podaj poprawną liczbę całkowitą!");
					}
				}
				WriteLine();
			}

			for (int i = 0; i < rozmiar; i++)
			{
				for (int j = 0; j < rozmiar; j++)
				{
					Write($"{tablica[i, j]}" + " ");
				}
				WriteLine();
			}

			WriteLine("\nRozpoczynam sumowanie kolejnych wierszy:");
			SumowanieWierszy(tablica, rozmiar);

			WriteLine("\nRozpoczynam sumowanie kolejnych kolumn:");
			SumowanieKolumn(tablica, rozmiar);

			WriteLine("\nRozpoczynam sumowanie przekatnych:");
			SumowaniePrzekatnych(tablica, rozmiar);

			WriteLine("\nRozpoczynanie sumowania połówek: ");
			SumowaniePolowek(tablica, rozmiar);

		}
	}
}

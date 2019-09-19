using System;

namespace museum
{
	class Program
	{
		static void Main(string[] args)
		{

			// Konstanter
			const string noDoorMessage = "Det finns ingen dörr där";
			// Start tillstånd
			// Vi är i lobbyn
			bool visiting = true;
			bool thereIsAFire = false;
			Random fireStarter = new Random();
			int triesLeftForEscaping = 10;
			int x = 20;
			int y = 1;
			int previousX = x;
			int previousY = y;
			bool doorUp = false;
			bool doorLeft = false;
			bool doorRight = false;
			bool doorDown = false;


			while (visiting)
			{
				int position = x + y;

				// Varna för brand
				if (thereIsAFire)
				{
					Console.WriteLine("🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥🔥");
					triesLeftForEscaping -= 1;

					if (triesLeftForEscaping <= 0)
					{
						Console.WriteLine("Det gick tyvärr inte så bra... försök igen :)");
						return;
					}
				}
				// Potentiellt starta en brand
				else if (9 == fireStarter.Next(0, 10))
				{
					thereIsAFire = true;
				}

				// Alla rum i en switch
				switch (position)
				{
					// Lobbyn
					case 21:
						doorUp = true;
						doorLeft = true;
						doorRight = true;
						doorDown = false;
						Console.WriteLine("Du är i Lobbyn");
						break;
					// Utsidan
					case 20:
						visiting = false;
						Console.WriteLine("Du är i frihet igen!");
						if (thereIsAFire)
						{
							Console.WriteLine("Skönt att den där brandövningen gick bra och så!");
							Console.WriteLine("Du tog dig ut med " + (triesLeftForEscaping) + " försök kvar :)");
						}
						return;
					// Blåa rummet
					case 0:
						doorUp = false;
						doorLeft = false;
						doorRight = false;
						doorDown = true;
						Console.WriteLine("Du är i Blåa rummet");
						break;
					// Röda rummet
					case 1:
						doorUp = true;
						doorLeft = false;
						doorRight = true;
						doorDown = false;
						Console.WriteLine("Du är i Röda rummet");
						break;
					// Gula rummet
					case 11:
						doorUp = false;
						doorLeft = true;
						doorDown = true;
						doorRight = true;
						Console.WriteLine("Du är i Gula rummet");
						break;
					// Svarta rummet
					case 2:
						doorUp = false;
						doorLeft = false;
						doorRight = true;
						doorDown = false;
						Console.WriteLine("Du är i Svarta rummet");
						break;
					// Gröna rummet
					case 12:
						doorUp = true;
						doorLeft = true;
						doorRight = false;
						doorDown = false;
						Console.WriteLine("Du är i Gröna rummet");
						break;

					// Det finns inget rum...
					default:
						throw new Exception("Användaren försökte gå till ett rum som inte finns.");
				}

				// Fråga vilken riktning användaren vill gå...
				Console.WriteLine("Vart vill du gå? [U|N|V|H]");
				string input = Console.ReadLine();

				// Gör inmatningen till bara stora bokstäver
				input = input.ToUpper();

				// Plocka den första bokstaven ur inmatningen
				string direction = input.Substring(0, 1);

				// Spara undan den senaste positionen
				previousX = x;
				previousY = y;

				// Uppdatera positionen
				switch (direction)
				{
					case "U":
						if (!doorUp) { Console.WriteLine(noDoorMessage); break; }
						y = y - 1;
						break;
					case "N":
						if (!doorDown) { Console.WriteLine(noDoorMessage); break; }
						y = y + 1;
						break;
					case "V":
						if (!doorLeft) { Console.WriteLine(noDoorMessage); break; }
						x = x - 10;
						break;
					case "H":
						if (!doorRight) { Console.WriteLine(noDoorMessage); break; }
						x = x + 10;
						break;
				}
			}
		}
	}
}
}

using System;
using System.Linq;

class Program
{
    static string[][] bankoPlade = new string[3][]
    {
        new string[] { "20", "30", "43", "55", "70" },
        new string[] { "4", "14", "33", "44", "67" },
        new string[] { "29", "49", "68", "78", "87" }
    };

    static bool CheckFullRow(string[][] plade) => plade.Any(row => row.All(x => x == "X"));

    static bool CheckTwoFullRows(string[][] plade) => plade.Count(row => row.All(x => x == "X")) >= 2;

    static bool CheckFullPlate(string[][] plade) => plade.All(row => row.All(x => x == "X"));

    static void PrintPlade(string[][] plade)
    {
        Array.ForEach(plade, row => Console.WriteLine(string.Join(" ", row)));
    }

    static void Main()
    {
        string trukketTal;
        bool fuldrække1 = false, fuldrække2 = false, fuldPlade = false;

        do
        {
            Console.Clear();
            PrintPlade(bankoPlade);
            Console.WriteLine("Indtast et tal (eller 'exit' for at afslutte):");
            trukketTal = Console.ReadLine();

            if (trukketTal == "exit")
            {
                break;
            }

            // Gennemgå bankopladerne og marker det trukne tal med "X"
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (bankoPlade[i][j] == trukketTal)
                    {
                        bankoPlade[i][j] = "X";
                    }
                }
            }

            // Resten af koden for at tjekke fulde rækker og plade (som tidligere)

        } while (!(fuldrække1 || fuldrække2 || fuldPlade));

        Console.WriteLine("Spillet er slut!");
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Megasena
{
    public static class MegasenaExecutor
    {
        public static void Run(int qtdJogos)
        {
            var fileDB = Path.GetTempFileName();
            var trainningDataset = Path.Combine(Environment.CurrentDirectory, "Megasena/MegaSenaDataSet.txt");
            List<String> predictResults = new List<string>();

            try
            {               
                using (FileStream fs = File.OpenWrite(fileDB))
                {
                    File.OpenRead(trainningDataset).CopyTo(fs);
                }

                MegasenaListResult dbl = null;

                if (MegasenaPredictor.CreateDatabase(fileDB, out dbl))
                {
                    for (int i = 0; i < qtdJogos; i++)
                    {
                        predictResults.Add(MegasenaPredictor.TrainModel(dbl));
                    }

                    Console.WriteLine("\n\n================================================================");
                    Console.Write("          Algoritmo Preditivo de Números da MegaSena\n                Made with");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" S2 ");
                    Console.ResetColor();
                    Console.Write("by Rodrigo Abib\n");
                    Console.WriteLine("================================================================\n\n");

                    int jogo = 1;

                    foreach (var predict in predictResults)
                    {
                        Console.WriteLine("Jogo " + jogo.ToString().PadLeft(2, '0') + "   ---   " + predict.Replace(",", " - "));
                        jogo++;
                    }

                    Console.ReadLine();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
            finally
            {
                File.Delete(fileDB);
            }
        }
    }
}
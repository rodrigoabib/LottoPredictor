using System;
using System.Collections.Generic;
using System.IO;

namespace LotoFacil
{
    public static class LotoFacilExecutor
    {
        public static void Run()
        {
            var fileDB = Path.GetTempFileName();
            var trainningDataset = Path.Combine(Environment.CurrentDirectory, "LotoFacil/LotoFacilDataSet.txt");
            List<String> predictResults = new List<string>();

            try
            {               
                using (FileStream fs = File.OpenWrite(fileDB))
                {
                    File.OpenRead(trainningDataset).CopyTo(fs);
                }

                LotoFacilListResult dbl = null;

                if (LotoFacilPredictor.CreateDatabase(fileDB, out dbl))
                {
                    for (int i = 0; i < 1; i++)
                    {
                        predictResults.Add(LotoFacilPredictor.TrainModel(dbl));
                    }

                    Console.WriteLine("\n\n================================================================");
                    Console.Write("          Algoritmo Preditivo de Números da Lotofácil\n                Made with");
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Encog.Engine.Network.Activation;
using Encog.ML.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using System.CodeDom.Compiler;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Linq;
using Megasena;
using LotoFacil;

namespace LottoPredictor
{
    class Program
    {
        static void Main(string[] args)
        {
            var datasetFile = String.Empty;
            Console.WriteLine("Qual jogo deseja rodar?\n");
            Console.WriteLine("=======================\n");
            Console.WriteLine("1 - Megasena\n");
            Console.WriteLine("2 - LotoFácil\n");
            var opt = Console.ReadLine();

            if(opt == "1")
            {
                Console.WriteLine("Qual dataset deseja usar?\n");
                Console.WriteLine("=======================\n");
                Console.WriteLine("1 - MegaSenaDataSet (old)\n");
                Console.WriteLine("2 - MegaSenaDataSetUnsorted\n");
                Console.WriteLine("3 - MegaSenaDataSetUnsortedNoZeros\n");
                var optDataset = Convert.ToInt32(Console.ReadLine());
                
                switch (optDataset)
                {
                    case 1:
                        datasetFile = "MegaSenaDataSet_old.txt";
                        break;
                    case 2:
                        datasetFile = "MegaSenaDataSetUnsortedNoZeros.txt";
                        break;
                    case 3:
                        datasetFile = "MegaSenaDataSetUnsorted.txt";
                        break;
                }
            }
            
            Console.WriteLine("Qual a profundidade da rede neural? (default: 20)\n");
            var deepness = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nQuantos jogos deseja rodar?\n");
            var qtdJogos = Convert.ToInt32(Console.ReadLine());
            

            switch (opt)
            {
                case "1":
                    MegasenaExecutor.Run(qtdJogos, datasetFile, deepness);
                    break;
                case "2":
                    LotoFacilExecutor.Run(qtdJogos);
                    break;
            }
        }   
    }
}
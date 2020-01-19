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
            Console.WriteLine("Qual jogo deseja rodar?\n");
            Console.WriteLine("=======================\n");
            Console.WriteLine("1 - Megasena\n");
            Console.WriteLine("2 - LotoFácil\n");
            var opt = Console.ReadLine();
            Console.WriteLine("\nQuantos jogos deseja rodar?\n");
            var qtdJogos = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case "1":
                    MegasenaExecutor.Run(qtdJogos);
                    break;
                case "2":
                    LotoFacilExecutor.Run(qtdJogos);
                    break;
            }
        }   
    }
}
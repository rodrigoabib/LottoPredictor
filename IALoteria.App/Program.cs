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
            //MegasenaExecutor.Run();
            LotoFacilExecutor.Run();
        }   
    }
}
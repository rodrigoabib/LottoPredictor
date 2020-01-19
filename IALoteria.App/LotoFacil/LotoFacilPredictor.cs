using System;
using System.IO;
using System.Linq;
using Encog.Engine.Network.Activation;
using Encog.ML.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation.Resilient;

namespace LotoFacil 
{
    public static class LotoFacilPredictor
    {
        public static bool CreateDatabase(string fileDB, out LotoFacilListResult dbl)
        {
            dbl = new LotoFacilListResult();

            using (var reader = File.OpenText(fileDB))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(' ')[2].Split(',');
                    var res = new LotoFacilResult(
                    int.Parse(values[0]),
                    int.Parse(values[1]),
                    int.Parse(values[2]),
                    int.Parse(values[3]), 
                    int.Parse(values[4]),
                    int.Parse(values[5]),
                    int.Parse(values[6]),
                    int.Parse(values[7]),
                    int.Parse(values[8]), 
                    int.Parse(values[9]),
                    int.Parse(values[10]),
                    int.Parse(values[11]),
                    int.Parse(values[12]),
                    int.Parse(values[13]), 
                    int.Parse(values[14]) 
                    );
                    dbl.Add(res);
                }
            }

            dbl.Reverse();

            return true;
        }

        public static String TrainModel(LotoFacilListResult dbl)
        {
            var deep = 20;
            var network = new BasicNetwork();

            network.AddLayer(new BasicLayer(null, true, 15 * deep));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 14 * 15 * deep));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 15 * 15 * deep));
            network.AddLayer(new BasicLayer(new ActivationLinear(), true, 15));

            network.Structure.FinalizeStructure();

            var learningInput = new double[deep][];

            for (int i = 0; i < deep; ++i)
            {
                learningInput[i] = new double[deep * 15];

                for (int j = 0, k = 0; j < deep; ++j)
                {
                    var idx = 2 * deep - i - j;
                    var data = dbl[idx];
                    learningInput[i][k++] = (double)data.V1;
                    learningInput[i][k++] = (double)data.V2;
                    learningInput[i][k++] = (double)data.V3;
                    learningInput[i][k++] = (double)data.V4;
                    learningInput[i][k++] = (double)data.V5;
                    learningInput[i][k++] = (double)data.V6;
                    learningInput[i][k++] = (double)data.V7;
                    learningInput[i][k++] = (double)data.V8;
                    learningInput[i][k++] = (double)data.V9;
                    learningInput[i][k++] = (double)data.V10;
                    learningInput[i][k++] = (double)data.V11;
                    learningInput[i][k++] = (double)data.V12;
                    learningInput[i][k++] = (double)data.V13;
                    learningInput[i][k++] = (double)data.V14;
                    learningInput[i][k++] = (double)data.V15;
                    
                }
            }

            var learningOutput = new double[deep][];

            for (int i = 0; i < deep; ++i)
            {
                var idx = deep - 1 - i;
                var data = dbl[idx];

                learningOutput[i] = new double[15]
                {
                    (double)data.V1,
                    (double)data.V2,
                    (double)data.V3,
                    (double)data.V4,
                    (double)data.V5,
                    (double)data.V6,
                    (double)data.V7,
                    (double)data.V8,
                    (double)data.V9,
                    (double)data.V10,
                    (double)data.V11,
                    (double)data.V12,
                    (double)data.V13,
                    (double)data.V14,
                    (double)data.V15

                };
            }

            var trainingSet = new BasicMLDataSet(learningInput, learningOutput);
            var train = new ResilientPropagation(network, trainingSet);
            train.NumThreads = Environment.ProcessorCount;

            START:
            network.Reset();

            RETRY:
            var step = 0;
            
            do
            {
                train.Iteration();
                Console.WriteLine("Train Error: {0}", train.Error);
                ++step;
            }
            while (train.Error > 0.001 && step < 20);

            var passedCount = 0;

            for (var i = 0; i < deep; ++i)
            {
                var should = new LotoFacilResult(learningOutput[i]);
                var inputn = new BasicMLData(15 * deep);

                Array.Copy(learningInput[i], inputn.Data, inputn.Data.Length);

                var comput = new LotoFacilResult(((BasicMLData)network.Compute(inputn)).Data);
                var passed = should.ToString() == comput.ToString();

                if (passed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    ++passedCount;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine("{0} {1} {2} {3}",
                should.ToString().PadLeft(17, ' '),
                passed ? "==" : "!=",
                comput.ToString().PadRight(17, ' '),
                passed ? "PASS" : "FAIL");
                Console.ResetColor();
            }

            var input = new BasicMLData(15 * deep);

            for (int i = 0, k = 0; i < deep; ++i)
            {
                var idx = deep - 1 - i;
                var data = dbl[idx];
                input.Data[k++] = (double)data.V1;
                input.Data[k++] = (double)data.V2;
                input.Data[k++] = (double)data.V3;
                input.Data[k++] = (double)data.V4;
                input.Data[k++] = (double)data.V5;
                input.Data[k++] = (double)data.V6;
                input.Data[k++] = (double)data.V7;
                input.Data[k++] = (double)data.V8;
                input.Data[k++] = (double)data.V9;
                input.Data[k++] = (double)data.V10;
                input.Data[k++] = (double)data.V11;
                input.Data[k++] = (double)data.V12;
                input.Data[k++] = (double)data.V13;
                input.Data[k++] = (double)data.V14;
                input.Data[k++] = (double)data.V15;
            }

            var perfect = dbl[0];
            var predict = new LotoFacilResult(((BasicMLData)network.Compute(input)).Data);

            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Predict: {0}", predict);
            Console.ResetColor();

            if (predict.IsOut())
                goto START;
            if ((double)passedCount < (deep * (double)9 / (double)10) ||
                !predict.IsValid())
                goto RETRY;

            //Console.WriteLine("Press any key for close...");
            //Console.ReadKey(true);
            
            return ReturnOrderedPredictResult(predict.ToString());
        }
        
        public static String ReturnOrderedPredictResult(String predict)
        {
            var numbers = predict.Split(',').ToList();
            numbers.Sort();
            string result = string.Empty;
            foreach(var n in numbers)
            {
                result += n + ",";
            }
            return result.Remove(result.LastIndexOf(','));
        }
    }
        
}

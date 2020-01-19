using System;

namespace LotoFacil
{
    public class LotoFacilResult
    {
        public int V1 { get; private set; }
        public int V2 { get; private set; }
        public int V3 { get; private set; }
        public int V4 { get; private set; }
        public int V5 { get; private set; }
        public int V6 { get; private set; }
        public int V7 { get; private set; }
        public int V8 { get; private set; }
        public int V9 { get; private set; }
        public int V10 { get; private set; }
        public int V11 { get; private set; }
        public int V12 { get; private set; }
        public int V13 { get; private set; }
        public int V14 { get; private set; }
        public int V15 { get; private set; }
        
        
        public LotoFacilResult(int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8, int v9, int v10, int v11, int v12, int v13, int v14, int v15)
        {
            V1  = v1;
            V2  = v2;
            V3  = v3;
            V4  = v4;
            V5  = v5;
            V6  = v6;
            V7  = v7;
            V8  = v8;
            V9  = v9;
            V10 = v10;
            V11 = v11;
            V12 = v12;
            V13 = v13;
            V14 = v14;
            V15 = v15;
        }

        public LotoFacilResult(double[] values)
        {
            V1  = (int)Math.Round(values[0]);
            V2  = (int)Math.Round(values[1]);
            V3  = (int)Math.Round(values[2]);
            V4  = (int)Math.Round(values[3]);
            V5  = (int)Math.Round(values[4]);
            V6  = (int)Math.Round(values[5]);
            V7  = (int)Math.Round(values[6]);
            V8  = (int)Math.Round(values[7]);
            V9  = (int)Math.Round(values[8]);
            V10 = (int)Math.Round(values[9]);
            V11 = (int)Math.Round(values[10]);
            V12 = (int)Math.Round(values[11]);
            V13 = (int)Math.Round(values[12]);
            V14 = (int)Math.Round(values[13]);
            V15 = (int)Math.Round(values[14]);
        }

        public bool IsValid()
        {
            return
            V1  >= 1 && V1  <= 25 &&
            V2  >= 1 && V2  <= 25 &&
            V3  >= 1 && V3  <= 25 &&
            V4  >= 1 && V4  <= 25 &&
            V5  >= 1 && V5  <= 25 &&
            V6  >= 1 && V6  <= 25 &&
            V7  >= 1 && V7  <= 25 &&
            V8  >= 1 && V8  <= 25 &&
            V9  >= 1 && V9  <= 25 &&
            V10 >= 1 && V10 <= 25 &&
            V11 >= 1 && V11 <= 25 &&
            V12 >= 1 && V12 <= 25 &&
            V13 >= 1 && V13 <= 25 &&
            V14 >= 1 && V14 <= 25 &&
            V15 >= 1 && V15 <= 25 &&
            V1 != V2 &&
            V1 != V3 &&
            V1 != V4 &&
            V1 != V5 &&
            V1 != V6 &&
            V1 != V7 &&
            V1 != V8 &&
            V1 != V9 &&
            V1 != V10 &&
            V1 != V11 &&
            V1 != V12 &&
            V1 != V13 &&
            V1 != V14 &&
            V1 != V15 &&
            V2 != V3 &&
            V2 != V4 &&
            V2 != V5 &&
            V2 != V6 &&
            V2 != V7 &&
            V2 != V8 &&
            V2 != V9 &&
            V2 != V10 &&
            V2 != V11 &&
            V2 != V12 &&
            V2 != V13 &&
            V2 != V14 &&
            V2 != V15 &&
            V3 != V4 &&
            V3 != V5 &&
            V3 != V6 &&
            V3 != V7 &&
            V3 != V8 &&
            V3 != V9 &&
            V3 != V10 &&
            V3 != V11 &&
            V3 != V12 &&
            V3 != V13 &&
            V3 != V14 &&
            V3 != V15 &&
            V4 != V5 &&
            V4 != V6 &&
            V4 != V7 &&
            V4 != V8 &&
            V4 != V9 &&
            V4 != V10 &&
            V4 != V11 &&
            V4 != V12 &&
            V4 != V13 &&
            V4 != V14 &&
            V4 != V15 &&
            V5 != V6 &&
            V5 != V7 &&
            V5 != V8 &&
            V5 != V9 &&
            V5 != V10 &&
            V5 != V11 &&
            V5 != V12 &&
            V5 != V13 &&
            V5 != V14 &&
            V5 != V15 &&
            V6 != V7 &&
            V6 != V8 &&
            V6 != V9 &&
            V6 != V10 &&
            V6 != V11 &&
            V6 != V12 &&
            V6 != V13 &&
            V6 != V14 &&
            V6 != V15 &&
            V7 != V8 &&
            V7 != V9 &&
            V7 != V10 &&
            V7 != V11 &&
            V7 != V12 &&
            V7 != V13 &&
            V7 != V14 &&
            V7 != V15 &&
            V8 != V9 &&
            V8 != V10 &&
            V8 != V11 &&
            V8 != V12 &&
            V8 != V13 &&
            V8 != V14 &&
            V8 != V15 &&
            V9 != V10 &&
            V9 != V11 &&
            V9 != V12 &&
            V9 != V13 &&
            V9 != V14 &&
            V9 != V15 &&
            V10 != V11 &&
            V10 != V12 &&
            V10 != V13 &&
            V10 != V14 &&
            V10 != V15 &&
            V11 != V12 &&
            V11 != V13 &&
            V11 != V14 &&
            V11 != V15 &&
            V12 != V13 &&
            V12 != V14 &&
            V12 != V15 &&
            V13 != V14 &&
            V13 != V15 &&
            V14 != V15;   
        }

        public bool IsOut()
        {
            return
            !(
            V1 >= 1 && V1 <= 25 &&
            V2 >= 1 && V2 <= 25 &&
            V3 >= 1 && V3 <= 25 &&
            V4 >= 1 && V4 <= 25 &&
            V5 >= 1 && V5 <= 25 &&
            V6 >= 1 && V6 <= 25 &&
            V7 >= 1 && V7 <= 25 &&
            V8 >= 1 && V8 <= 25 &&
            V9 >= 1 && V9 <= 25 &&
            V10 >= 1 && V10 <= 25 &&
            V11 >= 1 && V11 <= 25 &&
            V12 >= 1 && V12 <= 25 &&
            V13 >= 1 && V13 <= 25 &&
            V14 >= 1 && V14 <= 25 &&
            V15 >= 1 && V15 <= 25);
        }

        public override string ToString()
        {
            return string.Format(
            "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
            V1, V2, V3, V4, V5, V6, V7, V8, V9, V10, V11, V12, V13, V14, V15);
        }
    }    
}

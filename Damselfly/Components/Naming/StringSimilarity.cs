using System;

namespace Damselfly.Components.Naming
{
    public static class StringSimilarity
    {
        //public static bool IsValidFilename(string fileName)
        //{
        //    for (var i = 0; i < fileName.Length; i++)
        //    {
        //        var c = fileName[i];

        //        switch (c)
        //        {
        //            case '\x00':

        //                break;
        //        }
        //    }
        //}

        public static int Calculate(string x, string y)
        {
            var score = 0;

            for (var i = 0; i < Math.Min(x.Length, y.Length); i++)
            {
                score += Math.Abs(x[i] - y[i]);
            }

            score += Math.Abs(x.Length - y.Length);

            return score;
        }
    }
}

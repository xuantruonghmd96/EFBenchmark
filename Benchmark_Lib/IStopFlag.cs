using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmark_Lib
{
    public interface IStopFlag
    {
        bool CanStopHere(ICollection<double> array);
    }

    public class GaussianStopFlag : IStopFlag
    {
        public bool CanStopHere(ICollection<double> array)
        {
            int count = array.Count;
            if (count <= 10)
                return false;
            double mean = array.Average();
            double phuongSai = 0;
            foreach (var item in array)
                phuongSai += Math.Pow(item - mean, 2);
            phuongSai /= count - 1;
            double doLechChuan = Math.Sqrt(phuongSai);
            int lech1 = 0, lech2 = 0, lech3 = 0;
            foreach (var item in array)
            {
                if (Math.Abs(item - mean) <= 3 * doLechChuan)
                    lech3++;
                if (Math.Abs(item - mean) <= 2 * doLechChuan)
                    lech2++;
                if (Math.Abs(item - mean) <= 1 * doLechChuan)
                    lech1++;
            }

            if ((lech1 >= (double)count * 68.0 / 100.0)
                && (lech2 >= (double)count * 95.0 / 100.0)
                && (lech3 >= (double)count * 99.7 / 100.0))
                return true;
            else return false;
        }
    }
}

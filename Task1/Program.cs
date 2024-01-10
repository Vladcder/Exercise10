using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] angleParams=new int[3];
            string[] angleParamsNames=new string[3] {"градусы", "минуты", "секунды"};
            for (int i = 0; i< angleParams.Length; i++)
            {
                Console.Write($"Введите {angleParamsNames[i]} ");
                try
                {
                    angleParams[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    return;
                }
            }           
            var angle1 = new Angle(angleParams[0], angleParams[1], angleParams[2]);
            Console.WriteLine("Значение угла в радианах равно "+angle1.ToRadians());
            Console.ReadKey();
        }
    }




    public class Angle
    {
        private int gradus;
        private int min;
        private int sec;
        public int Gradus
        {
            get { return gradus; }
            set
            {
                if (gradus < 0)
                {
                    gradus = 0;
                }
                else if (gradus > 359)
                {
                    gradus = 359;
                }
                else
                {
                    gradus = value;
                }
            }
        }
        public int Min
        {
            get { return min; }
            set
            {
                if (min < 0)
                {
                    min = 0;
                }
                else if (min > 59)
                {
                    min = 59;
                }
                else
                {
                    min = value;
                }
            }
        }
        public int Sec
        {
            get { return sec; }
            set 
            { 
                if (sec<0)
                {
                    sec = 0;
                }
                else if (sec>59)
                {
                    sec = 59;
                }
                else
                {
                    sec = value;
                }
            }
        }
        public Angle(int gradus, int min, int sec)
        {
            this.gradus = gradus;
            this.min = min;
            this.sec = sec;
        }


        public double ToRadians()
        {
            double decimalGradus = gradus + (min + sec / 60d) / 60d;
            double radians=decimalGradus *Math.PI / 180;
            return radians;

        }

    }
}

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
            Angle angle1;
            do
            {
                for (int i = 0; i < angleParams.Length; i++)
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
                angle1 = new Angle(angleParams[0], angleParams[1], angleParams[2]);
                if (!angle1.IsCorrect)
                {
                    Console.WriteLine("Введенные данные не корректны");
                    
                }
            } while (!angle1.IsCorrect);
            
            Console.WriteLine("Значение угла в радианах равно "+angle1.ToRadians());
            Console.ReadKey();
        }
    }




    public class Angle
    {
        private int gradus;
        private int min;
        private int sec;
        public bool IsCorrect { get; private set; }
        public int Gradus
        {
            get { return gradus; }
            set
            {
                if (value < 0|| value > 359)
                {
                    IsCorrect = false;
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
                if (value < 0||value>59)
                {
                    IsCorrect = false;
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
                if (value<0||value>59)
                {
                    IsCorrect = false;
                }
                else
                {
                    sec = value;
                }
            }
        }
        public Angle(int gradus, int min, int sec)
        {
            IsCorrect = true;
            this.Gradus = gradus;
            this.Min = min;
            this.Sec = sec;
        }


        public double ToRadians()
        {
            double decimalGradus = gradus + (min + sec / 60d) / 60d;
            double radians=decimalGradus *Math.PI / 180;
            return radians;

        }

    }
}

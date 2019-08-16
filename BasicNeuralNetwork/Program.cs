using System;
using Pictures;

namespace BasicNeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello git!");

            GrayscalePicture pic = new GrayscalePicture("C:\\Users\\Workspace\\Pictures\\Jedna.png");

            // Test for picture
            for (int i = 0; i < pic.size; i++)
            {
                for (int j = 0; j < pic.size; j++)
                {
                    float val = 0.5f;
                    if (pic.NextValue() > val)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("Done!");

            Console.ReadLine();
        }
    }
}

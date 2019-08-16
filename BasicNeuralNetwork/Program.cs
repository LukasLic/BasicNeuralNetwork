using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Pictures;

namespace BasicNeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello git!");

            List<Dataset> datasets = new List<Dataset>();
            Dataset chosenDataset;

            string workingDirectory = "C:\\Users\\Workspace\\Pictures\\Dataset1";
            DirectoryInfo workingDirectory_info = new DirectoryInfo(workingDirectory);
            foreach(var directory in workingDirectory_info.GetDirectories("LearningSet_*"))
            {
                Console.WriteLine("Dateset found: " + directory.FullName);
                Dataset newDataset = new Dataset(directory.FullName);
                datasets.Add(newDataset);
                Console.WriteLine("Dataset added.");
            }

            Console.WriteLine("All " + 0 + "datasets were added.");
            Console.WriteLine();

            while(true)
            {
                int numberOfDatasets = 0;
                foreach(var dataset in datasets)
                {
                    Console.WriteLine((numberOfDatasets + 1) + "\t...........\t" + dataset.name);
                    numberOfDatasets++;
                }
                Console.WriteLine("Choose dataset 1 - " + numberOfDatasets + " or 0 to quit.");

                int input;
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("ERROR: Console requires integer!");
                    continue;
                }
                
                if(input == 0)
                {
                    Console.WriteLine("No dataset chosen! Ready to quit.");
                    Console.ReadLine();
                    return;
                }
                else if (input > 0 && input <= numberOfDatasets)
                {
                    chosenDataset = datasets.ToArray()[input - 1];
                    break;
                }
                else
                {
                    Console.WriteLine(input + " is NOT correct dataset!");
                }
            }

            Console.WriteLine(chosenDataset.name);
            for (int k = 0; k < chosenDataset.Lenght(); k++)
            {
                GrayscalePicture pic = new GrayscalePicture(chosenDataset.NextValue());
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
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine();
            }

            // Test for picture
            /*
            GrayscalePicture pic = new GrayscalePicture("C:\\Users\\Workspace\\Pictures\\Dataset1\\Jedna.png");
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
            */
            
            Console.WriteLine("Done!");

            Console.ReadLine();
        }
    }
}

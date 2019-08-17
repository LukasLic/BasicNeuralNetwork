using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BasicNeuralNetwork
{
    class Dataset
    {
        public string name;
        public string path_directory;
        private string[] paths_file;
        private int iterator;

        public Dataset(string directory)
        {
            DirectoryInfo dir_info;
            List<string> temp_paths_file = new List<string>();

            if (Directory.Exists(directory))
            {
                dir_info = new DirectoryInfo(directory);
            }
            else
            {
                Console.Beep();
                Console.WriteLine("ERROR: Directory " + directory + " does not exist.");
                return;
            }

            name = dir_info.Name;
            path_directory = directory;
            ResetIterator();

            foreach (var file in dir_info.GetFiles())
            {
                temp_paths_file.Add(file.FullName);
                Console.WriteLine(file.Name + " path was added to " + name);
            }

            paths_file = temp_paths_file.ToArray<string>();
        }

        public void ResetIterator()
        {
            iterator = 0;
        }
        public string NextValue()
        {
            if (iterator >= paths_file.Length)
            {
                iterator = 0;
            }
            return paths_file[iterator++];
        }
        public int Lenght()
        {
            return paths_file.Length;
        }
    }
}

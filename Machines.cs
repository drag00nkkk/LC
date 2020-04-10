using System;
using System.ComponentModel;
using System.IO;

namespace ConsoleApplication1
{
    public class Machines
    {
        public void PrintMachinesSize()
        {
            var folderPaths = Directory.GetDirectories("C:/Project/VideoSlotClient_AssetBundles/Internal/Android/machine");
            foreach (var folderPath in folderPaths)
            {
                var files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
                float len = 0;
                foreach (var filePath in files)
                {
                    FileInfo file = new FileInfo(filePath);
                    len += file.Length;
                }
                
                Console.WriteLine($"Machine {Path.GetFileName(folderPath)} size = {len / 1024 / 1024} MB");
            }
        }
    }
}
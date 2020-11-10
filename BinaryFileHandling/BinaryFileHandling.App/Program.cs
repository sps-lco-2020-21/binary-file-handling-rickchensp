using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BinaryFileHandling.App
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] content = File.ReadAllBytes("sps.bmp");


            Console.ReadKey();

        }
    }
}

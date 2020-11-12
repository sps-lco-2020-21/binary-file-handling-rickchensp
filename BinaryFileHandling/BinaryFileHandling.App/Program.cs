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

            FileSummary();


            Console.ReadKey();

        }


        static void FileSummary()
        {
            byte[] content = File.ReadAllBytes("sps.bmp");
            bool verified = BMPVerify(content);
            
            if(!verified)
            {
                return;
            }

            int image_size = BitConverter.ToInt32(content.Skip(2).Take(4).ToArray(), 0);
            int width = BitConverter.ToInt32(content.Skip(18).Take(4).ToArray(), 0);
            int height = BitConverter.ToInt32(content.Skip(22).Take(4).ToArray(), 0);
            int colour_depth = BitConverter.ToInt16(content.Skip(28).Take(2).ToArray(), 0);
            int horizontal_res = BitConverter.ToInt32(content.Skip(34).Take(4).ToArray(), 0);
            int vertical_res = BitConverter.ToInt32(content.Skip(38).Take(4).ToArray(), 0);

            Console.Write("the image size is {0} {6}\n the width is {1}\n the height is {2}\n the colour depthis {3}\n " +
                "the horizontal resolution is {4}\n the vertical resolution is {5}",
                image_size, width, height, colour_depth, horizontal_res, vertical_res, "bytes");
        }

        static bool BMPVerify(byte[] content)
        {

            int res1 = content[0] ^ (byte)'B';
            int res2 = content[1] ^ (byte)'M';

            if (res1 == 0 && res2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepInjExample
{
    public class Injection1Class
    {
        private static List<byte[]> memoryLeakList = new List<byte[]>();

        public  void AddMemory(int mb=100)
        {
            byte[] data = new byte[1024 * 1024]; // 1 MB
            
            for (int i = 0; i < mb; i++)
            {
                // Simulate adding 1 MB of data to the list
                data = new byte[1024 * 1024]; // 1 MB
                memoryLeakList.Add(data);

                Console.WriteLine($"Total memory allocated: {GC.GetTotalMemory(false) / (1024 * 1024)} MB");
            }

            memoryLeakList.Add(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bufaloserver
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWServerIP ipServer = new IWServerIP(1500);
            IWServerLog logServer = new IWServerLog(3005);

            Thread ipThread = new Thread(new ThreadStart(ipServer.Start));
            Thread logThread = new Thread(new ThreadStart(logServer.Start));

            ipThread.Start();
            logThread.Start();

            Console.Read();
        }
    }
}

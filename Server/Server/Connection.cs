using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms; // For test purposes

namespace Server
{
    class Connection
    {

        //fields

        private static int port_number; 
        // Incoming data from the client.
        private static string data = null;

        private static Socket listener;
        private static Socket handler;

        static private Action ac;
        

        //custom constructor
        public Connection(int port_numb)
        {
           port_number = port_numb;
           ac = new Action();
        }


        //methods
        public void StartListening()
        {
          
            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
           
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port_number);

            // Create a TCP/IP socket.
            listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.
                     handler = listener.Accept();
                     

                    // An incoming connection needs to be processed.
                    byte[] msg = receiveMsg(handler);
                 
                    // process the message
                    processMsg();

                    //respond to client with message
                    respondMsg(handler);
                    

                    //close socket   
                    SocketShutDown(handler);

                    //execute action after the socket is closed
                    pc_action();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();


           

        }

        private static void processMsg()
        {
            //show message in console
            Console.WriteLine("Command received : {0}", data);
            
           
        }

        private void pc_action()
        {
            //action on command
            if (data == "logoff")
            {
                ac.logOff();
            }
            else if (data == "sleep")
            {
                ac.sleep();
            }
            else if (data == "restart")
            {
                ac.restart();
            }
            else if (data == "shutdown")
            {
                ac.shutDown();
            }


        }

        private static void respondMsg(Socket handler)
        {
            // Echo the data back to the client.
           byte[] msg = Encoding.ASCII.GetBytes("command OK");
           handler.Send(msg);


        }

        private static void SocketShutDown(Socket handler)
        {

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        private static byte[] receiveMsg(Socket handler)
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];
            data = null;

            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            data = data.Replace("<EOF>", ""); // remove the EOF to get the text
            return bytes;
        }
     
        //--------------------------------------
    }
}

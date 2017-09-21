using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // For test purposes

namespace Client
{
    class Connection
    {
        //fields 
       static private int port;
       static private IPAddress ipAddress;
       static private IPEndPoint remoteEP;

       Socket sender;
       string action = "sleep"; // default action
     
      static private byte[] bytes = new byte[1024];  // Data buffer for incoming data.

       //custom constructor
        public Connection(string ip_address, int port_number, string a)
        {
            
              port = port_number;
              IPAddress temp;
              bool check_ip = IPAddress.TryParse(ip_address, out temp);

              //check ip address parsed
              if (check_ip)
              {
                  ipAddress = temp;
                  action = a;
            

              }
              else
              {
                  return; //the ip address is wrong

              }

             

        }

        //methods
        public void StartClient() {
       
       // Connect to a remote device.
        try {
            // Establish the remote endpoint for the socket.
            // This example uses port 11000 on the local computer.
            remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP  socket.
            sender = new Socket(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp );

            // Connect the socket to the remote endpoint. Catch any errors.
            try {
                sender.Connect(remoteEP);

                 Console.WriteLine("Socket connected to {0}",
                    sender.RemoteEndPoint.ToString());

                // Send the data through the socket.
                 sendMsg(sender, action);
               

                // Receive the response from the remote device.
                 receiveMsg(sender);

                // Release the socket.
                 SocketShutDown(sender);
               

            } catch (ArgumentNullException ane) {
                Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
                MessageBox.Show("ArgumentNullException.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (SocketException se) {
                Console.WriteLine("SocketException : {0}",se.ToString());
                MessageBox.Show("SocketException.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception e) {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
                MessageBox.Show("Unexpected exception.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        } catch (Exception e) {
            Console.WriteLine( e.ToString());
        }
    }

        private void sendMsg(Socket s, string message)
        {
            string endofstring = "<EOF>";
            // Encode the data string into a byte array.
            byte[] msg = Encoding.ASCII.GetBytes((message + endofstring));
            int bytesSent = s.Send(msg);

        }

        private void receiveMsg(Socket s)
        {

            int bytesRec = s.Receive(bytes);
            Console.WriteLine("Received = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));

            //notify user that the command was received by the server
            if(bytesRec > 0)
                MessageBox.Show("Command received by server", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBox.Show("No response from server", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void SocketShutDown(Socket s)
        {
            s.Shutdown(SocketShutdown.Both);
            s.Close();

        }

    
        //-------------------------------------------------
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;


namespace Client
{
    public partial class Form1 : Form
    {

        Connection con; //used to connect with the server 

        public Form1()
        {
            InitializeComponent();
            txtAddress.Text = "192.168.0.";
            txtPort.Text = "11000";
        }

        

        private void btnConnect_Click(object sender, EventArgs e)
        {

            //check network available
            bool b = checkNetowrkAvailable();
            if (!b)
            {
                MessageBox.Show("No network connection.","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

            }

         
            //validation of address & port
            if (!(string.IsNullOrEmpty(txtPort.Text) || string.IsNullOrEmpty(txtAddress.Text)))
            {
                //check port
                int port;
                bool check_port = int.TryParse(txtPort.Text, out port);
                //check ip address
                string pattern = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"; //Accurate regex to check for an IP address
                string ip_address = txtAddress.Text;
                Regex regex = new Regex(pattern);
                Match match = regex.Match(ip_address);

                //get the action from user
                string action = "sleep";
                if(rbLogoff.Checked)
                    action = "logoff";
                else if(rbRestart.Checked)
                    action = "restart";
                else if(rbShutdown.Checked)
                    action = "shutdown";
                else if(rbSleep.Checked)
                    action = "sleep";
                 
                //check port & ip address format, and the range of port 
                if (check_port && match.Success && (port >=0 && port <= 65536))
                {
                    //start the client
                    con = new Connection(ip_address, port, action);
                   con.StartClient();
         
                  

                }
                else
                {
                    MessageBox.Show("Invalid port/port range/ip address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private bool checkNetowrkAvailable()
        {

            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

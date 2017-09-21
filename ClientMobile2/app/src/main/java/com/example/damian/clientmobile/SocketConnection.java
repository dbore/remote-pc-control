package com.example.damian.clientmobile;

import android.app.Activity;
import android.content.Context;
import android.os.AsyncTask;
import android.os.StrictMode;
import android.util.Log;
import android.widget.Toast;

import java.io.Console;
import java.io.InputStream;
import java.net.InetAddress;
import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.SocketAddress;
import java.net.SocketException;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;


/**
 * Created by Damian on 23/10/2016.
 */
 public class SocketConnection implements Runnable {

    //fields

    private int port;
    private String ip_address;
    private String action = "sleep"; // default action

    private Socket sock;
    private Context c;
    private Activity act;

    private byte[] bytes = new byte[1024];  // Data buffer for incoming data.

    //custom constructor
    public SocketConnection(String ip_address, int port_number, String a, Context context, Activity act) {

        this.ip_address = ip_address;
        this.port = port_number;
        this.action = a;

        this.c = context;
        this.act = act;

        //runing internet/socket should be on different thread - this code bellow ensures
        //that the app uses one thread but the app can crash as the result of that
        //StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        //StrictMode.setThreadPolicy(policy);

    }

    //methods
    public void StartClient() {

        // Connect to a remote device.
        try {

            sock = null;

            // Create a socket.

            //tests
            //Log.e("Test: ", this.ip_address.toString() );
            //Log.e("Test: ", String.valueOf(this.port));

            //sock = new Socket(this.ip_address, this.port); // if you use this do not use sock.connect as this already connects
            sock = new Socket();

            // Connect the socket to the remote endpoint. Catch any errors.
            try {
                //endpoint address
                SocketAddress sockaddr = new InetSocketAddress(this.ip_address, this.port);
                //Log.e("Test: ", sockaddr.toString());

                sock.connect(sockaddr);

                Log.e("Information: ", "Socket connected to " + sockaddr.toString());


                // Send the data through the socket.
                sendMsg(sock, action);


                // Receive the response from the remote device.
                receiveMsg(sock);

                // Release the socket.
                SocketShutDown(sock);


            } catch (IllegalArgumentException ane) {
                //Toast.makeText(c.getApplicationContext(), "ERROR: IllegalArgumentException.", Toast.LENGTH_SHORT).show();
                act.runOnUiThread(new Runnable() {
                    public void run() {

                        Toast.makeText(c.getApplicationContext(), "ERROR: IllegalArgumentException.", Toast.LENGTH_SHORT).show();
                    }
                });
            } catch (SocketException se) {
                //Toast.makeText(c.getApplicationContext(), "ERROR: SocketException.", Toast.LENGTH_SHORT).show();
                act.runOnUiThread(new Runnable() {
                    public void run() {

                        Toast.makeText(c.getApplicationContext(), "ERROR: SocketException.", Toast.LENGTH_SHORT).show();
                    }
                });
            } catch (Exception e) {
                //Toast.makeText(c.getApplicationContext(), "ERROR: Exception.", Toast.LENGTH_SHORT).show();
                act.runOnUiThread(new Runnable() {
                    public void run() {

                        Toast.makeText(c.getApplicationContext(), "ERROR: Exception.", Toast.LENGTH_SHORT).show();
                    }
                });
            }

        } catch (Exception e) {
            //Toast.makeText(c.getApplicationContext(), "ERROR", Toast.LENGTH_SHORT).show();
            act.runOnUiThread(new Runnable() {
                public void run() {

                    Toast.makeText(c.getApplicationContext(), "ERROR", Toast.LENGTH_SHORT).show();
                }
            });
            Log.e("Error: ", e.toString());
        }
    }


    private void sendMsg(Socket s, String message) {
        String endofstring = "<EOF>";
        // Encode the data string into a byte array.
        message = message + endofstring;
        //byte[] msg = message.getBytes(StandardCharsets.US_ASCII);
        byte[] msg = message.getBytes(Charset.forName("UTF-8"));

        try {
            s.getOutputStream().write(msg);
        } catch (Exception e) {
            //Toast.makeText(c.getApplicationContext(), "ERROR: Cannot Send Msg.", Toast.LENGTH_SHORT).show();
            act.runOnUiThread(new Runnable() {
                public void run() {

                    Toast.makeText(c.getApplicationContext(), "ERROR: Cannot Send Msg.", Toast.LENGTH_SHORT).show();
                }
            });
        }
    }

    private void receiveMsg(Socket s) {
        String error_msg = "Cannot read response from server.";
        try {
            InputStream in = null;
            try {
                in = s.getInputStream();
            } catch (Exception e) {
                Log.e("ERROR: ", error_msg);
            }

            //read to buffer
            int count;
            while ((count = in.read(bytes)) > 0) {
            }

            if (count <= 0) {
               final String msg = new String(bytes, "UTF-8"); // for UTF-8 encoding
                //Toast.makeText(c.getApplicationContext(), msg, Toast.LENGTH_SHORT).show();
                act.runOnUiThread(new Runnable() {
                    public void run() {

                        Toast.makeText(c.getApplicationContext(), msg, Toast.LENGTH_SHORT).show();
                    }
                });
            }


        } catch (Exception ex) {
            Log.e("ERROR: ", error_msg);
        }


    }


    private void SocketShutDown(Socket s) {
        try {
            s.shutdownInput();
            s.shutdownOutput();
            s.close();
        } catch (Exception e) {
            Log.e("ERROR: ", "Cannot close socket.");
        }


    }

    @Override
    public void run() {
        StartClient();
    }


    //------------------------------------------
}


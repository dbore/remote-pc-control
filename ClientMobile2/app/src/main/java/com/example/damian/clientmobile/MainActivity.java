package com.example.damian.clientmobile;

import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.net.ConnectivityManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RelativeLayout;
import android.widget.Toast;

import java.net.HttpURLConnection;
import java.net.URL;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class MainActivity extends AppCompatActivity {

    private String ipAddress;
    private int portNumber;

    private Pattern pattern; // used for regex to validate ip address
    private Matcher matcher;
    private static final String IPADDRESS_PATTERN =
            "^([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
                    "([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
                    "([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\." +
                    "([01]?\\d\\d?|2[0-4]\\d|25[0-5])$";

    //store the option information
    private String action = "sleep";

    private SocketConnection con; //used to connect with the server


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //set background color in main activity
        RelativeLayout rl = (RelativeLayout)findViewById(R.id.activity_main);
        rl.setBackgroundColor(Color.argb(255, 255, 204, 0));

        //get values of edittext such as the ip address and port number
        final EditText mEdit_ipAddress   = (EditText)findViewById(R.id.ip_address);
        final EditText mEdit_portNumber   = (EditText)findViewById(R.id.port_number);

        //set the background colors of edittext
        //mEdit_ipAddress.getBackground().setColorFilter(Color.GREEN, PorterDuff.Mode.SRC_ATOP);


        //connect&send event handler
        final Button button = (Button) findViewById(R.id.connect);
        button.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                // Perform action on click

                //check internet connection first
                boolean is_network = isNetworkConnected();
                if(!is_network) {
                    Toast.makeText(getApplicationContext(), "ERROR: No internet connection.", Toast.LENGTH_SHORT).show();
                    return; //no internet connection
                }

                //validation of address & port
                if (!(isNullOrEmpty(mEdit_portNumber.getText().toString()) || isNullOrEmpty(mEdit_ipAddress.getText().toString())))
                {
                    //check port
                    boolean check_port = tryParseInt(mEdit_portNumber.getText().toString());
                    int port;

                    if(check_port)
                        port = Integer.parseInt(mEdit_portNumber.getText().toString());
                    else
                        port = -1;

                    //check ip address
                    IPAddressValidator();
                     boolean correct_ip_address =  validate(mEdit_ipAddress.getText().toString());


                    //check port & ip address format, and the range of port
                    if (check_port && correct_ip_address && (port >=0 && port <= 65536))
                    {
                        //the correct values, validated and sanitized
                        ipAddress = mEdit_ipAddress.getText().toString();
                        portNumber = port;

                        //start the client
                         //con = new SocketConnection(ipAddress, portNumber, action, getApplicationContext());
                         //con.StartClient();
                        Thread cThread = new Thread(new SocketConnection(ipAddress, portNumber, action, getApplicationContext(), MainActivity.this));
                        cThread.start();


                    }
                    else
                    {

                        Toast.makeText(getApplicationContext(), "Invalid port/port range/ip address.", Toast.LENGTH_SHORT).show();
                        return;
                    }
                }
                else
                {

                    Toast.makeText(getApplicationContext(), "Invalid input", Toast.LENGTH_SHORT).show();
                    return;
                }

            }
        });
    }

    //use regex to validate ip address
    public void IPAddressValidator(){
        pattern = Pattern.compile(IPADDRESS_PATTERN);
    }

    /**
     * Validate ip address with regular expression
     * @param ip ip address for validation
     * @return true valid ip address, false invalid ip address
     */
    public boolean validate(final String ip){
        matcher = pattern.matcher(ip);
        return matcher.matches();
    }


    //text validation & verification
//---------------------------------------------------------
    boolean tryParseInt(String value) {
        try {
            Integer.parseInt(value);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }


    public static boolean isNullOrEmpty(String s) {
        return s == null || s.length() == 0;
    }

    public static boolean isNullOrWhitespace(String s) {
        return s == null || isWhitespace(s);

    }
    private static boolean isWhitespace(String s) {
        int length = s.length();
        if (length > 0) {
            for (int i = 0; i < length; i++) {
                if (!Character.isWhitespace(s.charAt(i))) {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
    //---------------------------------------------------

    //radio buttons event handler
    public void onRadioButtonClicked(View view) {
        // Is the button now checked?
        boolean checked = ((RadioButton) view).isChecked();

        // Check which radio button was clicked
        switch(view.getId()) {
            case R.id.radio_sleep:
                if (checked)
                    // sleep checked
                    action = "sleep";
                    break;
            case R.id.radio_logoff:
                if (checked)
                    // log off checked
                    action = "logoff";
                    break;
            case R.id.radio_restart:
                if (checked)
                    // restart checked
                    action = "restart";
                    break;
            case R.id.radio_shutdown:
                if (checked)
                    // shut down checked
                    action = "shutdown";
                    break;

        }
    }

    public void ExitApp(View view){

        Log.e("Information: ", "Exit application");
        this.finishAffinity(); // exits all activities but requires api >=16

    }

    //check internet connection
    private boolean isNetworkConnected() {
        ConnectivityManager cm = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);

        return cm.getActiveNetworkInfo() != null;
    }



}

# remote pc control

It is a collection of server and two client applications. The server application needs to run on the system you want to control remotely.  The communication between the server and the client is achieved by using network sockets. The client sends a special command which the server interprets and does certain action depending on the command sent.  The server is responsible for the power state of the controlled machine.  The controlled machine can be forced to shut down, log off, restart or sleep. The client application comes in a PC and android version. 

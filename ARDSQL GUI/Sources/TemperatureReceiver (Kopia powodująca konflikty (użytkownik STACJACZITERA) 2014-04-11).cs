﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
namespace ARDSQL_GUI
{
    /// <summary>
    /// Implementacja serwera odbierającego
    /// </summary>
    class TemperatureReceiver
    {
        /// <summary>
        /// Konstruktor który uruchamia serwer
        /// </summary>
        /// <param name="port">Port na którym serwer powstanie</param>
        public TemperatureReceiver(int port, string ip)
        {
            try
            {
                this.port = port;
                this.serverAddr = IPAddress.Parse(ip); // przypisanie IP
                receiverListener = new TcpListener(serverAddr, this.port); //uruchomienie portu
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }
        /// <summary>
        /// Adres IP serwera
        /// </summary>
        IPAddress serverAddr;
        /// <summary>
        /// Otrzymane dane
        /// </summary>
        private int recv;
        /// <summary>
        /// Dane..?
        /// </summary>
        private byte[] data = new byte[1024];
        /// <summary>
        /// Nasłuchiwanie na protokole TCP
        /// </summary>
        TcpListener receiverListener;
        /// <summary>
        /// Port na którym działa serwer.
        /// </summary>
        private int port = 0;
        /// <summary>
        /// Maksymalna ilość połączeń do serwera
        /// </summary>
        private int maxConnectionsToServer = 0;
        /// <summary>
        /// Czy serwer wystartowal
        /// </summary>
        Boolean isServerStarted = false;
        /// <summary>
        /// Wystartowanie serwera
        /// </summary>
        /// <param name="maxConnections">Maksymalna ilość połączeń do serwera</param>
        public void startServer(int maxConnections)
        {
            /*
             * TODO: Zmienic flaki serwera. Pobrać adres z broadcastu a potem go przypisać
             */
            if (this.isServerStarted == false)
            {
                maxConnectionsToServer = maxConnections;
                receiverListener.Start(maxConnectionsToServer);
                Console.WriteLine("Server started... on {0}", this.receiverListener.LocalEndpoint);
                isServerStarted = true;
                String testIP = Console.ReadLine(); //do wywalenia potem
                IPAddress target = IPAddress.Parse(testIP);
                if(target.AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString())
                {
                    ///nothing here...
                }else
                {
                    Console.WriteLine("Entered IP is not from local network...");
                }
                Ping pingSender = new Ping();
                PingReply pingReply = pingSender.Send(target);
                if (pingReply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Ping Done. Netrunner is online. Starting data exchange.");
                }
                else
                {
                    Console.WriteLine("Ping Done. Did not receive ping response. Check that Netrunner is online. \n Shutting down server.");
                    try
                    {
                        receiverListener.Stop();
                        isServerStarted = false;
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Server is already started...");
            }
           
        }
    }
}

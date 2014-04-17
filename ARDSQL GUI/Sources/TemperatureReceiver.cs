using System;
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
        /// <param name="ip">Adres serwera na którym stoi</param>
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
        /// Konstruktor który uruchamia serwer
        /// </summary>
        /// <param name="port">Port na którym serwer powstanie</param>
        public TemperatureReceiver(int port)
        {
            try
            {
                this.port = port;
                this.serverAddr = IPAddress.Any; // przypisanie IP
                receiverListener = new TcpListener(serverAddr, this.port); //uruchomienie portu
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        /// <summary>
        /// Nazwa hosta serwera
        /// </summary>
        String serverHostName = "";
        /// <summary>
        /// Adres IP serwera
        /// </summary>
        IPAddress serverAddr = null;
        /// <summary>
        /// Otrzymane dane
        /// </summary>
        /// 
        private int recv;
        /// <summary>
        /// Dane..?
        /// </summary>
        private byte[] data = new byte[1024];
        /// <summary>
        /// Nasłuchiwanie na protokole TCP
        /// </summary>
        private TcpListener receiverListener;
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
        private Boolean isServerStarted = false;
        /// <summary>
        /// Ilość otrzymanych danych
        /// </summary>
        int amountOfReceivedData = 0;
        /// <summary>
        /// Network stream który obierze dane
        /// </summary>
        //  private NetworkStream serverRecvstream;
        /// <summary>
        /// Endpoint serwera
        /// </summary>
        private EndPoint receiverEndpoint;
        /// <summary>
        /// Bufor serwera
        /// </summary>
        private Byte[] buffer = new Byte[100];
        /// <summary>
        /// Adres klienta
        /// </summary>
        private IPAddress clientTemp = IPAddress.Parse("192.168.1.4");
        /// <summary>
        /// "Wysyłacz" ICMP pingów
        /// </summary>
        private Ping pingSender = new Ping();
        /// <summary>
        /// Przechowuje odpowiedź serwera
        /// </summary>
        private PingReply pingReply;
        /// <summary>
        /// Wystartowanie serwera
        /// </summary>
        /// <param name="maxConnections">Maksymalna ilość połączeń do serwera</param>
        public void startServer(int maxConnections)
        {
            /*
             * TODO: Dodac try...catch, wywalić rzeczy i dodać do pól klasy.
             */
            if (this.isServerStarted == false)
            {
                /// <summary>
                /// Socket serwera.
                /// </summary>
                Socket serverSocket;
                maxConnectionsToServer = maxConnections;
                receiverListener.Start(maxConnectionsToServer);
                Console.WriteLine("Starting server...");
                Console.WriteLine("Server started... on {0}", this.serverAddr.ToString());
                isServerStarted = true;
                Console.WriteLine("Sending Ping request to Netrunner...");
                pingReply = pingSender.Send(clientTemp);
                if (pingReply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Ping done. Netrunner is online. Starting data Exchange...");
                    Console.WriteLine("Waiting for connection...");
                    serverSocket = receiverListener.AcceptSocket();
                    if(serverSocket.Connected == true)
                    {
                        Console.WriteLine("Connected! Waiting for data...");
                        amountOfReceivedData = serverSocket.Receive(buffer);
                        Console.WriteLine("Received data: ");
                        for(int i = 0; i < buffer.Length; i++)
                        {
                            Console.Write(buffer[i]);
                            if(buffer[i] == 0)
                            {
                                Console.Write("\n Done receiving data. Closing server...");
                                break;
                            }
                        }
                        
                    }

                }
                else
                {
                    Console.WriteLine("Ping Done. Netrunner is offline. Check that Netrunner is connected to\n PC, using cross-over cable.");
                    Console.WriteLine("Closing server...");
                    isServerStarted = false;
                    receiverListener.Stop();
                }
            }
            else
            {
                Console.WriteLine("Server is already started...");
            }
            Console.WriteLine("Closing server...");
            isServerStarted = false;
            receiverListener.Stop();
        }
    }
}

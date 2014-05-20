using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Collections.Generic;
namespace ARDSQL_GUI
{
    /// <summary>
    /// Implementacja serwera odbierającego
    /// </summary>
    class TemperatureReceiver
        :
            public SQLCon
    {
        /// <summary>
        /// Konstruktor który uruchamia serwer
        /// </summary>
        /// <param name="port">Port na którym serwer powstanie</param>
        /// <param name="ip">Adres serwera na którym stoi</param>
        /// <param name="clientIP">Adres klienta.</param>
        public TemperatureReceiver(int port, string ip, string clientIP)
        {
            this.clientIpString = clientIP;
            this.clientIP = IPAddress.Parse(this.clientIpString);
            populateResponses(); //wypełnianmy odpowiedzi
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
        /// Kontruktor ładujący konfigurację klient'a i serwera z pliku Server.conf.
        /// </summary>
        /// <param name="port">Port na którym będzie stał.</param>
        public TemperatureReceiver(int port)
        {
            programIps = serverConf.getConfigurationIp();
            try
            {
                this.clientIP = IPAddress.Parse(programIps[0]);
                populateResponses(); //wypełnianmy odpowiedzi
                this.port = port;
                this.serverAddr = IPAddress.Parse(programIps[1]); // przypisanie IP
                receiverListener = new TcpListener(serverAddr, this.port); //uruchomienie portu
                foreach (string a in this.programIps)
                {
                    Console.Write("Read Ips: ");
                    Console.WriteLine(a);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        /// <summary>
        /// Configuracja serwera
        /// </summary>
        Configuration serverConf = new Configuration("Conf/Server.conf");
        /// <summary>
        /// Przetwarza dane odebrane od metody startServer
        /// </summary>
        /// <returns>Zwraca obiekt temperatury</returns>
        public Temperature processData()
        {
            this.writeBuffer.Clear();
            this.receivedData.Clear(); //Oczyszczanko uszanowanko - przypis Domy :D
           //this.receiverResponser = new TcpClient(this.clientIP, 134);
            Console.Write("Received data: ");
            for (int i = 0; i < recvBuffer.Length; i++)
            {
                if (recvBuffer[i] == 0)
                {
                    break;
                }
                writeBuffer.Add(recvBuffer[i]);
            }
            String temp = System.Text.Encoding.UTF8.GetString(writeBuffer.ToArray()); //konwersja na String z byte
            Console.WriteLine(temp);
            Console.Write("Done receiving data.");

            Console.WriteLine("Remembering received data.");
            receivedData.Add(temp);
            response(); //odpowiadamy
            return new Temperature();
        }
        /// <summary>
        /// Odpowiedź na dane do odczytu
        /// </summary>
        public void response()
        {
            if(receivedData[0] == responses[0])
            {
                Console.WriteLine("{0}.Preparing for data receive...", responses[0]);

            }
            else
            {
                Console.WriteLine("No known responses.");
            }
        }
        List<String> programIps = new List<String>();
        /// <summary>
        /// Bufor zapisu
        /// </summary>
        List<Byte> writeBuffer = new List<Byte>();
        /// <summary>
        /// Otrzymane dane.
        /// </summary>
        List<String> receivedData = new List<String>();
        /// <summary>
        /// Możliwe odpowiedzi
        /// </summary>
        List<String> responses = new List<string>();
        /// <summary>
        /// Wypełnienie listy odpowiedziami
        /// </summary>
        private void populateResponses()
        {
            responses.Add("RDY");
            responses.Add("DATA");
            responses.Add("END");
        }
        /// <summary>
        /// Adres IP serwera
        /// </summary>
        IPAddress serverAddr;
        /// <summary>
        /// Dane..?
        /// </summary>
        private byte[] data = new byte[5];
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
        /// Bufor serwera
        /// </summary>
        private Byte[] recvBuffer = new Byte[100];
        /// <summary>
        /// String adresu IP.
        /// </summary>
        private string clientIpString = "";
        /// <summary>
        /// Adres klienta
        /// </summary>
        private IPAddress clientIP;
        /// <summary>
        /// "Wysyłacz" ICMP pingów
        /// </summary>
        private Ping pingSender = new Ping();
        /// <summary>
        /// Przechowuje odpowiedź serwera
        /// </summary>
        private PingReply pingReply;
        /// <summary>
        /// Odbieracz i wysyłacz.
        /// </summary>
        NetworkStream receiverStream;
        /// <summary>
        /// Wystartowanie serwera
        /// </summary>
        /// <param name="maxConnections">Maksymalna ilość połączeń do serwera</param>
        /// <returns>Zwraca kod błędu
        /// 0 - all ok
        /// 1 - nie mozna wystartowac serwera
        /// 2 - nie mozna wyslac pingu
        /// 3 - nie mozna pobrac danych
        /// 4 - ping wysłany, ale nie doszedł
        /// </returns>
        public int startServer(int maxConnections)
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
                Console.WriteLine("Starting server...");
                maxConnectionsToServer = maxConnections;
                try
                {
                    receiverListener.Start(maxConnectionsToServer);
                    isServerStarted = true;  
                }catch(Exception e)
                {
                    isServerStarted = false;
                    Console.WriteLine("Cannot start server..." + e.ToString());
                    return 1;
                }
                Console.WriteLine("Server started... on {0}", this.serverAddr.ToString());
                Console.WriteLine("Sending Ping request to Netrunner...");
                try
                {
                    pingReply = pingSender.Send(clientIP);
                }catch(Exception e)
                {
                    Console.WriteLine("Cannot send ping..." + e.ToString());
                    return 2;
                }
                if (pingReply.Status == IPStatus.Success)
                {
                    /*
                     *  Wywalić wykomentowany kod i wstawić go do pól klas 
                     * 
                     */
                    Console.WriteLine("Ping done. Netrunner Hub is online. Starting data Exchange...");
                    Console.WriteLine("Waiting for connection...");
                    try
                    {
                        serverSocket = receiverListener.AcceptSocket();
                        if (serverSocket.Connected == true)
                        {
                            this.receiverStream = new NetworkStream(serverSocket);
                            Console.WriteLine("Connected! Waiting for data...");
                           // amountOfReceivedData = serverSocket.Receive(recvBuffer);
                            amountOfReceivedData = receiverStream.Read(recvBuffer, 0, recvBuffer.Length);
                            processData();
                            isServerStarted = false;
                        }
                    }catch(Exception e)
                    {
                        Console.WriteLine("Cannot read data..." + e.ToString());
                        return 3;
                    }
                }
                else
                {
                    Console.WriteLine("Ping Done. Netrunner Hub is offline. Check that Netrunner Hub is connected to\n PC, using network cable.");
                    Console.WriteLine("Closing server...");
                    isServerStarted = false;
                    receiverListener.Stop();
                    return 4;
                }
            }
            else
            {
                Console.WriteLine("Server is already started...");
            }
            Console.WriteLine("Closing server...");
            isServerStarted = false;
            receiverListener.Stop();
            return 0;
        }
    }
}

#ifndef H_CHubServer
#define H_CHubServer
#include <SFML/Network.hpp>
#include <string>
#include <iostream>
#include <stdio.h>
#include <stddef.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <thread>
#include <vector>
#define SHELL "/bin/sh"
class CHubServer
{
public:
	CHubServer();
	///Konstruktor aby ustawic ip
	CHubServer(std::string ip, int port, std::string clientIp);
	~CHubServer();
	void getInput(int gotOption);
private:
	std::vector<std::string> commands; //komendy serwera
	sf::TcpSocket *serverSocket; //nasze gniazdo
	sf::Socket::Status socketStatus;
	int serverPort;
	std::string serverIp;
	std::string clientIp;
	std::string pingResult;
	std::string commandName;
	std::string pingParameters; //-c 1 " + clientIp
	bool pingPcHost(); //pingujemy
	int gotInput;
	bool processPingOutput();
	void connect(); //��czymy si� :P
	bool connected; //czy po��czony
	///Wysy�amy pakiet. Podajemy w parametrze co ma by� w pakiecie
	///RDY - gotowy
	///DATA - wy�l� teraz dane
	///END - koniec nadawania, roz��cz
	void sendPacket(std::string whatToSend);
	///
	///Wype�niamy wektor danymi komend
	///
	void populateCommands();
	
};

#endif // H_CHubServer
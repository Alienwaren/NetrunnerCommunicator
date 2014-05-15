#include "CHubServer.h"

CHubServer::CHubServer()
	:
		serverPort(0), serverIp(" "), pingResult(" "), commandName(" "), pingParameters(" ")
{
}
CHubServer::CHubServer(std::string ip, int port, std::string pclientIp)
	:
		serverPort(port), pingParameters("-c " + clientIp), serverIp(ip), pingResult(" "), commandName("/bin/ping"), clientIp(pclientIp)
{

}
void CHubServer::getInput(int gotOption)
{
	gotInput = gotOption;
	std::cout << "I'm here! " << gotOption << std::endl;
	if(this->gotInput == 1)
	{
		std::cout << "Connecting to... " << clientIp << std::endl;
		connect();
	}
}
bool CHubServer::pingPcHost()
{

	std::string command = "ping -c 1 " + serverIp;
	const char* cmdChar = command.c_str();
	std::cout << command << std::endl;
	char buffer[500];
	FILE* pipe = popen(cmdChar, "r");
	if(!pipe)
	{
		std::cout << "Cannot execute ping" << std::endl;
		return false;
	}
	while(!feof(pipe))
	{
		if(fgets(buffer, 500, pipe) != NULL)
		{
			pingResult += buffer;
		}
	}
	std::cout << pingResult << std::endl;
	pclose(pipe);
	cmdChar = NULL;
	delete cmdChar;
	if(processPingOutput())
	{
		return true;
	}else
	{
		return false;
	}
}
bool CHubServer::processPingOutput()
{
	bool tempFound = pingResult.find("64 bytes from 192.168.1.5:");
	if(tempFound)
	{
		std::cout << "YAY!" << std::endl;
	}
	return tempFound;
	
}
void CHubServer::connect()
{
	serverSocket = new sf::TcpSocket();
	if(pingPcHost())
	{
		socketStatus = serverSocket->connect(clientIp, serverPort);
	}else
	{
		std::cout << "Cannot connect to PC :( " << std::endl;
	}
}
CHubServer::~CHubServer()
{

}
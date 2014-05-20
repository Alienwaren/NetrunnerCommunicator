#include "CHubServer.h"

CHubServer::CHubServer()
	:
		serverPort(0), serverIp(" "), pingResult(" "), commandName(" "), pingParameters(" "), connected(false)
{
}
CHubServer::CHubServer(std::string ip, int port, std::string pclientIp)
	:
		serverPort(port), pingParameters("-c " + clientIp), serverIp(ip), pingResult(" "), commandName("/bin/ping"), clientIp(pclientIp),
			connected(false)
{
	populateCommands();
}
void CHubServer::getInput(int gotOption)
{
	gotInput = gotOption;
	std::cout << "I'm here! " << gotOption << std::endl;
	if(this->gotInput == 1)
	{
		std::cout << "Connecting to... " << serverIp << std::endl;
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
	bool tempFound = pingResult.find("64 bytes from");
	if(tempFound)
	{
		std::cout << "YAY!" << std::endl;
	}else
	{
		std::cout << "Meh!" << std:: endl;
	}
	return tempFound;
	
}
void CHubServer::connect()
{
	serverSocket = new sf::TcpSocket();
	if(pingPcHost())
	{
		socketStatus = serverSocket->connect(clientIp, serverPort);
		if(socketStatus == sf::Socket::Done)
		{
			connected = true;
		}
	}else
	{
		std::cout << "Cannot connect to PC :( " << std::endl;
		connected = false;
	}
	sendPacket("RDY");
	serverSocket->disconnect();
    delete serverSocket;
}
void CHubServer::sendPacket(std::string whatToSend)
{
	if (connected)
	{
		if (whatToSend == commands[0])
		{
			std::cout << "Sending RDY command" << std::endl;
			if (serverSocket->send(commands[0].c_str(), commands[0].length()) != sf::Socket::Done)
			{
				std::cout << "Cannot send RDY command" << std::endl;
			}
		}
		connected = false;
	}
}
void CHubServer::populateCommands()
{
	commands.push_back("RDY");
}
///push_back

CHubServer::~CHubServer()
{

}
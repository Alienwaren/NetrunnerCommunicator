#include "CHubServer.h"
#include "CMenu.h"
int main()
{
	CHubServer *rpiHub = new CHubServer("192.168.0.11", 134, "192.168.0.12"); //std::string ip, int port, std::string clientIp
	CMenu *programMenu = new CMenu(); 
	int selectedOption;
	while(true)
	{
		programMenu->displayMenu();
		selectedOption = programMenu->getInput();
		rpiHub->getInput(selectedOption);
		if(selectedOption == 0)
		{
			break;
		}
	}
	delete rpiHub;
	delete programMenu;
	return 0;
}
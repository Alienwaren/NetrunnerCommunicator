#include "CMenu.h"

CMenu::CMenu()
{
	populateMenu();
}

void CMenu::populateMenu()
{
	menuEntries.push_back("Hello, select option: ");
	menuEntries.push_back("0. Exit from program");
	menuEntries.push_back("1. Connect to PC.");
}
void CMenu::displayMenu()
{
	for(int i = 0; i < menuEntries.size(); i++)
	{
		std::cout << menuEntries[i] << std::endl;
	}
}
int CMenu::getInput()
{
	std::cout << "Please, enter option: ";
	std::cin >> selectedOption;
	if(selectedOption == 1)
	{
		return 1;
	}else if(selectedOption == 0)
	{
		return 0;
	}
	return -1;
}


CMenu::~CMenu()
{
}
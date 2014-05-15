#ifndef H_CMenu
#define H_CMenu
#include <iostream>
#include <string>
#include <vector>
class CMenu
{
public:
	CMenu();
	~CMenu();
	std::vector<std::string> menuEntries; ///wpisy menu.
		///
		///@summary Zape³nienie menu.
		///
	void populateMenu(); 
		///
		///@summary wyœwietlamy je.
		///
	void displayMenu();
		///
		///@summary Otrzymanie wejœcia
		///
	int getInput();
		///
		///@summary otrzymany wpis menu
		///
	int selectedOption;
};
#endif //CMenu
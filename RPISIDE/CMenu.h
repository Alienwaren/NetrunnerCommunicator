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
		///@summary Zapełnienie menu.
		///
	void populateMenu(); 
		///
		///@summary wyświetlamy je.
		///
	void displayMenu();
		///
		///@summary Otrzymanie wejścia
		///
	int getInput();
		///
		///@summary otrzymany wpis menu
		///
	int selectedOption;
};
#endif //CMenu
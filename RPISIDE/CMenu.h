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
		///@summary Zape�nienie menu.
		///
	void populateMenu(); 
		///
		///@summary wy�wietlamy je.
		///
	void displayMenu();
		///
		///@summary Otrzymanie wej�cia
		///
	int getInput();
		///
		///@summary otrzymany wpis menu
		///
	int selectedOption;
};
#endif //CMenu
#include <iostream>
#include "fratction.h"
using namespace std;

void fraction::Init(int F, int S)
{
	first = F;
	second = S;
}

/*void fraction::Read()
{
	setlocale(0, "Rus");
	cout << "Числитель: ";
	cout << "Знаменатель: ";
	cin >> second;
}

void fraction::Show()
{
	cout << "Числитель: " << first << endl;
	cout << "Знаменатель: " << second << endl;
}
*/

int fraction::ipart()
{
	return first / second;
}
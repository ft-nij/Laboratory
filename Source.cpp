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
	cout << "���������: ";
	cout << "�����������: ";
	cin >> second;
}

void fraction::Show()
{
	cout << "���������: " << first << endl;
	cout << "�����������: " << second << endl;
}
*/

int fraction::ipart()
{
	return first / second;
}
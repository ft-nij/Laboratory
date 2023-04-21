#include <iostream>
#include "fratction.h"
using namespace std;

int main()
{
	setlocale(0, "rus");
	fraction A;
	int first, second;
	cout << "Введтите числитель: ";
	cin >> first;
	cout << "Введите знаменатель: ";
	cin >> second;
	if (second == 0)
	{
		cout << "Че за херня, чел";
	}
	else
	{
		A.Init(first, second);
		cout << first << '/' << second << '=' << A.ipart();
	}
	return 0;
}
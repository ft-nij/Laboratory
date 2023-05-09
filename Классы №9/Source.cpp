#include "Vector.h"
#include "Error.h"
#include <iostream>
using namespace std;
int main()
{
	setlocale(0, "rus");
	try
	{
		Vector x(3);
		cin >> x;
		Vector y;
		cout << x;
		cout << "Выберите элемент вектора: ";
		int i;
		cin >> i;
		cout << x[i] << endl;
		
	}
	catch (error e)
	{
		e.what();
	}
	return 0;
}
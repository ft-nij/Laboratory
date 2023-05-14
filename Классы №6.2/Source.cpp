#include "Stack.h"
#include <iostream>
#include <Windows.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	int n;
	cout << "Введите размер очереди: ";
	cin >> n;
	Stack a(n);
	int num;
	cout << a << endl;
	cout << "1. Удалить элемент из очереди\n";
	cout << "2. Добавить элемент в очереди\n";
	cout << "3. Вывести очередь на экран\n";
	cout << "4. Выход\n";
	int c = 0;
	while (c != 4)
	{
		cout << "Выберите операцию: ";
		cin >> c;
		switch (c)
		{
		case 1:
			a.pop();
			cout << "Элемент(ы) успешно удалены!\n";
			break;
		case 2:
			cout << "Введите число, которое хотите добавить в очередь: ";
			cin >> num;
			cout << "Элемент успешно добавлен!\n";
			a.push(num);
			break;
		case 3:
			cout << "Ваша очередь: " << a << endl;
			break;
		case 4:
			return 0;
			break;
		default:
			cout << "Введите номер операции корректно!\n";
			break;
		}
	}
	return 0;
}
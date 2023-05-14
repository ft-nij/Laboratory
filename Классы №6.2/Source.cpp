#include "Stack.h"
#include <iostream>
#include <Windows.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "ru");
	int n;
	cout << "������� ������ �������: ";
	cin >> n;
	Stack a(n);
	int num;
	cout << a << endl;
	cout << "1. ������� ������� �� �������\n";
	cout << "2. �������� ������� � �������\n";
	cout << "3. ������� ������� �� �����\n";
	cout << "4. �����\n";
	int c = 0;
	while (c != 4)
	{
		cout << "�������� ��������: ";
		cin >> c;
		switch (c)
		{
		case 1:
			a.pop();
			cout << "�������(�) ������� �������!\n";
			break;
		case 2:
			cout << "������� �����, ������� ������ �������� � �������: ";
			cin >> num;
			cout << "������� ������� ��������!\n";
			a.push(num);
			break;
		case 3:
			cout << "���� �������: " << a << endl;
			break;
		case 4:
			return 0;
			break;
		default:
			cout << "������� ����� �������� ���������!\n";
			break;
		}
	}
	return 0;
}
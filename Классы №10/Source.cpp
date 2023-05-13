#include "Time.h"
#include "file_work.h"
#include <iostream>
#include <fstream>
#include <string>
using namespace std;
int main()
{
	setlocale(LC_ALL, "ru");
	Time p, p1, p2;
	int k, c;
	char file_name[30];
	do
	{ //����
		cout << "1. ������� ����";
		cout << "\n2. ������� ���������� �����";
		cout << "\n3. ������� ������ �� �����";
		cout << "\n4. �������� ������ � ����";
		cout << "\n5. �������� ������ � �����";
		cout << "\n0. ����� �� ����\n";
		cin >> c;
		switch (c)
		{
		case 1: cout << "������� ��� �����: "; cin >> file_name;
			k = make_file(file_name);
			if (k < 0)cout << "���� �� ����� ���� ������!";
			break;
		case 2: cout << "������� ��� �����:"; cin >> file_name;
			k = print_file(file_name);
			if (k == 0)cout << "���� ����!\n";
			if (k < 0)cout << "���� �� ����� ���� ��������\n";
			break;
		case 3: cout << "������� ��� �����:"; cin >> file_name;
			int nom; cout << "������� ����� ��������, ������� ����� �������: "; cin >> nom;
			k = del_file(file_name, nom);
			if (k < 0)cout << "���������� ��������� ����!";
			break;
		case 4: cout << "������� ��� �����:";
			cin >> file_name;
			cout << "������� ���������� ����� ���������: ";
			cin >> nom;
			//cout << "����� ����������:\n";
			//Time p1;
			//cin >> p1;
			k = add_file(file_name, nom, p1);
			if (k < 0) cout << "���������� ��������� ����!";
			if (k == 0) k = add_end(file_name, p1);
			break;
		case 5: cout << "������� ��� �����: ";
			cin >> file_name;
			cout << "������� ����� �����, ������� ����� ��������: "; cin >> nom;
			cout << "����� ����������:\n";
			//Time p2;
			cin >> p2;
			k = change_file(file_name, nom, p2);
			if (k < 0) cout << "\n���������� ��������� ����!";
			if (k == 0) cout << "\n��� ����� ������!";
			break;
		}
	} while (c != 0);
	return 0;
}
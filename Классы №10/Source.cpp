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
	{ //Меню
		cout << "1. Создать файл";
		cout << "\n2. Вывести содержимое файла";
		cout << "\n3. Удалить запись из файла";
		cout << "\n4. Добавить запись в файл";
		cout << "\n5. Изменить запись в файле";
		cout << "\n0. Выход из меню\n";
		cin >> c;
		switch (c)
		{
		case 1: cout << "Введите имя файла: "; cin >> file_name;
			k = make_file(file_name);
			if (k < 0)cout << "Файл не может быть создан!";
			break;
		case 2: cout << "Введите имя файла:"; cin >> file_name;
			k = print_file(file_name);
			if (k == 0)cout << "Файл пуст!\n";
			if (k < 0)cout << "Файл не может быть прочитан\n";
			break;
		case 3: cout << "Введите имя файла:"; cin >> file_name;
			int nom; cout << "Введите номер элемента, который нужно удалить: "; cin >> nom;
			k = del_file(file_name, nom);
			if (k < 0)cout << "Невозможно прочитать файл!";
			break;
		case 4: cout << "Введите имя файла:";
			cin >> file_name;
			cout << "Введите количество новых элементов: ";
			cin >> nom;
			//cout << "Новая информация:\n";
			//Time p1;
			//cin >> p1;
			k = add_file(file_name, nom, p1);
			if (k < 0) cout << "Невозможно прочитать файл!";
			if (k == 0) k = add_end(file_name, p1);
			break;
		case 5: cout << "Введите имя файла: ";
			cin >> file_name;
			cout << "Введите номер файла, который нужно изменить: "; cin >> nom;
			cout << "Новая информация:\n";
			//Time p2;
			cin >> p2;
			k = change_file(file_name, nom, p2);
			if (k < 0) cout << "\nНевозможно прочитать файл!";
			if (k == 0) cout << "\nНет такой записи!";
			break;
		}
	} while (c != 0);
	return 0;
}
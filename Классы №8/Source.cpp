#include "Person.h"
#include "Employee.h"
#include "Vector.h"
#include "Event.h"
#include "Dialog.h"
#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "ru");
	system("chcp 1251");
	system("cls");
	Dialog D;
	cout << "Пожалуйста, выберите желаемое действие:\n";
	cout << "\nm Создать группу\n+ Добавить элемент в группу\n- Удалить элемент из группы\n"
"s Вывести информацию об элементах группы\nz Вывести информацию об имени элемента с номером k\nq Конец работы\n";
	D.Execute();
	return 0;
}
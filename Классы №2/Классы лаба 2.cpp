#include "Student.h"
#include <iostream>
#include <string>
using namespace std;
//функция для возврата объекта как результата
Student make_Student()
{
	string s;
	string i;
	float d;
	cout << "Введите ФИО: ";
	cin >> s;
	cout << "Введите группу: ";
	cin >> i;
	cout << "Введите средний балл: ";
	cin >> d;
	Student t(s, i, d);
	return t;
}
//функция для передачи объекта как параметра
void print_Student(Student t)
{
	t.show();
}
int main()
{
	setlocale(0, "rus");
	//конструктор без параметров
	Student t1;
	t1.show();
	//коструктор с параметрами
	Student t2("FIO", "IVT", 4.56);
	t2.show();
	//конструктор копирования
	Student t3 = t2;
	t3.show();
	//конструктор копированиz
	t3.set_FIO("Saba");
	t3.set_Group("IVT");
	t3.set_avg(4.2);
	print_Student(t3);
	//конструктор копирования
	t1 = make_Student();
	t1.show();
}
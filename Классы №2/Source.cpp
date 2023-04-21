#include "Student.h"
#include <iostream>
#include <string>
using namespace std;
//конструктор без параметров
Student::Student()
{
	FIO = " ";
	Group = " ";
	avg = 0;
	cout << "Constructor bez parametrov dlia objecta " << endl;
}
//конструктор с параметрами
Student::Student(string N, string K, float S)
{
	FIO = N;
	Group = K;
	avg = S;
	cout << "Constructor s parametrami dlia objecta " << endl;
}
//конструктор копирования
Student::Student(const Student& t)
{
	FIO = t.FIO;
	Group = t.Group;
	avg = t.avg;
	cout << "Constructor copirovania dlia objecta " << endl;
}
//деструктор
Student::~Student()
{
	cout << "Destructor dlia objecta " <<  endl;
}
//селекторы
string Student::get_FIO()
{
	return FIO;
}
string Student::get_Group()
{
	return Group;
}
float Student::get_avg()
{
	return avg;
}
//модификаторы
void Student::set_FIO(string N)
{
	FIO = N;
}
void Student::set_Group(string K)
{
	Group = K;
}
void Student::set_avg(float S)
{
	avg = S;
}
//метод для просмотра атрибутов
void Student::show()
{
	cout << "FIO :" << FIO << endl;
	cout << "Group :" << Group << endl;
	cout << "avg :" << avg << endl;
}
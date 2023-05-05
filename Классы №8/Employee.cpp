#include "Employee.h"
#include "Person.h"
#include <string>
#include <iostream>
using namespace std;

Employee::Employee(void) :Person() {
	salary = 0;
	position = "";
};
Employee::~Employee(void) {

};
Employee::Employee(string Name, int Age, double salary, string position) :Person(Name, Age)
{
	this->salary = salary;
	this->position = position;
};
Employee::Employee(const Employee& a) {
	salary = a.salary;
	position = a.position;
	Name = a.Name;
	Age = a.Age;
};
void Employee::set_salary(double salary) {
	this->salary = salary;
};
void Employee::set_position(string p) {
	position = p;
};
Employee& Employee::operator=(const Employee& a) {
	if (&a == this)return *this;
	Name = a.Name;
	Age = a.Age;
	return *this;
};
void Employee::show() {
	cout << endl << "Сотрудник: " << endl;
	cout << "Имя: " << Name << endl;
	cout << "Возраст: " << Age << endl;
	cout << "Заработная плата: " << salary << endl;
	cout << "Должность: " << position << endl;
};
void Employee::input() {
	cout << "Сотрудник: " << endl << "Введите имя: ";
	getchar();
	getline(cin, Name);
	cout << "Введите возраст: ";
	cin >> Age;
	cout << "Его заработная плата: ";
	cin >> salary;
	cout << "Занимаемая должность: ";
	getchar();
	getline(cin, position);
};
#include "Person.h"
#include <string>
#include <iostream>
using namespace std;

Person::Person(void) {
	Name = "";
	Age = 0;
};
Person::Person(string Name, int Age) {
	Name = Name;
	Age = Age;
};
Person::Person(const Person& a) {
	this->Age = a.Age;
	this->Name = a.Name;
};
Person::~Person(void) {

};
Person& Person::operator=(const Person& a) {
	if (&a == this) return*this;
	Name = a.Name;
	Age = a.Age;
	return *this;
};
void Person::setName(string m) {
	Name = m;
};
void Person::setAge(int a) {
	Age = a;
};
void Person::show() {
	cout << endl << "Человек: " << endl;
	cout << "Имя: " << Name << endl;
	cout << "Возраст: " << Age << endl;
};
void Person::input() {
	cout << "Человек: " << endl << "Введите имя человека: ";
	getchar();
	getline(cin, Name);
	cout << "Введите возраст человека: ";
	cin >> Age;
};
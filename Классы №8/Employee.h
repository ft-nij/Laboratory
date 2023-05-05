#pragma once
#include "Person.h"
#include <string>
#include<iostream>
using namespace std;
class Employee :public Person {
protected:
	double salary;
	string position;
public:
	Employee(void);
	Employee(string, int, double, string);
	Employee(const Employee&);
	int getsalary() { return salary; };
	string getposition() { return position; };
	void set_salary(double);
	void set_position(string);
	Employee& operator=(const Employee&);
	~Employee(void);
	void show();
	void input();
};
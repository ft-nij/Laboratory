#pragma once
#include "Object.h"
#include <string>
#include <iostream>
using namespace std;
class Person :public object {
protected:
	string Name;
	int Age;
public:
	Person(void);
	virtual ~Person(void);
	void show();
	void input();
	Person(string, int);
	Person(const Person&);
	string getName() { return Name; };
	int getAge() { return Age; };
	void setName(string);
	void setAge(int);
	Person& operator=(const  Person&);
};
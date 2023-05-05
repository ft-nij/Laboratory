#pragma once
#include "Object.h"
#include "Person.h"
#include <string>
#include <iostream>
using namespace std;
class vector {
protected:
	object** beg;
	int size;
	int cur;
public:
	vector();
	vector(int);
	~vector(void);
	void add(object*);
	void add();
	void del();
	void Get_Name();
	void show();
	int operator()();
};
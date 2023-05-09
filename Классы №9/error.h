#pragma once
#include <string>
#include <iostream>
using namespace std;
class error //класс ошибка
{
	string str;
public:
	//конструктор, инициирует атрибут str сообщением об ошибке
	error(string s) { str = s; }
	void what() { cout << str << endl; } //выводит значение атрибута str
};
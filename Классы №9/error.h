#pragma once
#include <string>
#include <iostream>
using namespace std;
class error //����� ������
{
	string str;
public:
	//�����������, ���������� ������� str ���������� �� ������
	error(string s) { str = s; }
	void what() { cout << str << endl; } //������� �������� �������� str
};
#include "Time.h"
#include <iostream>
using namespace std;
//перегрузка операции присваивания
Time& Time::operator=(const Time& t)
{
	//проверка на самоприсваивание
	if (&t == this) return *this;
	min = t.min;
	sec = t.sec;
	return *this;
}
/*
//перегрузка префиксной операции инкремент
Time& Time::operator++()
{
	int temp = min * 60 + sec;
	temp++;
	min = temp / 60;
	sec = temp % 60;
	return *this;
}
//перегрузка постфиксной операции инкремент
Time Time::operator ++(int)
{
	int temp = min * 60 + sec;
	temp++;
	Time t(min, sec);
	min = temp / 60;
	sec = temp % 60;
	return t;
}
*/
void Time::operator==(const Time& t)
{
	int temp1 = min * 60 + sec;
	int temp2 = t.min * 60 + t.sec;
	if (temp1==temp2)
	{
		cout << "Интервалы равны";
	}
	if (temp1 > temp2)
	{
		cout << "Первый интервал больше второго";
	}
	if (temp1 < temp2)
	{
		cout << "Первый интервал меньше второго ";
	}
	
}
//перегрузка бинарной операции сложения
Time Time::operator+(const Time& t)
{
	int temp1 = min * 60 + sec;
	int temp2 = t.min * 60 + t.sec;
	Time p;
	p.min = (temp1 + temp2) / 60;
	p.sec = (temp1 + temp2) % 60;
	return p;
}
//перегрузка глобальной функции-операции ввода
istream& operator>>(istream& in, Time& t)
{
	int num;
	cout << "Введите количество минут: "; in >> t.min;
	cout << "Введите количество секунд: "; 
	in >> num;
	while (num >= 60) {
		cout << "Введите количество секунд: ";
		in >> num;
	}
	t.sec=num;
	return in;
}
//перегрузка глобальной функции-операции вывода
ostream& operator<<(ostream& out, const Time& t)
{
	return (out << t.min << ":" << t.sec);
}
#include "Time.h"
Time::Time()
{
	minutes = 0 ; seconds = 0;
}
Time::Time(int M, int S)
{
	minutes = M; seconds = S;
}
Time::Time(const Time& p)
{
	minutes = p.minutes; seconds = p.seconds;
}
Time Time::operator =(const Time& p)
{
	if (&p == this) return *this;
	minutes = p.minutes; seconds = p.seconds;
	return*this;
}
Time::~Time()
{
}
void Time::operator==(const Time& p)
{
	int temp1 = minutes * 60 + seconds;
	int temp2 = p.minutes * 60 + p.seconds;
	if (temp1 == temp2)
	{
		cout << "Интервалы равны\n";
	}
	if (temp1 > temp2)
	{
		cout << "Первый интервал больше второго\n";
	}
	if (temp1 < temp2)
	{
		cout << "Первый интервал меньше второго\n";
	}

}
Time Time::operator-(const Time& p)
{
	int temp1 = minutes * 60 + seconds;
	int temp2 = p.minutes * 60 + p.seconds;
	Time t;
	t.minutes = (temp1 - temp2) / 60;
	t.seconds = (temp1 - temp2) % 60;
	return t;
}
ostream& operator<<(ostream& out, const Time& p)
{
	out << p.minutes << ":" << p.seconds << "\n";
	return out;
}
istream& operator>>(istream& in, Time& p)
{
	cout << "Введите минуты: "; in >> p.minutes;
	cout << "Введите секунды: "; in >> p.seconds;
	return in;
}
fstream& operator>>(fstream& fin, Time& p)
{
	fin >> p.minutes;
	fin >> p.seconds;
	return fin;
}
fstream& operator<<(fstream& fout, const Time& p)
{
	fout << p.minutes << "\n" << p.seconds << "\n";
	return fout;
}
#include <iostream>
#include "Pair.h"
#include <set>
#include <ctime>
using namespace std;

typedef set<Pair>TMset;//���������� ��� ��� ������  
typedef TMset::iterator it;//��������

//������� ��� ������������  
TMset make_set(int n)
{
	srand(time(NULL));
	TMset m;
	for (int i = 0; i < n; i++)
	{
		Pair a(rand() % 20, round(((double)(rand()) / RAND_MAX * 10 + 1) * 100) / 100);
		m.insert(a);
	}
	return m;//���������� ��� ��������� ������ �������
}
//������� ��� ������ 
void printset(TMset m)
{
	int j = 1;
	for (it i = m.begin(); i != m.end(); i++) cout << *i;
}
void remove_elements(TMset& v, Pair min, Pair max)
{
	if (min > max) swap(min, max);
	for (it i = v.begin(); i != v.end();)
	{
		if (*i <= max && *i >= min) i = v.erase(i);
		else ++i;
	}
}
void add_set(TMset& v, Pair el)
{
	v.insert(el);
}
//���������� �������� ��������������� 
Pair average(TMset v)
{
	Pair s;
	for (it i = v.begin(); i != v.end(); i++) s += *i;
	int n = v.size();
	return s / n;
}
//����� ������������� �������� 
Pair Max(TMset v)
{
	it i = v.end();
	--i;
	Pair max = *i;
	return max;
}
Pair Min(TMset v)
{
	it i = v.begin();
	Pair min = *i;
	return min;
}
void delenie(TMset& v, Pair min, Pair max)
{
	TMset v1;
	for (it i = v.begin(); i != v.end(); ++i)
	{
		Pair v2 = min + max + *i;
		v1.insert(v2);
	}
	v = v1;

}

void main()
{
	setlocale(0, "");
	int n;
	Pair range_min, range_max, min_el, max_el;
	cout << "������� ������ ����������: ";
	cin >> n;
	TMset v = make_set(n);
	printset(v);
	Pair el = average(v);
	add_set(v, el);
	cout << "\n������� ��������������  ��������: \n";
	printset(v);
	min_el = Min(v);
	cout << min_el << endl;
	max_el = Max(v);
	cout << "\n����������� � ������� �������� ������ ����� ������������ � ������������� ��������\n";
	delenie(v, min_el, max_el);
	printset(v);
	cout << "������� �������� �� ��������:\n��:  ";
	cin >> range_min;
	cout << "��:  ";
	cin >> range_max;
	cout << "\n�������� �����\n";
	remove_elements(v, range_min, range_max);
	printset(v);
}
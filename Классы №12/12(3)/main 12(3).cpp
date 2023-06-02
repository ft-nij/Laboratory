#include <iostream>
#include "List.h"
#include "Pair.h"
#include <set>
#include <ctime>
using namespace std;

void main()
{
	setlocale(0, "");
	int n;
	cout << "������� ������ ������: ";
	cin >> n;
	List<Pair> l(n);
	l.Print();
	Pair range_min, range_max, min_el, max_el;
	Pair el = l.average();
	l.add_list(el);
	cout << "������� �������������� ���� ��������� � ����� ������\n";
	l.Print();
	min_el = l.min();
	max_el = l.max();
	cout << "���������� ���� �������� ������ �� ����� ������������ � �������������:\n";
	l.increase_elements(min_el, max_el);
	l.Print();
	cout << "������� ����� ���:\n��\n";
	cin >> range_min;
	cout << "��\n";
	cin >> range_max;
	cout << "������ � ��������� ����������:\n";
	l.remove_elements(range_min, range_max);
	l.Print();
}
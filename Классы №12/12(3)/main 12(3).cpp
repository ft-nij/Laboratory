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
	cout << "Введите размер списка: ";
	cin >> n;
	List<Pair> l(n);
	l.Print();
	Pair range_min, range_max, min_el, max_el;
	Pair el = l.average();
	l.add_list(el);
	cout << "Среднее арифметическое было добавлено в конец списка\n";
	l.Print();
	min_el = l.min();
	max_el = l.max();
	cout << "Увеличение всех элментов списка на сумму минимального и максимального:\n";
	l.increase_elements(min_el, max_el);
	l.Print();
	cout << "Введите ключи пар:\nОТ\n";
	cin >> range_min;
	cout << "ДО\n";
	cin >> range_max;
	cout << "Список с удалёнными элементами:\n";
	l.remove_elements(range_min, range_max);
	l.Print();
}
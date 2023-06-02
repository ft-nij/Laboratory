#include <iostream>
#include <list>
#include <map>
#include <vector>
#include "Pair.h"
#include <algorithm>
#include <functional>
using namespace std;

void print_vect(Pair elem)
{
	cout << "Ключ: " << elem.sum() << endl;
	cout << "Значение: " << elem << endl;
}

ostream& operator<<(ostream& out, map<double, Pair>& m)
{
	for (map <double, Pair>::iterator it = m.begin(); it != m.end(); it++)
	{
		cout << "Ключ: " << it->first << endl;
		cout << "Значение: " << it->second << endl;
	}
	return out;
}

void menu(const int c, map<double, Pair>& l)
{
	switch (c)
	{
		//arithmetical mean
	case 1:
	{
		cout << l << endl << endl;
		Pair sum;
		for (auto it = l.begin(); it != l.end(); it++) sum += it->second;

		sum.set_first(sum.get_first() / l.size());
		sum.set_second(round((double)(sum.get_second() / l.size()) * 100) / 100);

		cout << "В список было добавлено среднее арифметическое: " << sum.sum() << endl;
		l.insert(make_pair(sum.sum(), sum));
		cout << l << endl;
		break;
	}
	//find element 
	case 2:
	{
		cout << l << endl;
		cout << "Введите ключ пары: ";
		double value;
		cin >> value;
		const auto it = find_if(l.begin(), l.end(), [&value](decltype(*l.begin())& it)->bool
			{
				return it.second == value;
			}
		);

		if (it == l.end())
		{
			cout << "Такой элемент не был найден!\n";
		}
		else
		{
			for (map<double, Pair>::iterator i = l.begin(); i != l.end(); ++i)
			{
				if (i == it)
				{
					cout << "Искомый элемент: " << i->second << endl;
				}
			}
		}
		break;
	}
	// sort
	case 3:
	{
		cout << l << endl;
		cout << "Введите <, чтобы отсортировать по возрастанию\n";
		cout << "Введите >, чтобы отсортировать по убыванию\n";
		char sorting;
		cin >> sorting;
		if (sorting == '<') cout << l << endl;
		else if (sorting == '>')
		{
			vector<Pair> copied;
			Pair elem;
			for (map <double, Pair>::iterator it = l.begin(); it != l.end(); it++)
			{
				elem = it->second;
				copied.push_back(elem);
			}
			sort(copied.begin(), copied.end(), mem_fun_ref(&Pair::operator>));
			for_each(copied.begin(), copied.end(), ptr_fun(print_vect));
			copied.~vector();
		}
		else cout << "Такая сортировка не предусмотрена\n";
		break;
	}
	//delete from range
	case 4:
	{
		cout << l << endl;
		double f, s;
		cout << "\nВведите первую границу\n";
		cin >> f;
		cout << "\nВведите вторую границу\n";
		cin >> s;
		if (f > s) swap(f, s);

		while (find_if(l.begin(), l.end(), [&f, &s](decltype(*l.begin())& it) -> bool
			{
				return it.second.sum() > f && it.second.sum() < s;
			}
		) != l.end())
			// тело цикла
		{
			const auto it = find_if(l.begin(), l.end(), [&f, &s](decltype(*l.begin())& it) -> bool
				{
					return it.second.sum() >= f && it.second.sum() <= s;
				}
			);
			l.erase(it->first);
		}

		cout << "Пары были удалены " << endl;
		break;
	}
	//Pair + sum(min, max)
	case 5:
	{
		cout << l << endl << endl;

		const auto mini = l.begin();
		const auto maxi = --l.end();
		cout << "Минимальное значение (по сумме): " << mini->second << endl;
		cout << "Максимальное значение (по сумме): " << maxi->second << endl;


		Pair sum;
		sum = mini->second + maxi->second;
		for (auto it = l.begin(); it != l.end(); it++)
		{
			it->second.set_second(it->second.get_second() + sum.get_second());
			it->second.set_first(it->second.get_first() + sum.get_first());
		}

		cout << endl << l << endl;
		break;
	}
	//print
	case 6:
	{
		cout << l << endl;
		break;
	}
	//exit
	case 0:
		exit(777);
	default:
	{
		cout << "Введите номер операции верно!\n";
	}
	}
}


int main()
{
	setlocale(LC_ALL, "ru");
	srand(time(NULL));
	int n, c = 1;
	cout << "Введите размер списка: ";
	cin >> n;
	map<double, Pair> l;
	for (int i = 0; i < n; ++i)
	{
		Pair p;
		p.create_rand();
		l.insert(make_pair(p.sum(), p));
	}
	cout << l << endl;

	while (c != 0)
	{
		system("pause");
		system("cls");
		cout << "1. Найти среднее арифметическое" << endl;
		cout << "2. Найти пару" << endl;
		cout << "3. Отсортировать контейнер" << endl;
		cout << "4. Удалить пары" << endl;
		cout << "5. Добавить ко всем элементам списка сумму наименьшего и наибольшего" << endl;
		cout << "6. Вывести список на экран" << endl;
		cout << "0. Выход" << endl;
		cout << "Выберите действие: ";
		cin >> c;
		system("cls");
		menu(c, l);
	}
	return 0;
}
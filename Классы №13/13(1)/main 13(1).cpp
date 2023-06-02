#include <iostream>
#include <list>
#include "Pair.h"
#include <algorithm>
#include <functional>
using namespace std;

bool Search_Pair(Pair a, double t)
{
	double sum = a.get_first() + a.get_second();
	if (a.get_first() == t || a.get_second() == t || sum == t) return true;
	return false;
}
ostream& operator<<(ostream& out, list<Pair>& a) // pair output
{
	for_each(a.begin(), a.end(), [](Pair& p)
		{
			cout << p;
		}
	);
	return out;
}

void menu(const int c, list<Pair>& l)
{
	switch (c)
	{
		//arithmetical mean
	case 1:
	{
		cout << l << endl << endl;
		Pair sum;
		for_each(l.begin(), l.end(), [&sum](Pair& p)
			{
				sum += p;
			}
		);
		sum.set_first(sum.get_first() / l.size());
		sum.set_second(sum.get_second() / l.size());
		l.push_back(sum);
		cout << "В список было добавлено среднее арифметическое: " << sum << endl;
		break;
	}
	//find element 
	case 2:
	{
		cout << l << "\n\n";
		cout << "Введите одно из чисел пары (либо её сумму): ";
		double value;
		cin >> value;
		auto it = find_if(l.begin(), l.end(), bind2nd(ptr_fun(Search_Pair), value));
		if (it == l.end()) {
			cout << "Такой пары не было найдено!" << endl;
			break;
		}
		for (list<Pair>::iterator i = l.begin(); i != l.end(); ++i)
		{
			if (i == it)
				cout << "Найденная пара: " << *i << endl;
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
		if (sorting == '<') l.sort(mem_fun_ref(&Pair::operator<));
		else if (sorting == '>') l.sort(mem_fun_ref(&Pair::operator>));
		else cout << "Такая сортировка не предусмотрена\n";
		cout << l << endl;
		break;
	}
	//delete from range
	case 4:
	{
		cout << l << endl;
		Pair first, second;
		cout << "\nВведите первую границу\n";
		cin >> first;
		cout << "\nВведите вторую границу\n";
		cin >> second;
		if (first > second) swap(first, second);

		auto s = remove_if(l.begin(), l.end(), [first, second](Pair& p)
			{
				return p >= first && p <= second;
			}
		);
		l.erase(s, l.end());

		cout << "Пары были удалены " << endl;
		break;
	}
	//Pair + sum(min, max)
	case 5:
	{
		cout << l << endl << endl;
		auto mini = min_element(l.begin(), l.end());
		auto maxi = max_element(l.begin(), l.end());
		cout << "Минимальное значение (по сумме): " << *mini << endl;
		cout << "Максимальное значение (по сумме): " << *maxi << endl;
		Pair sum;
		sum = *mini + *maxi;
		for_each(l.begin(), l.end(), [&sum](Pair& p) {p += sum; });
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
	case 7:
	{
		cout << "Введите новую пару\n";
		Pair a;
		cin >> a;
		l.push_back(a);
		break;
	}
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
	list<Pair> l(n);
	generate(l.begin(), l.end(), []()
		{
			Pair p;
			p.create_rand();
			return p;
		}
	);
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
		cout << "7. Добавить пару" << endl;
		cout << "0. Выход" << endl;
		cout << "Выберите действие: ";
		cin >> c;
		system("cls");
		menu(c, l);
	}
	return 0;
}
#include <iostream>
#include <set>
#include <ctime>
using namespace std;

typedef set<double>TMset;//определяем тип для работы  
typedef TMset::iterator it;//итератор

//функция для формирования  
TMset makeset(int n)
{
	srand(time(NULL));
	TMset m;
	double a;
	for (int i = 0; i < n; i++)
	{
		a = round(((double)(rand()) / RAND_MAX * 10 + 1) * 100) / 100;
		m.insert(a);
	}
	return m;//возвращаем как результат работы функции
}
//функция для печати 
void printset(TMset m)
{
	int j = 0;
	for (it i = m.begin(); i != m.end(); i++) cout << j++ << " : " << *i << " " << endl;
}
void remove_elements(TMset& v, double min, double max)
{
	if (min > max) swap(min, max);
	for (it i = v.begin(); i != v.end();)
	{
		if (*i <= max && *i >= min) i = v.erase(i);
		else ++i;
	}
}
void addset(TMset& v, double el)
{
	v.insert(el);
}
//вычисление среднего арифметического 
double average(TMset v)
{
	double s = 0;
	for (it i = v.begin(); i != v.end(); i++) s += *i;
	int n = v.size();
	return s / n;
}
//поиск максимального элемента 
double Max(TMset v)
{
	it i = v.end();
	--i;
	double max = *i;
	return max;
}
double Min(TMset v)
{
	it i = v.begin();
	double min = *i;
	return min;
}
void delenie(TMset& v, double min, double max)
{
	TMset v1;
	for (it i = v.begin(); i != v.end(); ++i)
	{
		double v2 = *i + min + max;
		v1.insert(v2);
	}
	v = v1;

}

void main()
{
	setlocale(0, "");
	int n;
	double range_min, range_max, min_el, max_el;
	cout << "Введите размер контейнера: ";
	cin >> n;
	TMset v = makeset(n);
	printset(v);
	double el = average(v);
	addset(v, el);
	cout << "\nСреднее арифметическое  значение: \n";
	printset(v);
	min_el = Min(v);
	max_el = Max(v);
	cout << "\nПрибавление к каждому элементу списка суммы минимального и максимального значений\n";
	delenie(v, min_el, max_el);
	printset(v);
	cout << "Введите элементы на границах:\nОТ:  ";
	cin >> range_min;
	cout << "ДО:  ";
	cin >> range_max;
	cout << "\nУдаление чисел\n";
	remove_elements(v, range_min, range_max);
	printset(v);
}
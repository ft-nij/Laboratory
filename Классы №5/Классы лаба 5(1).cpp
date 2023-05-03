#include "Object.h"
#include "Pair.h"
#include "Rectangle.h"
#include "Vector.h"
#include <string>
#include <iostream>
using namespace std;

int main()
{
	setlocale(0, "rus");
	Vector v(5);//вектор из 5 элементов
	Pair a;//объект класса Pair
	cout << "Введите 2 объекта класса Pair:\n";
	cin >> a;
	Rectangle b;// объект класса Rectangle
	cout << "Введите 2 объекта класса Pair:\n";
	cin >> b;
	Object* p = &a;//ставим указатель на объект класса Pair
	v.Add(p);//добавляем объект в вектор
	p = &b;//ставим указатель на объект класса Rectangle
	v.Add(p); //добавляем объект в вектор
	cout << v;//вывод вектора
	return 0;
}
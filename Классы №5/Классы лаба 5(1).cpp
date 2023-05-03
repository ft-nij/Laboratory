#include "Object.h"
#include "Pair.h"
#include "Rectangle.h"
#include "Vector.h"
#include <string>
#include <iostream>
using namespace std;

int main()
{
	Vector v(5);//вектор из 5 элементов
	Pair a;//объект класса Pair
	Rectangle b(4, 5);// объект класса Rectangle
	Object* p = &a;//ставим указатель на объект класса Pair
	v.Add(p);//добавляем объект в вектор
	p = &b;//ставим указатель на объект класса Rectangle
	v.Add(p); //добавляем объект в вектор
	cout << v;//вывод вектора
}
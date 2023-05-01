#include <iostream>
#include "Rectangle.h"

void main()
{
	setlocale(LC_ALL, "ru");
	Rectangle a(5, 4);
	cout << "Площадь прямоугольника:" << a.getArea() << endl;
	cout << "Периметр прямоугольника:" << a.getPerimeter() << endl;
}
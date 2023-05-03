#include "Rectangle.h"
// Конструктор без параметров
Rectangle::Rectangle()
{

}
// Конструктор с параметрами
Rectangle::Rectangle(int f, int s)
{

}
Rectangle::Rectangle(const Rectangle& p)
{
    first = p.first;
    second = p.second;
}
int Rectangle::getArea()
{
    return first * second;
}
int Rectangle::getPerimeter()
{
    return 2 * first + 2 * second;
}
void Rectangle::Show()
{
    cout << "\nFirst : " << first;
    cout << "\nSecond : " << second;
    cout << "\n";
}

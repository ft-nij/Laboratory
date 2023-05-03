#include "Rectangle.h"
// Конструктор без параметров
Rectangle::Rectangle()
{
}
// Конструктор с параметрами
Rectangle::Rectangle(int f, int s) : Pair(f, s)
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
    cout << "\nArea : " << first * second;
    cout << "\nPerimetr : " << 2 * first + 2 * second;
    cout << "\n";
}
istream& operator>>(istream& in, Rectangle& p) {
    in >> p.first >> p.second;
    return in;
}
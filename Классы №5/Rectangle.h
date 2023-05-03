#pragma once
// ѕроизводный класс Rectangle
#include "Pair.h"
#include <fstream>
class Rectangle : public Pair
{
public:
    Rectangle(); // конструктор без параметров
    Rectangle(int l, int w); // конструктор с параметрами
    Rectangle(const Rectangle&); // конструктор копировани€
    ~Rectangle() {}; // деструктор
    void Show();//функци€ дл€ просмотра атрибутов класса с помощью указател€
    int getArea(); // метод дл€ вычислени€ площади
    int getPerimeter(); // метод дл€ вычислени€ периметра
    friend istream& operator>>(istream& in, Rectangle& p); // перегрузка операции ввода объекта
};

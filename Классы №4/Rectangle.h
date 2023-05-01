// Производный класс Rectangle
#include "Pair.h"
class Rectangle : public Pair
{
public:
    Rectangle(); // конструктор без параметров
    Rectangle(int l, int w); // конструктор с параметрами
    Rectangle(const Rectangle&); // конструктор копирования
    ~Rectangle() {}; // деструктор
    int getArea(); // метод для вычисления площади
    int getPerimeter(); // метод для вычисления периметра
};
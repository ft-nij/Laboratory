#include <iostream>
#include "Vector.h"
using namespace std;
//Тестирование операторов :
int main() {
    setlocale(0, "rus");
    Vector a(3);
    a[0] = 1;
    a[1] = 2;
    a[2] = 3;
    cout << "Вектор а = " << a << endl;
    Vector b(3);
    b[0] = 4;
    b[1] = 5;
    b[2] = 6;
    cout << "Вектор b = " << b << endl;
    Vector c = a + b;
    cout << "Сумма векторов = " << c << endl;
    cout << "Введите размер вектора d: ";
    Vector d;
    cin >> d;
    cout << "Вектор d = " << d << endl;
    cout << "Размер вектора d: " << d.getSize() << endl;
    cout << "Количество элементов в векторе d:";
    for (Vector::Iterator it = d.begin(); it != d.end(); ++it)
    {
        cout << ' ' << *it;
    }
    cout << endl;
    cout << "Введите индекс: ";
    int index;
    cin >> index;
    Vector::Iterator it = d.begin();
    if (index < d.getSize())
    {
        for (int i = 1; i <= index; i++)
        {
            ++it;
        }
        cout << "Элемент под индексом " << index << ": " << *it << endl;
    }
    else
    {
        cout << "Такого индекса нет!" << endl;
    }
    return 0;
}
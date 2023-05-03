#pragma once
#include <iostream>
#include <fstream>
#include "Object.h"
using namespace std;
class Pair : public Object
{
public:
    // конструктор без параметров
    Pair(void);
    // конструктор с параметрами
    Pair(int f, int c);
    // конструктор копирования
    Pair(const Pair&);
    // деструктор
    virtual ~Pair(void) {};
    //функция для просмотра атрибутов класса с помощью указателя
    void Show();
    // модификаторы
    void setFirst(int f);
    void setSecond(int c);
    // селекторы
    int getFirst() { return first; };
    int getSecond() { return second; };
    Pair& operator=(const Pair&); // перегрузка операции присваивания
    friend ostream& operator<<(ostream& os, const Pair& p); // перегрузка операции вывода объекта
    friend istream& operator>>(istream& is, Pair& p); // перегрузка операции ввода объекта
protected:
    int first;
    int second;
};
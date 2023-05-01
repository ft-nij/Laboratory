#include <iostream>
#include <fstream>
using namespace std;
class Pair
{
public:
    // конструктор без параметров
    Pair();
    // конструктор с параметрами
    Pair(int f, int c);
    // конструктор копирования
    Pair(const Pair&);
    // деструктор
    virtual ~Pair(void) {};
    // модификаторы
    void setFirst(int f);
    void setSecond(int c);
    // селекторы
    int getFirst() { return first; };
    int getSecond() { return second; };
    // метод для вычисления произведения чисел
    int getProduct();
    Pair& operator=(const Pair&); // перегрузка операции присваивания
    friend ostream& operator<<(ostream& os, const Pair& p); // перегрузка операции вывода объекта
    friend istream& operator>>(istream& is, Pair& p); // перегрузка операции ввода объекта
protected:
    int first;
    int second;
};
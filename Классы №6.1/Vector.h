#include <iostream>
#include <fstream>
class Vector {
private:
    int* data; // указатель на массив элементов
    int size; // размер вектора
public:
    Vector(); // конструктор по умолчанию
    Vector(int s); // конструктор с параметром
    Vector(const Vector& other); // конструктор копирования
    ~Vector(); // деструктор
    int getSize() const; // метод, возвращающий размер вектора
    void pushBack(int value); // метод, добавляющий элемент в конец вектора
    int& operator[](int index); // оператор доступа по индексу
    const int& operator[](int index) const; // оператор доступа по индексу для константного объекта
    Vector& operator=(const Vector& other); // оператор присваивания
    friend Vector operator+(const Vector& a, const Vector& b); // оператор сложения векторов
    friend std::ostream& operator<<(std::ostream& out, const Vector& v); // оператор вывода вектора в поток
    friend std::istream& operator>>(std::istream& in, Vector& v); // оператор ввода вектора из потока
    class Iterator { // класс-итератор
    private:
        int* ptr; // указатель на текущий элемент
    public:
        Iterator(int* p = nullptr) : ptr(p) {}
        Iterator& operator++() { // оператор перехода к следующему элементу
            ++ptr;
            return *this;
        }
        int& operator*() const { // оператор доступа к текущему элементу
            return *ptr;
        }
        bool operator!=(const Iterator& other) const { // оператор сравнения
            return ptr != other.ptr;
        }
    };
    Iterator begin() const { // метод, возвращающий итератор на первый элемент
        return Iterator(data);
    }
    Iterator end() const { // метод, возвращающий итератор на элемент, следующий за последним
        return Iterator(data + size);
    }
};




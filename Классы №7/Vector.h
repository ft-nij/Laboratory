#pragma once
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
using namespace std;
Vector::Vector() : data(nullptr), size(0) {}
Vector::Vector(int s) : data(new int[s]), size(s) {}
Vector::Vector(const Vector& other) : data(new int[other.size]), size(other.size) {
    for (int i = 0; i < size; ++i) {
        data[i] = other.data[i];
    }
}
Vector::~Vector() {
    delete[] data;
}
int Vector::getSize() const {
    return size;
}
void Vector::pushBack(int value) {
    int* newData = new int[size + 1];
    for (int i = 0; i < size; ++i) {
        newData[i] = data[i];
    }
    newData[size] = value;
    delete[] data;
    data = newData;
    ++size;
}
int& Vector::operator[](int index) {
    return data[index];
}
const int& Vector::operator[](int index) const {
    return data[index];
}
Vector& Vector::operator=(const Vector& other) {
    if (this != &other) {
        delete[] data;
        data = new int[other.size];
        size = other.size;
        for (int i = 0; i < size; ++i) {
            data[i] = other.data[i];
        }
    }
    return *this;
}
Vector operator+(const Vector& a, const Vector& b) {
    if (a.size != b.size) {
        throw logic_error("Вектора имеют разные размеры!");
    }
    Vector result(a.size);
    for (int i = 0; i < a.size; ++i) {
        result[i] = a[i] + b[i];
    }
    return result;
}
ostream& operator<<(ostream& out, const Vector& v) {
    for (int i = 0; i < v.size; ++i) {
        out << v[i] << ' ';
    }
    return out;
}
istream& operator>>(istream& in, Vector& v) {
    int size;
    in >> size;
    Vector temp(size);
    for (int i = 0; i < size; ++i) {
        in >> temp[i];
    }
    v = temp;
    return in;
}

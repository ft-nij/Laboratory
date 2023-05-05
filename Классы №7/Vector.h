#pragma once
#include <iostream>
#include <fstream>
class Vector {
private:
    int* data; // ��������� �� ������ ���������
    int size; // ������ �������
public:
    Vector(); // ����������� �� ���������
    Vector(int s); // ����������� � ����������
    Vector(const Vector& other); // ����������� �����������
    ~Vector(); // ����������
    int getSize() const; // �����, ������������ ������ �������
    void pushBack(int value); // �����, ����������� ������� � ����� �������
    int& operator[](int index); // �������� ������� �� �������
    const int& operator[](int index) const; // �������� ������� �� ������� ��� ������������ �������
    Vector& operator=(const Vector& other); // �������� ������������
    friend Vector operator+(const Vector& a, const Vector& b); // �������� �������� ��������
    friend std::ostream& operator<<(std::ostream& out, const Vector& v); // �������� ������ ������� � �����
    friend std::istream& operator>>(std::istream& in, Vector& v); // �������� ����� ������� �� ������
    class Iterator { // �����-��������
    private:
        int* ptr; // ��������� �� ������� �������
    public:
        Iterator(int* p = nullptr) : ptr(p) {}
        Iterator& operator++() { // �������� �������� � ���������� ��������
            ++ptr;
            return *this;
        }
        int& operator*() const { // �������� ������� � �������� ��������
            return *ptr;
        }
        bool operator!=(const Iterator& other) const { // �������� ���������
            return ptr != other.ptr;
        }
    };
    Iterator begin() const { // �����, ������������ �������� �� ������ �������
        return Iterator(data);
    }
    Iterator end() const { // �����, ������������ �������� �� �������, ��������� �� ���������
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
        throw logic_error("������� ����� ������ �������!");
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

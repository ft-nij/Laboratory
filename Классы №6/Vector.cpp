#include "Vector.h"
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

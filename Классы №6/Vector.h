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




#pragma once
// ����������� ����� Rectangle
#include "Pair.h"
#include <fstream>
class Rectangle : public Pair
{
public:
    Rectangle(); // ����������� ��� ����������
    Rectangle(int l, int w); // ����������� � �����������
    Rectangle(const Rectangle&); // ����������� �����������
    ~Rectangle() {}; // ����������
    void Show();//������� ��� ��������� ��������� ������ � ������� ���������
    int getArea(); // ����� ��� ���������� �������
    int getPerimeter(); // ����� ��� ���������� ���������
    friend istream& operator>>(istream& in, Rectangle& p); // ���������� �������� ����� �������
};

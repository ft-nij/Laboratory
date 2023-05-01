// ����������� ����� Rectangle
#include "Pair.h"
class Rectangle : public Pair
{
public:
    Rectangle(); // ����������� ��� ����������
    Rectangle(int l, int w); // ����������� � �����������
    Rectangle(const Rectangle&); // ����������� �����������
    ~Rectangle() {}; // ����������
    int getArea(); // ����� ��� ���������� �������
    int getPerimeter(); // ����� ��� ���������� ���������
};
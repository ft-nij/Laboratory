// ����������� ����� Rectangle
#include "Pair.h"
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
};
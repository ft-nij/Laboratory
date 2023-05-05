#include "Vector.h"
#include "Time.h"
#include <iostream>
using namespace std;
int main()
{
    setlocale(0, "rus");
    Vector a(3);
    a[0] = 1;
    a[1] = 2;
    a[2] = 3;
    cout << "������ � = " << a << endl;
    Vector b(3);
    b[0] = 4;
    b[1] = 5;
    b[2] = 6;
    cout << "������ b = " << b << endl;
    Vector c = a + b;
    cout << "����� �������� = " << c << endl;
    cout << "������� ������ ������� d: ";
    Vector d;
    cin >> d;
    cout << "������ d = " << d << endl;
    cout << "������ ������� d: " << d.getSize() << endl;
    cout << "���������� ��������� � ������� d:";
    for (Vector::Iterator it = d.begin(); it != d.end(); ++it)
    {
        cout << ' ' << *it;
    }
    cout << endl;
    cout << "������� ������: ";
    int index;
    cin >> index;
    Vector::Iterator it = d.begin();
    if (index < d.getSize())
    {
        for (int i = 1; i <= index; i++)
        {
            ++it;
        }
        cout << "������� ��� �������� " << index << ": " << *it << endl;
    }
    else
    {
        cout << "������ ������� ���!" << endl;
    }
    Time t;
    cin >> t;
    cout << t;
	return 0;
}
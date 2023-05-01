#include "Pair.h"
using namespace std;
Pair::Pair()
{
    first = 0;
    second = 0;
}
Pair::Pair(int f, int s) {
    first = f;
    second = s;
}
Pair::Pair(const Pair& other) {
    first = other.first;
    second = other.second;
}
//���������� - �������
void Pair::setFirst(int f) {
    first = f;
}
void Pair::setSecond(int s) {
    second = s;
}
//���������� �������� ������������ :
Pair& Pair::operator=(const Pair& other) {
    if (this == &other) return *this;

    first = other.first;
    second = other.second;
    return *this;
}
//���������� �������� ����� � ������ :
ostream& operator<<(ostream& os, const Pair& p) {
    os << "(" << p.first << ", " << p.second << ")";
    return os;
}
istream& operator>>(istream& is, Pair& p) {
    is >> p.first >> p.second;
    return is;
}
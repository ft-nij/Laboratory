#include "Vector.h"
#include "Error.h"
#include <iostream>
using namespace std;
Vector::Vector(int s)
{
	if (s > MAX_SIZE) throw error("Vector length more than MAXSIZE\n");
	size = s;
	beg = new int[s];
	for (int i = 0; i < size; i++)
		beg[i] = 0;
}
Vector::Vector(const Vector& v)
{
	size = v.size;
	beg = new int[size];
	for (int i = 0; i < size; i++)
		beg[i] = v.beg[i];
}
Vector::~Vector()
{
	if (beg != 0) delete[]beg;
}
Vector::Vector(int s, int* mas)
{
	if (s > MAX_SIZE) throw error("Vector length more than MAXSIZE\n");
	size = s;
	beg = new int[size];
	for (int i = 0; i < size; i++)
		beg[i] = mas[i];
}
const Vector& Vector::operator =(const Vector& v)
{
	if (this == &v)return *this;
	if (beg != 0) delete[]beg;
	size = v.size;
	beg = new int[size];
	for (int i = 0; i < size; i++)
		beg[i] = v.beg[i];
	return*this;
}
ostream& operator<<(ostream& out, const Vector& v)
{
	if (v.size == 0) out << "Empty\n";
	else
	{
		for (int i = 0; i < v.size; i++)
			out << v.beg[i] << " ";
		out << endl;
	}
	return out;
}
istream& operator >>(istream& in, Vector& v)
{
	for (int i = 0; i < v.size; i++)
	{
		cout << ">";
		in >> v.beg[i];
	}
	return in;
}
int Vector::operator [](int i)
{
	if (i < 0) throw error("index <0");
	if (i >= size) throw error("index>size");
	return beg[i];
}
Vector Vector::operator-(int b) {
	if (b > size) {
		throw out_of_range("Cannot remove more elements than vector size!");
	}
	size -= b;
}
Vector Vector::operator+(int a) {
	if (size + a > MAX_SIZE) {
		throw out_of_range("Cannot add more elements than maximum vector size!");
	}
	size += a;
}
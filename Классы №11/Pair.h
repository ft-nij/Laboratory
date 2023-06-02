#pragma once
#include <iostream>
using namespace std;
class Pair
{
public:
	int a;
	double b;
	friend istream& operator>>(istream& in, Pair& p);			
	friend ostream& operator<<(ostream& out, const Pair& p);	

	Pair(int a, double b);										
	Pair();														
	Pair(const Pair& p);										
	~Pair();													
	Pair& operator=(const Pair& p);								
	Pair operator-(const Pair& p);							
	Pair& operator+(int a);										
	Pair& operator+(double b);									
	Pair& operator++();											
	Pair operator++(int);									
	Pair operator+(const Pair& p);
	bool operator!=(const Pair& p) { return !((this->a == p.a) && (this->b == p.b)); }
	bool operator==(const Pair& p) { return ((this->a == p.a) && (this->b == p.b)); }
	bool operator>(const Pair& p) { return (this->a > p.a) && (this->b > p.b); }
	bool operator>=(const Pair& p) { return (this->a >= p.a) && (this->b >= p.b); }
	bool operator<=(const Pair& p) { return (this->a <= p.a) && (this->b <= p.b); }
	bool operator<(const Pair& p) { return (this->a < p.a) && (this->b < p.b); }
	Pair operator * (Pair& pair)
	{
		Pair new_pair;
		new_pair.a = this->a * pair.a;
		new_pair.b = this->b * pair.b;
		return new_pair;
	}
};

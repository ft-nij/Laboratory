#pragma once
#include <iostream>
using namespace std;

struct Node
{
	Node* prev = nullptr, * next = nullptr;
	int data = 0;
};

class Iterator
{
	friend class Stack;
	Node* elem;
public:
	Iterator() { elem = nullptr; }
	Iterator(const Iterator& it) { elem = it.elem; }
	Iterator& operator=(const Iterator& a)
	{
		elem = a.elem;
		return *this;
	}
	bool operator==(const Iterator& it) { return elem == it.elem; }
	bool operator!=(const Iterator& it) { return elem != it.elem; };
	Iterator& operator++()
	{
		elem = elem->next;
		return *this;
	};
	Iterator& operator--()
	{
		elem = elem->prev;
		return *this;
	}
	Iterator& operator+(const int& a)
	{
		for (int i = 0; i < a; i++) elem = elem->next;
		return *this;
	}
	Iterator& operator-(const int& a)
	{
		for (int i = 0; i < a; i++) elem = elem->prev;
		return *this;
	}
	int& operator *() const { return elem->data; }

};

class Stack
{
	int size;
	Node* head = nullptr, * tail = nullptr;
	Iterator beg, end;
public:
	Stack();
	Stack(int s, int k = 0);
	Stack(const Stack&);
	~Stack();
	int front();
	void push(int data);
	void pop();
	bool empty();
	Stack& operator=(const Stack&);
	int& operator[](int index);
	int& operator()();
	friend ostream& operator <<(ostream&, const Stack&);
	friend istream& operator >>(istream&, const Stack&);
	Iterator first() { return beg; }
	Iterator last() { return end; }
};

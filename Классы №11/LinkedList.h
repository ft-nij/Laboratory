#pragma once
#include <iostream>
#include <algorithm>		
#include "Error.h"

using namespace std;
template<typename T>
struct Point
{
	T num;							
	Point* next = nullptr;			
};

template <typename T>
class Iterator
{
private:
	Point<T>* elem = nullptr;		
public:
	Iterator() { elem = nullptr; }
	Iterator(Point<T>* point) { elem = point; }
	Iterator(const Iterator& it) { elem = it.elem; };
	bool operator == (const Iterator& it) { return elem == it.elem; }
	bool operator != (const Iterator& it) { return elem != it.elem; }
	Iterator& operator ++ ();								
	Iterator operator ++ (int);									
	Iterator& operator + (int n);						
	T operator * () const;										
};

template <typename T>
T Iterator<T>::operator * () const
{
	if (elem)
		return elem->num;
	else
		throw IndexError2();
}

template <typename T>
Iterator<T>& Iterator<T>::operator ++ ()
{
	if (elem == nullptr) throw IndexError2();
	elem = elem->next;
	return *this;
}

template <typename T>
Iterator<T> Iterator<T>::operator ++ (int)
{
	if (elem == nullptr) throw IndexError2();
	Iterator<T> temp(elem);
	++(*this);
	return temp;
}

template <typename T>
Iterator<T>& Iterator<T>::operator + (int n)
{
	for (int i = 0; i < n; i++)
	{
		if (elem == nullptr) throw IndexError2();
		elem = elem->next;
	}
	return *this;
}






template <typename T>
class LinkedList
{
private:
	size_t size = 0;					
	Point<T>* head = nullptr;	
	Point<T>* top = nullptr;						

	void output(Point<T>* obj) const;
	void show() const;
	
public:
	friend ostream& operator<<(ostream& out, const LinkedList<T>& list)
	{
		list.show();
		return out;
	}
	friend istream& operator>>(istream& in, LinkedList<T>& list)
	{
		T k;
		in >> k;
		list.push(k);
		return in;
	}
	LinkedList();										
	LinkedList(size_t s, T k);						
	~LinkedList();									
	LinkedList(const LinkedList<T>& list);				
	T& operator [](int index) const;					
	LinkedList& operator =(const LinkedList<T>& list);	
	LinkedList operator * (LinkedList<T>& list);		
	int operator ()() { return size; };					
	void push(T k);									
	T pop();										
	Iterator<T> begin() { return Iterator<T>(head); }	
	Iterator<T> end() { return Iterator<T>(top->next); }

};



template <typename T>
LinkedList<T>::LinkedList()
{
	head = nullptr;
	top = nullptr;
	size = 0;
}

template <typename T>
LinkedList<T>::LinkedList(size_t s, T k)
{
	size = s;
	if (size != 0) {
		
		Point<T>* obj = new Point<T>;
		obj->num = k;
		head = obj;
		Point<T>* temp = head;
		for (int i = size - 1; i != 0; i--)
		{
			obj = new Point<T>;
			temp->next = obj;
			obj->num = k;
			temp = obj;
		}
		top = obj;

	}
}

template <typename T>
void LinkedList<T>::push(T k)
{

	if (size == 0)
	{
		head = new Point<T>;
		head->num = k;
		top = head;

	}
	
	else {
		Point<T>* obj = new Point<T>;
		top->next = obj;
		obj->num = k;
		top = obj;
	}
	size++;
}
template <typename T>
T LinkedList<T>::pop()
{
	if (size == 0) throw EmptySizeError();
	T k = head->num;
	Point<T>* temp = head;
	head = head->next;
	size--;
	delete temp;
	return k;
}
template <typename T>
LinkedList<T>::~LinkedList()
{
	cout << endl << "Вызван деструктор!" << endl << endl;
	while (head != nullptr)
	{
		pop();
	}
}

template <typename T>
void LinkedList<T>::output(Point<T>* obj) const
{
	cout << obj->num << " ";
	if (obj == top) return;
	output(obj->next);
}
template <typename T>
void LinkedList<T>::show() const
{
	if (size == 0) cout << "Список пуст" << endl;
	else output(head);
}
template <typename T>
T& LinkedList<T>::operator[](int index) const
{
	if (index == 0 && size == 0) throw IndexError();
	if (index < 0) throw IndexError1();
	if (index >= size) throw IndexError2();
	Point<T>* temp = head;
	int count = 0;
	while (temp != nullptr)
	{
		if (count == index)
			return temp->num;
		temp = temp->next;
		++count;
	}
}

template <typename T>
LinkedList<T>::LinkedList(const LinkedList<T>& list)
{
	for (int i = 0; i < list.size; i++)
	{
		this->push(list[i]);
	}
}
template <typename T>
LinkedList<T>& LinkedList<T>::operator =(const LinkedList<T>& list)
{
	
	int size_temp = size;

	for (int i = 0; i < size_temp; i++)
	{
		this->pop();
	}
	
	for (int i = 0; i < list.size; i++)
	{
		this->push(list[i]);
	}
	return *this;
}

template <typename T>
LinkedList<T> LinkedList<T>::operator * (LinkedList<T>& list)
{
	T nulik;
	nulik = 0;
	LinkedList<T> new_list;
	for (int i = 0; i < min((int)size, list()); i++)
	{
		new_list.push((*this)[i] * list[i]);
	}
	for (int i = 0; i < max((int)size, list()) - min((int)size, list()); i++)
	{
		new_list.push(nulik);
	}
	return new_list;
}
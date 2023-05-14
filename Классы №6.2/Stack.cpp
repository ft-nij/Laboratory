#include "Stack.h"
#include "Stack.h"
#include <iostream>
#include <ctime>
using namespace std;

Stack::Stack(int s, int k)
{
	srand(time(NULL));
	size = s;
	Node* node = new Node;
	node->data = k;
	head = node;
	tail = node;
	for (int i = 0; i < size - 1; i++)
	{
		Node* node = new Node;
		node->data = rand() % 10;
		tail->next = node;
		node->prev = tail;
		tail = node;
	}
	tail->next = nullptr;
	beg.elem = head;
	end.elem = tail->next;
}

Stack::Stack() {
	size = 0;
	head = nullptr;
	tail = nullptr;
}
Stack::Stack(const Stack& a) {
	Node* node = a.head;
	while (node != nullptr) {
		push(node->data);
		node = node->next;
	}
	beg = a.beg;
	end = a.end;
}

Stack::~Stack() {
	Node* curr = head;
	while (curr != nullptr) {
		head = curr->next;
		delete curr;
		curr = head;
	}
}

void Stack::push(int data) {
	Node* newNode = new Node;
	newNode->data = data;
	if (head == nullptr) {
		head = newNode;
		tail = newNode;
		size++;
		end.elem = tail->next;
	}
	else {
		tail->next = newNode;
		newNode->prev = tail;
		tail = newNode;
		size++;
		end.elem = tail->next;
	}
}


int Stack::front() { return head->data; }


void Stack::pop() {
	if (head != nullptr) {
		Node* curr = head;
		head = curr->next;
		delete curr;
		head->prev = nullptr;
		size--;
		beg.elem = head;
	}
}

bool Stack::empty() { return size == 0; }


Stack& Stack::operator=(const Stack& a) {
	if (this == &a) return *this;
	Node* node = head;
	while (node != nullptr) {
		head = node->next;
		delete node;
		node = head;
		size--;
	}
	Node* curr = a.head;
	while (curr != nullptr) {
		push(curr->data);
		curr = curr->next;
	}
	beg = a.beg;
	end = a.end;
	return *this;
}

int& Stack::operator[](int index) {
	if (index < size && index >= 0) {
		Node* curr = head;
		for (int i = 0; i < index; i++) curr = curr->next;
		return curr->data;
	}
	else {
		cout << "Wrond index!" << endl;
		exit(222);
	}

}

int& Stack::operator ()()
{
	return size;
}
ostream& operator<<(ostream& out, const Stack& a) {
	Node* curr = a.head;
	while (curr != nullptr) {
		cout << curr->data << " ";
		curr = curr->next;
	}
	cout << endl;
	return out;
}
istream& operator>>(istream& in, const Stack& a)
{
	Node* curr = a.head;
	while (curr != nullptr)
	{
		in >> curr->data;
		curr = curr->next;
	}
	return in;
}
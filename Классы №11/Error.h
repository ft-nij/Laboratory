#pragma once
#include <string>
#include <iostream>
using namespace std;
class Error
{
public:
	virtual void what() {};
};

class IndexError :public Error 
{
protected:
	string msg;
public:
	IndexError() { msg = "Index Error\n"; }
	virtual void what() { cout << msg; }
};
class SizeError :public Error {
protected:
	string msg;
public:
	SizeError() { msg = "size error\n"; }
	virtual void what() { cout << msg; }
};

class EmptySizeError :public SizeError 
{
protected:
	string msg_;
public:
	EmptySizeError() { SizeError(); msg_ = "Лист пуст\n"; }
	virtual void what() { cout << msg << msg_; }
};
class IndexError1 :public IndexError
{
protected:
	string msg_;
public:
	IndexError1() { IndexError(); msg_ = "index <0\n"; }
	virtual void what() { cout << msg << msg_; }
};
class IndexError2 :public IndexError 
{
protected:
	string msg_;
public:
	IndexError2() { IndexError(); msg_ = "index>size\n"; }
	virtual void what() { cout << msg << msg_; }
};
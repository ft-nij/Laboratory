#pragma once
#include <iostream>
#include "Vector.h"
#include "Event.h"
#include "Employee.h"
#include <string>
using namespace std;
class Dialog :public vector {
protected:
	int EndState;
public:
	Dialog();
	virtual ~Dialog();
	virtual void GetEvent(TEvent&);
	virtual int Execute();
	virtual void HandleEvent(TEvent&);
	virtual void ClearEvent(TEvent&);
	bool Valid();
	void EndExec();
};
#include "Dialog.h"
#include <iostream>
#include "Vector.h"
#include "Event.h"
#include "Employee.h"
#include <string>
using namespace std;
Dialog::Dialog() {
	EndState = 0;
};
Dialog::~Dialog() {
};
void Dialog::GetEvent(TEvent& event) {
	string opint = "+-szqam";
	string s, param;
	char code;
	cout << "\n¬аш выбор: ";
	cin >> s;
	code = s[0];
	if (opint.find(code) >= 0) {
		event.what = evMessage;
		switch (code)
		{
		case 'm':event.command = cmMake; break;
		case '+':event.command = cmAdd; break;
		case '-':event.command = cmDel; break;
		case 's':event.command = cmShow; break;
		case 'q':event.command = cmQuit; break;
		case 'z':event.command = cmGet; break;
		}
		if (s.length() > 1) {
			param = s.substr(1, s.length() - 1);
			int A = atoi(param.c_str());
			event.a = A;
		}
	}
	else event.what = evNothing;
};
int Dialog::Execute() {
	TEvent event;
	do {
		EndState = 0;
		GetEvent(event);
		HandleEvent(event);
	} while (Valid());
	return EndState;
};
bool Dialog::Valid() {
	return EndState == 0;

};
void Dialog::ClearEvent(TEvent& event) {
	event.what = evNothing;
};
void Dialog::EndExec() {
	EndState = 1;
};
void Dialog::HandleEvent(TEvent& event) {
	if (event.what == evMessage) {
		switch (event.command) {
		case cmMake:
			cout << "¬ведите размер группы: ";
			cin >> size;
			beg = new object * [size];
			cur = 0;
			ClearEvent(event);
			break;
		case cmAdd:
			add();
			ClearEvent(event);
			break;
		case cmDel:
			del();
			ClearEvent(event);
			break;
		case cmShow:
			show();
			ClearEvent(event);
			break;
		case cmQuit:EndExec();
			ClearEvent(event);
			break;
		case cmGet:Get_Name();
			ClearEvent(event);
			break;
		};
	}
};
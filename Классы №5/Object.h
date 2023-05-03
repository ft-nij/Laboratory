#pragma once
class Object
{
public:
	Object() {};
	~Object(void) {};
	virtual void Show() = 0; // чисто вируальная функция
};
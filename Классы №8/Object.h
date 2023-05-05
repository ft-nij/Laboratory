#pragma once
class object {
public:
	object(void);
	virtual void show() = 0;
	virtual void input() = 0;
	virtual ~object(void);
};

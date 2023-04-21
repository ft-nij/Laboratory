#include <iostream>
#include <string>
using namespace std;
class Student
{
	//атрибуты
	string FIO;
	string Group;
	float avg;
public:
	Student();//конструктор без параметров
	Student(string, string, float);//конструктор с параметрами
	Student(const Student&);//конструктор копирования
	~Student();//деструктор
	string get_FIO();//селектор
	void set_FIO(string);//модификатор
	string get_Group();//селектор
	void set_Group(string); //модификатор
	float get_avg();//селектор
	void set_avg(float); //модификатор
	void show();//просмотр атрибутов
};


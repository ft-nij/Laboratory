#include <iostream>
#include <string>
using namespace std;
class Student
{
	//��������
	string FIO;
	string Group;
	float avg;
public:
	Student();//����������� ��� ����������
	Student(string, string, float);//����������� � �����������
	Student(const Student&);//����������� �����������
	~Student();//����������
	string get_FIO();//��������
	void set_FIO(string);//�����������
	string get_Group();//��������
	void set_Group(string); //�����������
	float get_avg();//��������
	void set_avg(float); //�����������
	void show();//�������� ���������
};


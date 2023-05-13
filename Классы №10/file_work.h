#pragma once
#include "Time.h"
#include <iostream>
#include <fstream>
#include <string>
using namespace std;
int make_file(const char* f_minutes)
{
	fstream stream(f_minutes, ios::out | ios::trunc);//открыть для записи
	if (!stream)return -1;//ошибка открытия файла
	int n;
	Time p;
	cout << "Введите количество элементов: "; cin >> n;
	for (int i = 0; i < n; i++)
	{
		cin >> p;//ввод атрибутов объекта из стандартного потока
		stream << p << "\n";//запись объекта в файловый поток
	}
	stream.close();//закрыть поток
	return n;//вернуть количество записанных объектов
}
int print_file(const char* f_minutes)
{
	fstream stream(f_minutes, ios::in);//открыть для чтения
	if (!stream)return -1;//ошибка открытия файла
	Time p; int i = 0;
	while (stream >> p)
	{
		cout << p << "\n";
		i++;
	}
	stream.close();
	return i;
}
int del_file(const char* f_minutes, int k)
{
	fstream temp("temp", ios::out);//открыть для записи
	fstream stream(f_minutes, ios::in);//открыть для чтения
	if (!stream)return -1;//ошибка открытия файла
	int i = 0; Time p;
	while (stream >> p)//пока нет конца файла выполняем чтение объекта
	{
		//если прочитан признак конца файла,то выход из цикла
		if (stream.eof())break;
		i++;
		//если номер объекта не равен k, то записываем его во вспомогательый файл
		if (i != k) temp << p;
	}
	//закрыть файлы
	stream.close(); temp.close();
	remove(f_minutes);//удалить старый файл
	rename("temp", f_minutes);// переименовать temp
	return i;//количество прочитанных 
}
int add_file(const char* f_minutes, int count, Time pp)
{
	fstream temp("temp", ios::out);//открыть для записи
	fstream stream(f_minutes, ios::in);//открыть для чтения
	if (!stream)return -1;//ошибка открытия файла
	Time p; int i = 0, l = 0;
	while (stream >> p)
	{
		if (stream.eof())break;
		i++;
		if (i == 1)
		{
			for (int j = 0; j < count; j++)
			{
				Time new_Time;
				cout << "Введите новое время" << endl;
				cin >> new_Time;
				temp << new_Time;
				l++;
			}
		}
		temp << p;
	}
	stream.close(); temp.close();
	remove(f_minutes);
	rename("temp", f_minutes);
	return l;//количество добавленных
}
int add_end(const char* f_minutes, Time pp)
{
	fstream stream(f_minutes, ios::app);//открыть для добавления
	if (!stream)return -1;//ошибка открытия файла
	stream << pp; //записать новую запись
	return 1;
}
int change_file(const char* f_minutes, int k, Time pp)
{
	fstream temp("temp", ios::out);//открыть для записи
	fstream stream(f_minutes, ios::in);//открыть для чтения
	if (!stream)return -1;//ошибка открытия файла
	Time p; int i = 0, l = 0;
	char x;
	while (stream >> p)
	{
		if (stream.eof())break;
		i++;
		if (i == k)
		{
			cout << p << "Если хотите продолжить, подтвердите[y/n]?\n";
			cin >> x;
			if (x == 'n' || x == 'N')break;
			temp << pp;
			l++;
		}
		else temp << p;
	}
	stream.close(); temp.close();
	remove(f_minutes);
	rename("temp", f_minutes);
	return l;//количество измененных элементов
}
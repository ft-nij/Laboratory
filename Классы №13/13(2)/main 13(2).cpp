#include <iostream>
#include <queue>
#include <vector>
#include "Pair.h"
#include <algorithm>
#include <functional>
using namespace std;

bool Search_Pair(Pair a, double t)
{
	double sum = a.get_first() + a.get_second();
	if (a.get_first() == t || a.get_second() == t || sum == t) return true;
	return false;
}
ostream& operator<<(ostream& out, priority_queue<Pair>& l)
{
	vector<Pair> copied;
	Pair elem;
	int num = l.size();
	for (size_t i = 0; i < num; ++i)
	{
		elem = l.top();
		cout << elem << endl;
		copied.push_back(elem);
		l.pop();
	}
	int k = 0;
	for (int i = 0; i < copied.size(); ++i)
	{
		l.push(copied[k++]);
	}
	copied.clear();
	return out;
}

void menu(const int c, priority_queue<Pair>& l)
{
	switch (c)
	{
		//arithmetical mean
	case 1:
	{
		cout << l << endl << endl;
		Pair sum;
		Pair elem;
		vector<Pair> copied;
		while (!l.empty())
		{
			elem = l.top();
			copied.push_back(elem);
			l.pop();
		}
		for_each(copied.begin(), copied.end(), [&sum](Pair& p) {sum += p; });
		sum.set_first(round(sum.get_first() / copied.size() * 100) / 100);
		sum.set_second(round(sum.get_second() / copied.size() * 100) / 100);
		cout << "� ������ ���� ��������� ������� ��������������: " << sum << endl;
		l.push(sum);
		while (!copied.empty())
		{
			l.push(copied[copied.size() - 1]);
			copied.pop_back();
		}
		cout << l << endl;
		break;
	}
	//find element 
	case 2:
	{
		cout << l << "\n\n";
		cout << "������� ���� �� ����� ���� (���� � �����): ";
		double value;
		cin >> value;
		auto f = [value](priority_queue<Pair>& q)
		{
			vector<Pair> copied;
			Pair elem;
			bool flag = false;
			int num = q.size();
			for (int i = 0; i < num && !flag; ++i)
			{
				elem = q.top();
				if (Search_Pair(elem, value))
				{
					flag = true;
					cout << "������� �������: " << elem << endl;
				}
				copied.emplace_back(elem);
				q.pop();
			}
			if (!flag) cout << "����� ������� �� ��� ������!\n";
			while (!copied.empty())
			{
				q.push(copied[copied.size() - 1]);
				copied.pop_back();
			}
		};
		f(l);
		break;
	}
	// sort
	case 3:
	{
		cout << l << endl;
		cout << "������� <, ����� ������������� �� �����������\n";
		cout << "������� >, ����� ������������� �� ��������\n";
		char sorting;
		cin >> sorting;
		if (sorting == '>') cout << l << endl;
		else if (sorting == '<') {
			vector<Pair> copied;
			Pair elem;
			int num = l.size();
			for (int i = 0; i < num; ++i) {
				elem = l.top();
				copied.push_back(elem);
				l.pop();
			}
			sort(copied.begin(), copied.end(), mem_fun_ref(&Pair::operator<));
			for_each(copied.begin(), copied.end(), [](Pair& p) {cout << p << endl; });
			while (!copied.empty())
			{
				l.push(copied[copied.size() - 1]);
				copied.pop_back();
			}
		}
		else cout << "����� ���������� �� �������������\n";
		break;
	}
	//delete from range
	case 4:
	{
		cout << l << endl;
		Pair elem;
		vector<Pair> copied;
		while (!l.empty())
		{
			elem = l.top();
			copied.push_back(elem);
			l.pop();
		}
		Pair first, second;
		cout << "\n������� ������ �������\n";
		cin >> first;
		cout << "\n������� ������ �������\n";
		cin >> second;
		double f = first.sum();
		double s = second.sum();
		if (f > s) swap(f, s);

		auto n = remove_if(copied.begin(), copied.end(), [f, s](Pair& p)
			{
				return p.sum() >= f && p.sum() <= s;
			}
		);
		copied.erase(n, copied.end());

		while (!copied.empty())
		{
			l.push(copied[copied.size() - 1]);
			copied.pop_back();
		}
		cout << "���� ���� ������� " << endl;
		break;
	}
	//Pair + sum(min, max)
	case 5:
	{
		cout << l << endl << endl;
		Pair elem;
		vector<Pair> copied;
		while (!l.empty())
		{
			elem = l.top();
			copied.push_back(elem);
			l.pop();
		}
		auto mini = copied[copied.size() - 1];
		auto maxi = copied[0];
		cout << "����������� �������� (�� �����): " << mini << endl;
		cout << "������������ �������� (�� �����): " << maxi << endl;
		Pair sum;
		sum = mini + maxi;
		for_each(copied.begin(), copied.end(), [&sum](Pair& p) {p += sum; });
		while (!copied.empty())
		{
			l.push(copied[copied.size() - 1]);
			copied.pop_back();
		}
		cout << endl << l << endl;
		break;
	}
	//print
	case 6:
	{
		cout << l << endl;
		break;
	}
	//exit
	case 0:
		exit(777);
	default:
	{
		cout << "������� ����� �������� �����!\n";
	}
	}
}


int main()
{
	setlocale(LC_ALL, "ru");
	srand(time(NULL));
	int n, c = 1;
	cout << "������� ������ ������: ";
	cin >> n;
	priority_queue<Pair> l;
	Pair p;
	for (int i = 0; i < n; ++i)
	{
		p.create_rand();
		l.push(p);
	}
	cout << l << endl;

	while (c != 0)
	{
		system("pause");
		system("cls");
		cout << "1. ����� ������� ��������������" << endl;
		cout << "2. ����� ����" << endl;
		cout << "3. ������������� ���������" << endl;
		cout << "4. ������� ����" << endl;
		cout << "5. �������� �� ���� ��������� ������ ����� ����������� � �����������" << endl;
		cout << "6. ������� ������ �� �����" << endl;
		cout << "0. �����" << endl;
		cout << "�������� ��������: ";
		cin >> c;
		system("cls");
		menu(c, l);
	}
	return 0;
}
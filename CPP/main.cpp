/****************************************************************
 * Project: coding-interviews
 * File: main.cpp
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: Main entry.
****************************************************************/

#include <iostream>
#include <string>
#include "Find.h"

using namespace std;

template <class T>
inline void Test()
{
	string name = typeid(T).name();
	int pb = name.find(' ');
	int pe = name.find(':');
	string taskName = "Test " + name.substr(pb + 1, pe - pb - 1);
	cout << "**** Begin " << taskName << " ****" << endl;
	if (T().Run())
	{
		cout << taskName << " Pass" << endl;
	}
	else
	{
		cout << taskName << " Fail" << endl;
	}
	cout << "**** End " << taskName << " ****" << endl;
}

int main()
{
	Test<Find::Tester>();
}

#include <iostream>
#include <string>
#include "Solution.h"
#include "Test.h"

template <class T>
inline void Test(Solution& solution)
{
	const char* name = typeid(T).name();
	const char* name2 = strchr(name, ' ');
	const char* realName = name2 ? name2 + 1 : name;
	cout << "Begin " << realName << endl;
	if (T().Test(solution))
	{
		cout << realName << " Pass" << endl;
	}
	else
	{
		cout << realName << " Fail" << endl;
	}
	cout << "End " << realName << endl;
}

int main()
{
	Solution solution;
	Test<TestFind>(solution);
}

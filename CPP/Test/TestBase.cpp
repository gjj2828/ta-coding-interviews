#include <iostream>
#include "TestBase.h"

void TestBase::Print(vector<vector<int>>& array)
{
	int row = array.size();
	for (int i = 0; i < row; i++)
	{
		int col = array[i].size();
		for (int j = 0; j < col; j++)
		{
			cout << array[i][j] << '\t';
		}
		cout << endl;
	}
}

//int TestFind::Rand(vector<vector<int>>& array, int row, int col, int exclude)
//{
//	int base = 0;
//	base = row > 0 ? max(array[row - 1][col], base) : base;
//	base = col > 0 ? max(array[row][col - 1], base) : base;
//	//return base + rand() % 10 + 2;
//	int rnd = base + rand() % 10 + 2;
//	if (rnd == exclude) {
//		rnd++;
//	}
//	return rnd;
//}

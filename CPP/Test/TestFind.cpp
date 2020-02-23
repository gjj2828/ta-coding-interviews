#include <algorithm>
#include <iostream>
#include "TestFind.h"

TestFind::TestFind(): mArray(mRowNum)
{
	for (int i = 0; i < mRowNum; i++)
	{
		for (int j = 0; j < mColNum; j++)
		{
			mArray[i].push_back(0);
		}
	}
}

bool TestFind::Test(Solution& solution)
{
	for (int i = 0; i < mRowNum; i++)
	{
		for (int j = 0; j < mColNum; j++)
		{
			Rand(i, j);
		}
	}
	Print(mArray);
	int max = mArray[mRowNum - 1][mColNum - 1] + 10;
	for (int i = 0; i < max; i++)
	{
		bool bFound = false;
		for (int r = 0; r < mRowNum; r++)
		{
			for (int c = 0; c < mColNum; c++)
			{
				if (mArray[r][c] == i)
				{
					bFound = true;
					break;
				}
			}
		}
		if (solution.Find(i, mArray) == bFound)
		{
			if (i == 0)
			{
				cout << "Test pass:";
			}
			else
			{
				cout << ' ' << i;
			}
		}
		else
		{
			if (i > 0)
			{
				cout << endl;
			}
			cout << "Test fail: ";
			if (bFound)
			{
				cout << "Should find ";
			}
			else
			{
				cout << "Should not find ";
			}
			cout << i << endl;
			return false;
		}
	}
	cout << endl;
	return true;
}

void TestFind::Rand(int row, int col)
{
	int base = 0;
	base = row > 0 ? max(mArray[row - 1][col], base) : base;
	base = col > 0 ? max(mArray[row][col - 1], base) : base;
	mArray[row][col] = base + rand() % 10 + 2;
}

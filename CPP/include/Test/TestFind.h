#pragma once
#include <vector>
#include "Solution.h"
#include "TestBase.h"

using namespace std;

class TestFind:
	public TestBase
{
public:
	TestFind();
	bool Test(Solution& solution);

private:
	const int mRowNum = 10;
	const int mColNum = 10;
	vector<vector<int>> mArray;

	void Rand(int row, int col);
};


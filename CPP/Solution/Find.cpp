#include <algorithm>
#include <iostream>
#include <vector>
#include "Find.h"
#include "TestBase.h"

using namespace std;

// 查找 数组 二维数组中的查找
namespace Find
{
	class Solution
	{
	public:
		bool Find(int target, vector<vector<int>> array) {
			int r = array.size() - 1;
			unsigned int c = 0;
			while (r >= 0) {
				vector<int>& row = array[r];
				if (c < row.size()) {
					if (target == row[c]) return true;
					target > row[c] ? c++ : r--;
				}
				else {
					r--;
				}
			}
			return false;
		}
	};

	class Test : public TestBase
	{
	public:
		Test() : mArray(mRowNum)
		{
			for (int i = 0; i < mRowNum; i++)
			{
				for (int j = 0; j < mColNum; j++)
				{
					mArray[i].push_back(0);
				}
			}
		}

		bool Run()
		{
			Solution solution;

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
					if (bFound) break;
				}
				if (solution.Find(i, mArray) == bFound)
				{
					if (i == 0)
					{
						cout << "Test pass:";
					}
					cout << ' ' << i;
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

	private:
		const int mRowNum = 10;
		const int mColNum = 10;
		vector<vector<int>> mArray;

		void Rand(int row, int col)
		{
			int base = 0;
			base = row > 0 ? max(mArray[row - 1][col], base) : base;
			base = col > 0 ? max(mArray[row][col - 1], base) : base;
			mArray[row][col] = base + rand() % 10 + 2;
		}
	};

	bool Tester::Run()
	{
		return Test().Run();
	}

	//namespace Find {
	//	//bool Test() {
	//	//	return false;
	//	//}
	//
	//
	//	Test::Test() : mArray(mRowNum)
	//	{
	//		for (int i = 0; i < mRowNum; i++)
	//		{
	//			for (int j = 0; j < mColNum; j++)
	//			{
	//				mArray[i].push_back(0);
	//			}
	//		}
	//	}
	//
	//	bool Test::Run()
	//	{
	//		Solution solution;
	//
	//		for (int i = 0; i < mRowNum; i++)
	//		{
	//			for (int j = 0; j < mColNum; j++)
	//			{
	//				Rand(i, j);
	//			}
	//		}
	//		Print(mArray);
	//		int max = mArray[mRowNum - 1][mColNum - 1] + 10;
	//		for (int i = 0; i < max; i++)
	//		{
	//			bool bFound = false;
	//			for (int r = 0; r < mRowNum; r++)
	//			{
	//				for (int c = 0; c < mColNum; c++)
	//				{
	//					if (mArray[r][c] == i)
	//					{
	//						bFound = true;
	//						break;
	//					}
	//				}
	//				if (bFound) break;
	//			}
	//			if (solution.Find(i, mArray) == bFound)
	//			{
	//				if (i == 0)
	//				{
	//					cout << "Test pass:";
	//				}
	//				cout << ' ' << i;
	//			}
	//			else
	//			{
	//				if (i > 0)
	//				{
	//					cout << endl;
	//				}
	//				cout << "Test fail: ";
	//				if (bFound)
	//				{
	//					cout << "Should find ";
	//				}
	//				else
	//				{
	//					cout << "Should not find ";
	//				}
	//				cout << i << endl;
	//				return false;
	//			}
	//		}
	//		cout << endl;
	//		return true;
	//	}
	//
	//	void Test::Rand(int row, int col)
	//	{
	//		int base = 0;
	//		base = row > 0 ? max(mArray[row - 1][col], base) : base;
	//		base = col > 0 ? max(mArray[row][col - 1], base) : base;
	//		mArray[row][col] = base + rand() % 10 + 2;
	//	}
	//}
}

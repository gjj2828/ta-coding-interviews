#include <algorithm>
#include <iostream>
#include <vector>
//#include "Test.h"

using namespace std;

class Solution
{
public:
	// 数组 二维数组中的查找
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

class Test {
//private:
//	class TestBase {
//	public:
//		void Test(Solution& solution) {
//			const char* name = GetName();
//			printf("Begin %s\n", name);
//			if (DoTest(solution)) {
//				printf("%s Pass\n", name);
//			} else {
//				printf("%s Fail\n", name);
//			}
//			printf("End %s\n", name);
//		}
//	private:
//		virtual const char* GetName() = 0;
//		virtual bool DoTest(Solution& solution) = 0;
//	};
//
//	class TestFind : public TestBase {
//	private:
//		const char* GetName() {
//			return "TestFind";
//		}
//
//		bool DoTest(Solution& solution) {
//			return true;
//		}
//	};
//
//	TestFind mTestFind;
public:
	//void TestFind(Solution& solution) {
	//	mTestFind.Test(solution);
	//}
	bool TestFind(Solution& solution) {
		int r = 10, c = 10, n = rand() % 100;
		vector<vector<int>> array(r);
		for (int i = 0; i < r; i++) {
			for (int j = 0; j < c; j++) {
				array[i].push_back(Rand(array, i, j, n));
			}
		}
		Print(array);
		int tr = rand() % r;
		int tc = rand() % c;
		int ttarget = array[tr][tc];
		//return solution.Find(ttarget, array) && !solution.Find(ttarget + 1, array);
		if (!solution.Find(ttarget, array)) {
			printf("Can not find %d!\n", ttarget);
			return false;
		}
		if (solution.Find(n, array)) {
			printf("Should not find %d!\n", ttarget + 1);
			return false;
		}
		return true;
	}

private:
	int Rand(vector<vector<int>>& array, int row, int col, int n)
	{
		int base = 0;
		base = row > 0 ? max(array[row - 1][col], base) : base;
		base = col > 0 ? max(array[row][col - 1], base) : base;
		//return base + rand() % 10 + 2;
		int rnd = base + rand() % 10 + 2;
		if (rnd == n) {
			rnd++;
		}
		return rnd;
	}

	void Print(vector<vector<int>>& array)
	{
		int row = array.size();
		for (int i = 0; i < row; i++)
		{
			int col = array[i].size();
			for (int j = 0; j < col; j++)
			{
				printf("%d\t", array[i][j]);
			}
			printf("\n");
		}
	}
};

#define TEST(name) \
	printf("Begin %s\n", #name); \
	if (test.##name(solution)) { \
		printf("%s Pass\n", #name); \
	} else { \
		printf("%s Fail\n", #name); \
	} \
	printf("End %s\n\n", #name);

int main() {
	Solution solution;
	Test test;
	//test.TestFind(solution);
	TEST(TestFind)
	return 0;
}

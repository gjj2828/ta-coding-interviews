//#include <vector>
//#include "Solution.h"
//
//using namespace std;
//
////class Solution
////{
////public:
////	// 数组 二维数组中的查找
////	bool Find(int target, vector<vector<int>> array) {
////		int r = array.size() - 1;
////		int c = 0;
////		while (r >= 0) {
////			vector<int> &row = array[r];
////			if (c < (int)row.size()) {
////				if (target == row[c]) return true;
////				target > row[c] ? c++ : r--;
////			}
////			else {
////				r--;
////			}
////		}
////		return false;
////	}
////};
//
//bool Solution::Find(int target, vector<vector<int>> array) {
//	int r = array.size() - 1;
//	int c = 0;
//	while (r >= 0) {
//		vector<int>& row = array[r];
//		if (c < (int)row.size()) {
//			if (target == row[c]) return true;
//			target > row[c] ? c++ : r--;
//		}
//		else {
//			r--;
//		}
//	}
//	return false;
//}

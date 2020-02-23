#include <vector>
#include "Solution.h"

using namespace std;

bool Solution::Find(int target, vector<vector<int>> array) {
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

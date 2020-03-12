#include "replaceSpace.h"

namespace replaceSpace
{
	class Solution {
	public:
		void replaceSpace(char* str, int length) {
			int spaceNum = 0;
			for (int i = 0; i < length; i++)
			{
				if (str[i] == ' ')
				{
					spaceNum++;
				}
			}

			if (spaceNum == 0) return;

			int newLength = length + spaceNum * 2;
			str[newLength] = '\0';
			for (int i = length - 1, j = newLength - 1; i >= 0 && i < j; i--)
			{
				if (str[i] == ' ')
				{
					str[j--] = '0';
					str[j--] = '2';
					str[j--] = '%';
				}
				else
				{
					str[j--] = str[i];
				}
			}
		}
	};
}
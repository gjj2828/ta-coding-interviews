#include "Solution.h"

#pragma once
class Test
{
private:
	class TestBase {
	public:
		void Test(Solution& solution);
	private:
		virtual const char* GetName() = 0;
		virtual bool DoTest(Solution& solution) = 0;
	};
	class TestFind : public TestBase {
	private:
		const char* GetName();
		bool DoTest(Solution& solution);
	};
	TestFind mTestFind;
public:
    void TestFind(Solution& solution);
};

//class Test
//{
//public:
//	void TestFind(Solution& solution);
//};

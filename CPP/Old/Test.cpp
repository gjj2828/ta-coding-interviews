//#include <stdio.h>
//#include <vector>
//#include "Test.h"
//#include "Solution.h"
//
////class Test {
////private:
////	class TestBase {
////	public:
////		void Test(Solution& solution) {
////			const char* name = GetName();
////			printf("Begin %s\n", name);
////			if (DoTest(solution)) {
////				printf("%s Pass\n", name);
////			} else {
////				printf("%s Fail\n", name);
////			}
////			printf("End %s\n", name);
////		}
////	private:
////		virtual const char* GetName() = 0;
////		virtual bool DoTest(Solution& solution) = 0;
////	};
////
////	class TestFind : public TestBase {
////	private:
////		const char* GetName() {
////			return "TestFind";
////		}
////
////		bool DoTest(Solution& solution) {
////			return true;
////		}
////	};
////
////	TestFind mTestFind;
////public:
////	void TestFind(Solution& solution) {
////		mTestFind.Test(solution);
////	}
////};
//
//void Test::TestBase::Test(Solution& solution) {
//	const char* name = GetName();
//	printf("Begin %s\n", name);
//	if (DoTest(solution)) {
//		printf("%s Pass\n", name);
//	} else {
//		printf("%s Fail\n", name);
//	}
//	printf("End %s\n", name);
//}
//
//const char* Test::TestFind::GetName() {
//	return "TestFind";
//}
//
//bool Test::TestFind::DoTest(Solution& solution) {
//	return true;
//}
//
//void Test::TestFind(Solution& solution) {
//	mTestFind.Test(solution);
//}

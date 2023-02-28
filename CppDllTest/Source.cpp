#include <iostream>
#include "TunerWrapper.h"
using namespace std;

int main()
{
	char test[] = "test.dll";
	char model[] = "testModel";
	char error[100];
	std::cout << "Testing...\n";
	try
	{
		std::cout << "Error code: " << addControllerWrapper(0, test, model, 0, 3, 0, 2048, error);
	}
	catch (exception ex)
	{
		std::cout << ex.what() << std::endl;
	}
}
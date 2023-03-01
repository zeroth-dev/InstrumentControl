#include <iostream>
#include <stdlib.h>
#include "TunerCommands.h"
using namespace std;
#ifdef _DEBUG
int main()
{
	char ctrlDriver[] = "C:\\Users\\korisnik\\Desktop\\Maury\\MLibV04\\Drivers\\Tun986.dll\0";
	char tunerFile[] = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun\0";
	std::cout << "Testing...\n";
#else
int main(int argc, char *argv[])
{

	char *ctrlDriver = argv[1];
	char *tunerFile = argv[2];
	double real = atof(argv[3]);
	double imag = atof(argv[4]);
	char* usingImpedance = argv[5];

#endif
	try
	{
		
		int errCode = initTuner(ctrlDriver, tunerFile);
		if (errCode != 0)
		{
			return errCode;
		}

		if (!std::strcmp(usingImpedance, "true"))
		{
			errCode = moveTunerToImpedance(real, imag, 2.4);
		}
		else
		{
			errCode = moveTunerToReflection(real, imag, 2.4);
		}
		if (errCode != 0)
		{
			return errCode;
		}
	}
	catch (exception ex)
	{
		std::cout << ex.what() << std::endl;
	}
	return 0;
}
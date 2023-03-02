#include <iostream>
#include <stdlib.h>
#include "TunerCommands.h"
using namespace std;

int main(int argc, char *argv[])
{
	// .exe init {tuner|controller}
	// .exe init controller ctrlDrv gpibAddress
	// .exe init tuner tunCharFile tunerNumber={0|1} inputTuner={0|1}
	// .exe deinit controller
	// .exe deinit tuner tunerNumber
	// .exe set tunerNumber={0|1} double(gammaX/Zreal) double(gammaY/Zimag) double(freq) usingImpedance={0|1}

	// .exe init ctrlDrv gpibAddress tunCharfile tunerNumber inputTuner real imag freq usingImpedance
#ifndef _DEBUG
	string init = argv[1];
	char *driver = argv[2];
	string gpibAddress = argv[3];
	char *tunCharFile = argv[4];
	int tunNum = std::atoi(argv[5]);
	string input = argv[6];
	double real = atof(argv[7]);
	double imag = atof(argv[8]);
	double freq = atof(argv[9]);
	bool usingImpedance = std::atoi(argv[10]);
#else
	string init = "init";
	char driver[] = "C:/Users/korisnik/Desktop/Maury/MLibV04/Drivers/Tun986.dll";
	string gpibAddress = "3";
	char tunCharFile[] = "C:\\Users\\korisnik\\Downloads\\Tuner files\\to send\\to send\\karakterizacija_fund_2400MHz_all.tun";
	int tunNum = 0;
	string input = "0";
	double real = 50;
	double imag = 0;
	double freq = 2.4;
	bool usingImpedance = true;
	argc = 6;
#endif
	short errorCode = 0;
	// Init command
	if (init == "init")
	{
		initController(driver, std::atoi(gpibAddress.c_str()));
		initTuner(tunCharFile, tunNum, std::atoi(input.c_str()));
		if (usingImpedance)
		{
			errorCode = moveTunerToImpedance(tunNum, real, imag, freq);
		}
		else
		{
			errorCode = moveTunerToReflection(tunNum, real, imag, freq);
		}

		std::cout << "Error code: " << errorCode << std::endl;
	}
	// set command - used to set tuner to specified impedance or reflection
	else if (!std::strcmp(argv[1], "set"))
	{
		// .exe set tunerNumber={0|1} double(gammaX/Zreal) double(gammaY/Zimag) double(freq) usingImpedance={true|false}
		int tunerNumber = std::atoi(argv[2]);
		double real = atof(argv[3]);
		double imag = atof(argv[4]);
		double freq = atof(argv[5]);
		bool usingImpedance = std::atoi(argv[6]);
		try
		{
			if (usingImpedance)
			{
				errorCode = moveTunerToImpedance(tunerNumber, real, imag, freq);
			}
			else
			{
				errorCode = moveTunerToReflection(tunerNumber, real, imag, freq);
			}
		}
		catch (exception ex)
		{
			std::cout << ex.what() << std::endl;
		}
	}
	else
	{
		std::cout << "Invalid arguments passed" << std::endl;
		return -1;
	}


	
	return errorCode;
}
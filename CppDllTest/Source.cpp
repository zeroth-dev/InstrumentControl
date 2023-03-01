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
	short errorCode = 0;

	// Init command
	if (!std::strcmp(argv[1], "init"))
	{
		if (!std::strcmp(argv[2], "controller"))
		{
			if (argc < 5) 
			{
				std::cout << "Not enough arguments" << std::endl;
				return -1;
			}
			errorCode = initController(argv[3], std::atoi(argv[4]));
		}
		else if (!std::strcmp(argv[2], "tuner"))
		{
			if (argc < 6)
			{
				std::cout << "Not enough arguments" << std::endl;
				return -1;
			}
			errorCode = initTuner(argv[3], std::atoi(argv[4]), std::atoi(argv[5]));
		}
		else
		{
			std::cout << "Invalid arguments passed" << std::endl;
			return -1;
		}
	}
	// deinit command
	else if (!std::strcmp(argv[1], "deinit"))
	{
		if (!std::strcmp(argv[2], "controller"))
		{
			deinitController();
		}
		else if (!std::strcmp(argv[2], "tuner"))
		{
			deinitTuner(std::atoi(argv[3]));
		}
		else
		{
			std::cout << "Invalid arguments passed" << std::endl;
			return -1;
		}
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
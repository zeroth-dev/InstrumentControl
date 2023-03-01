#include "TunerCommands.h"

#define CTRL_MODEL "MT986B02"
#define CTRL_SERIAL 2048
#define TUNER_MODEL "MT982EU30"
#define OUTPUT_TUNER 1333
#define INPUT_TUNER 1331
#define OUTPUT_PORT 2
#define INPUT_PORT 1

short initTuner(char ctrlDrv[], char tunCharFile[])
{
	char ctrlModel[] = CTRL_MODEL;
	char errorString[500];
	short errorCode = addController(0, ctrlDrv, ctrlModel, 0, 3, 0, CTRL_SERIAL, errorString);

	if (errorCode != 0)
	{
		std::cout << "Error has occured:\n" << errorString << std::endl;
		return errorCode;
	}

	char tunerModel[] = TUNER_MODEL;
	short no_of_motors = 0;
	long max_range[3];
	double fmin = 0;
	double fmax = 0;
	double fcrossover = 0;
	errorCode = addTuner(0, tunerModel, OUTPUT_TUNER, 0, OUTPUT_PORT, &no_of_motors, max_range, &fmin, &fmax, &fcrossover, errorString);

	if (errorCode != 0)
	{
		std::cout << "Error has occured:\n" << errorString << std::endl;
		return errorCode;
	}

	errorCode = readTunerDataFile(0, tunCharFile, tunerModel, errorString);

	if (errorCode != 0)
	{
		std::cout << "Error has occured:\n" << errorString << std::endl;
		return errorCode;
	}
	return 0;
}

short moveTunerToReflection(double gammaReal, double gammaImag, double freq)
{

	char errorString[500];
	short errorCode = 0;
	long carr = 0;
	long p1 = 0;
	long p2 = 0;
	double s11_x[100];
	double s11_y[100];
	double s12_x[100];
	double s12_y[100];
	double s21_x[100];
	double s21_y[100];
	double s22_x[100];
	double s22_y[100];
	errorCode = getTunerReflData(0, 0, freq, 0, 0, gammaReal, gammaImag, &carr, &p1, &p2,
		s11_x, s11_y, s21_x, s21_y, s12_x, s12_y, s22_x, s22_y, errorString);

	if (errorCode != 0)
	{
		std::cout << "Error has occured:\n" << errorString << std::endl;
		return errorCode;
	}

	errorCode = moveTuner(0, carr, p1, p2, errorString);


	if (errorCode != 0)
	{
		std::cout << "Error has occured:\n" << errorString << std::endl;
		return errorCode;
	}
	return errorCode;
}

short moveTunerToImpedance(double real, double imag, double freq)
{
	// Reflection coefficient calculation
	double readDiff = real - 50;
	double imagDiff = imag;

	double realNum = real * real + imag * imag - 50 * 50;
	double imagNum = 100;
	double denominator = (real + 50) * (real + 50) + imag * imag;

	double gammaReal = realNum / denominator;
	double gammaImag = imagNum / denominator;

	return moveTunerToReflection(gammaReal, gammaImag, freq);

}
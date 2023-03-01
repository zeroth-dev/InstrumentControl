#pragma once
#include "TunerWrapper.h"
#include <iostream>


short initController(char ctrlDrv[], short gpibAddress);

short initTuner(char tunCharFile[], int tunerNumber, bool inputTuner);

short deinitController();

short deinitTuner(short tunerNumber);

short moveTunerToReflection(short tunerNumber, double gammaReal, double gammaImag, double freq);

short moveTunerToImpedance(short tunerNumber, double real, double imag, double freq);
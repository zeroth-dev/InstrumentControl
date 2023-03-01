#pragma once
#include "TunerWrapper.h"
#include <iostream>

short initTuner(char ctrlDrv[], char tunCharFile[]);

short moveTunerToReflection(double gammaReal, double gammaImag, double freq);

short moveTunerToImpedance(double real, double imag, double freq);
#pragma once
#include "TunerWrapper.h"
short addTunerWrapper(short tuner_number, char model[], short serial_number, short ctlr_num, short ctlr_port, short* no_of_motors, long max_range[], double* fmin, double* fmax, double* fcrossover, char error_string[])
{
	return add_tuner(tuner_number, model, serial_number, ctlr_num, ctlr_port, no_of_motors, max_range, fmin, fmax, fcrossover, error_string);
}

short addControllerWrapper(short controller_number, char driver[], char model[], int timeout, int address, long delay_ms, short serial_number, char error_string[])
{
	return add_controller(controller_number, driver, model, timeout, address, delay_ms, serial_number, error_string);
}

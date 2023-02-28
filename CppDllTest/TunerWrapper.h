#pragma once

#include <MLibTuners.h>
extern "C"
{
	short addTunerWrapper(short tuner_number, char model[],
		short serial_number, short ctlr_num, short ctlr_port, short* no_of_motors,
		long max_range[], double* fmin, double* fmax, double* fcrossover,
		char error_string[]);

	short addControllerWrapper(short controller_number,
		char driver[], char model[], int timeout, int address, long delay_ms,
		short serial_number, char error_string[]);
}
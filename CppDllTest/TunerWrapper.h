#pragma once

#include <MLibTuners.h>
extern "C"
{
	short addTuner(short tuner_number, char model[],
		short serial_number, short ctlr_num, short ctlr_port, short* no_of_motors,
		long max_range[], double* fmin, double* fmax, double* fcrossover,
		char error_string[]);

	short addController(short controller_number,
		char driver[], char model[], int timeout, int address, long delay_ms,
		short serial_number, char error_string[]);

	short addTunerEx(short tuner_number, char driver[],
		char model[], short serial_number, int address, char error_string[]);

	short initTuners(char error_string[]);

	short readTunerDataFile(short tuner_number,
		char fname[], char tuner_model[], char error_string[]);

	short moveTuner(short tuner_number,
		long carr, long p1, long p2, char error_string[]);

	short getTunerInitStatus(short tuner_number,
		short* status, char error_string[]);

	short getTunerReflData(short tuner_number,
		short interp_mode, double freq, double gamma_termination_x,
		double gamma_termination_y, double gamma_target_x, double gamma_target_y,
		long* carr, long* p1, long* p2, double s11_x[], double s11_y[],
		double s21_x[], double s21_y[], double s12_x[], double s12_y[],
		double s22_x[], double s22_y[], char error_string[]);

	short deleteTuner(short tuner_number);

	short deleteController(short controller_number);
}
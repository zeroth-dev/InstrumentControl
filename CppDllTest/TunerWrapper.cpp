#pragma once
#include "TunerWrapper.h"
short addTuner(short tuner_number, char model[], short serial_number, short ctlr_num, short ctlr_port, short* no_of_motors, long max_range[], double* fmin, double* fmax, double* fcrossover, char error_string[])
{
	return add_tuner(tuner_number, model, serial_number, ctlr_num, ctlr_port, no_of_motors, max_range, fmin, fmax, fcrossover, error_string);
}

short addController(short controller_number, char driver[], char model[], int timeout, int address, long delay_ms, short serial_number, char error_string[])
{
	return add_controller(controller_number, driver, model, timeout, address, delay_ms, serial_number, error_string);
}

short addTunerEx(short tuner_number, char driver[], char model[], short serial_number, int address, char error_string[])
{
	return add_tuner_ex(tuner_number, driver, model, serial_number, address, error_string);
}

short initTuners(char error_string[])
{
	return init_tuners(error_string);
}

short readTunerDataFile(short tuner_number, char fname[], char tuner_model[], char error_string[])
{
	return read_tuner_data_file(tuner_number, fname, tuner_model, error_string);
}

short moveTuner(short tuner_number, long carr, long p1, long p2, char error_string[])
{
	return move_tuner(tuner_number, carr, p1, p2, error_string);
}

short getTunerInitStatus(short tuner_number, short* status, char error_string[])
{
	return get_tuner_init_status(tuner_number, status, error_string);
}

short getTunerReflData(short tuner_number, short interp_mode, double freq, double gamma_termination_x, double gamma_termination_y, double gamma_target_x, double gamma_target_y, long* carr, long* p1, long* p2, double s11_x[], double s11_y[], double s21_x[], double s21_y[], double s12_x[], double s12_y[], double s22_x[], double s22_y[], char error_string[])
{
	return get_tuner_refl_data(tuner_number, interp_mode, freq, gamma_termination_x, gamma_termination_y, gamma_target_x,
								gamma_target_y, carr, p1, p2, s11_x, s11_y, s21_x, s21_y, s12_x, s12_y, 
								s22_x, s22_y, error_string);
}

short deleteTuner(short tuner_number)
{
	return delete_tuner(tuner_number);
}

short deleteController(short controller_number)
{
	return delete_controller(controller_number);
}

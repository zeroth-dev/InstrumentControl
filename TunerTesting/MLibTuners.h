#ifndef _MLibTuners_H      // setup for including once!
#define _MLibTuners_H

#ifdef MLibTuners_EXPORTS
	#define MLibTuners_API __declspec(dllexport)
#else
	#define MLibTuners_API __declspec(dllimport)
#endif

#ifndef _MAX_TUNER_MOTORS_DEFINED
#define MAX_TUNER_MOTORS 3  // maximum number of motors per tuner
#define _MAX_TUNER_MOTORS_DEFINED
#endif

#define MAX_MODEL_STRING 1024

#ifndef _INSTRUMENT_COMM_TYPE_DEFINED
// Communication type
#define NO_COMM			0     // no direct comm
#define GPIB_COMM		0x01  // uses GPIB (default)
#define USB_COMM		0x02  // uses USB object
#define SERIAL_COMM		0x04  // uses serial port
#define OCX_COMM		0x08  // uses COM object
#define MATHLINK_COMM	0x10  // uses Mathlink to talk to Mathematica object
#define IP_COMM			0x20  // uses IP Adrress
#define _INSTRUMENT_COMM_TYPE_DEFINED
#endif

// ----------------------------------------------------------------------
// Exported functions
extern "C"
{
// Obsolete functions
MLibTuners_API short __stdcall add_tuner(short tuner_number, char model[],
	short serial_number, short ctlr_num, short ctlr_port, short *no_of_motors,
	long max_range[], double *fmin, double *fmax, double *fcrossover,
	char error_string[]);
MLibTuners_API short __stdcall delete_tuner(short tuner_number);
MLibTuners_API short __stdcall add_controller(short controller_number,
	char driver[], char model[], int timeout, int address, long delay_ms,
	short serial_number, char error_string[]);
MLibTuners_API short __stdcall delete_controller(short controller_number);
MLibTuners_API short __stdcall delete_controller_ex(short controller_number,
	char error_string[]);
MLibTuners_API short __stdcall isthere_tuner_controllers(
	int gpib_board_address,char error_string[]);
MLibTuners_API short __stdcall move_tuner(short tuner_number,
	long carr,long p1,long p2, char error_string[]);
MLibTuners_API short __stdcall move_tuners(long carr[], long p1[], long p2[],
	char error_string[]);
MLibTuners_API short __stdcall get_tuner_position(short tuner_number,
	long *carr, long *p1, long *p2, char error_string[]);

// Setup functions
MLibTuners_API void __stdcall get_tuner_driver_version(char version_string[]);
MLibTuners_API short __stdcall get_model_lists(char FileName[],
	char controller_model_string[],	char tuner_model_string[],
	char error_string[]);
MLibTuners_API short __stdcall add_gpib_board(char model[], int timeout,
	int address, long delay_ms, char driver[], char error_string[]);
MLibTuners_API short __stdcall add_tuner_ex(short tuner_number,char driver[],
	char model[],short serial_number,int address,char error_string[]);
MLibTuners_API short __stdcall delete_tuner_ex(short tuner_number,
	char error_string[]);
MLibTuners_API short __stdcall add_controller_ex(short tuner_number,
	char model[], short ctlr_num,short ctlr_port, int timeout, int address,
	long delay_ms, short serial_number, char error_string[]);
MLibTuners_API short __stdcall get_use_controller(short tuner_number,
	char driver[], char model[],short *use_controller,char error_string[]);
MLibTuners_API short __stdcall get_tuner_comm_type(short tuner_number,
	char driver[],short *comm_type,char error_string[]);
MLibTuners_API short __stdcall get_tuner_params(short tuner_number,
	short *num_motors,long max_range[],long z0_posn[],double *freq_min,
	double *freq_max,double *freq_crossover,char error_string[]);

// Initialization / position control functions
MLibTuners_API short __stdcall isthere_tuners(char error_string[]);
MLibTuners_API short __stdcall get_tuner_init_status(short tuner_number,
	short *status,char error_string[]);
MLibTuners_API short __stdcall init_tuners(char error_string[]);
MLibTuners_API short __stdcall move_tuner_ex(short tuner_number,
	long position[], char error_string[]);
MLibTuners_API short __stdcall move_tuners_ex(
	long position[][MAX_TUNER_MOTORS],char error_string[]);
MLibTuners_API short __stdcall get_tuner_position_ex(short tuner_number,
	long position[],char error_string[]);

// Tuner data file functions
MLibTuners_API short __stdcall read_tuner_data_file(short tuner_number,
	char fname[], char tuner_model[], char error_string[]);
MLibTuners_API short __stdcall free_tuner_data(short tuner_number);
MLibTuners_API short __stdcall free_tuner_data_ex(short tuner_number,
	char error_string[]);

// Tuner data / reflection functions
MLibTuners_API short __stdcall get_tuner_freqs(short tuner_number,
	short *numfreq,	double freqs[], char error_string[]);
MLibTuners_API short __stdcall get_tuner_harmonics(short tuner_number,
	double freq, short *num_harmonics, char error_string[]);
MLibTuners_API short __stdcall get_tuner_position_mode(short tuner_number,
	double freq,long carr,long p1,long p2,short *interp_mode,
	char error_string[]);
MLibTuners_API short __stdcall get_tuner_position_spara(short tuner_number,
	double freq,short interp_mode,long *carr,long *p1,long *p2,
	double s11_x[],double s11_y[],double s21_x[], double s21_y[],
	double s12_x[], double s12_y[],double s22_x[], double s22_y[],
	char error_string[]);
MLibTuners_API short __stdcall get_tuner_position_num(short tuner_number,
	double freq,short *num_positions,char error_string[]);
MLibTuners_API short __stdcall get_tuner_position_list(short tuner_number,
	double freq,long carr[],long p1[],long p2[],char error_string[]);
MLibTuners_API short __stdcall get_tuner_refl_posn(short tuner_number,
	short interp_mode, double freq, double gamma_termination_x,
	double gamma_termination_y,	double gamma_target_x, double gamma_target_y,
	long *carr, long *p1, long *p2,	char error_string[]);
MLibTuners_API short __stdcall get_tuner_refl_data(short tuner_number,
	short interp_mode,double freq,double gamma_termination_x,
	double gamma_termination_y,double gamma_target_x,double gamma_target_y,
	long *carr,long *p1,long *p2,double s11_x[], double s11_y[],
	double s21_x[], double s21_y[],double s12_x[], double s12_y[],
	double s22_x[], double s22_y[],char error_string[]);

// Deembedding functions
MLibTuners_API short __stdcall read_spara_file(const char fname[],
	short *spara_valid,short *numfreq,double freq[],
	double s11_x[], double s11_y[], double s21_x[], double s21_y[],
	double s12_x[], double s12_y[], double s22_x[], double s22_y[],
	char error_string[]);
MLibTuners_API short __stdcall set_tuner_deembed_dut(short tuner_number, 
	short numfreq, double freq[], double s11_x[], double s11_y[], 
	double s21_x[], double s21_y[], double s12_x[], double s12_y[], 
	double s22_x[], double s22_y[], char error_string[]);
MLibTuners_API short __stdcall set_tuner_deembed_back(short tuner_number, 
	short numfreq, double freq[], double s11_x[], double s11_y[], 
	double s21_x[], double s21_y[], double s12_x[], double s12_y[], 
	double s22_x[], double s22_y[], char error_string[]);
MLibTuners_API short __stdcall clear_tuner_deembed_dut(short tuner_number,
	char error_string[]);
MLibTuners_API short __stdcall clear_tuner_deembed_back(short tuner_number,
	char error_string[]);
}

#endif	//#ifndef _MLibTuners_H

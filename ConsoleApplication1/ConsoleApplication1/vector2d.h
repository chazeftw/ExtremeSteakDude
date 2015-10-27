#ifndef __v2d__
#define __v2d__

class v2d {
private:
	double x, y;
public:
	// standard constructor
	// builds a vector (a,b)
	v2d(double a, double b);

	// destructor
	~v2d();

	// copy constructor
	// builds a vector that is exactly as v
	v2d(const v2d & v);

	// assignment
	v2d & operator=(const v2d &v);

	// vector addition
	v2d & operator+(const v2d &v);

	// direct product
	double operator*(const v2d &v);

	// scalar multiplication
	v2d & operator*(double k);

	// length
	double length();

};

#endif
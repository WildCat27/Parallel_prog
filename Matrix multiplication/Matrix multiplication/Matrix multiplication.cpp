// Matrix multiplication.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//


#include "pch.h"
#include <iostream>
#include <cstdlib>
#include <ctime>
#include <omp.h>

using namespace std;

void randomiseMatrix(int **matrix, int n, int m) {
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			matrix[i][j] = rand() % 11;
		}
	}
	return;
}

int **Matrix_Initialization(int Size)
{
	int **Matrix = new int*[Size];
	for (int row = 0; row < Size; row++)
	{
		Matrix[row] = new int[Size];
		for (int column = 0; column < Size; column++)
		{
			Matrix[row][column] = 1;
		}
	}
	return Matrix;
}

int **Sequential_Matrix_Multiplication(int **Matrix1, int **Matrix2, int Size)
{
	int **Result = new int*[Size];
	for (int row = 0; row < Size; row++)
	{
		Result[row] = new int[Size];
		for (int column = 0; column < Size; column++)
		{
			int item = 0;
			for (int index = 0; index < Size; index++)
			{
				item += Matrix1[index][column] * Matrix2[row][index];
			}
			Result[row][column] = item;
		}
	}
	return Result;
}

int **Block_Multiplication(int **Matrix1, int **Matrix2, int Size, int x, int y, int width)
{
	int **Result = new int*[width];
	for (int row = 0; row < width; row++)
	{
		Result[row] = new int[width];
		for (int column = 0; column < width; column++)
			Result[row][column] = 0;
	}
	for (int i = 0; i < Size; i++)
	{
		for (int index1 = 0; index1 < width; index1++)
			for (int index2 = 0; index2 < width; index2++)
			{
				int item = 0;
				for (int index = 0; index < width; index++)
				{
					item += Matrix1[x*width + index1][i*width + index] * Matrix2[i*width + index][y*width + index2];
				}
				Result[index1][index2] += item;
			}
	}
	return Result;
}

int **Parallel_Tape_Matrix_Multiplication_Vertical(int Size, int **Matrix1, int **Matrix2)
{
	int **Result = new int*[Size];
	for (int row = 0; row < Size; row++)
	{
		Result[row] = new int[Size];
		for (int column = 0; column < Size; column++)
		{
			Result[row][column] = 0;
		}
	}
	int num_threads, thread_num, tape_width;

#pragma omp parallel private(thread_num) shared(Result)
	{
		num_threads = omp_get_num_threads();
		thread_num = omp_get_thread_num();
		tape_width = Size / num_threads;

		/*if (thread_num < num_threads - 1)
			for (int row1 = thread_num * tape_width; row1 < (thread_num + 1)*tape_width; row1++)
				for (int column2 = 0; column2 < Size; column2++)
					for (int index = 0; index < Size; index++)
					{
						Result[row1][(row1 + column2) % Size] += Matrix1[row1][index] * Matrix2[index][(row1 + column2) % Size];
					}
		else
			for (int row1 = thread_num * tape_width; row1 < Size; row1++)
				for (int column2 = 0; column2 < Size; column2++)
					for (int index = 0; index < Size; index++)
					{
						Result[row1][(row1 + column2) % Size] += Matrix1[row1][index] * Matrix2[index][(row1 + column2) % Size];
					}*/
		if (thread_num < num_threads - 1)
			for (int row1 = thread_num * tape_width; row1 < (thread_num + 1)*tape_width; row1++)
				for (int column2 = 0; column2 < Size; column2++)
					for (int index = 0; index < Size; index++)
					{
						Result[row1][(column2)] += Matrix1[row1][index] * Matrix2[index][(column2)];
					}
		else
			for (int row1 = thread_num * tape_width; row1 < Size; row1++)
				for (int column2 = 0; column2 < Size; column2++)
					for (int index = 0; index < Size; index++)
					{
						Result[row1][(column2)] += Matrix1[row1][index] * Matrix2[index][(column2)];
					}
	}
	return Result;
}

void Write_Matrix(int Size, int **Matrix)
{
	for (int row = 0; row < Size; row++)
	{
		for (int column = 0; column < Size; column++)
			cout << Matrix[row][column] << " ";
		cout << endl;
	}
}

void Matrix_Removal(int Size, int **Matrix)
{
	for (int row = 0; row < Size; row++)
	{
		delete[] Matrix[row];
	}
	delete[] Matrix;
}

int **Parallel_Tape_Matrix_Multiplication_Horizontal(int Size, int **Matrix1, int **Matrix2)
{
	int **Result = new int*[Size];
	for (int row = 0; row < Size; row++)
	{
		Result[row] = new int[Size];
		for (int column = 0; column < Size; column++)
		{
			Result[row][column] = 0;
		}
	}
	int num_threads, thread_num, tape_width;

#pragma omp parallel private(thread_num) shared(Result)
	{
		num_threads = omp_get_num_threads();
		thread_num = omp_get_thread_num();
		tape_width = Size / num_threads;

		/*if (thread_num < num_threads - 1)
			for (int row1 = thread_num * tape_width; row1 < (thread_num + 1)*tape_width; row1++)
				for (int row2 = 0; row2 < Size; row2++)
					for (int index = 0; index < Size; index++)
					{
						Result[row1][index] += Matrix1[row1][index] * Matrix2[(row1 + row2) % Size][index];
					}
		else
			for (int row1 = thread_num * tape_width; row1 < Size; row1++)
				for (int row2 = 0; row2 < Size; row2++)
					for (int index = 0; index < Size; index++)
					{
						Result[row1][index] += Matrix1[row1][index] * Matrix2[(row1 + row2) % Size][index];
					} */
		if (thread_num < num_threads - 1)
			for (int row1 = thread_num * tape_width; row1 < (thread_num + 1)*tape_width; row1++)
				for (int row2 = 0; row2 < Size; row2++)
					for (int index = 0; index < Size; index++)
					{
						Result[row1][index] += Matrix1[row1][index] * Matrix2[(row2)][index];
					}
		else
			for (int row1 = thread_num * tape_width; row1 < Size; row1++)
				for (int row2 = 0; row2 < Size; row2++)
					for (int index = 0; index < Size; index++)
					{
						Result[row1][index] += Matrix1[row1][index] * Matrix2[(row2)][index];
					}
	}
	return Result;
}

int **Parallel_Tape_Matrix_Multiplication_Block(int Size, int **Matrix1, int **Matrix2)
{
	int **Result = new int*[Size];
	for (int row = 0; row < Size; row++)
	{
		Result[row] = new int[Size];
		for (int column = 0; column < Size; column++)
		{
			Result[row][column] = 0;
		}
	}
	int num_threads, thread_num, tape_width;

#pragma omp parallel private(thread_num) shared(Result)
	{
		num_threads = omp_get_num_threads();
		thread_num = omp_get_thread_num();
		tape_width = Size / num_threads;

		//if (thread_num < num_threads - 1)+
				//for (int i = 0; i < num_threads; i++)
		for (int j = 0; j < num_threads; j++)
		{
			int **c = Block_Multiplication(Matrix1, Matrix2, num_threads, thread_num, j, tape_width);
			for (int index1 = 0; index1 < tape_width; index1++)
				for (int index2 = 0; index2 < tape_width; index2++)
					Result[thread_num*tape_width + index1][j*tape_width + index2] += c[index1][index2];
		}
		/*else
			for (int row1 = thread_num * tape_width; row1 < Size; row1++)
				for (int row2 = 0; row2 < Size; row2++)
					for (int index = 0; index < Size; index++)
					{
						Result[row1][index] += Matrix1[row1][index] * Matrix2[(row2)][index];
					}*/
	}
	return Result;
}

int **Par(int Size, int **Matrix1, int **Matrix2)
{
	int **Result = new int*[Size];
	for (int row = 0; row < Size; row++)
	{
		Result[row] = new int[Size];
		for (int column = 0; column < Size; column++)
		{
			Result[row][column] = 0;
		}
	}
	int num_threads = 4, tape_width = Size / num_threads;
	for (int i = 0; i < num_threads; i++)
		for (int j = 0; j < num_threads; j++)
		{
			int **c = Block_Multiplication(Matrix1, Matrix2, num_threads, i, j, tape_width);
			for (int index1 = 0; index1 < tape_width; index1++)
				for (int index2 = 0; index2 < tape_width; index2++)
					Result[i*tape_width + index1][j*tape_width + index2] += c[index1][index2];
		}
	return Result;
}

int Check_Sum(int Size, int **Matrix)
{
	int check_sum = 0;
	for (int row = 0; row < Size; row++)
	{
		for (int column = 0; column < Size; column++)
		{
			check_sum += Matrix[row][column];
		}
	}
	return check_sum;
}

int main()
{
	srand(time(NULL));
	setlocale(LC_CTYPE, "Russian");

	int size = 200;
	int **matrix1, **matrix2, **result, **presult;
	long int sum = 0, psum = 0;

	// Инициализация матриц
	matrix1 = Matrix_Initialization(size);
	matrix2 = Matrix_Initialization(size);

	double time;
	time = omp_get_wtime();

	// Последовательный алгоритм
	result = Sequential_Matrix_Multiplication(matrix1, matrix2, size);

	time = omp_get_wtime() - time;
	cout << "Последовательный алгоритм: " << time << endl;

	sum = Check_Sum(size, result);
	cout << "sum = " << sum << endl;

	time = omp_get_wtime();

	// Ручная параллель
	//presult = Par(size, matrix1, matrix2);
	presult = Parallel_Tape_Matrix_Multiplication_Block(size, matrix1, matrix2);

	time = omp_get_wtime() - time;
	cout << "Ручная параллель: " << time << endl;

	time = omp_get_wtime();

	psum = Check_Sum(size, presult);
	cout << "psum = " << psum << endl;

	//Write_Matrix(size, result);
	//Write_Matrix(size, presult);

	// Завершение работы
	Matrix_Removal(size, matrix1);
	Matrix_Removal(size, matrix2);
	Matrix_Removal(size, result);
	Matrix_Removal(size, presult);

	return 0;
}

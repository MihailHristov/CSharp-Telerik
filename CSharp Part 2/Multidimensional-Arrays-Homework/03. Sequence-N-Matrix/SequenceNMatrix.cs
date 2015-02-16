﻿// Problem 3. Sequence n matrix
/* 
   We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets 
 * of several neighbour elements located on the same line, column or diagonal.
   Write a program that finds the longest sequence of equal strings in the matrix.

Example:
matrix 	                result 		    matrix 	        result
ha 	 fifi 	ho 	 hi     ha, ha, ha      s 	qq 	s       s, s, s
fo 	 ha 	hi 	 xx                     pp 	pp 	s
xxx  ho     ha 	 xx                     pp 	qq 	s
*/

using System;

class SequenceNMatrix
{

    static void Main()
    {
        Console.WriteLine("Autogenerated random matrix: \n");
        Random rnd = new Random();
        int n = rnd.Next(4, 6);
        int m = rnd.Next(4, 6);

        string[] srcSeq = { "ha", "ho", "hi", "fo", "xx", "xxx" };
        string[,] matrix = new string[n, m];
        int count = 1;
        int maxSecq = 1;
        string maxValue = "";

        // fill the matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = srcSeq[rnd.Next(6)];
            }
        }

        // print the matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("{0,4} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();


        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)     //Searching horizontally
            {
                if ((matrix[row, col] == matrix[row, col + 1]))
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count > maxSecq)
                {
                    maxSecq = count;
                    maxValue = matrix[row, col];
                }
            }
            count = 1;
        }


        for (int col = 0; col < matrix.GetLength(1); col++)                 //Searching vertically
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if ((matrix[row, col] == matrix[row + 1, col]))
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count > maxSecq)
                {
                    maxSecq = count;
                    maxValue = matrix[row, col];
                }
            }
            count = 1;
        }


        //Searching diagonally from left to right
        for (int row = 0, col = 0; row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 1; row++, col++)
        {
            if ((matrix[row, col] == matrix[row + 1, col + 1]))
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count > maxSecq)
            {
                maxSecq = count;
                maxValue = matrix[row, col];
            }
        }
        count = 1;


        //Searching diagonally from right to left
        for (int row = 0, col = 0; row < matrix.GetLength(0) - 1 && col > 0; row++, col--)
        {
            if ((matrix[row, col] == matrix[row + 1, col + 1]))
            {
                count++;
            }
            else
            {
                count = 1;
            }
            if (count > maxSecq)
            {
                maxSecq = count;
                maxValue = matrix[row, col];
            }
        }

        // printing the result:
        Console.WriteLine("The longest sequence of equal strings in the matrix is: ");

        for (int i = 0; i < maxSecq; i++)
        {
            if (i < maxSecq - 1)
            {
                Console.Write("{0}, ", maxValue);    
            }
            else
            {
                Console.Write("{0}", maxValue);    
            }
                   
        }
        Console.WriteLine();
    }
}
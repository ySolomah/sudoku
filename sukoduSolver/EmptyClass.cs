using System;
using System.Text;

namespace Core
{
	public class innerSudokuSolver
	{

		public string[,] sudokuSolver(string[,] A)
		{
			string numberString = "0123456789";
			innerSudokuSolver functionCaller = new innerSudokuSolver();
			//Initialization
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					A[i, j] = functionCaller.determineString(A[i, j]);
					//System.Console.WriteLine("{0}", A[i, j]);
				}
			}

			int k = 0;
			int tracker = 0;
			string[,] B = new string[4, 4];
			B = functionCaller.recursiveSolution(A);
			string[,] temp = B;
			while (k == 0)
			{
				tracker = 0;
				for (int m = 0; m < 4; m++)
				{
					for (int n = 0; n < 4; n++)
					{
						if (B[m, n].Length == 1)
						{
							continue;
						}
						else
						{
							tracker = 1;
						}
					}
				}
				if (tracker == 1)
				{
					//System.Console.WriteLine("BEGINNING RECURSIVE FUNCTION CALL");
					B = functionCaller.recursiveSolution(B);
				}
				else
				{
					k = 1;
				}
				if (temp == B)
				{
					break;
				}
				else
				{
					temp = B;
				}
			}

			for (int i = 0; i < 4; i++)
			{
				//System.Console.WriteLine("");
				for (int j = 0; j < 4; j++)
				{
					//System.Console.Write(" {0} ", temp[i, j]);
				}
			}

			return (B);
		}
		private string determineString(string input)
		{
			//System.Console.WriteLine("Now pritning input");
			//System.Console.WriteLine(input);
			if (input.Length == 1 && " 1234 ".Contains(input))
			{
				return (input.Trim());
			}
			//System.Console.WriteLine("Skipped first check");
			if (String.IsNullOrEmpty(input))
			{
				return ("1234");
			}
			else
			{
				//System.Console.WriteLine("Skipped second check");
				return ("1234");
			}
		}
		private string[,] recursiveSolution(string[,] matrixToSolve)
		{
			int x = matrixToSolve.GetLength(0);
			int y = x;

			//System.Console.WriteLine("The length of the matrix is: {0}x{1}", x, y);

			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					//System.Console.WriteLine("My value is: {0}", matrixToSolve[i, j]);
					for (int n = 0; n < y; n++)
					{
						if (n == j)
						{
							//System.Console.WriteLine("Continuing");
							continue;
						}
						else
						{
							//System.Console.WriteLine("In the Else");
							if (matrixToSolve[i, n].Length == 1 && matrixToSolve[i, j].Length != 1)
							{
								//System.Console.WriteLine("Attempting to see containment");

								if (matrixToSolve[i, j].Contains((matrixToSolve[i, n])))
								{
									//System.Console.WriteLine("Indeed, does contain");
									//System.Console.WriteLine("Values of i,j,n: {0},{1},{2} ", i,j,n);
									//System.Console.WriteLine(" {0} ", matrixToSolve[i,n] );
									matrixToSolve[i, j] = matrixToSolve[i, j].Replace(matrixToSolve[i, n], string.Empty);
									//System.Console.WriteLine("Finished Replacement");
									//System.Console.WriteLine("{0}, length {1}", matrixToSolve[i,j], matrixToSolve[i,j].Length);

								}
							}
						}
					}
					for (int m = 0; m < x; m++)
					{
						if (m == i)
						{
							continue;
						}
						else
						{
							if (matrixToSolve[m, j].Length == 1 && matrixToSolve[i, j].Length != 1)
							{
								if (matrixToSolve[i, j].Contains((matrixToSolve[m, j])))
								{
									matrixToSolve[i, j] = matrixToSolve[i, j].Replace(matrixToSolve[m, j], string.Empty);
									//System.Console.WriteLine("Finished Replacement");
									//System.Console.WriteLine("{0}, length {1}", matrixToSolve[i,j], matrixToSolve[i,j].Length);
								}
							}
						}
					}

					for (int k = 1; k < 5; k++)
					{
						int neighbourNoNumber = 0;
						System.Console.WriteLine("Neighbour value {0}", neighbourNoNumber);
						for (int h = 2 * (i / 2); h < 2 * (i / 2) + 2; h++)
						{
							for (int g = 2 * (j / 2); g < 2 * (j / 2) + 2; g++)
							{
								if (matrixToSolve[i, j].Length == 1 || (h == i && g == j))
								{
									//System.Console.WriteLine("Continuing");
									continue;
								}
								else
								{
									if (matrixToSolve[h, g].Contains(Convert.ToString(k)))
									{
										neighbourNoNumber = 1;
									}
								}
							}
						}
						System.Console.WriteLine("Value of neighbour cell: {0}", neighbourNoNumber);
						if (neighbourNoNumber == 0 && matrixToSolve[i, j].Length != 1)
						{
							//System.Console.WriteLine("Converting Value from {0} to {1}", matrixToSolve[i, j], k);
							matrixToSolve[i, j] = Convert.ToString(k);
						}
					}
					//System.Console.WriteLine("My final value: {0}", matrixToSolve[i, j]);
				}
			}
			return (matrixToSolve);
		}
	}
}

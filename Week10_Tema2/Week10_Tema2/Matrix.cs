using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10_Tema2
{
    public class Matrix<T> : IEnumerable<T> where T : struct
    {
        private readonly T[,] matrix = null;
        private uint rows;
        private uint columns;
     
        public uint Rows
        {
            get { return this.rows; }
        }
        public uint Columns
        {
            get { return this.columns; }

        }


        public Matrix( uint rows,uint columns)
        {
            this.matrix = new T[rows, columns];
            this.rows = rows;
            this.columns = columns;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write($"{this.matrix[j,i]} \t");
                }
                Console.WriteLine();
            }

            return result.ToString();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    yield return matrix[i, j];
                }

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.matrix.GetEnumerator();
        }

        public T this[uint index1, uint index2]
        {
            
           get
            {
                return matrix[index1, index2];
            }

            set
            {
                matrix[index1, index2] = value;
            }
        }

        public static Matrix<T> operator+ (Matrix<T> first, Matrix<T> second)
        {
            if (first.rows != second.rows || first.columns != second.columns)
            {
                throw new ArgumentException("Martices have different sizes, thus addition is not possible");
            }
            var newMatrix = new Matrix<T>(first.rows, first.columns);
            
                for (uint i = 0; i < first.Count(); i++)
                {
                    for (uint j = 0; j < first.Count(); j++)
                    {
                        newMatrix[i, j] = (dynamic)first.matrix[i, j] + second.matrix[i, j];
                    }
                }
                return first + second;
        }

        public static Matrix<T> operator- (Matrix<T> first, Matrix<T> second)
        {
            if (first.rows != second.rows || first.columns != second.columns)
            {
                throw new ArgumentException("Martices have different sizes, thus substraction is not possible");
            }
            var newMatrix = new Matrix<T>(first.rows, first.columns);
            for (uint i = 0; i < first.Count(); i++)
            {
                for (uint j = 0; j < first.Count(); j++)
                {
                    newMatrix[i, j] = (dynamic)first.matrix[i, j] - second.matrix[i, j];
                }
            }
            return first + second;
        }

        public static Matrix<T> operator* (Matrix<T> first, Matrix<T> second)
        {
            uint m = first.rows;
            uint n = first.columns;
            uint p = second.rows;
            uint q = second.columns;
            var third = new Matrix<T>(m, q);
            if (n != p)
            {
                throw new ArgumentException("Matrix multiplication not possible");
                
            }
            else
            {
                for (uint i = 0; i < m; i++)
                {
                    for (uint j = 0; j < q; j++)
                    {
                        third[i, j] = default(T);
                        for (uint k = 0; k < n; k++)
                        {
                            third[i, j] += (dynamic)first[i, k] * second[k, j];
                        }
                    }
                }
            }
            return third;
        }

        public bool CheckNonZero()
        {
            for (uint i = 0; i < this.rows; i++)
            {
                for (uint j = 0; j < this.columns; j++)
                {
                    if (matrix[i,j].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

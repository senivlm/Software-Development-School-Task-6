using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Задача_6._3
{
    public class Matrix : IEnumerable
    { Можна матрицю параметризовану зробити
        private int[][] value;
        private int rows, columns;

        public Matrix(int m, int n)
        {Чому як масив масивів?
            value = new int[m][];
            rows = m;
            columns = n;

            for (int i = 0; i < m; i++)
                value[i] = new int[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    value[i][j] = i + j;
                }
            }
        }

        public MatrixEnum GetEnumerator()
        {
            return new MatrixEnum(value, rows, columns);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
    }

    public class MatrixEnum : IEnumerator
    {
        private int[][] value;
        private int rows, columns;
        int positionI, positionJ;

        public MatrixEnum(int[][] arr, int m, int n)
        {
            value = arr;
            rows = m;
            columns = n;

            positionI = rows - 1;
            positionJ = columns;
        }

        public bool MoveNext()
        {
            positionJ--;

            if (positionJ < 0)
            {
                positionI--;
                positionJ = columns - 1;
            }

            return (positionI >= 0 && positionJ >= 0);
        }

        public void Reset()
        {
            positionI = rows - 1;
            positionJ = columns;
        }

        public int Current
        {
            get
            {
                try
                {
                    return value[positionI][positionJ];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;
    }
}

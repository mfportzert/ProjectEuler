using System;
namespace ProjectEuler
{
    public static class MaximumPathSum
    {
        public static int Solve(string triangleStr)
        {
            var triangle = Parse(triangleStr);
            var nbRows = triangle.Length;
            for (int y = nbRows - 2; y >= 0; y--)
            {
                var nbColumns = y + 1;
                for (int x = 0; x < nbColumns; x++)
                {
                    var largestChild = Math.Max(triangle[y + 1][x], triangle[y + 1][x + 1]);
                    triangle[y][x] += largestChild;
                }
            }
            return triangle[0][0];
        }

        private static int[][] Parse(string triangleStr)
        {
            var nbLines = triangleStr.Count(c => c == '\n');
            if (!triangleStr.EndsWith('\n'))
                nbLines++;

            var rows = new int[nbLines][];
            var rowIndex = 0;
            var column = new int[rowIndex + 1];
            var colIndex = 0;
            var strLength = triangleStr.Length;
            for (int i = 0; i < strLength; i++)
            {
                var numberLength = 0;
                while (i + numberLength < strLength &&
                    triangleStr[i + numberLength] >= (0 + '0') &&
                    triangleStr[i + numberLength] <= (9 + '0'))
                {
                    numberLength++;
                }

                if (numberLength > 0)
                {
                    var number = int.Parse(triangleStr.Substring(i, numberLength));
                    column[colIndex++] = number;
                    i += numberLength;
                }

                if (i + numberLength >= strLength || triangleStr[i] == '\n')
                {
                    rows[rowIndex++] = column;
                    column = new int[rowIndex + 1];
                    colIndex = 0;
                }
            }
            return rows;
        }
    }
}


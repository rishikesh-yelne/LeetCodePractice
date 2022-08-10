namespace LeetCodeTrials
{
    internal class RotateMatrix
    {
        public RotateMatrix()
        {
            Rotate(new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 4, 5, 6 }, new int[3] { 7, 8, 9 } });
        }

        public void Rotate(int[][] matrix)
        {
            // Approach 1 : self 
            //int[][] solution = new int[matrix.Length][];
            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    solution[i] = new int[matrix[i].Length];
            //}

            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    for (int j = 0; j < matrix[i].Length; j++)
            //    {
            //        solution[i][j] = matrix[matrix[i].Length - 1 - j][i];
            //    }
            //}

            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    for (int j = 0; j < matrix[i].Length; j++)
            //    {
            //        matrix[i][j] = solution[i][j];
            //    }
            //}

            // Approach 2 : rotation
            //int length = matrix.Length;
            //for (int i = 0; i < (length + 1) / 2; i++)
            //{
            //    for (int j = 0; j < matrix.Length / 2; j++)
            //    {
            //        int temp = matrix[length - 1 - j][i];
            //        matrix[length - 1 - j][i] = matrix[length - 1 - i][length - 1 - j];
            //        matrix[length - 1 - i][length - 1 - i] = matrix[j][length - 1 - i];
            //        matrix[j][length - 1 - i] = matrix[i][j];
            //        matrix[i][j] = temp;
            //    }
            //}

            // Approach 3 : transpose + reverse
            Transpose(matrix);
            Reverse(matrix);
        }

        private void Transpose(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i + 1; j < matrix[i].Length; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        private void Reverse(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length / 2; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][matrix.Length - 1 - j];
                    matrix[i][matrix.Length - 1 - j] = temp;
                }
            }
        }
    }
}

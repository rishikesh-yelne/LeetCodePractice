namespace LeetCodeTrials
{
    internal class Tetris
    {
        Dictionary<char, List<List<int>>> figures = new Dictionary<char, List<List<int>>>();

        public Tetris()
        {
            figures.Add('A', new List<List<int>> { new List<int>() { 1 } });
            figures.Add('B', new List<List<int>> { new List<int>() { 1, 1, 1 } });
            figures.Add('C', new List<List<int>> { new List<int>() { 1, 1 }, new List<int>() { 1, 1 } });
            figures.Add('D', new List<List<int>> { new List<int>() { 1, 0 }, new List<int>() { 1, 1 }, new List<int>() { 1, 0 } });
            figures.Add('E', new List<List<int>> { new List<int>() { 0, 1, 0 }, new List<int>() { 1, 1, 1 } });

            long startTimestamp = DateTime.UtcNow.Ticks;
            var matrix = GenerateMatrix(4, 4, new List<char> { 'D', 'B', 'A', 'C' });
            long endTimestamp = DateTime.UtcNow.Ticks;
            //var matrix = tetris.GenerateMatrix(3, 5, new List<char> { 'A', 'D', 'E' });
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Time taken: {new DateTime(endTimestamp - startTimestamp).TimeOfDay}");
        }

        private bool FitFigureInMatrix(List<List<int>> matrix, char figure, int value)
        {
            var emptySpaces = matrix.Select((x, i) => new { count = x.Count(x => x == 0), index = i }).ToList();
            List<List<int>> figureMatrix = figures[figure];

            bool isFitting = false;
            foreach (var row in emptySpaces)
            {
                int spaceCountForFirstRow = figureMatrix[0].Count(x => x == 1);
                if (row.count >= spaceCountForFirstRow)
                {
                    isFitting = PlaceInMatrixAtIndex(matrix, row.index, figureMatrix, value);
                }
                if (isFitting) break;
            }

            return isFitting;
        }

        private bool PlaceInMatrixAtIndex(List<List<int>> matrix, int index, List<List<int>> figureMatrix, int value)
        {
            int colIndex = -1;
            for (int j = 0; j < matrix[0].Count; j++)
            {
                bool possible = TryPlacingAtIndex(matrix, index, j, figureMatrix);
                if (possible)
                {
                    colIndex = j;
                    break;
                }
            }

            if (colIndex == -1) return false;

            // reaching here, so able to fit
            for (int i = 0; i < figureMatrix.Count; i++)
            {
                for (int j = 0; j < figureMatrix[i].Count; j++)
                {
                    if ((matrix[index + i][colIndex + j] == 0 && figureMatrix[i][j] == 1)
                        || (matrix[index + i][colIndex + j] != 0 && figureMatrix[i][j] == 0))
                        matrix[index + i][colIndex + j] = figureMatrix[i][j] == 1 ? value : matrix[index + i][colIndex + j];
                }
            }
            return true;
        }

        private bool TryPlacingAtIndex(List<List<int>> matrix, int rowIndex, int colIndex, List<List<int>> figureMatrix)
        {
            for (int i = 0; i < figureMatrix.Count; i++)
            {
                // check if overflowing 
                if (rowIndex + i >= matrix.Count) return false;

                for (int j = 0; j < figureMatrix[i].Count; j++)
                {
                    // check if overflowing 
                    if (colIndex + j >= matrix[0].Count) return false;

                    // check if able to place
                    if (!((matrix[rowIndex + i][colIndex + j] == 0 && figureMatrix[i][j] == 1)
                        || (figureMatrix[i][j] == 0)))
                        return false;
                }
            }
            return true;
        }

        public List<List<int>> GenerateMatrix(int n, int m, List<char> figures)
        {
            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                matrix.Add(Enumerable.Range(0, m).Select(x => 0).ToList());
            }

            for (int i = 0; i < figures.Count; i++)
            {
                bool isPlaced = FitFigureInMatrix(matrix, figures[i], i + 1);
                if (!isPlaced) throw new Exception("Can't place in matrix");
            }

            return matrix;
        }
    }
}

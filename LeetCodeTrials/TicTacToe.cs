namespace LeetCodeTrials
{
    internal class PlayTicTactoe
    {
        public PlayTicTactoe()
        {
            TicTacToe ticTacToe = new TicTacToe(3);
            Console.WriteLine(ticTacToe.Move(0, 0, 1));
            Console.WriteLine(ticTacToe.Move(0, 2, 2));
            Console.WriteLine(ticTacToe.Move(2, 2, 1));
            Console.WriteLine(ticTacToe.Move(1, 1, 2));
            Console.WriteLine(ticTacToe.Move(2, 0, 1));
            Console.WriteLine(ticTacToe.Move(1, 0, 2));
            Console.WriteLine(ticTacToe.Move(2, 1, 1));
        }
    }

    internal class TicTacToe
    {
        int[][] ttt;
        public TicTacToe(int n)
        {
            ttt = new int[n][];
            for (int i = 0; i < n; i++)
            {
                ttt[i] = new int[n];
            }
        }

        public int Move(int row, int col, int player)
        {
            ttt[row][col] = player;
            if (WinningPosition(row, col, player)) return player;
            return 0;
        }

        private bool WinningPosition(int row, int col, int player)
        {
            bool rowFlag = true, colFlag = true, diag1Flag = true, diag2Flag = true;
            for (int i = 0; i < ttt.Length; i++)
            {
                if (ttt[row][i] != player) rowFlag = false;
                if (ttt[i][col] != player) colFlag = false;
                if (ttt[row][row] != player) diag1Flag = false;
                if (ttt[row][ttt.Length - row - 1] != player) diag2Flag = false;
            }
            return rowFlag || colFlag || (row == col && diag1Flag) || (row == ttt.Length - col - 1 && diag2Flag);
        }
    }
}

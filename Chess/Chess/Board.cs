namespace Chess;

public class Board
{
    public char[] board = new char[64];
    public void DisplayBoard()
    {
        int line = 2;
        Console.WriteLine("");
        Console.Write(1 + ": ");
        for (int i = 0; i < board.Length; i++)
        {
            if (i % 8 == 0 && i != 0)
            {
                Console.Write("\n   --------------------------------\n");
                Console.Write(line + ": ");
                line++;
            }

            char currentPeice = board[i];
            if (Char.IsLower(currentPeice))
                Console.ForegroundColor = ConsoleColor.Red;
            else if (Char.IsUpper(currentPeice))
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            else
                currentPeice = ' ';
            
            Console.Write($" {currentPeice} ");
            Console.ResetColor();
            Console.Write("|");
        }
        Console.WriteLine("\n\n    a   b   c   d   e   f   g   h");
    }
}
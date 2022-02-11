namespace Chess;

public class GameHandler
{
    private string Turn = "Blue";
    
    public void PlayerMove(Board board)
    {
        Console.WriteLine($"It is {Turn} time to move enter current cell and the cell you want to move to");
        string[] temp = Console.ReadLine().Split(' ');
        int currentPosition = ConvertCellToInt(temp[0].ToLower());
        int newPostion = ConvertCellToInt(temp[1].ToLower());

        char currentPeice = board.board[currentPosition];
        board.board[currentPosition] = ' ';
        board.board[newPostion] = currentPeice;
    }

    private int ConvertCellToInt(string cell)
    {
        int position = 0;
        position += Convert.ToInt32(cell[0]) - 96;
        position += ((Convert.ToInt32(cell[1]) - 48) * 8) - 9;

        return position;
    }
}
using System.Net.NetworkInformation;

namespace Chess;

public class FENhandler
{
    public Board ParseFen(string FEN)
    {
        string[] config = FEN.Split(' ');
        Board board = new Board();
        PraseBoard(board, config[0]);
        
        return board;
    }

    private static void PraseBoard(Board board, string boardStatus)
    {
        int boardPostion = 0;
        int statusPostion = 0;
        foreach (char piece in boardStatus)
        {
            if (Char.IsDigit(piece))
                boardPostion += Convert.ToInt32(piece) - 49;
            else if (piece == '/')
                boardPostion--;
            else
                board.board[boardPostion] = boardStatus[statusPostion];
            
            statusPostion++;
            boardPostion++;
        }
    }
}
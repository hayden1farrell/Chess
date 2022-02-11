namespace Chess;

public class MoveChecker
{
    public bool BasicCheck(string playerToMove, char piece)
    {
        return playerToMove == "Blue" && char.IsUpper(piece) || playerToMove == "Red" && char.IsLower(piece);
    }

    public bool PawnCheck(int newPostion, int currentPostion, string turn, Board board)
    {
        bool valid = true;
        int offset = 0;
        if (turn == "Blue")
            offset = -8;
        else
            offset = 8;

        if (board.board[newPostion].ToString() == "\0") // if the square is empty
        {
            if (currentPostion + offset != newPostion)
                valid =  false;
            if(currentPostion is >= 8 and <= 15 or >= 48 and <= 55)
                if (currentPostion + offset * 2 == newPostion)
                    valid = true;
        }
        else   // if the square has a piece 
        {
            valid = false;
            if (turn == "Blue")
            {
                if (board.board[currentPostion - 7].ToString() != "\0" || board.board[currentPostion - 9].ToString() != "\0")
                    valid = true;
            }
            else
            {
                if (board.board[currentPostion + 7].ToString() != "\0" || board.board[currentPostion + 9].ToString() != "\0")
                    valid = true;
            }
        }
        
        return valid;
    }

    public void RookCheck()
    {
        throw new NotImplementedException();
    }

    public void BishopCheck()
    {
        throw new NotImplementedException();
    }

    public void QueenCheck()
    {
        throw new NotImplementedException();
    }

    public void KingCheck()
    {
        throw new NotImplementedException();
    }

    public void KnightCheck()
    {
        throw new NotImplementedException();
    }
}
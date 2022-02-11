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

        if (currentPostion + offset != newPostion)
            valid =  false;
        if((currentPostion >= 8 && currentPostion <= 15 || currentPostion >= 48 && currentPostion <= 55))
            if (currentPostion + offset * 2 == newPostion)
                valid = true;


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
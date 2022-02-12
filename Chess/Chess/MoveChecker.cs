namespace Chess;

public class MoveChecker
{
    public bool BasicCheck(string playerToMove, char piece, char newPiece)
    {
        bool valid = false;
        valid  = playerToMove == "Blue" && char.IsUpper(piece) || playerToMove == "Red" && char.IsLower(piece);
        if (newPiece != '\0' && valid == true)
        {
            if (playerToMove == "Blue" && char.IsUpper(newPiece) == true)
                valid = false;
            else if (playerToMove == "Red" && char.IsLower(newPiece) == true)
                valid = false;
        }
        return valid;
    }

    public (bool, int) PawnCheck(int newPosition, int currentPosition, string turn, Board board, int enPassentSquares)
    {
        bool enPassent = false;
        bool valid = true;
        int offset = 0;
        if (turn == "Blue")
            offset = -8;
        else
            offset = 8;

        if (board.board[newPosition] == '\0') // if the square is empty
        {
            if (currentPosition + offset != newPosition)
                valid =  false;
            if(currentPosition is >= 8 and <= 15 or >= 48 and <= 55)
                if (currentPosition + offset * 2 == newPosition)
                {
                    enPassentSquares = newPosition - offset;
                    enPassent = true;
                    valid = true;
                }

            if (newPosition == enPassentSquares)
            {
                board.board[enPassentSquares - offset] = '\0';
                valid = true;
            }
        }
        else   // if the square has a piece 
        {
            valid = false;
            if (turn == "Blue")
            {
                if (board.board[currentPosition - 7] != '\0' || board.board[currentPosition - 9] != '\0')
                    valid = true;
            }
            else
            {
                if (board.board[currentPosition + 7] != '\0' || board.board[currentPosition + 9] != '\0')
                    valid = true;
            }
        }

        if (enPassent == false)
            enPassentSquares = -555;
        
        return (valid, enPassentSquares);
    }
    
    private bool SimpleMoverCheck(int currentPosition, int newPosition, Board board, int[] offsets)
    {
        foreach (int direction in offsets)
        {
            int tempPostion = currentPosition;
            while (tempPostion >= 0 && tempPostion <= board.board.Length - 1)
            {
                tempPostion += direction;
                if(tempPostion is >= 63 or < 0)
                    break;
                if (tempPostion == newPosition)
                    return true;
                if (board.board[tempPostion].ToString() != "\0")
                    break;
            }
        }

        return false;
    }

    public bool RookCheck(int currentPosition, int newPosition, Board board)
    {
        int[] offsets = {-1, 8, 1, -8}; // left, up, right, down
        return SimpleMoverCheck(currentPosition, newPosition, board, offsets);
    }

    public bool BishopCheck(int currentPosition, int newPostion, Board board)
    {
        int[] offsets = {7, 9, -7, -9}; // left, up, right, down
        return SimpleMoverCheck(currentPosition, newPostion, board, offsets);
    }

    public bool QueenCheck(int currentPosition, int newPostion, Board board)
    {
        int[] offsets = {-1, 8, 1, -8, 7, 9, -7, -9};
        return SimpleMoverCheck(currentPosition, newPostion, board, offsets);
    }

    public bool KingCheck(int currentPosition, int newPosition)
    {
        int[] offsets = {1, 7, 8, 9, -1, -7, -8, -9};
        foreach (int direction in offsets)
        {
            if (currentPosition + direction == newPosition)
                return true;
        }
        return false;
    }

    public bool KnightCheck(int currentPosition, int newPosition)
    {
        int[] offsets = {15, 17, 6, 10, -6, -10, -15, -17};
        foreach (int direction in offsets)
        {
            if (currentPosition + direction == newPosition)
                return true;
        }

        return false;
    }
}
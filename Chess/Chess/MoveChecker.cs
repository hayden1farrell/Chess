namespace Chess;

public class MoveChecker
{
    public bool CorrectColour(string playerToMove, char piece)
    {
        return playerToMove == "Blue" && char.IsUpper(piece) || playerToMove == "Red" && char.IsLower(piece);
    }
}
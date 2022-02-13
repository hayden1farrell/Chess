namespace Chess
{
    class Game
    {
        private static void Main()
        {
            const string startingFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            GameHandler handler = new GameHandler();
            FENhandler fen = new FENhandler();
            Board boardHandler = fen.ParseFen(startingFen, handler);

            while (true)
            {
                boardHandler.DisplayBoard();
                boardHandler = handler.PlayerMove(boardHandler);
            }
        }
    }    
}



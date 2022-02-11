namespace Chess
{
    class Game
    {
        private static void Main()
        {
            string StartingFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            GameHandler handler = new GameHandler();
            FENhandler fen = new FENhandler();
            Board boardHandler = fen.ParseFen(StartingFen, handler);

            while (true)
            {
                boardHandler.DisplayBoard();
                handler.PlayerMove(boardHandler);
            }
        }
    }    
}



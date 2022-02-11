namespace Chess
{
    class Game
    {
        private static void Main()
        {
            string StartingFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            Console.WriteLine("Chess is starting up");
            FENhandler fen = new FENhandler();
            Board boardHandler = fen.ParseFen(StartingFen);
            
            boardHandler.DisplayBoard();
        }
    }    
}



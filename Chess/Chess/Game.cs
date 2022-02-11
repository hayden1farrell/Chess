namespace Chess
{
    class Game
    {
        private static void Main()
        {
            Console.WriteLine("Chess is starting up");
            FENhandler fen = new FENhandler();
            Board boardHandler = fen.ParseFen("rnb1kbnr/pppqpppp/8/1B6/4pP2/8/PPPP2PP/RNBQK1NR w KQkq - 2 4");
            
            boardHandler.DisplayBoard();
        }
    }    
}



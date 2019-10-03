namespace TicTacToe
{
    public interface IGame
    {
        bool GameIsOver { get; }
        void RenderGame();
        void NextPlayer();
        void Play();
    }
}

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Game manager interface
    /// </summary>
    public interface IGameManager : IManager
    {
        /// <summary>
        /// Game state
        /// </summary>
        EGameState GameState { get; set; }

        /// <summary>
        /// Points
        /// </summary>
        long Points { get; set; }

        /// <summary>
        /// Remaining counter count
        /// </summary>
        uint RemainingCounterCount { get; }

        /// <summary>
        /// Remaining time
        /// </summary>
        float RemainingTime { get; }

        /// <summary>
        /// On points updated
        /// </summary>
        event PointsUpdatedDelegate OnPointsUpdated;

        /// <summary>
        /// On counting started
        /// </summary>
        event CountingStartedDelegate OnCountingStarted;

        /// <summary>
        /// On count ticked
        /// </summary>
        event CountTickedDelegate OnCountTicked;

        /// <summary>
        /// On game started
        /// </summary>
        event GameStartedDelegate OnGameStarted;

        /// <summary>
        /// On game paused
        /// </summary>
        event GamePausedDelegate OnGamePaused;

        /// <summary>
        /// On game resumed
        /// </summary>
        event GameResumedDelegate OnGameResumed;

        /// <summary>
        /// On game ended
        /// </summary>
        event GameEndedDelegate OnGameEnded;

        /// <summary>
        /// Start counting
        /// </summary>
        void StartCounting();

        /// <summary>
        /// Exit game
        /// </summary>
        void ExitGame();
    }
}

using MufajaA.Managers;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Game manager class
    /// </summary>
    public static class GameManager
    {
        /// <summary>
        /// Game state
        /// </summary>
        public static EGameState GameState
        {
            get => GameManagerScript.Instance ? GameManagerScript.Instance.GameState : EGameState.None;
            set
            {
                if (GameManagerScript.Instance)
                {
                    GameManagerScript.Instance.GameState = value;
                }
            }
        }

        /// <summary>
        /// Points
        /// </summary>
        public static long Points
        {
            get => GameManagerScript.Instance ? GameManagerScript.Instance.Points : 0L;
            set
            {
                if (GameManagerScript.Instance)
                {
                    GameManagerScript.Instance.Points = value;
                }
            }
        }

        /// <summary>
        /// Remaining counter count
        /// </summary>
        public static uint RemainingCounterCount => GameManagerScript.Instance ? GameManagerScript.Instance.RemainingCounterCount : 0U;

        /// <summary>
        /// Remaining time
        /// </summary>
        public static float RemainingTime => GameManagerScript.Instance ? GameManagerScript.Instance.RemainingTime : 0.0f;
    }
}

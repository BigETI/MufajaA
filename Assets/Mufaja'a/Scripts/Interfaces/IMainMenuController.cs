/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Main menu controller interface
    /// </summary>
    public interface IMainMenuController : IBehaviour
    {
        /// <summary>
        /// Start game
        /// </summary>
        void StartGame();

        /// <summary>
        /// SHow options
        /// </summary>
        void ShowOptions();

        /// <summary>
        /// Exit game
        /// </summary>
        void ExitGame();
    }
}

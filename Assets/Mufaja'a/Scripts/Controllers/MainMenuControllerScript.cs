using UnityEngine;
using UnitySceneLoaderManager;
using UnityUtils;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Main menu controller script class
    /// </summary>
    public class MainMenuControllerScript : MonoBehaviour, IMainMenuController
    {
        /// <summary>
        /// Start game
        /// </summary>
        public void StartGame() => SceneLoaderManager.LoadScene("GameScene");

        /// <summary>
        /// SHow options
        /// </summary>
        public void ShowOptions() => SceneLoaderManager.LoadScene("OptionsScene");

        /// <summary>
        /// Exit game
        /// </summary>
        public void ExitGame() => Game.Quit();
    }
}

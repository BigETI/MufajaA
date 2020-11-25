using MufajaA.InputActions;
using UnityEngine;
using UnitySceneLoaderManager;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Intro controller script class
    /// </summary>
    public class IntroControllerScript : MonoBehaviour, IIntroController
    {
        /// <summary>
        /// Game input actions
        /// </summary>
        private GameInputActions gameInputActions;

        /// <summary>
        /// Show main menu
        /// </summary>
        public void ShowMainMenu() => SceneLoaderManager.LoadScene("MainMenuScene");

        /// <summary>
        /// Awake
        /// </summary>
        private void Awake()
        {
            gameInputActions = new GameInputActions();
            gameInputActions.GameActionMap.Any.performed += (context) =>
            {
                ShowMainMenu();
            };
        }

        /// <summary>
        /// On enable
        /// </summary>
        private void OnEnable() => gameInputActions.Enable();

        /// <summary>
        /// On disable
        /// </summary>
        private void OnDisable() => gameInputActions.Disable();
    }
}

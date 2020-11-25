using MufajaA.InputActions;
using UnityEngine;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Player controller script class
    /// </summary>
    [RequireComponent(typeof(CharacterControllerScript))]
    public class PlayerControllerScript : MonoBehaviour, IPlayerController
    {
        /// <summary>
        /// BAckground plane
        /// </summary>
        private Plane backgroundPlane = new Plane(Vector3.back, Vector3.zero);

        /// <summary>
        /// Game input actions
        /// </summary>
        private GameInputActions gameInputActions;

        /// <summary>
        /// Character controller
        /// </summary>
        public ICharacterController CharacterController { get; private set; }

        /// <summary>
        /// Game camera
        /// </summary>
        public Camera GameCamera { get; private set; }

        /// <summary>
        /// On enable
        /// </summary>
        private void OnEnable() => gameInputActions.Enable();

        /// <summary>
        /// On disable
        /// </summary>
        private void OnDisable() => gameInputActions.Disable();

        /// <summary>
        /// Awake
        /// </summary>
        private void Awake()
        {
            gameInputActions = new GameInputActions();
            gameInputActions.GameActionMap.MousePosition.performed += (context) =>
            {
                if ((CharacterController != null) && GameCamera)
                {
                    Vector2 mouse_position = context.ReadValue<Vector2>();
                    Ray ray = GameCamera.ScreenPointToRay(new Vector3(mouse_position.x, mouse_position.y, 0.0f));
                    if (backgroundPlane.Raycast(ray, out float enter))
                    {
                        Vector3 looking_at_position = ray.origin + (ray.direction * enter);
                        CharacterController.LookingAtPosition = new Vector2(looking_at_position.x, looking_at_position.y);
                    }
                }
            };
            gameInputActions.GameActionMap.LickLeft.performed += (context) =>
            {
                if (CharacterController != null)
                {
                    CharacterController.Lick(false);
                }
            };
            gameInputActions.GameActionMap.LickRight.performed += (context) =>
            {
                if (CharacterController != null)
                {
                    CharacterController.Lick(true);
                }
            };
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            CharacterController = GetComponent<CharacterControllerScript>();
            GameCamera = FindObjectOfType<Camera>();
        }
    }
}

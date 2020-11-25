using System;
using UnityEngine;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Character controller script class
    /// </summary>
    public class CharacterControllerScript : MonoBehaviour, ICharacterController
    {
        /// <summary>
        /// Is character right
        /// </summary>
        [SerializeField]
        private bool isRight;

        /// <summary>
        /// Tracker controller
        /// </summary>
        [SerializeField]
        private TrackerControllerScript[] trackerControllers = Array.Empty<TrackerControllerScript>();

        /// <summary>
        /// Is character right
        /// </summary>
        public bool IsRight
        {
            get => isRight;
            set => isRight = value;
        }

        /// <summary>
        /// Tracker controllers
        /// </summary>
        public TrackerControllerScript[] TrackerControllers
        {
            get => trackerControllers ?? Array.Empty<TrackerControllerScript>();
            set => trackerControllers = (TrackerControllerScript[])(value ?? throw new ArgumentNullException(nameof(value))).Clone();
        }

        /// <summary>
        /// Looking at position
        /// </summary>
        public Vector2 LookingAtPosition { get; set; }

        /// <summary>
        /// Lick
        /// </summary>
        /// <param name="useRight">Use right character</param>
        public void Lick(bool useRight)
        {
            if (isRight == useRight)
            {
                foreach (TrackerControllerScript tracker_controller in TrackerControllers)
                {
                    if (tracker_controller is TongueControllerScript tongue_controller)
                    {
                        tongue_controller.Lick();
                    }
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            Vector2 looking_at_position = LookingAtPosition;
            foreach (TrackerControllerScript tracker_controller in TrackerControllers)
            {
                if (tracker_controller)
                {
                    tracker_controller.LookingAtPosition = looking_at_position;
                }
            }
        }
    }
}

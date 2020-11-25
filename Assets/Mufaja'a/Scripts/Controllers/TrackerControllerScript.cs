using UnityEngine;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Tracker controller script class
    /// </summary>
    public class TrackerControllerScript : MonoBehaviour, ITrackerController
    {
        /// <summary>
        /// Looking at position
        /// </summary>
        public Vector2 LookingAtPosition { get; set; }

        /// <summary>
        /// Update
        /// </summary>
        protected virtual void Update() =>
            transform.rotation = Quaternion.FromToRotation(Vector3.left, (new Vector3(LookingAtPosition.x, LookingAtPosition.y, 0.0f) - transform.position).normalized);
    }
}

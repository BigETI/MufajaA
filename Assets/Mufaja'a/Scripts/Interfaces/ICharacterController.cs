using MufajaA.Controllers;
using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Character controller interface
    /// </summary>
    public interface ICharacterController : IBehaviour
    {
        /// <summary>
        /// Is character right
        /// </summary>
        bool IsRight { get; set; }

        /// <summary>
        /// Tracker controllers
        /// </summary>
        TrackerControllerScript[] TrackerControllers { get; set; }

        /// <summary>
        /// Looking at position
        /// </summary>
        Vector2 LookingAtPosition { get; set; }

        /// <summary>
        /// Lick
        /// </summary>
        /// <param name="useRight">Use right character</param>
        void Lick(bool useRight);
    }
}

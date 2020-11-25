using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Player controller interface
    /// </summary>
    public interface IPlayerController : IBehaviour
    {
        /// <summary>
        /// Character controller
        /// </summary>
        ICharacterController CharacterController { get; }

        /// <summary>
        /// Game camera
        /// </summary>
        Camera GameCamera { get; }
    }
}

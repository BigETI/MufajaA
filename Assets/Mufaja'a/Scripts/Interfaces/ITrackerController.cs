using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Tracker controller interface
    /// </summary>
    public interface ITrackerController : IBehaviour
    {
        /// <summary>
        /// Looking at position
        /// </summary>
        Vector2 LookingAtPosition { get; set; }
    }
}

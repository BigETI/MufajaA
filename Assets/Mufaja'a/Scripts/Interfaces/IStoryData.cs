using UnityEngine.Events;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Story data interface
    /// </summary>
    public interface IStoryData
    {
        /// <summary>
        /// On executed
        /// </summary>
        UnityEvent OnExecuted { get; set; }

        /// <summary>
        /// Time
        /// </summary>
        float Time { get; set; }
    }
}

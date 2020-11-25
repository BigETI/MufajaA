using TMPro;
using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Game start counter UI controller interface
    /// </summary>
    public interface IGameStartCounterUIController : IBehaviour
    {
        /// <summary>
        /// Counter string format
        /// </summary>
        string CounterStringFormat { get; set; }

        /// <summary>
        /// Counter finished string
        /// </summary>
        string CounterFinishedString { get; set; }

        /// <summary>
        /// Counter text
        /// </summary>
        TextMeshProUGUI CounterText { get; }

        /// <summary>
        /// Counter animator
        /// </summary>
        Animator CounterAnimator { get; }

        /// <summary>
        /// Tick
        /// </summary>
        /// <param name="count">Count</param>
        void Tick(uint count);
    }
}

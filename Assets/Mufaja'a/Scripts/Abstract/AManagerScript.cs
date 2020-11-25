using UnityEngine;

/// <summary>
/// Mufaja'a managers namespace
/// </summary>
namespace MufajaA.Managers
{
    /// <summary>
    /// Manager script abstract class
    /// </summary>
    /// <typeparam name="T">Manager type</typeparam>
    public abstract class AManagerScript<T> : MonoBehaviour, IManager where T : AManagerScript<T>
    {
        /// <summary>
        /// Instance
        /// </summary>
        public static T Instance { get; private set; }

        /// <summary>
        /// On enable
        /// </summary>
        protected virtual void OnEnable()
        {
            if (Instance == null)
            {
                Instance = (T)this;
            }
        }

        /// <summary>
        /// On disable
        /// </summary>
        protected virtual void OnDisable()
        {
            if (Instance == this)
            {
                Instance = default;
            }
        }
    }
}

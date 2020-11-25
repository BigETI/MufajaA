using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Mufaja'a data namespace
/// </summary>
namespace MufajaA.Data
{
    /// <summary>
    /// Story data structure
    /// </summary>
    [Serializable]
    public struct StoryData : IStoryData
    {
        /// <summary>
        /// On executed
        /// </summary>
        [SerializeField]
        private UnityEvent onExecuted;

        /// <summary>
        /// Time
        /// </summary>
        [SerializeField]
        private float time;

        /// <summary>
        /// On executed
        /// </summary>
        public UnityEvent OnExecuted
        {
            get => onExecuted;
            set => onExecuted = value;
        }

        /// <summary>
        /// Time
        /// </summary>
        public float Time
        {
            get => time;
            set => time = value;
        }
    }
}

using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Game start counter UI controller script
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    [RequireComponent(typeof(Animator))]
    public class GameStartCounterUIControllerScript : MonoBehaviour, IGameStartCounterUIController
    {
        /// <summary>
        /// Default counter string format
        /// </summary>
        private static readonly string defaultCounterStringFormat = "{0}";

        /// <summary>
        /// Default counter finished string
        /// </summary>
        private static readonly string defaultCounterFinishedString = "Go!";

        /// <summary>
        /// Show hash
        /// </summary>
        private static readonly int showHash = Animator.StringToHash("Show");

        /// <summary>
        /// Counter string format
        /// </summary>
        [SerializeField]
        private string counterStringFormat = defaultCounterStringFormat;

        /// <summary>
        /// Counter finished string
        /// </summary>
        [SerializeField]
        private string counterFinishedString = defaultCounterFinishedString;

        /// <summary>
        /// Counter string format
        /// </summary>
        public string CounterStringFormat
        {
            get => counterStringFormat ?? defaultCounterStringFormat;
            set => counterStringFormat = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Counter finished string
        /// </summary>
        public string CounterFinishedString
        {
            get => counterFinishedString ?? defaultCounterFinishedString;
            set => counterFinishedString = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Counter text
        /// </summary>
        public TextMeshProUGUI CounterText { get; private set; }

        /// <summary>
        /// Counter animator
        /// </summary>
        public Animator CounterAnimator { get; private set; }

        /// <summary>
        /// Tick
        /// </summary>
        /// <param name="count">Count</param>
        public void Tick(uint count)
        {
            if (CounterText)
            {
                CounterText.text = (count == 0U) ? CounterFinishedString : string.Format(CounterStringFormat, count);
            }
            if (CounterAnimator)
            {
                CounterAnimator.Play(showHash);
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            CounterText = GetComponent<TextMeshProUGUI>();
            CounterAnimator = GetComponent<Animator>();
        }
    }
}

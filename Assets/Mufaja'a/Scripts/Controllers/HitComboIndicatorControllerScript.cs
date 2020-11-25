using System;
using UnityEngine;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Hit combo indicator controller script class
    /// </summary>
    public class HitComboIndicatorControllerScript : MonoBehaviour, IHitComboIndicatorController
    {
        /// <summary>
        /// Default combo string format
        /// </summary>
        private static readonly string defaultComboStringFormat = "x{0}";

        /// <summary>
        /// Combo string format
        /// </summary>
        [SerializeField]
        private string comboStringFormat = defaultComboStringFormat;

        /// <summary>
        /// Combo text
        /// </summary>
        [SerializeField]
        private TextMesh comboText = default;

        /// <summary>
        /// Combo string format
        /// </summary>
        public string ComboStringFormat
        {
            get => comboStringFormat ?? defaultComboStringFormat;
            set => comboStringFormat = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Combo text
        /// </summary>
        public TextMesh ComboText
        {
            get => comboText;
            set => comboText = value;
        }

        /// <summary>
        /// Set values
        /// </summary>
        /// <param name="combo">Combo</param>
        public void SetValues(uint combo)
        {
            if (comboText)
            {
                comboText.text = string.Format(ComboStringFormat, combo);
            }
        }
    }
}

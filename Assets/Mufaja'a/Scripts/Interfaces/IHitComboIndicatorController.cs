using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Hit combo indicator controller interface
    /// </summary>
    public interface IHitComboIndicatorController
    {
        /// <summary>
        /// Combo string format
        /// </summary>
        string ComboStringFormat { get; set; }

        /// <summary>
        /// Combo text
        /// </summary>
        TextMesh ComboText { get; set; }

        /// <summary>
        /// Set values
        /// </summary>
        /// <param name="combo">Combo</param>
        void SetValues(uint combo);
    }
}

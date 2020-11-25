using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Food object interface
    /// </summary>
    public interface IFoodObject : IObject
    {
        /// <summary>
        /// Food name
        /// </summary>
        string FoodName { get; set; }

        /// <summary>
        /// Points
        /// </summary>
        long Points { get; set; }

        /// <summary>
        /// Bias
        /// </summary>
        float Bias { get; set; }

        /// <summary>
        /// Asset
        /// </summary>
        GameObject Asset { get; set; }
    }
}

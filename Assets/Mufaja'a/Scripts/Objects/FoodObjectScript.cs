using System;
using UnityEngine;

/// <summary>
/// Mufaja'a objects namespace
/// </summary>
namespace MufajaA.Objects
{
    /// <summary>
    /// Food object script class
    /// </summary>
    [CreateAssetMenu(fileName = "Food", menuName = "Mufaya'a/Food")]
    public class FoodObjectScript : ScriptableObject, IFoodObject
    {
        /// <summary>
        /// Food name
        /// </summary>
        [SerializeField]
        private string foodName;

        /// <summary>
        /// Points
        /// </summary>
        [SerializeField]
        private long points;

        /// <summary>
        /// Bias
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float bias = 1.0f;

        /// <summary>
        /// Asset
        /// </summary>
        [SerializeField]
        private GameObject asset;

        /// <summary>
        /// Food name
        /// </summary>
        public string FoodName
        {
            get => foodName ?? string.Empty;
            set => foodName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Points
        /// </summary>
        public long Points
        {
            get => points;
            set => points = value;
        }

        /// <summary>
        /// Bias
        /// </summary>
        public float Bias
        {
            get => bias;
            set => bias = value;
        }

        /// <summary>
        /// Asset
        /// </summary>
        public GameObject Asset
        {
            get => asset;
            set => asset = value;
        }
    }
}

using MufajaA.Objects;
using UnityEngine;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Food controller script class
    /// </summary>
    public class FoodControllerScript : MonoBehaviour, IFoodController
    {
        /// <summary>
        /// Food object
        /// </summary>
        [SerializeField]
        private FoodObjectScript foodObject;

        /// <summary>
        /// Food object
        /// </summary>
        public FoodObjectScript FoodObject
        {
            get => foodObject;
            set => foodObject = value;
        }
    }
}

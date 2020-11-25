using MufajaA.Objects;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Food controller interface
    /// </summary>
    public interface IFoodController
    {
        /// <summary>
        /// Food object
        /// </summary>
        FoodObjectScript FoodObject { get; set; }
    }
}

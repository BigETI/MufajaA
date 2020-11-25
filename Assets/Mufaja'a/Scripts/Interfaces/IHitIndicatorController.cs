using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Hit indicator controller interface
    /// </summary>
    public interface IHitIndicatorController : IBehaviour
    {
        /// <summary>
        /// Good hit indicator color
        /// </summary>
        Color GoodHitIndicatorColor { get; set; }

        /// <summary>
        /// Bad hit indicator color
        /// </summary>
        Color BadHitIndicatorColor { get; set; }

        /// <summary>
        /// Good points text string format
        /// </summary>
        string GoodPointsTextStringFormat { get; set; }

        /// <summary>
        /// Bad points text string format
        /// </summary>
        string BadPointsTextStringFormat { get; set; }

        /// <summary>
        /// Good points color
        /// </summary>
        Color GoodPointsColor { get; set; }

        /// <summary>
        /// Bad points color
        /// </summary>
        Color BadPointsColor { get; set; }

        /// <summary>
        /// Hit indicator sprite
        /// </summary>
        SpriteRenderer HitIndicatorSprite { get; set; }

        /// <summary>
        /// Points text
        /// </summary>
        TextMesh PointsText { get; set; }

        /// <summary>
        /// Set values
        /// </summary>
        /// <param name="newPoints">New points</param>
        void SetValues(long newPoints);
    }
}

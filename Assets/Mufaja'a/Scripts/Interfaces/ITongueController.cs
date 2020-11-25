using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Tongue controller interface
    /// </summary>
    public interface ITongueController : ITrackerController
    {
        /// <summary>
        /// Tongue contraction speed
        /// </summary>
        float TongueContractionSpeed { get; set; }

        /// <summary>
        /// Tongue retraction speed
        /// </summary>
        float TongueRetractionSpeed { get; set; }

        /// <summary>
        /// Lick hit radius
        /// </summary>
        float LickHitRadius { get; set; }

        /// <summary>
        /// Hit indicator show time
        /// </summary>
        float HitIndicatorShowTime { get; set; }

        /// <summary>
        /// Hit combo indicator show time
        /// </summary>
        float HitComboIndicatorShowTime { get; set; }

        /// <summary>
        /// Hit indicator asset
        /// </summary>
        GameObject HitIndicatorAsset { get; set; }

        /// <summary>
        /// Hit combo indicator asset
        /// </summary>
        GameObject HitComboIndicatorAsset { get; set; }

        /// <summary>
        /// Lick state
        /// </summary>
        ELickState LickState { get; set; }

        /// <summary>
        /// Licking at position
        /// </summary>
        Vector2 LickingAtPosition { get; }

        /// <summary>
        /// Tongue sprite renderer
        /// </summary>
        SpriteRenderer TongueSpriteRenderer { get; }

        /// <summary>
        /// On licking started
        /// </summary>
        event LickingStartedDelegate OnLickingStarted;

        /// <summary>
        /// On licking hit succeeded
        /// </summary>
        event LickingHitSucceededDelegate OnLickingHitSucceeded;

        /// <summary>
        /// On licking hit failed
        /// </summary>
        event LickingHitFailedDelegate OnLickingHitFailed;

        /// <summary>
        /// On licking missed
        /// </summary>
        event LickingMissedDelegate OnLickingMissed;

        /// <summary>
        /// On licking ended
        /// </summary>
        event LickingEndedDelegate OnLickingEnded;

        /// <summary>
        /// Lick
        /// </summary>
        void Lick();
    }
}

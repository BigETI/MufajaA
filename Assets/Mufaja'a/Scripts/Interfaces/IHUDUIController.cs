using TMPro;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// HUD UI controller interface
    /// </summary>
    public interface IHUDUIController : IBehaviour
    {
        /// <summary>
        /// Remaining time string format
        /// </summary>
        string RemainingTimeStringFormat { get; set; }

        /// <summary>
        /// Point count speed
        /// </summary>
        uint PointCountSpeed { get; set; }

        /// <summary>
        /// Points string format
        /// </summary>
        string PointsStringFormat { get; set; }

        /// <summary>
        /// Remaining time text
        /// </summary>
        TextMeshProUGUI RemainingTimeText { get; set; }

        /// <summary>
        /// Points text
        /// </summary>
        TextMeshProUGUI PointsText { get; set; }
    }
}

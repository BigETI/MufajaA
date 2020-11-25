using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// HUD UI controller script class
    /// </summary>
    public class HUDUIControllerScript : MonoBehaviour, IHUDUIController
    {
        /// <summary>
        /// Default remaining time string format
        /// </summary>
        private static readonly string defaultRemainingTimeStringFormat = "{0:00}:{1:00}:{2:000}";

        /// <summary>
        /// Default points string format
        /// </summary>
        private static readonly string defaultPointsStringFormat = "{0} P";

        /// <summary>
        /// Remaining time string format
        /// </summary>
        [SerializeField]
        private string remainingTimeStringFormat = defaultRemainingTimeStringFormat;

        /// <summary>
        /// Point count speed
        /// </summary>
        [SerializeField]
        private uint pointCountSpeed = 5000U;

        /// <summary>
        /// Points string format
        /// </summary>
        [SerializeField]
        private string pointsStringFormat = defaultPointsStringFormat;

        /// <summary>
        /// Remaining time text
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI remainingTimeText = default;

        /// <summary>
        /// Points text
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI pointsText = default;

        /// <summary>
        /// Last points
        /// </summary>
        private long lastPoints;

        /// <summary>
        /// Remaining time string format
        /// </summary>
        public string RemainingTimeStringFormat
        {
            get => remainingTimeStringFormat ?? defaultRemainingTimeStringFormat;
            set => remainingTimeStringFormat = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Point count speed
        /// </summary>
        public uint PointCountSpeed
        {
            get => pointCountSpeed;
            set => pointCountSpeed = value;
        }

        /// <summary>
        /// Points string format
        /// </summary>
        public string PointsStringFormat
        {
            get => pointsStringFormat ?? defaultPointsStringFormat;
            set => pointsStringFormat = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Remaining time text
        /// </summary>
        public TextMeshProUGUI RemainingTimeText
        {
            get => remainingTimeText;
            set => remainingTimeText = value;
        }

        /// <summary>
        /// Points text
        /// </summary>
        public TextMeshProUGUI PointsText
        {
            get => pointsText;
            set => pointsText = value;
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            if (remainingTimeText)
            {
                float remaining_time = GameManager.RemainingTime;
                remainingTimeText.text = string.Format(RemainingTimeStringFormat, Mathf.FloorToInt(remaining_time / 60.0f), Mathf.FloorToInt(remaining_time % 60.0f), Mathf.FloorToInt((remaining_time * 1000.0f) % 1000.0f));
            }
            if (pointsText)
            {
                long points = GameManager.Points;
                if (lastPoints < points)
                {
                    lastPoints += (long)(PointCountSpeed * Time.deltaTime);
                    if (lastPoints > points)
                    {
                        lastPoints = points;
                    }
                    pointsText.text = string.Format(PointsStringFormat, lastPoints);
                }
                else if (lastPoints > points)
                {
                    lastPoints -= (long)(PointCountSpeed * Time.deltaTime);
                    if (lastPoints < points)
                    {
                        lastPoints = points;
                    }
                    pointsText.text = string.Format(PointsStringFormat, lastPoints);
                }
            }
        }
    }
}

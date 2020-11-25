using System;
using UnityEngine;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Hit indicator controller script class
    /// </summary>
    public class HitIndicatorControllerScript : MonoBehaviour, IHitIndicatorController
    {
        /// <summary>
        /// Default good points text string format
        /// </summary>
        private static readonly string defaultGoodPointsTextStringFormat = "+{0}";

        /// <summary>
        /// Default bad points text string format
        /// </summary>
        private static readonly string defaultBadPointsTextStringFormat = "{0}";

        /// <summary>
        /// Good points text string format
        /// </summary>
        [SerializeField]
        private string goodPointsTextStringFormat = defaultGoodPointsTextStringFormat;

        /// <summary>
        /// Bad points text string format
        /// </summary>
        [SerializeField]
        private string badPointsTextStringFormat = defaultBadPointsTextStringFormat;

        /// <summary>
        /// Good hit indicator color
        /// </summary>
        [SerializeField]
        private Color goodHitIndicatorColor = new Color(0.5f, 1.0f, 0.5f, 1.0f);

        /// <summary>
        /// Bad hit indicator color
        /// </summary>
        [SerializeField]
        private Color badHitIndicatorColor = new Color(1.0f, 0.5f, 0.5f, 1.0f);

        /// <summary>
        /// Good points color
        /// </summary>
        [SerializeField]
        private Color goodPointsColor = new Color(0.625f, 1.0f, 0.625f, 1.0f);

        /// <summary>
        /// Bad points color
        /// </summary>
        [SerializeField]
        private Color badPointsColor = new Color(1.0f, 0.5f, 0.5f, 1.0f);

        /// <summary>
        /// Hit indicator sprite
        /// </summary>
        [SerializeField]
        private SpriteRenderer hitIndicatorSprite = default;

        /// <summary>
        /// Points text
        /// </summary>
        [SerializeField]
        private TextMesh pointsText = default;

        /// <summary>
        /// New points
        /// </summary>
        private long newPoints;

        /// <summary>
        /// Good hit indicator color
        /// </summary>
        public Color GoodHitIndicatorColor
        {
            get => goodHitIndicatorColor;
            set => goodHitIndicatorColor = value;
        }

        /// <summary>
        /// Bad hit indicator color
        /// </summary>
        public Color BadHitIndicatorColor
        {
            get => badHitIndicatorColor;
            set => badHitIndicatorColor = value;
        }

        /// <summary>
        /// Good points text string format
        /// </summary>
        public string GoodPointsTextStringFormat
        {
            get => goodPointsTextStringFormat ?? defaultGoodPointsTextStringFormat;
            set => goodPointsTextStringFormat = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Bad points text string format
        /// </summary>
        public string BadPointsTextStringFormat
        {
            get => badPointsTextStringFormat ?? defaultBadPointsTextStringFormat;
            set => badPointsTextStringFormat = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Good points color
        /// </summary>
        public Color GoodPointsColor
        {
            get => goodPointsColor;
            set => goodPointsColor = value;
        }

        /// <summary>
        /// Bad points color
        /// </summary>
        public Color BadPointsColor
        {
            get => badPointsColor;
            set => badPointsColor = value;
        }

        /// <summary>
        /// Hit indicator sprite
        /// </summary>
        public SpriteRenderer HitIndicatorSprite
        {
            get => hitIndicatorSprite;
            set => hitIndicatorSprite = value;
        }

        /// <summary>
        /// Points text
        /// </summary>
        public TextMesh PointsText
        {
            get => pointsText;
            set => pointsText = value;
        }

        /// <summary>
        /// Set values
        /// </summary>
        /// <param name="newPoints">New points</param>
        public void SetValues(long newPoints)
        {
            this.newPoints = newPoints;
            if (pointsText)
            {
                pointsText.color = (newPoints < 0L) ? badPointsColor : goodPointsColor;
                pointsText.text = string.Format((newPoints < 0L) ? BadPointsTextStringFormat : GoodPointsTextStringFormat, newPoints);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            if (hitIndicatorSprite)
            {
                hitIndicatorSprite.color = (newPoints < 0L) ? badHitIndicatorColor : goodHitIndicatorColor;
            }
        }
    }
}

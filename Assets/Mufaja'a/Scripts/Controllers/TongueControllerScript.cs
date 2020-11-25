using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Tongue controller script class
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class TongueControllerScript : TrackerControllerScript, ITongueController
    {
        /// <summary>
        /// Tongue contraction speed
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        private float tongueContractionSpeed = 100.0f;

        /// <summary>
        /// Tongue retraction speed
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        private float tongueRetractionSpeed = 100.0f;

        /// <summary>
        /// Lick hit radius
        /// </summary>
        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float lickHitRadius = 1.0f;

        /// <summary>
        /// Hit indicator show time
        /// </summary>
        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float hitIndicatorShowTime = 0.5f;

        /// <summary>
        /// Hit combo indicator show time
        /// </summary>
        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float hitComboIndicatorShowTime = 0.5f;

        /// <summary>
        /// Hit indicator asset
        /// </summary>
        [SerializeField]
        private GameObject hitIndicatorAsset = default;

        /// <summary>
        /// Hit combo indicator asset
        /// </summary>
        [SerializeField]
        private GameObject hitComboIndicatorAsset = default;

        /// <summary>
        /// On licking started
        /// </summary>
        [SerializeField]
        private UnityEvent onLickingStarted = default;

        /// <summary>
        /// On licking hit succeeded
        /// </summary>
        [SerializeField]
        private UnityEvent onLickingHitSucceeded = default;

        /// <summary>
        /// On licking hit failed
        /// </summary>
        [SerializeField]
        private UnityEvent onLickingHitFailed = default;

        /// <summary>
        /// On licking missed
        /// </summary>
        [SerializeField]
        private UnityEvent onLickingMissed = default;

        /// <summary>
        /// On licking ended
        /// </summary>
        [SerializeField]
        private UnityEvent onLickingEnded = default;

        /// <summary>
        /// Licked colliders
        /// </summary>
        private Collider2D[] lickedColliders = default;

        /// <summary>
        /// Last food hook game object
        /// </summary>
        private GameObject lastFoodHookGameObject;

        /// <summary>
        /// Tongue contraction speed
        /// </summary>
        public float TongueContractionSpeed
        {
            get => Mathf.Max(tongueContractionSpeed, 0.0f);
            set => tongueContractionSpeed = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Tongue retraction speed
        /// </summary>
        public float TongueRetractionSpeed
        {
            get => Mathf.Max(tongueRetractionSpeed, 0.0f);
            set => tongueRetractionSpeed = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Lick hit radius
        /// </summary>
        public float LickHitRadius
        {
            get => Mathf.Max(lickHitRadius, 0.0f);
            set => lickHitRadius = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Hit indicator show time
        /// </summary>
        public float HitIndicatorShowTime
        {
            get => Mathf.Max(hitIndicatorShowTime, 0.0f);
            set => hitIndicatorShowTime = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Hit combo indicator show time
        /// </summary>
        public float HitComboIndicatorShowTime
        {
            get => Mathf.Max(hitComboIndicatorShowTime, 0.0f);
            set => hitComboIndicatorShowTime = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Hit indicator asset
        /// </summary>
        public GameObject HitIndicatorAsset
        {
            get => hitIndicatorAsset;
            set => hitIndicatorAsset = value;
        }

        /// <summary>
        /// Hit combo indicator asset
        /// </summary>
        public GameObject HitComboIndicatorAsset
        {
            get => hitComboIndicatorAsset;
            set => hitComboIndicatorAsset = value;
        }

        /// <summary>
        /// Lick state
        /// </summary>
        public ELickState LickState { get; set; } = ELickState.None;

        /// <summary>
        /// Licking at position
        /// </summary>
        public Vector2 LickingAtPosition { get; private set; }

        /// <summary>
        /// Tongue sprite renderer
        /// </summary>
        public SpriteRenderer TongueSpriteRenderer { get; private set; }

        /// <summary>
        /// On licking started
        /// </summary>
        public event LickingStartedDelegate OnLickingStarted;

        /// <summary>
        /// On licking hit succeeded
        /// </summary>
        public event LickingHitSucceededDelegate OnLickingHitSucceeded;

        /// <summary>
        /// On licking hit failed
        /// </summary>
        public event LickingHitFailedDelegate OnLickingHitFailed;

        /// <summary>
        /// On licking missed
        /// </summary>
        public event LickingMissedDelegate OnLickingMissed;

        /// <summary>
        /// On licking ended
        /// </summary>
        public event LickingEndedDelegate OnLickingEnded;

        /// <summary>
        /// Lick
        /// </summary>
        public void Lick()
        {
            if ((LickState == ELickState.Ready) && TongueSpriteRenderer)
            {
                LickingAtPosition = LookingAtPosition;
                LickState = ELickState.Contracting;
                if (onLickingStarted != null)
                {
                    onLickingStarted.Invoke();
                }
                OnLickingStarted?.Invoke();
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            TongueSpriteRenderer = GetComponent<SpriteRenderer>();
            LickState = ELickState.Ready;
        }

        /// <summary>
        /// Update
        /// </summary>
        protected override void Update()
        {
            if (TongueSpriteRenderer && ((LickState == ELickState.Contracting) || (LickState == ELickState.Retracting)))
            {
                Vector3 position = transform.position;
                float licking_distance_squared = (LickingAtPosition - new Vector2(position.x, position.y)).sqrMagnitude;
                if (licking_distance_squared > 1.0f)
                {
                    float tongue_size = TongueSpriteRenderer.size.x;
                    switch (LickState)
                    {
                        case ELickState.Contracting:
                            tongue_size += TongueContractionSpeed * Time.deltaTime;
                            if ((tongue_size * tongue_size) >= licking_distance_squared)
                            {
                                tongue_size = Mathf.Sqrt(licking_distance_squared);
                                LickState = ELickState.Retracting;
                                int hit_count = PhysicsUtilities.CircleOverlapAll(LickingAtPosition, LickHitRadius, ref lickedColliders);
                                int lick_hit_count = 0;
                                long new_points = 0L;
                                bool is_food_good = true;
                                Vector3 hit_position_sum = Vector3.zero;
                                for (int licked_collider_index = 0; licked_collider_index < hit_count; licked_collider_index++)
                                {
                                    Collider2D licked_collider = lickedColliders[licked_collider_index];
                                    FoodControllerScript food_controller = licked_collider.GetComponentInParent<FoodControllerScript>();
                                    if (food_controller && food_controller.FoodObject)
                                    {
                                        Rigidbody2D[] food_rigidbodies = food_controller.GetComponentsInParent<Rigidbody2D>();
                                        Collider[] food_colliders = food_controller.GetComponentsInParent<Collider>();
                                        if (food_rigidbodies != null)
                                        {
                                            foreach (Rigidbody2D food_rigidbody in food_rigidbodies)
                                            {
                                                if (food_rigidbody)
                                                {
                                                    Destroy(food_rigidbody);
                                                }
                                            }
                                        }
                                        if (food_colliders != null)
                                        {
                                            foreach (Collider food_collider in food_colliders)
                                            {
                                                if (food_collider)
                                                {
                                                    Destroy(food_collider);
                                                }
                                            }
                                        }
                                        ++lick_hit_count;
                                        new_points += food_controller.FoodObject.Points;
                                        if (food_controller.FoodObject.Points < 0L)
                                        {
                                            is_food_good = false;
                                        }
                                        if (!lastFoodHookGameObject)
                                        {
                                            lastFoodHookGameObject = new GameObject("FoodHook");
                                            lastFoodHookGameObject.transform.position = position + ((new Vector3(LickingAtPosition.x, LickingAtPosition.y, 0.0f) - position).normalized * tongue_size);
                                        }
                                        hit_position_sum += food_controller.transform.position;
                                        food_controller.transform.SetParent(lastFoodHookGameObject.transform, true);
                                        if (hitIndicatorAsset)
                                        {
                                            GameObject hit_indicator_game_object = Instantiate(hitIndicatorAsset, food_controller.transform.position, Quaternion.identity);
                                            if (hit_indicator_game_object)
                                            {
                                                if (hit_indicator_game_object.TryGetComponent(out HitIndicatorControllerScript hit_indicator_controller))
                                                {
                                                    hit_indicator_controller.SetValues(food_controller.FoodObject.Points);
                                                }
                                                Destroy(hit_indicator_game_object, HitIndicatorShowTime);
                                            }
                                        }
                                    }
                                }
                                if (lick_hit_count > 0)
                                {
                                    if (is_food_good)
                                    {
                                        new_points *= lick_hit_count;
                                        if ((lick_hit_count > 1) && hitComboIndicatorAsset)
                                        {
                                            GameObject hit_combo_indicator_game_object = Instantiate(hitComboIndicatorAsset, hit_position_sum / lick_hit_count, Quaternion.identity);
                                            if (hit_combo_indicator_game_object)
                                            {
                                                if (hit_combo_indicator_game_object.TryGetComponent(out HitComboIndicatorControllerScript hit_combo_indicator_controller))
                                                {
                                                    hit_combo_indicator_controller.SetValues((uint)lick_hit_count);
                                                }
                                                Destroy(hit_combo_indicator_game_object, HitComboIndicatorShowTime);
                                            }
                                        }
                                        if (onLickingHitSucceeded != null)
                                        {
                                            onLickingHitSucceeded.Invoke();
                                        }
                                        OnLickingHitSucceeded?.Invoke();
                                    }
                                    else
                                    {
                                        if (onLickingHitFailed != null)
                                        {
                                            onLickingHitFailed.Invoke();
                                        }
                                        OnLickingHitFailed?.Invoke();
                                    }
                                }
                                else
                                {
                                    if (onLickingMissed != null)
                                    {
                                        onLickingMissed.Invoke();
                                    }
                                    OnLickingMissed?.Invoke();
                                }
                                GameManager.Points += new_points;
                            }
                            break;
                        case ELickState.Retracting:
                            tongue_size -= TongueRetractionSpeed * Time.deltaTime;
                            if (tongue_size <= 1.0f)
                            {
                                tongue_size = 1.0f;
                                if (lastFoodHookGameObject)
                                {
                                    Destroy(lastFoodHookGameObject);
                                }
                                LickState = ELickState.Ready;
                                if (onLickingEnded != null)
                                {
                                    onLickingEnded.Invoke();
                                }
                                OnLickingEnded?.Invoke();
                            }
                            break;
                    }
                    if (lastFoodHookGameObject)
                    {
                        lastFoodHookGameObject.transform.position = position + ((new Vector3(LickingAtPosition.x, LickingAtPosition.y, 0.0f) - position).normalized * tongue_size);
                    }
                    TongueSpriteRenderer.size = new Vector2(tongue_size, 1.0f / Mathf.Pow(tongue_size, 0.25f));
                }
                else
                {
                    if (lastFoodHookGameObject)
                    {
                        Destroy(lastFoodHookGameObject);
                    }
                    LickState = ELickState.Ready;
                    if (onLickingEnded != null)
                    {
                        onLickingEnded.Invoke();
                    }
                    OnLickingEnded?.Invoke();
                }
            }
            else
            {
                base.Update();
            }
        }
    }
}

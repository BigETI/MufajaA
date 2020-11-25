using MufajaA.Objects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityTiming.Data;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Food spawn controller script class
    /// </summary>
    public class FoodSpawnControllerScript : MonoBehaviour, IFoodSpawnController
    {
        /// <summary>
        /// Minimal launch speed
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        private float minimalLaunchSpeed = 10.0f;

        /// <summary>
        /// Maximal launch speed
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        private float maximalLaunchSpeed = 15.0f;

        /// <summary>
        /// Minimal launch angular speed
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        private float minimalLaunchAngularSpeed = 0.0f;

        /// <summary>
        /// Maximal launch angular speed
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        private float maximalLaunchAngularSpeed = 20.0f;

        /// <summary>
        /// Random angle
        /// </summary>
        [SerializeField]
        [Range(0.0f, 360.0f)]
        private float randomAngle = 15.0f;

        /// <summary>
        /// Shot time
        /// </summary>
        [SerializeField]
        [Range(0.0f, 10.0f)]
        private float shotTime = 0.125f;

        /// <summary>
        /// Burst quantity
        /// </summary>
        [SerializeField]
        private uint burstQuantity = 5U;

        /// <summary>
        /// Burst wait time
        /// </summary>
        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float burstWaitTime = 2.0f;

        /// <summary>
        /// Food alive time
        /// </summary>
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        private float foodAliveTime = 10.0f;

        /// <summary>
        /// On firing food started
        /// </summary>
        [SerializeField]
        private UnityEvent onFiringFoodStarted = default;

        /// <summary>
        /// On firing food ended
        /// </summary>
        [SerializeField]
        private UnityEvent onFiringFoodEnded = default;

        /// <summary>
        /// Food spawner state
        /// </summary>
        private EFoodSpawnerState foodSpawnerState = EFoodSpawnerState.Firing;

        /// <summary>
        /// Food assets
        /// </summary>
        private List<(GameObject, float)> foodAssets = new List<(GameObject, float)>();

        /// <summary>
        /// Food assets bias sum
        /// </summary>
        private float foodAssetsBiasSum;

        /// <summary>
        /// Timing data
        /// </summary>
        private TimingData timingData;

        /// <summary>
        /// Remaining burst shot count
        /// </summary>
        private uint remainingBurstShotCount;

        /// <summary>
        /// Remaining time
        /// </summary>
        private float remainingTime;

        /// <summary>
        /// Minimal launch speed
        /// </summary>
        public float MinimalLaunchSpeed
        {
            get => Mathf.Max(minimalLaunchSpeed, 0.0f);
            set => minimalLaunchSpeed = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Maximal launch speed
        /// </summary>
        public float MaximalLaunchSpeed
        {
            get => Mathf.Max(MinimalLaunchSpeed, maximalLaunchSpeed);
            set => maximalLaunchSpeed = Mathf.Max(value, MinimalLaunchSpeed);
        }

        /// <summary>
        /// Minimal launch angular speed
        /// </summary>
        public float MinimalLaunchAngularSpeed
        {
            get => Mathf.Max(minimalLaunchAngularSpeed, 0.0f);
            set => minimalLaunchAngularSpeed = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Maximal launch angular speed
        /// </summary>
        public float MaximalLaunchAngularSpeed
        {
            get => Mathf.Max(MinimalLaunchAngularSpeed, maximalLaunchAngularSpeed);
            set => maximalLaunchAngularSpeed = Mathf.Max(value, MinimalLaunchAngularSpeed);
        }

        /// <summary>
        /// Random angle
        /// </summary>
        public float RandomAngle
        {
            get => Mathf.Repeat(randomAngle, 360.0f - float.Epsilon);
            set => randomAngle = Mathf.Repeat(value, 360.0f - float.Epsilon);
        }

        /// <summary>
        /// Shot time
        /// </summary>
        public float ShotTime
        {
            get => Mathf.Max(shotTime, 0.0f);
            set => shotTime = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Burst quantity
        /// </summary>
        public uint BurstQuantity
        {
            get => burstQuantity;
            set => burstQuantity = value;
        }

        /// <summary>
        /// Burst wait time
        /// </summary>
        public float BurstWaitTime
        {
            get => Mathf.Max(burstWaitTime, 0.0f);
            set => burstWaitTime = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Food alive time
        /// </summary>
        public float FoodAliveTime
        {
            get => Mathf.Max(foodAliveTime, 0.0f);
            set => foodAliveTime = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Food spawner state
        /// </summary>
        public EFoodSpawnerState FoodSpawnerState
        {
            get => foodSpawnerState;
            private set
            {
                if (foodSpawnerState != value)
                {
                    foodSpawnerState = value;
                    switch (foodSpawnerState)
                    {
                        case EFoodSpawnerState.Firing:
                            if (onFiringFoodStarted != null)
                            {
                                onFiringFoodStarted.Invoke();
                            }
                            OnFiringFoodStarted?.Invoke();
                            break;
                        case EFoodSpawnerState.Waiting:
                            if (onFiringFoodEnded != null)
                            {
                                onFiringFoodEnded.Invoke();
                            }
                            OnFiringFoodEnded?.Invoke();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Food assets
        /// </summary>
        public IReadOnlyList<(GameObject, float)> FoodAssets => foodAssets;

        /// <summary>
        /// On firing food started
        /// </summary>
        public event FiringFoodStartedDelegate OnFiringFoodStarted;

        /// <summary>
        /// On firing food ended
        /// </summary>
        public event FiringFoodEndedDelegate OnFiringFoodEnded;

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            FoodObjectScript[] food_objects = Resources.LoadAll<FoodObjectScript>("Food");
            if (food_objects != null)
            {
                foreach (FoodObjectScript food_object in food_objects)
                {
                    if (food_object.Asset)
                    {
                        foodAssets.Add((food_object.Asset, food_object.Bias));
                        foodAssetsBiasSum += food_object.Bias;
                    }
                }
            }
            timingData = new TimingData(ShotTime);
            remainingBurstShotCount = BurstQuantity;
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            if (foodAssets.Count > 0)
            {
                int ticks = timingData.ProceedUpdate(false, false) + timingData.ProceedTime(remainingTime);
                uint shot_count;
                remainingTime = 0.0f;
                switch (foodSpawnerState)
                {
                    case EFoodSpawnerState.Firing:
                        if (remainingBurstShotCount <= ticks)
                        {
                            shot_count = remainingBurstShotCount;
                            ticks -= (int)remainingBurstShotCount;
                            remainingBurstShotCount = 0U;
                            remainingTime = (timingData.TickTime * ticks) + timingData.ElapsedTickTime;
                            timingData.Reset();
                            timingData.TickTime = BurstWaitTime;
                            FoodSpawnerState = EFoodSpawnerState.Waiting;
                        }
                        else
                        {
                            shot_count = (uint)ticks;
                            remainingBurstShotCount -= (uint)ticks;
                        }
                        float random_angle = RandomAngle;
                        for (int shot_index = 0; shot_index < shot_count; shot_index++)
                        {
                            float selection = Random.Range(0.0f, foodAssetsBiasSum);
                            GameObject food_asset = null;
                            foreach ((GameObject, float) current_food_asset in foodAssets)
                            {
                                selection -= current_food_asset.Item2;
                                if (selection <= 0.0f)
                                {
                                    food_asset = current_food_asset.Item1;
                                    break;
                                }
                            }
                            if (food_asset)
                            {
                                GameObject food_game_object = Instantiate(food_asset, transform.position, Quaternion.identity);
                                if (food_game_object != null)
                                {
                                    if (food_game_object.TryGetComponent(out Rigidbody2D food_rigidbody))
                                    {
                                        Vector3 new_up = Quaternion.AngleAxis(Random.Range(random_angle * -0.5f, random_angle * 0.5f), Vector3.forward) * transform.up;
                                        food_rigidbody.velocity = new Vector2(new_up.x, new_up.y) * Random.Range(MinimalLaunchSpeed, MaximalLaunchSpeed);
                                        food_rigidbody.angularVelocity = Random.Range(MinimalLaunchAngularSpeed, MaximalLaunchAngularSpeed) * ((Random.Range(0, 2) == 0) ? 1.0f : -1.0f);
                                        Destroy(food_game_object, FoodAliveTime);
                                    }
                                    else
                                    {
                                        Destroy(food_game_object);
                                    }
                                }
                            }
                        }
                        break;
                    case EFoodSpawnerState.Waiting:
                        if (ticks > 0)
                        {
                            ticks -= 1;
                            remainingTime = (timingData.TickTime * ticks) + timingData.ElapsedTickTime;
                            timingData.Reset();
                            timingData.TickTime = ShotTime;
                            remainingBurstShotCount = BurstQuantity;
                            FoodSpawnerState = EFoodSpawnerState.Firing;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// On draw gizmos
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 0.25f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (transform.up * MaximalLaunchSpeed));
            Gizmos.color = Color.magenta;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation * Quaternion.FromToRotation(Vector3.forward, Vector3.up), Vector3.one);
            Gizmos.DrawFrustum(Vector3.zero, RandomAngle, MaximalLaunchSpeed, 0.0f, 1.0f);
            Gizmos.color = Color.blue;
            Gizmos.DrawFrustum(Vector3.zero, RandomAngle, MinimalLaunchSpeed, 0.0f, 1.0f);
        }
    }
}

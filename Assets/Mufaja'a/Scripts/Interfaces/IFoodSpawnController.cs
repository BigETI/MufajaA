using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Food spawner controller interface
    /// </summary>
    public interface IFoodSpawnController : IBehaviour
    {
        /// <summary>
        /// Minimal launch speed
        /// </summary>
        float MinimalLaunchSpeed { get; set; }

        /// <summary>
        /// Maximal launch speed
        /// </summary>
        float MaximalLaunchSpeed { get; set; }

        /// <summary>
        /// Minimal launch angular speed
        /// </summary>
        float MinimalLaunchAngularSpeed { get; set; }

        /// <summary>
        /// Maximal launch angular speed
        /// </summary>
        float MaximalLaunchAngularSpeed { get; set; }

        /// <summary>
        /// Random angle
        /// </summary>
        float RandomAngle { get; set; }

        /// <summary>
        /// Shot time
        /// </summary>
        float ShotTime { get; set; }

        /// <summary>
        /// Burst quantity
        /// </summary>
        uint BurstQuantity { get; set; }

        /// <summary>
        /// Burst wait time
        /// </summary>
        float BurstWaitTime { get; set; }

        /// <summary>
        /// Food alive time
        /// </summary>
        float FoodAliveTime { get; set; }

        /// <summary>
        /// Food spawner state
        /// </summary>
        EFoodSpawnerState FoodSpawnerState { get; }

        /// <summary>
        /// Food assets
        /// </summary>
        IReadOnlyList<(GameObject, float)> FoodAssets { get; }

        /// <summary>
        /// On firing food started
        /// </summary>
        event FiringFoodStartedDelegate OnFiringFoodStarted;

        /// <summary>
        /// On firing food ended
        /// </summary>
        event FiringFoodEndedDelegate OnFiringFoodEnded;
    }
}

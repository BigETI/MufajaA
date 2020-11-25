using UnityEngine;
using UnityEngine.Events;
using UnityTiming.Data;
using UnityUtils;

/// <summary>
/// Mufaja'a managers namespace
/// </summary>
namespace MufajaA.Managers
{
    /// <summary>
    /// Game manager script class
    /// </summary>
    public class GameManagerScript : AManagerScript<GameManagerScript>, IGameManager
    {
        /// <summary>
        /// On points updated
        /// </summary>
        [SerializeField]
        private UnityEvent<long> onPointsUpdated = default;

        /// <summary>
        /// On counting started
        /// </summary>
        [SerializeField]
        private UnityEvent onCountingStarted = default;

        /// <summary>
        /// On count ticked
        /// </summary>
        [SerializeField]
        private UnityEvent<uint> onCountTicked = default;

        /// <summary>
        /// On game started
        /// </summary>
        [SerializeField]
        private UnityEvent onGameStarted = default;

        /// <summary>
        /// On game paused
        /// </summary>
        [SerializeField]
        private UnityEvent onGamePaused = default;

        /// <summary>
        /// On game resumed
        /// </summary>
        [SerializeField]
        private UnityEvent onGameResumed = default;

        /// <summary>
        /// On game ended
        /// </summary>
        [SerializeField]
        private UnityEvent onGameEnded = default;

        /// <summary>
        /// Game state
        /// </summary>
        private EGameState gameState;

        /// <summary>
        /// Points
        /// </summary>
        private long points;

        /// <summary>
        /// Remaining counter count
        /// </summary>
        private uint remainingCounterCount = 4U;

        /// <summary>
        /// Timing data
        /// </summary>
        private TimingData timingData = new TimingData(1.0f);

        /// <summary>
        /// Game state
        /// </summary>
        public EGameState GameState
        {
            get => gameState;
            set
            {
                switch (gameState)
                {
                    case EGameState.None:
                        if (value == EGameState.Counting)
                        {
                            gameState = EGameState.Counting;
                            if (onCountingStarted != null)
                            {
                                onCountingStarted.Invoke();
                            }
                            OnCountingStarted?.Invoke();
                        }
                        break;
                    case EGameState.Counting:
                        if (value == EGameState.Playing)
                        {
                            gameState = EGameState.Playing;
                            if (onGameStarted != null)
                            {
                                onGameStarted.Invoke();
                            }
                            OnGameStarted?.Invoke();
                        }
                        break;
                    case EGameState.Playing:
                        switch (value)
                        {
                            case EGameState.Paused:
                                if (onGamePaused != null)
                                {
                                    onGamePaused.Invoke();
                                }
                                OnGamePaused?.Invoke();
                                break;
                            case EGameState.GameOver:
                                if (onGameEnded != null)
                                {
                                    onGameEnded.Invoke();
                                }
                                OnGameEnded?.Invoke();
                                break;
                        }
                        break;
                    case EGameState.Paused:
                        if (value == EGameState.Playing)
                        {
                            if (onGameResumed != null)
                            {
                                onGameResumed.Invoke();
                            }
                            OnGameResumed?.Invoke();
                        }
                        break;
                    case EGameState.GameOver:
                        break;
                }
            }
        }

        /// <summary>
        /// Points
        /// </summary>
        public long Points
        {
            get => points;
            set
            {
                if (points != value)
                {
                    points = value;
                    if (onPointsUpdated != null)
                    {
                        onPointsUpdated.Invoke(points);
                    }
                    OnPointsUpdated?.Invoke(points);
                }
            }
        }

        /// <summary>
        /// Remaining counter count
        /// </summary>
        public uint RemainingCounterCount
        {
            get => remainingCounterCount;
            private set
            {
                if (remainingCounterCount != value)
                {
                    remainingCounterCount = value;
                    if (onCountTicked != null)
                    {
                        onCountTicked.Invoke(remainingCounterCount);
                    }
                    OnCountTicked?.Invoke(remainingCounterCount);
                }
            }
        }

        /// <summary>
        /// Remaining time
        /// </summary>
        public float RemainingTime { get; private set; } = 40.0f;

        /// <summary>
        /// On points updated
        /// </summary>
        public event PointsUpdatedDelegate OnPointsUpdated;

        /// <summary>
        /// On counting started
        /// </summary>
        public event CountingStartedDelegate OnCountingStarted;

        /// <summary>
        /// On count ticked
        /// </summary>
        public event CountTickedDelegate OnCountTicked;

        /// <summary>
        /// On game started
        /// </summary>
        public event GameStartedDelegate OnGameStarted;

        /// <summary>
        /// On game paused
        /// </summary>
        public event GamePausedDelegate OnGamePaused;

        /// <summary>
        /// On game resumed
        /// </summary>
        public event GameResumedDelegate OnGameResumed;

        /// <summary>
        /// On game ended
        /// </summary>
        public event GameEndedDelegate OnGameEnded;

        /// <summary>
        /// Start counting
        /// </summary>
        public void StartCounting() => GameState = EGameState.Counting;

        /// <summary>
        /// Exit game
        /// </summary>
        public void ExitGame() => Game.Quit();

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            switch (gameState)
            {
                case EGameState.Counting:
                    int ticks = timingData.ProceedUpdate(false, false);
                    if (ticks > RemainingCounterCount)
                    {
                        RemainingCounterCount = 0U;
                        timingData.Reset();
                        GameState = EGameState.Playing;
                    }
                    else
                    {
                        RemainingCounterCount -= (uint)ticks;
                    }
                    break;
                case EGameState.Playing:
                    RemainingTime -= Time.deltaTime;
                    if (RemainingTime <= 0.0f)
                    {
                        RemainingTime = 0.0f;
                        GameState = EGameState.GameOver;
                    }
                    break;
            }
        }
    }
}

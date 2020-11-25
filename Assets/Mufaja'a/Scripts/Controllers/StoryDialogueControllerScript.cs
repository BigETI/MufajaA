using MufajaA.Data;
using System;
using UnityEngine;
using UnityTiming.Data;

/// <summary>
/// Mufaja'a controllers namespace
/// </summary>
namespace MufajaA.Controllers
{
    /// <summary>
    /// Story dialogue controller script class
    /// </summary>
    public class StoryDialogueControllerScript : MonoBehaviour, IStoryDialogueController
    {
        /// <summary>
        /// Is running
        /// </summary>
        [SerializeField]
        private bool isRunning;

        /// <summary>
        /// Story
        /// </summary>
        [SerializeField]
        private StoryData[] story = Array.Empty<StoryData>();

        /// <summary>
        /// Current story index
        /// </summary>
        private int currentStoryIndex = -1;

        /// <summary>
        /// Story timing data
        /// </summary>
        private TimingData storyTimingData;

        /// <summary>
        /// Remaining elapsed time
        /// </summary>
        private float remainingElapsedTime;

        /// <summary>
        /// Is running
        /// </summary>
        public bool IsRunning
        {
            get => isRunning;
            set => isRunning = value;
        }

        /// <summary>
        /// Story
        /// </summary>
        public StoryData[] Story
        {
            get => story ?? Array.Empty<StoryData>();
            set => story = (StoryData[])(value ?? throw new ArgumentNullException(nameof(value))).Clone();
        }

        /// <summary>
        /// Current story index
        /// </summary>
        public int CurrentStoryIndex
        {
            get => currentStoryIndex;
            set
            {
                currentStoryIndex = value;
                storyTimingData.Reset();
                IStoryData new_story = CurrentStory;
                if (new_story != null)
                {
                    storyTimingData.TickTime = new_story.Time;
                    if (new_story.OnExecuted != null)
                    {
                        new_story.OnExecuted.Invoke();
                    }
                }
            }
        }

        /// <summary>
        /// Current story
        /// </summary>
        public IStoryData CurrentStory
        {
            get
            {
                StoryData[] story = Story;
                return ((currentStoryIndex >= 0) && (currentStoryIndex < story.Length)) ? (IStoryData)story[currentStoryIndex] : null;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            if (isRunning)
            {
                StoryData[] story = Story;
                IStoryData current_story = CurrentStory;
                if ((currentStoryIndex < 0) && (story.Length > 0))
                {
                    CurrentStoryIndex = 0;
                }
                else if (current_story != null)
                {
                    int ticks = storyTimingData.ProceedUpdate(false, false) + storyTimingData.ProceedTime(remainingElapsedTime);
                    remainingElapsedTime = 0.0f;
                    if (ticks > 0)
                    {
                        remainingElapsedTime = (storyTimingData.TickTime * (ticks - 1)) + storyTimingData.ElapsedTickTime;
                        if ((currentStoryIndex + 1) < story.Length)
                        {
                            ++CurrentStoryIndex;
                        }
                    }
                }
            }
        }
    }
}

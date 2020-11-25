using MufajaA.Data;

/// <summary>
/// Mufaja'a namespace
/// </summary>
namespace MufajaA
{
    /// <summary>
    /// Story dialogue controller interface
    /// </summary>
    public interface IStoryDialogueController
    {
        /// <summary>
        /// Is running
        /// </summary>
        bool IsRunning { get; set; }

        /// <summary>
        /// Story
        /// </summary>
        StoryData[] Story { get; set; }

        /// <summary>
        /// Current story index
        /// </summary>
        int CurrentStoryIndex { get; set; }

        /// <summary>
        /// Current story
        /// </summary>
        IStoryData CurrentStory { get; }
    }
}

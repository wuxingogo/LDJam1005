using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    [System.Serializable]
    /// <summary>
    /// A serializable entity to store retro adventure scenes, whether they've been completed, unlocked, how many stars were collected, and which ones
    /// </summary>
    public class RetroAdventureScene
    {
        public string SceneName;
        public bool LevelComplete = false;
        public bool LevelUnlocked = false;
        public int MaxStars;
        public bool[] CollectedStars;
    }

    [System.Serializable]
    /// <summary>
    /// A serializable entity used to store progress : a list of scenes with their internal status (see above), how many lives are left, and how much we can have
    /// </summary>
    public class Progress
    {
        public int InitialMaximumLives = 0;
        public int InitialCurrentLives = 0;
        public int MaximumLives = 0;
        public int CurrentLives = 0;
        public RetroAdventureScene[] Scenes;
    }
}
using UnityEngine;

namespace Score
{
    public class GameScore
    {
        public int Score {  get; private set; }
        public GameScore(int score)
        {
            Score = score;
        }

        public GameScore()
        {
            Score = 0;
        }
        public void AddScore(int score)
        {
            Score += score;
        }
        public void Save()
        {
            PlayerPrefs.SetInt(GameConfig.ScoreKey, Score);
        }

        public bool Load()
        {
            if(PlayerPrefs.HasKey(GameConfig.ScoreKey))
            {
                Score = PlayerPrefs.GetInt(GameConfig.ScoreKey);
                return true;
            }
            else
            {
                Score = 0;
                return false;
            }
            
        }
    }
}

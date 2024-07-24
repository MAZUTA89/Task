public static class GameConfig
{
    public static readonly string GameSceneName;
    public static readonly string MenuSceneName;
    public static readonly string ScoreKey;

    static GameConfig()
    {
        GameSceneName = "GameScene";
        MenuSceneName = "MenuScene";
        ScoreKey = "GameScore";
    }
}

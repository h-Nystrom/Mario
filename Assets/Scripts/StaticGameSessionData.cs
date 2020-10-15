public static class StaticGameSessionData {
    static int _lifes = 3;
    static int _Score = 0;
    static int _currentLevel = 0;
    public static int Lifes {
        get => _lifes;
        set => _lifes = value;
    }
    public static int Score {
        get => _Score;
        set => _Score = value;
    }
    public static int CurrentLevel {
        get => _currentLevel;
        set => _currentLevel = value;
    }
    public static bool PlayerIsDead { get => Lifes == 0; }

}
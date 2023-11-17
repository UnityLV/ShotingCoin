public class LevelCompleteCondition
{
    public bool IsThisLevelCompleted(int level)
    {
        return UnityEngine.PlayerPrefs.GetInt($"{level}") == 1;
    }

    public bool IsThisLastUncompleted(int level)
    {
        int levels = 10;

        for (int i = 1; i <= levels; i++)
        {
            if (UnityEngine.PlayerPrefs.GetInt($"{i}") == 0)
            {
                return i == level;
            }
        }

        return false;
    }
}
using UnityEngine.SceneManagement;



public class LevelSequenceController : SingletonBase<LevelSequenceController>
{
    public static string MainMenuSceneNickname = "MainMenu";//имя сцены главного меню

    public Episode CurrentEpisode { get; private set; }

    public int CurrentLevel { get; private set; }//индекс в общем массиве всех уровней эпизода


    public void StartEpisode(Episode e)
    {
        CurrentEpisode = e;
        CurrentLevel = 0;

        SceneManager.LoadScene(e.Levels[CurrentLevel]);
    }


    public void FinishCurrentLevel(bool succes)
    {
        AdvanceLevel();
    }


    /// <summary>
    /// завершение уровня
    /// </summary>
    public void AdvanceLevel()
    {

        CurrentLevel++;

        if (CurrentEpisode.Levels.Length <= CurrentLevel)
        {
            SceneManager.LoadScene(MainMenuSceneNickname);
        }
        else
        {
            SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
        }
    }


}

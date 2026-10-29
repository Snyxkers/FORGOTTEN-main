using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject storyPanel;
    public GameObject settingsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenStory()
    {
        storyPanel.SetActive(true);
    }

    public void CloseStory()
    {
        storyPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
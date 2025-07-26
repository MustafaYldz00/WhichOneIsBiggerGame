using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _replyButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private GameObject _pausePanel;

    private TimerManager _timerManager;

    private void Start()
    {
        _timerManager = Object.FindAnyObjectByType<TimerManager>();
    }

    public void pauseButton()
    {
         _timerManager.PauseTimer();
         _pausePanel.SetActive(true);
    }

    public void resumeButton()
    {
         _timerManager.ResumeTimer();
         _pausePanel.SetActive(false); 
    }

    public void replyButton()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MenuLevel");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerDisplay;
    [SerializeField] private int _minutes, _seconds;

    [SerializeField] private TextMeshProUGUI _scoreDisplay;

    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private TextMeshProUGUI _finalScoreDisplay;

    public static GameManager Instance { get; private set; }

    private bool _isRunning;

    private int _totalScore;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this; 
    }

    public bool IsGameRunning()
    {
        return _isRunning;
    }


    // Start is called before the first frame update
    void Start()
    {
        _isRunning = true;
        _totalScore = 0;
        TogglePanels();
        DisplayScore();
        StartCoroutine(StartTimer());   
    }

    private void TogglePanels()
    {
        _gameOverPanel.SetActive(!_isRunning);
        _gamePanel.SetActive(_isRunning);
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    public void AddScore()
    {
        _totalScore++;

        DisplayScore();
    }
        
    private void DisplayScore()
    {
        _scoreDisplay.text = _totalScore.ToString("000");
    }

    private IEnumerator StartTimer()
    {
        int totalSeconds = (_minutes * 60) + _seconds;

        while(_isRunning && totalSeconds >= 0)
        {
            UpdateTimer(totalSeconds);
            yield return new WaitForSeconds(1);
            totalSeconds--;
        }

        _isRunning = false;

        _finalScoreDisplay.text = "Score: " + _totalScore.ToString("000");

        TogglePanels();

    }

    private void UpdateTimer(int totalSeconds)
    {
        int minutes = Mathf.RoundToInt(totalSeconds / 60);
        int seconds = Mathf.RoundToInt(totalSeconds % 60);

        string timerDisplay = minutes.ToString() + ":" + seconds.ToString("00");

        _timerDisplay.text = timerDisplay;
    }
}

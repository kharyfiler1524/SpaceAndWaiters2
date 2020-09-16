using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreValueText;
    public TextMeshProUGUI victorySplash;
    public TextMeshProUGUI lossSplash;
    public GameObject playAgainButtonObj;
    public GameObject exitToMainButtonObj;

    int score;

    public static ScoreController instance;
    private void Awake()
    {
        Time.timeScale = 1;
        score = 0;
        instance = this;

        playAgainButtonObj.GetComponent<Button>().onClick.AddListener(PlayAgain);
        exitToMainButtonObj.GetComponent<Button>().onClick.AddListener(MainMenu);

        victorySplash.enabled = false;
        lossSplash.enabled = false;
        ToggleFightSceneButtons(false);
    }

    private void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreValueText.text = score.ToString();
    }

    public void VictorySplash()
    {
        Time.timeScale = 0;
        victorySplash.enabled = true;
        ToggleFightSceneButtons(true);
    }

    public void LossSplash()
    {
        Time.timeScale = 0;
        lossSplash.enabled = true;
        ToggleFightSceneButtons(true);
    }

    void ToggleFightSceneButtons(bool toggle)
    {
        playAgainButtonObj.SetActive(toggle);
        exitToMainButtonObj.SetActive(toggle);
    }

    void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

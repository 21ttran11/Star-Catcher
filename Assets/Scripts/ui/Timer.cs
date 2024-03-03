using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] float timeRemaining = 30f;
    [SerializeField] TextMeshProUGUI timer;
    bool isFinished = false;

    [SerializeField] GameObject endCanvas;

    void Update()
    {
        if (!isFinished)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                isFinished = true;
                PauseGame();
                ShowEnd();
            }
            else
            {
                int seconds = Mathf.FloorToInt(timeRemaining % 60);
                timer.text = seconds.ToString();
            }
        if (isFinished)
            {

            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }
    void ShowEnd()
    {
        endCanvas.SetActive(true);
    }

}

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] float timeRemaining = 30f;
    [SerializeField] TextMeshProUGUI timer;
    bool isFinished = false;

    void Update()
    {
        if (!isFinished)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                isFinished = true;
            }
            else
            {
                int seconds = Mathf.FloorToInt(timeRemaining % 60);
                timer.text = seconds.ToString();
            }
        }
    }
}

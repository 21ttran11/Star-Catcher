using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointBox : MonoBehaviour
{
    public Net net;
    [SerializeField] private List<AudioClip> sounds;
    [SerializeField] private int score;

    public TMP_Text scoreText; 

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Point");
        if (collider.CompareTag("Star"))
            net.HandleStar(collider.gameObject);

        score += 1;

        int soundIndex = (score - 1) % sounds.Count;
        SoundManager.instance.PlaySound(sounds[soundIndex]);

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); 
        }
    }
}
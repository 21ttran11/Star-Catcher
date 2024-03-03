using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointBox : MonoBehaviour
{
    public Net net;
    [SerializeField] private List<AudioClip> sounds;
    [SerializeField] private int score;
    [SerializeField] private int bluereward;

    public TMP_Text scoreText;
    public TMP_Text scoreText2;

    private readonly Dictionary<string, int> starCounts = new Dictionary<string, int>();
    private readonly Dictionary<string, int> starPointRewards = new Dictionary<string, int>();

    private void Start()
    {
        starCounts["BlueStar"] = 0;
        starCounts["OrangeStar"] = 0;
        starPointRewards["BlueStar"] = bluereward;
        starPointRewards["OrangeStar"] = 0;
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Point");
        if (collider.CompareTag("Star"))
        {
            string starType = collider.gameObject.name.ToLower();
            if (starType.StartsWith("bluestar"))
                starType = "BlueStar";

            if (starType.StartsWith("orangestar"))
                starType = "OrangeStar";
            net.HandleStar(collider.gameObject);

            // Update star count
            if (!starCounts.ContainsKey(starType))
            {
                starCounts[starType] = 0;
            }
            starCounts[starType]++;

            if (starPointRewards.ContainsKey(starType) && starCounts[starType] % 10 == 0)
            {
                score += starPointRewards[starType];
            }
            else
            {
                score += 1;
            }

            // Play sound
            int soundIndex = (score - 1) % sounds.Count;
            SoundManager.instance.PlaySound(sounds[soundIndex]);

            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if (scoreText2 != null)
        {
            scoreText2.text = "score: " + score.ToString();
        }
    }
}
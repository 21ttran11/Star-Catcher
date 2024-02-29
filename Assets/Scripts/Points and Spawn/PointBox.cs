using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBox : MonoBehaviour
{
    public Net net;
    [SerializeField] private List<AudioClip> sounds;
    [SerializeField] private int score;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Point");
        if (collider.CompareTag("Star"))
            net.HandleStar(collider.gameObject);

        score += 1;

        int soundIndex = (score - 1) % sounds.Count;
        SoundManager.instance.PlaySound(sounds[soundIndex]);
    }
}
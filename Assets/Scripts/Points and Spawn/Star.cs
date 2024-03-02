using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Net net;
    [SerializeField] 
    float MoveSpeed = 1f;
    public ParticleSystem particles;

    private void Start()
    {
        net = FindObjectOfType<Net>();
        Debug.Log("Fish created");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, net.transform.position, Time.deltaTime * MoveSpeed); // object moves towards the net (center of screen)
    }

    private void OnDestroy()
    {
        Debug.Log("Bye Bye Fish");
        PlayParticleEffect();
    }

    private void PlayParticleEffect()
    {
        GameObject particleInstance = Instantiate(particles, transform.position, Quaternion.identity).gameObject;
        Destroy(particleInstance, 2f);
    }
}

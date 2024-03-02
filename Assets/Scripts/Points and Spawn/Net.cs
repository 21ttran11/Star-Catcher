using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    public float rotationSpeed;
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.1f;
    StarManager em;

    private void Start()
    {
        em = FindObjectOfType<StarManager>();
    }

    public void HandleStar(GameObject other)
    {
        if (em && em.usePooling)
            em.Pool.StarPool.Release(other);
        else
            Destroy(other);

        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if (collider.CompareTag("Star"))
            HandleStar(collider.gameObject);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * -horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
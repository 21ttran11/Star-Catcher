using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    public float rotationSpeed;

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
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if (collider.CompareTag("Star"))
            HandleStar(collider.gameObject);
    }
    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = (Vector2)mousePosition - (Vector2)transform.position;
        transform.up = direction.normalized;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    public ObjectPool<GameObject> StarPool
    {
        get; protected set;
    }

    [SerializeField] GameObject starPrefab;

    private void OnEnable()
    {
        StarPool = new ObjectPool<GameObject>(CreatePooledStar, OnGetStarFromPool, OnReleasedPool, OnDestroyFromPool);
    }

    GameObject CreatePooledStar()
    {
        GameObject obj = Instantiate(starPrefab);
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        return obj;
    }

    void OnGetStarFromPool(GameObject star)
    {
        gameObject.SetActive(true);
    }

    void OnReleasedPool(GameObject star)
    {
        gameObject.SetActive(false);
    }

    void OnDestroyFromPool(GameObject star)
    {
        Destroy(gameObject);
    }
}

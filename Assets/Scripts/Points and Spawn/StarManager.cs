using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Pool))]
public class StarManager : MonoBehaviour
{
    [SerializeField]
    int maxStarSpawned = 20;

    [SerializeField]
    private float spawnPerSecond = 1;

    public bool usePooling = false;
    [SerializeField]
    GameObject starPrefab;

    [Header("Ranges")]
    public float maxx;
    public float minx;
    public float maxy;
    public float miny;

    public Pool Pool
    {
        get; protected set;
    }

    float timer = 0;
    public readonly int curSpawned = 0;

    private void Start()
    {
        Pool = GetComponent<Pool>();
    }

    GameObject SpawnStar()
    {
        GameObject go;
        if (usePooling)
        {
            go = Pool.StarPool.Get();
        }
        else
        {        
            go = Instantiate(starPrefab, transform);
        }

        go.transform.position = new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy));
        return go;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(curSpawned < maxStarSpawned && timer > 1f / spawnPerSecond)
        {
            SpawnStar();
            timer = 0;
        }
    }
}

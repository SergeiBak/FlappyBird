using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pipes;
    [SerializeField]
    private float spawnRate = 1f;
    [SerializeField]
    private float minHeight = -1f;
    [SerializeField]
    private float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        GameObject pipeset = Instantiate(pipes, transform.position, Quaternion.identity);
        pipeset.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}

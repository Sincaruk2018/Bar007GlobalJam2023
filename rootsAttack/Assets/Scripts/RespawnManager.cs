using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] veggies;
    [SerializeField] public Transform[] veggieTarget; 
    public float spawnTimer; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTimer);

            var c = Random.Range(0, veggieTarget.Length);
            var i = Random.Range(0, spawnPoints.Length);
            var v = Random.Range(0, veggies.Length);
            var go = Instantiate(veggies[v], spawnPoints[i].position, Quaternion.identity) as GameObject;
            go.GetComponent<Icollect>().SetTarget(veggieTarget[c]);
        }
    }
}

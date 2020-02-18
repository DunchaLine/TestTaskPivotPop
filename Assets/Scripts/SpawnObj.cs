using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public GameObject[] objToSpawn;
    private IEnumerator coroutine;
    private GameObject tmp;
    void Start()
    {
        coroutine = InstantiateObj(Random.Range(3f, 4f));
        StartCoroutine(coroutine);
    }

    void Update()
    {
        
    }

    private IEnumerator InstantiateObj(float _time)
    {
        while (true)
        {
            yield return new WaitForSeconds(_time);
            tmp = Instantiate(objToSpawn[Random.Range(0, objToSpawn.Length)], transform.position, Quaternion.identity) as GameObject;
            Destroy(tmp, 10f);
        }
    }
}

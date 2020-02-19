using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public GameObject[] objToSpawn;
    public GameObject managerObj;
    private gManager manager;
    private IEnumerator coroutine;
    private GameObject tmp;
    void Start()
    {
        manager = managerObj.GetComponent<gManager>();
        coroutine = InstantiateObj(Random.Range(3f, 4f), manager.Line);
        StartCoroutine(coroutine);
    }

    void Update()
    {
        
        if (manager.Line == true)
        {
            Debug.Log("Stop it now");
            StopAllCoroutines();
            coroutine = InstantiateObj(Random.Range(0f, 0f), true);
            StartCoroutine(coroutine);
            if (GameObject.FindGameObjectWithTag("Line") == null)
            {
                Debug.Log("Now u can continue");
                StopAllCoroutines();
                manager.Line = false;
                coroutine = InstantiateObj(Random.Range(3f, 4f), false);
                StartCoroutine(coroutine);
            }
        }
            
    }

    private IEnumerator InstantiateObj(float _time, bool _line)
    {
        while (_line == false)
        {
            Debug.Log("Or maybe dont stop?");
            yield return new WaitForSeconds(_time);
            tmp = Instantiate(objToSpawn[Random.Range(0, objToSpawn.Length)], transform.position, Quaternion.identity) as GameObject;
            Destroy(tmp, 10f);
        }
        while (_line == true)
        {
            yield return null;
            Debug.Log("It must stop right now");
        }
    }
}

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
    private bool tmpBool;
    void Start()
    {
        manager = managerObj.GetComponent<gManager>();
        InvokeRepeating("InstantiateObj", 2f, Random.Range(3f, 4f));
    }

    void Update()
    {
        if (tmpBool)
        {
            CancelInvoke();
            if (GameObject.FindGameObjectWithTag("Line") == null)
            {
                manager.Line = false;
                InvokeRepeating("InstantiateObj", 2f, Random.Range(3f, 4f));
            }
        }
        tmpBool = manager.Line;   
    }

    private void InstantiateObj()
    {
        tmp = Instantiate(objToSpawn[Random.Range(0, objToSpawn.Length)], transform.position, Quaternion.identity);
        Destroy(tmp, 10f);
    }
}

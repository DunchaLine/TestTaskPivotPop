using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public GameObject[] objToSpawn;
    public GameObject managerObj;
    private gManager _manager;
    private IEnumerator _coroutine;
    private GameObject _tmp;
    private bool _tmpBool;
    void Start()
    {
        _manager = managerObj.GetComponent<gManager>();
        InvokeRepeating("InstantiateObj", 2f, Random.Range(3f, 4f));
    }

    void Update()
    {
        if (_tmpBool)
        {
            CancelInvoke();
            if (GameObject.FindGameObjectWithTag("Line") == null)
            {
                _manager.Line = false;
                InvokeRepeating("InstantiateObj", 2f, Random.Range(3f, 4f));
            }
        }
        _tmpBool = _manager.Line;   
    }

    private void InstantiateObj()
    {
        _tmp = Instantiate(objToSpawn[Random.Range(0, objToSpawn.Length)], transform.position, Quaternion.identity);
        Destroy(_tmp, 10f);
    }
}

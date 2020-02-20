using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLineToChangeColor : MonoBehaviour
{
    public GameObject lineToSpawn;
    public GameObject managerObj;
    private gManager manager;
    private IEnumerator coroutine;
    private GameObject tmp;
    void Start()
    {
        manager = managerObj.GetComponent<gManager>();
        coroutine = InstantiateLine(15f);
        StartCoroutine(coroutine);
    }

    private IEnumerator InstantiateLine(float _time)
    {
        while(true)
        {
            yield return new WaitForSeconds(_time);
            tmp = Instantiate(lineToSpawn, transform.position, Quaternion.identity);
            manager.Line = true;
            Destroy(tmp, 7f);
        }
    }
}

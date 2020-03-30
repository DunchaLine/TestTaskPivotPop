using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLineToChangeColor : MonoBehaviour
{
    public GameObject lineToSpawn;
    public GameObject managerObj;
    private gManager _manager;
    private IEnumerator _coroutine;
    private GameObject _tmp;
    void Start()
    {
        _manager = managerObj.GetComponent<gManager>();
        _coroutine = InstantiateLine(25f);
        StartCoroutine(_coroutine);
    }

    private IEnumerator InstantiateLine(float _time)
    {
        while(true)
        {
            yield return new WaitForSeconds(_time);
            _tmp = Instantiate(lineToSpawn, transform.position, Quaternion.identity);
            _manager.Line = true;
            Destroy(_tmp, 7f);
        }
    }
}

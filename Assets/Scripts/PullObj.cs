using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObj : MonoBehaviour
{
    public GameObject[] prefabs;
    public Material[] objColors;
    private Material _ownMaterial;
    private Vector3 _posParent;
    private Quaternion _rotParent;
    private float _lastTime = 0f;
    private float _timeToActive = 0f;
    private List<GameObject> _pool = new List<GameObject>();

    void Start()
    {
        if (prefabs != null)
        {
            foreach (var item in prefabs)
            {
                var instance = (GameObject)Instantiate(item, _posParent, _rotParent);
                instance.SetActive(false);
                _pool.Add(instance);
            }
        }
    }

    void Update()
    {
        if (Time.time > (_lastTime + Random.Range(3f, 4f)))
        {
            var instance = Instantiate();
            if (instance != null)
            {
                _lastTime = Time.time;
            }
        }
    }

    public GameObject Instantiate()
    {
        _posParent = transform.position;
        _rotParent = transform.rotation;
        foreach(var item in _pool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = _posParent;
                item.transform.rotation = _rotParent;
                Material tmp = item.GetComponent<Renderer>().material;
                tmp.color = objColors[Random.Range(0, objColors.Length)].color;
                if (Time.time > (_timeToActive + Random.Range(3f, 4f)))
                {
                    item.SetActive(true);
                    _timeToActive = Time.time;
                }
                return item;
            }            
        }
        return null;
    }

    void ChangeColor()
    {
        _ownMaterial.color = objColors[Random.Range(0, objColors.Length)].color;
    }
}

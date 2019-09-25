using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacker : MonoBehaviour
{
    public int total;

    public GameObject prefab;

    public int spacing;

    void Start()
    {
        for(int i = 0; i < total; i++)
        {
            Instantiate(prefab, new Vector3(transform.position.x, spacing, transform.position.z), Quaternion.identity);
        }
    }

}

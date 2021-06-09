using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulPrefab;

    void Start()
    {
        StartCoroutine(Tr());
        Destroy(gameObject, 4f);
    }

    IEnumerator Tr()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(bulPrefab);
            yield return new WaitForSeconds(1f);
        }
    }
}

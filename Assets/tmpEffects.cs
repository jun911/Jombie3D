using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmpEffects : MonoBehaviour
{
    [SerializeField] float delayToDestruct = 1f;

    private void Start()
    {
        StartCoroutine(DestroyChild());
    }

    IEnumerator DestroyChild()
    {
        foreach (Transform child in transform)
        {
            Debug.Log($"destroy child name : {child.transform.name}");
            Destroy(child);
        }

        yield return new WaitForSeconds(delayToDestruct);
    }
}

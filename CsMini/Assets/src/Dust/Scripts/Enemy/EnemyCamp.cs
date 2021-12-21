using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCamp : MonoBehaviour
{
    [SerializeField] private Transform[] camps;

    public Transform getCamp()
    {
        return camps[Random.Range(0, camps.Length)];
    }
}

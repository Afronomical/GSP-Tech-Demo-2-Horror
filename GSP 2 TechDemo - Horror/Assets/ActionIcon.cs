using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionIcon : MonoBehaviour
{
    [SerializeField] Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    } 
}

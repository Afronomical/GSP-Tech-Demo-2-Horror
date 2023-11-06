using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public static MoveCamera Instance;

    public Transform cameraPosition;

    [SerializeField] Camera mainCamera;

    [SerializeField] Camera secondaryCamera;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }

    public void SwitchCamera(Camera camera)
    {
        secondaryCamera= camera;
        secondaryCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
    }
    public void ResetCamera()
    {
        if(secondaryCamera!= null)
        {
            secondaryCamera.gameObject.SetActive(false);
        }
        
        mainCamera.gameObject.SetActive(true);
        
    }
}

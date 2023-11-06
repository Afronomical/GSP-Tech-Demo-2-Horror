using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] Camera fpsCam;
    [SerializeField] float hitRange;

    [SerializeField] GameObject lastHitObj;
    [SerializeField] bool hitting;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        ShootRay();
    }

    void ShootRay()
    {
       
        

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, hitRange)) // we hit an object
        {

            

            if (hit.transform.GetComponent<IInteractable>()!= null)
            {
                GameObject go = hit.transform.gameObject;

                if(lastHitObj==null)   // OnRaycastEnter
                {

                    go.GetComponent<IInteractable>().View(true);
                    if (GameManager.Instance.getDebugMode())
                        Debug.Log("Ray Enter");


                }
                else if(lastHitObj.GetInstanceID() == go.GetInstanceID()) //OnRaycastStay
                {
                    if (GameManager.Instance.getDebugMode())
                        Debug.Log("Ray stay");
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        go.GetComponent<IInteractable>().Interact();
                    }

                }
                else         //OnRaycastEnterNewInteractable
                {
                    lastHitObj.GetComponent<IInteractable>().View(false);
                    go.GetComponent<IInteractable>().View(true);
                    if (GameManager.Instance.getDebugMode())
                        Debug.Log("Ray Switch");
                }

                hitting= true;
                lastHitObj = go;
            }
            else
            {   if(lastHitObj != null)
                {
                    lastHitObj.GetComponent<IInteractable>().View(false);
                    hitting = false;
                    lastHitObj = null;
                    if (GameManager.Instance.getDebugMode())
                        Debug.Log("Ray exit to non Interactable");
                }
                
            }
            
        
            
        }
        else if (hitting)  // OnRaycastExit
        {
            if (lastHitObj != null)
            {
                lastHitObj.GetComponent<IInteractable>().View(false);
                hitting = false;
                lastHitObj = null;
                if (GameManager.Instance.getDebugMode())
                    Debug.Log("Ray exit to null");
            }

        }
       
    }
}

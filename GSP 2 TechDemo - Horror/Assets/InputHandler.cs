using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public static InputHandler instance;

    public PlayerInputStates currentInputState;

    [SerializeField] List<MonoBehaviour> playerMovementScriptsList;
    [SerializeField] List<MonoBehaviour> playerInactiveScriptsList;

    public enum PlayerInputStates
    {
        Movement, Interacting
    }

    private void Awake()
    {
        
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
            }


        
    }

    private void Update()
    {
        if (currentInputState == PlayerInputStates.Movement)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            MoveCamera.Instance.ResetCamera();

            foreach (MonoBehaviour script in playerInactiveScriptsList)
            {


                if (script.GetComponent<Canvas>())
                {
                    script.gameObject.SetActive(false);
                }
                else
                {
                    script.enabled = false;
                }

            }
            foreach (MonoBehaviour script in playerMovementScriptsList)
            {
                if (script.GetComponent<Canvas>())
                {
                    script.gameObject.SetActive(true);
                }
                else
                {
                    script.enabled = true;
                }
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            foreach (MonoBehaviour script in playerInactiveScriptsList)
            {

                if (script.GetComponent<Canvas>())
                {
                    script.gameObject.SetActive(true);
                }
                else
                {
                    script.enabled = true;
                }

            }
            foreach (MonoBehaviour script in playerMovementScriptsList)
            {
                if (script.GetComponent<Canvas>())
                {
                    script.gameObject.SetActive(false);
                }
                else
                {
                    script.enabled = false;
                }
            }
        }
    }
    public void ChangeInputState(PlayerInputStates states)
    {
        currentInputState= states;


        switch (currentInputState)
        {
            case PlayerInputStates.Movement:

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                foreach (MonoBehaviour script in playerInactiveScriptsList)
                {
                    script.enabled = false;

                }
                foreach (MonoBehaviour script in playerMovementScriptsList)
                {
                    script.enabled = true;
                }


                break;

            case PlayerInputStates.Interacting:

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                foreach (MonoBehaviour script in playerInactiveScriptsList)
                {
                    script.enabled = true;

                }
                foreach (MonoBehaviour script in playerMovementScriptsList)
                {
                    script.enabled = false;
                }

                break;

            default:
                break;
        }
    }
   
}

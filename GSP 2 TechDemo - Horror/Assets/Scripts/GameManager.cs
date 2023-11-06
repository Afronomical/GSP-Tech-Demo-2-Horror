using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] bool debugMode = false;

        private void Start()
    {
        Instance = this;
        
    }

    public bool getDebugMode()
    {
        return debugMode;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioObject clipToPlay;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (GameManager.Instance.getDebugMode())
            {
                Debug.Log("Playing Audio");
            }
            Vocals.Instance.Say(clipToPlay);
        }
    }
}

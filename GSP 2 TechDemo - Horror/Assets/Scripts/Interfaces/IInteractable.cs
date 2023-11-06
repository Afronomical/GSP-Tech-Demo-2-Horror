using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public  void View(bool isViewing);
    public void Interact();
    public void Inspect();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    public string promptMessage;
    public void BaseInteract()
    {
        Interact();
    
    }
    // Start is called before the first frame update
    protected virtual void Interact()
    {
    
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad: Interactable
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Design a interaction using code here
    protected override void Interact()
    {
        Debug.Log("interacted with keypad/testInteractable" + gameObject.name);
    }
    
    
}

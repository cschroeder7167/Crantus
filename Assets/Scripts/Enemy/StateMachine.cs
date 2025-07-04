using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;
    public void Initialise(){
        patrolState = new PatrolState();
        ChangeState(patrolState);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeState(BaseState newState){

        if(activeState != null){

            activeState.Exit();
        }
        activeState = newState;
        if(activeState != null){

            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(activeState != null){
            activeState.Perform();

        }
    }
}

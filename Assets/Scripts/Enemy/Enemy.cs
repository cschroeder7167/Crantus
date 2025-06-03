using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;

    public UnityEngine.AI.NavMeshAgent Agent { get => agent; }
    [SerializeField]
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stateMachine.Initialise();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

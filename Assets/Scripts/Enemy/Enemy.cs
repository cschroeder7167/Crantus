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
    public Path path;
    private GameObject player;
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
      CanSeePlayer();
    }
    public bool CanSeePlayer()
    {
        if(player != null){
            if(Vector3.Distance(transform.position,player.transform.position) < sightDistance ){
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView) {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray, out hitInfo, sightDistance)){
                        if(hitInfo.transform.gameObject == player)
                        {
                            return true;
                        }

                    }
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);

                }
            }
        }
        return false;
    }
}

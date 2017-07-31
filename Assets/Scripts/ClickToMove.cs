// ClickToMove.cs
using UnityEngine;


[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
public class ClickToMove : MonoBehaviour {
	RaycastHit hitInfo = new RaycastHit();
	UnityEngine.AI.NavMeshAgent agent;
    public Transform cameraRigTransform;
    float wanderingTime = 30.0f; // In seconds
    float wandering_clock = 30.0f;
    float chaseTime = 30.0f; // In seconds
    float chase_clock = 30.0f;
    float walkRadius = 50.0f;
    Vector3 randomDirection;
    Vector3 finalPosition;

    void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        update_position();
    }

	void Update () {
        
        
        if (wandering_clock > 0)
        {
            wandering_clock -= Time.deltaTime;
            agent.destination = finalPosition;
        } else if (chase_clock > 0)
        {
            chase_clock -= Time.deltaTime;
            agent.destination = cameraRigTransform.position + 2*transform.forward;
        }
        else
        {
            reset_wandering_time();
            reset_chase_time();
            update_position();
        }
    }
    

    void reset_wandering_time()
    {
        wandering_clock = wanderingTime;
    }
    void reset_chase_time()
    {
        chase_clock = chaseTime;
    }
    void update_position()
    {
        randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        finalPosition = hit.position;
    }
}

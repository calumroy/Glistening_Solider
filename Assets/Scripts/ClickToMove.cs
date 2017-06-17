// ClickToMove.cs
using UnityEngine;

[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
public class ClickToMove : MonoBehaviour {
	RaycastHit hitInfo = new RaycastHit();
	UnityEngine.AI.NavMeshAgent agent;
    public Transform cameraRigTransform;

    void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	void Update () {
        agent.destination = cameraRigTransform.position;

        }
	
}

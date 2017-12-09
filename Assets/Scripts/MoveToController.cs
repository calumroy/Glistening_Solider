using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletUnity;
using BulletSharp;
using BulletUnity.Primitives;

public class MoveToController : MonoBehaviour {

    // Use this for initialization
    private BRigidBody rigidCollidingObj;
    private SteamVR_TrackedObject trackedObj;
    private Vector3 cntl_pos;
    private Quaternion col_rot;
    private GameObject v_cunt;
    private GameObject controller_left;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Start()
    {
        Debug.Log("I'm attached to " + gameObject.name);
        rigidCollidingObj = (BRigidBody)gameObject.GetComponent("BRigidBody");
        v_cunt = GameObject.Find("v_cunt");
        controller_left = GameObject.Find("Controller (left)");
        col_rot = new Quaternion(0, 0, 0, 1);
    }


    // Update is called once per frame
    void Update()
    {
        // 1
        // Move the bullet object to the controllers position
        controller_left = GameObject.Find("Controller (left)");
        if (controller_left != null)
        {
            cntl_pos = controller_left.transform.position;
            col_rot = controller_left.transform.rotation;
            //rigidCollidingObj.SetPosition(cntl_pos);
            //rigidCollidingObj.SetRotation(col_rot);
            rigidCollidingObj.SetPositionAndRotation(cntl_pos, col_rot);
        }
            //transform.setOrigin(new_position);
            //body->setCenterOfMassTransform(transform);

        //cntl_pos = v_cunt.transform.position;
        //rigidCollidingObj.SetPosition(cntl_pos);

    }
}

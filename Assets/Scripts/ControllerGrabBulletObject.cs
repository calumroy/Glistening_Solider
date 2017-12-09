using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletUnity;
using BulletSharp;
using System.Collections.Generic;
using BulletUnity.Primitives;

public class ControllerGrabBulletObject : MonoBehaviour {

    // Use this for initialization
    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
        // 1
        //private GameObject collidingObject;
    private CollisionObject collidingObject;
    private BRigidBody rigidCollidingObj;
    // 2
    private CollisionObject objectInHand;



    public void SetCollidingObject(CollisionObject col)
    {
        // 1
        //if (collidingObject!=false || (col.GetCollisionObject()== null))
        if (!(collidingObject==null) || !(col.UserObject== null))
        {
            return;
        }
        // 2
        collidingObject = col; //col.gameObject;
    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        //SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        //SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!(collidingObject == null))
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        //joint.connectedBody = objectInHand.GetComponent<BulletSharp.RigidBody>();
        //joint.otherRigidBody = objectInHand;
    }

    // 3
    private BFixedConstraint AddFixedJoint()
    {
        BFixedConstraint fx = gameObject.AddComponent<BFixedConstraint>();
        fx.breakingImpulseThreshold = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            //objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // 4
        objectInHand = null;
    }



    // Update is called once per frame
    void Update ()
    {
        // 1
        if (Controller.GetHairTriggerDown())
        {
            if (!(collidingObject == null))
            {
                GrabObject();
            }
        }

        // 2
        if (Controller.GetHairTriggerUp())
        {
            if (!(objectInHand == null))
            {
                ReleaseObject();
            }
        }
    }
}

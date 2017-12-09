using UnityEngine;
using System.Collections;
using BulletSharp;
using BulletUnity;

public class CustomCollisionCallbackScriptBullet : BCollisionCallbacksDefault {



    /// <summary>
    ///Beware of creating, destroying, adding or removing bullet objects inside CollisionEnter, CollisionStay and CollisionExit. Doing so can alter the list of collisions and ContactManifolds 
    ///that are being iteratated over
    ///(comodification). This can result in infinite loops, null pointer exceptions, out of sequence Enter,Stay,Exit, etc... A good way to handle this sitution is 
    ///to collect the information in these callbacks then override "OnFinishedVisitingManifolds" like:
    ///
    /// public override void OnFinishedVisitingManifolds(){
    ///     base.OnFinishedVistingManifolds(); //don't omit this it does the callbacks
    ///     do my Instantiation and deletion here.
    /// }
    /// </summary>
    /// 
    ControllerGrabBulletObject reference;

    private RigidBody rigidCollidingObj;

    public override void BOnCollisionEnter(CollisionObject other, PersistentManifoldList manifoldList)
    {
        Debug.Log("On Collision" + " Enter with " + other.UserObject + " frame " + BPhysicsWorld.Get().frameCount);
        //rigidCollidingObj = (BulletSharp.RigidBody)other;
        //reference = GameObject.Find("Controller (left)").GetComponent<ControllerGrabBulletObject>();
        //reference.SetCollidingObject(other);
    }

    public override void BOnCollisionStay(CollisionObject other, PersistentManifoldList manifoldList)
    {
        //Debug.Log("On Collision Stay " + BPhysicsWorld.Get().frameCount);
    }

    public override void BOnCollisionExit(CollisionObject other)
    {
        Debug.Log("On Collision Exit with " + other.UserObject+ " frame " + BPhysicsWorld.Get().frameCount);
    }

    public override void OnFinishedVisitingManifolds()
    {
        base.OnFinishedVisitingManifolds();
        //it is safe to Instantiate, Destroy, Enable and Disable here
    }
}

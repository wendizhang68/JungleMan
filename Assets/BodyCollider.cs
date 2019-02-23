using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{

    // Returns whether the obj is a floor, platform, or wall
    bool isFloor(GameObject obj)
    {
        return obj.layer == LayerMask.NameToLayer("Floor");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (isFloor(coll.gameObject)
            && GetComponentInParent<PlayerController>().bodyContact
            && GetComponentInParent<PlayerController>().feetContact)
        {
            GetComponentInParent<PlayerController>().canJumpVar = true;
        }
        else if (isFloor(coll.gameObject)
            && GetComponentInParent<PlayerController>().bodyContact)
        {
            GetComponentInParent<PlayerController>().canJumpVar = false;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        GetComponentInParent<PlayerController>().feetContact = true;
        GetComponentInParent<PlayerController>().canJumpVar = true;
        GetComponentInParent<PlayerController>().bodyContact = false;

    }
}

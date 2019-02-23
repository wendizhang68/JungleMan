using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour
{

    // Returns whether the obj is a floor, platform, or wall
    bool isFloor(GameObject obj)
    {
        Debug.Log(obj.layer);
        return obj.layer == LayerMask.NameToLayer("Floor");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (isFloor(coll.gameObject))
        {
            GetComponentInParent<PlayerController>().feetContact = true;
            GetComponentInParent<PlayerController>().canJumpVar = true;
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        GetComponentInParent<PlayerController>().feetContact = false;
        GetComponentInParent<PlayerController>().canJumpVar = false;

    }
}

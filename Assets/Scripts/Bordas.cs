using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bordas : MonoBehaviour
{
    public BoxCollider BoxCollider;

    void OnTriggerExit(Collider other)
    {
        var exitngObj = other.transform;
        var position = exitngObj.position;

        var boundaryPosition = transform.position;
        var colliderSize = BoxCollider.bounds.extents;

        if (position.x >= (boundaryPosition.x + colliderSize.x) || position.x <= (boundaryPosition.x - colliderSize.x))
            position.x = -position.x;

        if (position.y >= (boundaryPosition.y + colliderSize.y) || position.y <= (boundaryPosition.y - colliderSize.y))
            position.y = -position.y;

        exitngObj.position = position;
    }
}

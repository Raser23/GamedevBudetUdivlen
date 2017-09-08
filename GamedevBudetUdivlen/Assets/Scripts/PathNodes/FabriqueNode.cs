using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabriqueNode : Node {

    public Node next;

    public override Node Next(GameObject obj)
    {
        if(next != null)
        {
            return next;
        }else
        {
            return null;
        }
    }

    public override void OnCompleted()
    {
        
    }

    public void OnDrawGizmos()
    {
        if(next != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position,next.transform.position);
        }
    }

}

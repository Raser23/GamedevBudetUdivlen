using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkNode : PathNode {
        
    [SerializeField] public PathNode nextNode1;

    public override Node Next(GameObject obj)
    {
        int rand = Random.Range(1, 3);

        if(rand == 1)
        {
            return nextNode;
        }else
        {
            return nextNode1;
        }
        //return base.Next();
    }

    public override List<Node> GetAllNodes()
    {
        List<Node> nodes = base.GetAllNodes();
        nodes.Add(nextNode1);
        return nodes;
    }

    public override void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if(nextNode)
		    Gizmos.DrawLine(transform.position, nextNode.position);
        if(nextNode1)
            Gizmos.DrawLine(transform.position, nextNode1.position);
        //base.OnDrawGizmos();
    }
}

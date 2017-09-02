using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideNode : PathNode {

    public PathNode nextNode1;
    private int count;

    public override void Start()
    {
        base.Start();
        count = 0;
    }

	public override PathNode Next(GameObject obj)
	{
        count++;
		if (count%2 == 0)
		{
			
			return nextNode;
		}
		else
		{
			return nextNode1;
		}

		//return base.Next();
	}

	public override void OnDrawGizmos()
	{
        Gizmos.color = Color.cyan;
		if (nextNode)
			Gizmos.DrawLine(transform.position, nextNode.position);
		Gizmos.color = Color.cyan;
		if (nextNode1)
			Gizmos.DrawLine(transform.position, nextNode1.position);
		//base.OnDrawGizmos();
	}
}

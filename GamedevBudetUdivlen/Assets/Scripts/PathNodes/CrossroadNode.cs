using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossroadNode : PathNode
{
    List<GameObject> visited;

	[SerializeField] public PathNode nextNode1;


    public override void Start()
    {
        visited = new List<GameObject>();
    }

	public override PathNode Next(GameObject obj)
	{
		
        if (!visited.Contains(obj))
		{
            visited.Add(obj);
			return nextNode;
		}
		else
		{
            visited.Remove(obj);
			return nextNode1;
		}
		//return base.Next();
	}

	public override void OnDrawGizmos()
	{
        Gizmos.color = Color.green;
		if (nextNode)
			Gizmos.DrawLine(transform.position, nextNode.position);
        Gizmos.color = Color.red;
		if (nextNode1)
			Gizmos.DrawLine(transform.position, nextNode1.position);
		//base.OnDrawGizmos();
	}
}

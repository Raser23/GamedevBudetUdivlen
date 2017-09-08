﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : Node 
{

    [SerializeField] public Node nextNode;

    public override Node Next(GameObject obj)
    {
        if (nextNode)
            return nextNode;
        else
            return null;
    }

    public virtual void Start()
    {
        
    }

    public override void OnCompleted()
    {
        //print("Crossed");

    }


	public virtual void OnDrawGizmos()
	{
		if (nextNode != null)
		{
			Gizmos.color = Color.black;
			Gizmos.DrawLine(transform.position, nextNode.position);
		}

	}
}

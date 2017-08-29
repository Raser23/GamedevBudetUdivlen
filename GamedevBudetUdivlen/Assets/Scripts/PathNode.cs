using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour 
{

    [SerializeField] public PathNode nextNode;

    public PathNode Next()
    {
        if (nextNode)
            return nextNode;
        else
            return null;
    }

    public Vector3 position{
        get{
            return gameObject.transform.position;
        }
    }
	public Vector2 position2d
	{
		get
		{
            return (Vector2)gameObject.transform.position;
		}
	}

    private void OnDrawGizmos()
    {
        if(nextNode != null){
            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position,nextNode.position);
        }

    }
}

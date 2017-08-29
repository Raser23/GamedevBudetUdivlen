using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour 
{

    [SerializeField] public PathNode nextNode;

    public virtual PathNode Next(GameObject obj)
    {
        if (nextNode)
            return nextNode;
        else
            return null;
    }

    public virtual void Start()
    {
        
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

    public virtual void OnDrawGizmos()
    {
        if(nextNode != null){
            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.position,nextNode.position);
        }

    }
}

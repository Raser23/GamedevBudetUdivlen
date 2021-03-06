using UnityEngine;
using System.Collections.Generic;

public abstract class Node : MonoBehaviour
{
    public abstract Node Next(GameObject obj);
	public Vector3 position
	{
		get
		{
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

    public abstract void OnCompleted();

    public abstract List<Node> GetAllNodes();
}

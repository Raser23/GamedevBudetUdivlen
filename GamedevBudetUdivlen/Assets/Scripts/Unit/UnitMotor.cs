using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitMotor : MonoBehaviour 
{
    public delegate void Movement(UnitMotor um);
    public event Movement OnPathEnd;


    public UnitStats stats;

    
    Node target;
    Node stopNode;

    Path path;



    IEnumerator FollowPath()
    {
        bool followingPath = true;
        int pathIndex = 0;

        FacePoint2(path.lookPoints[0].position);

        while (followingPath)
        {
            Vector2 pos2D = (Vector2)transform.position;

            while(path.turnBoundaries[pathIndex].HasCrossedLine(pos2D))
            {
                if (pathIndex == path.finishLineIndex)
                {
                    followingPath = false;
                    OnPathEnd.Invoke(this);
                    break;
                }
                else
                {
                    pathIndex++;
                    List<Node> uncompletedNodes = new List<Node>();

                    for (int i = pathIndex ; i < path.lookPoints.Length;i++){
                        uncompletedNodes.Add(path.lookPoints[i]);
                    }
         

                    path = calculatePath(uncompletedNodes,1);

                    pathIndex =0;
                }
            }
            if (followingPath){
                FacePoint(path.lookPoints[pathIndex].position);
                transform.Translate(Vector3.up * Time.deltaTime * stats.speed,Space.Self);
            }

            yield return null;
        }
    }



    public void StopMoving(){
        StopAllCoroutines();
    }

    void FacePoint(Vector3 pnt)
	{
		Quaternion newRotation = Quaternion.LookRotation(transform.position - pnt, Vector3.forward);
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * stats.rotateSpeed);
	}
	void FacePoint2(Vector3 pnt)
	{
		Quaternion newRotation = Quaternion.LookRotation(transform.position - pnt, Vector3.forward);
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
        transform.rotation = newRotation;
	}

    public void SetTarget(Node _target,Node _stopNode)
    {
        stopNode = _stopNode;
        target = _target;

        path = calculatePath(target,3);
        StartCoroutine(FollowPath());

    }

    Path calculatePath(Node start,int l)
    {
        int pathL = l;
        List<Node> p = new List<Node>();
		Node current = start;
        int counter = 0;
		while (current != null && counter < pathL)
		{
			p.Add(current);
			if (current == stopNode)
				break;
			current = current.Next(gameObject);
			counter++;
		}
        return new Path(p.ToArray(), transform.position, stats.turnDist);
    }
	Path calculatePath(List<Node> start, int l)
	{
		int pathL = l;
        List<Node> p = new List<Node>(start);
        Node current = start[start.Count-1];
		int counter = 0;
		while (current != null && counter < pathL)
		{
			
			if (current == stopNode)
				break;
			current = current.Next(gameObject);
			counter++;
            if(current != null)
                p.Add(current);
		}
		return new Path(p.ToArray(), transform.position, stats.turnDist);
	}


	public void SetTarget(Node _target)
	{
        SetTarget(_target,null);
	}

    public void OnDrawGizmosSelected()
    {
        if(path != null)
        path.DrawWithGizmos();
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(transform.position, transform.up*3);
    }

}

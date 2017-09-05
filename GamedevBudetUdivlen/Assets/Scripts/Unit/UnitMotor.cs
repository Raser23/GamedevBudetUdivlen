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

        FacePoint2(path.lookPoints[0]);

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
                }else
                {
                    pathIndex++;
                }
            }
            if (followingPath){
                
                FacePoint(path.lookPoints[pathIndex]);
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
        List<Vector3> p = new List<Vector3>();
        Node current = target;

        while(current != null)
        {
            p.Add(current.position);
            if (current == stopNode)
                break;
            current = current.Next(gameObject);
        }

        path = new Path(p.ToArray(), transform.position, stats.turnDist);
        StartCoroutine(FollowPath());

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

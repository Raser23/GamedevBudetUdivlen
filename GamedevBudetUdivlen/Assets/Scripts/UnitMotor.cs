using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitMotor : MonoBehaviour 
{

    public UnitStats stats;

    public float turnDst = 0f;

    PathNode target;

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

    public void SetTarget(PathNode _target)
    {
        target = _target;
        List<Vector3> p = new List<Vector3>();
        PathNode current = target;

        while(current != null){
            p.Add(current.position);
            current = current.Next(gameObject);
        }
        path = new Path(p.ToArray(), transform.position, turnDst);
        StartCoroutine(FollowPath());

    }

    public void OnDrawGizmosSelected()
    {
        if(path != null)
        path.DrawWithGizmos();
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(transform.position, transform.up*3);
    }

}

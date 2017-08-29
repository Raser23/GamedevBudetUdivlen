using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitMotor : MonoBehaviour 
{

    public UnitStats stats;

    public float turnDst = 0.5f;

    PathNode target;

    Path path;
    //List<Vector2> path;

    void Update()
    {
        
    }

    void MoveToTarget()
    {


        Vector2 direction = (target.position2d - (Vector2)transform.position).normalized;
        float dst = (target.position2d - (Vector2)transform.position).magnitude;
        if (dst < 0.0001f){
            target = target.Next(gameObject);
            return; 
        }

        float moveAmount = stats.speed * Time.deltaTime;

        Vector2 moveVector = Mathf.Min(dst, moveAmount) * direction;
        FaceTarget();
        transform.position += (Vector3)moveVector;
    }


    IEnumerator FollowPath()
    {
        bool followingPath = true;
        int pathIndex = 0;

        FacePoint(path.lookPoints[0]);

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

	void FaceTarget()
	{
        Quaternion newRotation = Quaternion.LookRotation(transform.position - (Vector3)target.position2d, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * stats.rotateSpeed);
	}
    void FacePoint(Vector3 pnt)
	{
		Quaternion newRotation = Quaternion.LookRotation(transform.position - pnt, Vector3.forward);
		newRotation.x = 0.0f;
		newRotation.y = 0.0f;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * stats.rotateSpeed);
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
        path.DrawWithGizmos();
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(transform.position, transform.up*3);
    }

}

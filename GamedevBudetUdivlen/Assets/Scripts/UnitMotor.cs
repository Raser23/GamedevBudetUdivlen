using UnityEngine;

public class UnitMotor : MonoBehaviour 
{

    public UnitStats stats;

    PathNode target;


    void Update()
    {
        if(target != null)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        Vector2 direction = (target.position2d - (Vector2)transform.position).normalized;
        float dst = (target.position2d - (Vector2)transform.position).magnitude;
        //print(dst);
        if (dst < 0.0001f){
            target = target.Next();
            return; 
        }

		
        float moveAmount = stats.speed * Time.deltaTime;

        Vector2 moveVector = Mathf.Min(dst, moveAmount) * direction;
        FaceTarget();
        transform.position += (Vector3)moveVector;
    }
	void FaceTarget()
	{
        Quaternion newRotation = Quaternion.LookRotation(transform.position - (Vector3)target.position2d, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * stats.rotateSpeed);
	}

    public void SetTarget(PathNode _target)
    {
        target = _target;
    }

    public void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(transform.position, transform.up*3);
    }

}

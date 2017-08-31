using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    public UnitMotor motor;
    public UnitStats stats;
    public Animator animator;
    public GameObject HpBarPos;
     
    public void SetTargetNode(PathNode node)
    {
        motor.SetTarget(node);
        stats.HpBelowZero += OnHPBelowZero;
    }
	
	void Update () {
        
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        //Debug.Log(screenPos);
	}

    void OnHPBelowZero(){
        StartToDie();
    }
    public void StartToDie(){
        motor.StopMoving();
        GameManager.instance.OnUnitDestroyed(this);
        animator.SetBool("Dead", true);
		
    }
    public void DestorySelf(){


        Destroy(gameObject);
    }
}

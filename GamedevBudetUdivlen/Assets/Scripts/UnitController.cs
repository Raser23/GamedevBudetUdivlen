using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    public UnitMotor motor;
    public UnitStats stats;
    public Animator animator;
     
    public void SetTargetNode(PathNode node)
    {
        motor.SetTarget(node);
        stats.HpBelowZero += OnHPBelowZero;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnHPBelowZero(){
        StartToDie();
    }
    public void StartToDie(){
        motor.StopMoving();
        animator.SetBool("Dead", true);
		
        //DestorySelf();
    }
    public void DestorySelf(){
        
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    public UnitMotor motor;
    public UnitStats stats;
    public Animator animator;
    public GameObject HpBarPos;


    public GameObject focusCircle;

    public void SetTargetNode(Node node, Node stopNode)
    {
        motor.SetTarget(node,stopNode);
        stats.HpBelowZero += OnHPBelowZero;
    }
	public void SetTargetNode(Node node)
	{
        SetTargetNode(node,null);
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


    public void OnFocused()
    {
        focusCircle.SetActive(true);
    }
    public void OnUnfocused()
	{
        focusCircle.SetActive(false);
	}
}

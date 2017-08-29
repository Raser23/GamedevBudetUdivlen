using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    public UnitMotor motor;

     
    public void SetTargetNode(PathNode node)
    {
        motor.SetTarget(node);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

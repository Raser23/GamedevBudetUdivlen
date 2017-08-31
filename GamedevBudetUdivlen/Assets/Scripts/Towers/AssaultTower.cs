using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultTower : Tower {

	public Transform rotor;
	public float rotSpeed;



	void Start () {
		//TODO make these upgradable huisosu
		dmg = 1;
		//range = 10;
		atk_speed = 2;
		upgrade_cost = 150;
		refund = 50;
		desc = "Deals average damage at decent speed";
		self_position = gameObject.transform.position;
		atk_timer = 0;
		//rotor = gameObject.transform.Find("Assault Head");
		rotSpeed = 1;
	}
	GameObject currentTarget;
	
	void lookForTarget(){
		List<GameObject> targets = getTargets();
		
		if(targets.Count!=0){
			print("pizdiec");
			currentTarget = targets.closestTo(self_position);
		}
		else{
			currentTarget = null;
		}
	}

	void turnTo(GameObject obj){
		//print(rotor);
		Quaternion newRotation = Quaternion.LookRotation(rotor.position - obj.transform.position,Vector3.forward);
		newRotation.x = 0;
		newRotation.y = 0;
        
		rotor.rotation = Quaternion.Lerp(rotor.rotation, newRotation, Time.deltaTime * 8);
	}

	void Update () {
		if(currentTarget){
			float dist = Vector3.Distance(currentTarget.transform.position, self_position);
			if(dist>range){
				currentTarget = null;
			}
			else{
				turnTo(currentTarget);
				atk_timer += Time.deltaTime;
				if(atk_timer>=atk_speed){
					atk_timer = 0;
					attackUnit(currentTarget);
				}
			}

		}
		else{
			lookForTarget();
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position,range);
		//Gizmos.DrawRay(rotor.position,rotor.forward.normalized * 10);
		if(currentTarget!=null)
		{
			//Gizmos.DrawLine(rotor.position,currentTarget.transform.position);
		}
	}
}

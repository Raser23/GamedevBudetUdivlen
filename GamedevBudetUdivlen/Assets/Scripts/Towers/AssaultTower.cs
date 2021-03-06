﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class AssaultTower : Tower {

	public Transform rotor;
	public float rotSpeed;
	public Color gizmColor;
	public VolumetricLineBehavior laser;
	public Transform muzzle;

	

	void Start () {
		self_position = gameObject.transform.position;
	}
	GameObject currentTarget;
	
	void lookForTarget(){
		List<GameObject> targets = getTargets();
		
		if(targets.Count!=0){
			currentTarget = targets.closestTo(self_position);
		}
		else{
			currentTarget = null;
		}
	}

	void turnTo(GameObject obj){
		Quaternion newRotation = Quaternion.LookRotation(rotor.position - obj.transform.position,Vector3.forward);
		newRotation.x = 0;
		newRotation.y = 0;
		rotor.rotation = Quaternion.Lerp(rotor.rotation, newRotation, Time.deltaTime * rotSpeed);
	}

	void Update () {
		if(currentTarget){
			laser.gameObject.SetActive(true);
			float dist = Vector3.Distance(currentTarget.transform.position, self_position);
            Vector3 d  = currentTarget.GetComponent<UnitController>().head.transform.position - muzzle.position;
			laser.EndPos = new Vector3(0, Mathf.Sqrt(Mathf.Pow(d.x, 2) + Mathf.Pow(d.y, 2))/muzzle.transform.lossyScale.y, d.z/muzzle.transform.lossyScale.y);
			if(dist>range){
				currentTarget = null;
			}
			else{
				turnTo(currentTarget);
				atk_timer += Time.deltaTime;
				if(atk_timer>=atk_speed){
					atk_timer = 0;
					if(attackUnit(currentTarget)){
						currentTarget = null;
					}
				}
			}

		}
		else{
			laser.gameObject.SetActive(false);
			lookForTarget();
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = gizmColor;
		Gizmos.DrawWireSphere(transform.position,range);
	}
}

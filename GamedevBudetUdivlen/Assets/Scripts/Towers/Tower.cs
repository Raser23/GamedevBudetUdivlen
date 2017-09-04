using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour{
	//TODO make these upgradable
	public float dmg, range;
	protected float atk_timer;
	public float atk_speed;//Time between attacks

	public LayerMask shoot_mask;

	public int upgrade_cost, refund;
	public Vector3 self_position;
	public string desc;

	protected List<GameObject> getTargets(){
		Collider[] colliders_within_range = Physics.OverlapSphere(self_position, range, shoot_mask);
		List<GameObject> targets = new List<GameObject>();
		foreach(Collider collider in colliders_within_range){
			targets.Add(collider.gameObject);
		}
		return targets; 
	}

	protected bool attackUnit(GameObject unit){
		UnitStats stats = unit.GetComponentInParent<UnitController>().stats;
		stats.currentHP -= dmg;
		if(stats.currentHP <=0){
			return true;
		}
		return false;
	}		
}

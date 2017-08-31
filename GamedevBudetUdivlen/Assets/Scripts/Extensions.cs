using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Extensions{

	public static GameObject closestTo(this List<GameObject> positions, Vector3 target_position){
		Debug.Log("pizdec");
		float min_dist = Vector3.Distance(positions[0].transform.position, target_position);
		GameObject closest = positions[0];
		foreach( GameObject pos in positions ){
			float dist =  Vector3.Distance(pos.transform.position, target_position);
			if(dist < min_dist){ 
				min_dist = dist;
				closest = pos;
			}
		}
		return closest; 
	}

}

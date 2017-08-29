using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {


    public void FormPath(){
        PathNode[] nodes;
        nodes = gameObject.transform.GetComponentsInChildren<PathNode>();
        for (int i = 0; i < nodes.Length-1;i++){
            nodes[i].nextNode = nodes[i + 1];
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}

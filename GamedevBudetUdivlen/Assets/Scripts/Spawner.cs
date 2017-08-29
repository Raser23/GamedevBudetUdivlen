using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public PathNode startNode;
    public float timePerWave;
    public List<Wave> waves;

    private float passedTime;
    private int spawnedCount;

	void Start () 
    {
        passedTime = timePerWave;
        spawnedCount = 0;
    }
    void Update()
    {
        passedTime += Time.deltaTime;
        if(passedTime >= timePerWave && spawnedCount < waves.Count)
        {
            InstantiateWave(waves[spawnedCount]);
            spawnedCount++;
            passedTime = 0;
        }  
    }

    void InstantiateWave(Wave w){
        GameObject unit =  GameObject.Instantiate(w.units[0],transform.position,Quaternion.identity);
        unit.GetComponent<UnitController>().SetTargetNode(startNode);
    }
}

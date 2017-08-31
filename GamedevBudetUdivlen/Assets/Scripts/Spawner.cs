using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public PathNode startNode;
    public float timePerWave;
    public float timePerUnit;
    public List<Wave> waves;
    public Wave currentWave;

    private Queue<Wave> wavesQueue;

	[SerializeField]private float passedTimeInWave;
	[SerializeField] private float passedTimeBtwSpawns;
	void Start () 
    {   
        wavesQueue = new Queue<Wave>(waves);
        if (waves.Count > 0)
        {
            currentWave = wavesQueue.Dequeue();
        }
        ResetTimeVars();
    }



	void Update()
    {
        IncTimeVars();
        if(passedTimeInWave >= timePerWave && wavesQueue.Count > 0){
            if (currentWave != null)
                currentWave.Reset();
            ResetTimeVars();
            currentWave = wavesQueue.Dequeue();
            print(currentWave.unspawnedUnits);
        }
        if(passedTimeBtwSpawns >= timePerUnit && currentWave.unspawnedUnits >0)
        {
            SpawnUnit(currentWave.getUnit());
            passedTimeBtwSpawns -= timePerUnit;
        }


    }
    void ResetTimeVars()
    {
		passedTimeInWave = 0;
		passedTimeBtwSpawns = 0;
    }
	void IncTimeVars()
	{
        passedTimeInWave +=Time.deltaTime;
		passedTimeBtwSpawns += Time.deltaTime;
	}

    void InstantiateWave(int index){
       
        //Wave w = waves[spawnedCount];
        //GameObject unit =  GameObject.Instantiate(w.units[index],transform.position,Quaternion.identity);
        //unit.GetComponent<UnitController>().SetTargetNode(startNode);
    }
    void SpawnUnit(GameObject prefab){
        GameObject unit = Instantiate(prefab, transform.position, Quaternion.identity);
		unit.GetComponent<UnitController>().SetTargetNode(startNode);
	}
}

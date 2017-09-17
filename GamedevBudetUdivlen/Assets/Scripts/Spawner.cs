using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public PathNode startNode;
    public float timePerWave;
    public float timePerUnit;
    public List<Wave> waves;
    public Wave currentWave;

    public int maxWaveCount;
    public int currentWaveNum;


    private Queue<Wave> wavesQueue;
    private int unitCount;



	[SerializeField] private float passedTimeInWave;
	[SerializeField] private float passedTimeBtwSpawns;
	void Start () 
    {   


        wavesQueue = new Queue<Wave>(waves);
        maxWaveCount = wavesQueue.Count;
        currentWaveNum = 0;

        if (waves.Count > 0)
        {
            NextWave();
        }
        ResetTimeVars();
    }

    public void NextWave()
    {
        currentWaveNum++;
        ResetTimeVars();
        currentWave =Object.Instantiate( wavesQueue.Dequeue()) as Wave;
		unitCount = 0; 
    }

    public bool HasNextWave()
    {
        return wavesQueue.Count > 0;
    }

	void Update()
    {
        IncTimeVars();
        //print(wavesQueue.Count);
        if(passedTimeInWave >= timePerWave && wavesQueue.Count > 0){

            NextWave();
        }

        if(passedTimeBtwSpawns >= timePerUnit && unitCount < currentWave.units.Count)
        {
            SpawnNextUnit(); 
        }

    }

    void SpawnNextUnit()
    {
		SpawnUnit(currentWave.getUnit(unitCount));
		passedTimeBtwSpawns -= timePerUnit;
		unitCount++;
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
        unit.transform.SetParent(transform);
        UnitController uc = unit.GetComponent<UnitController>();
        uc.SetTargetNode(startNode);
        GameManager.instance.OnUnitCreated(uc);
	}
}

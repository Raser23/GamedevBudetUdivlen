using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabrique : MonoBehaviour {

    public int workersCount;
    public int factor;
    public int coinsPerWorker;
    public int secForPay;
    private float passedTime;


    public Fabrique nextFab;
    public FabriqueNode fabNode;
    public GameObject workerPrefab;
    public GameObject exit;

    public Dictionary<UnitMotor, Fabrique> comingTo;

    public void Start()
    {
        passedTime = 0;
        comingTo = new Dictionary<UnitMotor, Fabrique>();
    }
    public void FixedUpdate()
    {
        passedTime += Time.fixedDeltaTime;
        if(passedTime >= secForPay)
        {
            GameManager.instance.coins += workersCount * factor * coinsPerWorker;
            passedTime = 0;
        }
    }
	public void AddWorker(UnitMotor um)
	{
		Destroy(um.gameObject);
		workersCount++;
	}

	public void tst(UnitMotor um)
	{
		if (comingTo.ContainsKey(um))
		{
			comingTo[um].AddWorker(um);
			comingTo.Remove(um);
		}
        um.OnPathEnd -= tst;
		//print("endos");
	}

    public void StartEvacuating()
    {
        print("here");
        StartCoroutine("Evacuate");
    }

    IEnumerator Evacuate()
    {
        for (int i = 0; i < workersCount; i++)
        {
            GameObject worker = Instantiate(workerPrefab, exit.transform.position, Quaternion.identity);
            UnitController uc = worker.GetComponent<UnitController>();
            uc.SetTargetNode(fabNode, nextFab.fabNode);
            uc.motor.OnPathEnd += tst;
            comingTo.Add(uc.motor,nextFab);
            yield return new WaitForSeconds(0.5f); 

        }
        workersCount = 0;
    }



}

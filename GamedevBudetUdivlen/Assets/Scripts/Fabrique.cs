using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabrique : MonoBehaviour {

    public int workersCount;
    public int factor;
    public int coinsPerWorker;
    public int secForPay;
    public int maxWorkersCount;
    public float timeForEvacuateOne;

    private float passedTime;
    private bool evacuating;

    public Fabrique nextFab;
    public FabriqueNode fabNode;
    public GameObject workerPrefab;
    public GameObject exit;

    public Dictionary<UnitMotor, Fabrique> comingTo;

    public void Start()
    {
        evacuating = false;
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
        if (workersCount < maxWorkersCount && !evacuating)
        {
            workersCount++;
            Destroy(um.gameObject);
        }
        else
        {
            SendToNextFabrique(um.GetComponent<UnitController>());
        }
	}

	public void tst(UnitMotor um)
	{
		if (comingTo.ContainsKey(um))
		{
			comingTo[um].AddWorker(um);
			comingTo.Remove(um);
		}
        um.OnPathEnd -= tst;
	}

    public void StartEvacuating()
    {
        evacuating = true;
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor",Color.red);
        StartCoroutine("Evacuate");
    }

    IEnumerator Evacuate()
    {
        int wc = workersCount;
        for (int i = 0; i < wc; i++)
        {
            GameObject worker = Instantiate(workerPrefab, exit.transform.position, Quaternion.identity);
            UnitController uc = worker.GetComponent<UnitController>();
            SendToNextFabrique(uc);
            workersCount--;
            yield return new WaitForSeconds(timeForEvacuateOne); 

        }
        workersCount = 0;
    }

    void SendToNextFabrique(UnitController uc)
    {
		uc.SetTargetNode(fabNode, nextFab.fabNode);
		uc.motor.OnPathEnd += tst;
		comingTo.Add(uc.motor, nextFab);
    }


}

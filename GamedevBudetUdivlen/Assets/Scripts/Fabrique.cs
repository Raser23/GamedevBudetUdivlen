using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabrique : MonoBehaviour {

    public int workersCount;
    public int factor;
    public int coinsPerWorker;
    public int secForPay;
    private float passedTime;

    public void Start()
    {
        passedTime = 0;
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
}

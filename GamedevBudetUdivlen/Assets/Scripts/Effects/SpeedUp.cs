using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {
    private int addSpeed;
    private float lifeTime;

    private UnitStats stats;

    public void SetInfo(int _addSpeed, int _lifeTime)
    {
        lifeTime = _lifeTime;
        if (stats == null)
        {
            stats = gameObject.GetComponent<UnitStats>();
            Boost();
			
        }else
        {
			DeBoost();
        }
		addSpeed = _addSpeed;
        Boost();
		working = true;
    }

	protected bool working;
	[SerializeField]protected float passed_time;

	protected virtual void Start()
	{
        working = false;
		passed_time = 0;
	}
	protected virtual void Update()
	{
        if (!working)
            return;
        
		passed_time += Time.deltaTime;
        if (passed_time >= lifeTime)
        {
            DeBoost();
            Destroy(this);
        }
	}
    private void Boost()
    {
        stats.speed += addSpeed;
    }
    private void DeBoost()
    {
        stats.speed -= addSpeed;
    }

    public void ResetWorkingTime()
    {
        passed_time = 0;
    }
}

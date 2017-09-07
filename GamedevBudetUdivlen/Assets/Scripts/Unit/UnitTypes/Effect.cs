using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    protected bool working;
    protected float passed_time;
    public abstract void SetInfo();

	protected virtual void Start()
	{
        passed_time = 0;
	}

    protected virtual void Update()
    {
        passed_time += Time.deltaTime;
    }
}

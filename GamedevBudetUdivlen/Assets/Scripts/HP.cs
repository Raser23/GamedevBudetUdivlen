using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {

	public float maxHp;

    protected float _hp;

	public virtual void Start()
	{
		_hp = maxHp;
	}

	public float currentHP
	{
		get { return _hp; }
		set
		{
			_hp = value;
			if (_hp <= 0)
			{
				HpBelowZero.Invoke();
			}
		}
	}

    public float clampedHP{
        get { return _hp / maxHp; }
    }

	public delegate void StatsAction();
	public event StatsAction HpBelowZero;
}

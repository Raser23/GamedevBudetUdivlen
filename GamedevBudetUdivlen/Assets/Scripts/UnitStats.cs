using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float maxHp;

    float _hp;

    private void Start()
    {
        
        _hp = maxHp;
    }

    public float HP
    {
        get { return _hp; }
        set { 
            _hp = value; 
            if(_hp<=0)
            {
                HpBelowZero.Invoke();    
            }
        }
    }


	public delegate void StatsAction();
	public event StatsAction HpBelowZero;

}

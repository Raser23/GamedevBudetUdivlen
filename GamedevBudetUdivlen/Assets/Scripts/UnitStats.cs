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
        //HP -= 10;
        //print(HP);
    }
    public float HP
    {
        get { return _hp; }
        set { _hp = value; }
    }
}

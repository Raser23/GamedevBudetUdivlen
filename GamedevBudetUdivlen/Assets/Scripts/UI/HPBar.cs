using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    public RectTransform rt;
    public HP hp;
    public GameObject following;
    public Slider slider;
    public bool working = false;

    public void Update()
    {
        if(working)
            slider.value = hp.clampedHP;
        if (following != null)
        {
            Vector3 screenPos = GameManager.instance.cam.WorldToScreenPoint(following.transform.position);
            rt.position = screenPos;
		}
    }

    public void StartUpdating(){
        working = true;        
    }
    public void StopUpdating(){
        working = false;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    TextMeshProUGUI mText;
    float passedTime;

	void Start () {
        mText = gameObject.GetComponent<TextMeshProUGUI>();
        passedTime =0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        passedTime += Time.fixedDeltaTime;
        mText.text = getTime();
	}

    string getTime()
    {
        int pt = (int)(passedTime*100);
        int minutes = pt/6000;
        pt -= minutes * 6000;
        int secs = pt / 100;
        pt -= secs * 100;
        int msecs = pt;

        string res = nicier(minutes.ToString())+":"+nicier(secs.ToString())+":"+nicier(msecs.ToString());
        return res;
    }
    string nicier(string str)
    {
        
        for (int i = str.Length; i < 2;i++)
        {
            
            str = "0" + str;
        }
        return str;
    }
}

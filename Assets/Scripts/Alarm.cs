using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour {

    [SerializeField]
    Material turnOnMaterial;
    [SerializeField]
    Material turnOffMaterial;

    bool isAlarmOn = false;
    bool isLightOn = false;

    AudioSource source;
    MeshRenderer meshRenderer;

    float alarmTime = 0;
    float alarmRate = 0.75f;

    // Use this for initialization
    void Awake () {
        meshRenderer = GetComponent<MeshRenderer>();
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isAlarmOn)
        {
            if (Time.time >= alarmTime)
            {
                if (isLightOn)
                {
                    isLightOn = false;
                    alarmTime = Time.time + alarmRate;
                    meshRenderer.material = turnOffMaterial;
                    source.Play();

                }
                else
                {
                    isLightOn = true;
                    alarmTime = Time.time + alarmRate;
                    meshRenderer.material = turnOnMaterial;
                    source.Play();
                }
            }
        }
	}


    public void TurnOn()
    {
        isAlarmOn = true;
        alarmTime = Time.time + alarmRate;
    }

    public void TurnOff()
    {
        isAlarmOn = false;
        isLightOn = false;
        meshRenderer.material = turnOffMaterial;
    }
}

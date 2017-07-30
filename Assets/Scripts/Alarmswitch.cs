using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarmswitch : SwitchBehaviour {

    [Header("Alarms")]
    public Alarm alarm;

	// Use this for initialization
	void Start () {
        PowerConsumption = 15f;
        TurnOff(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TurnOn(bool noSound = false)
    {
        base.TurnOn(noSound);

        alarm.TurnOn();
    }

    public override void TurnOff(bool noSound = false)
    {
        base.TurnOff(noSound);

        alarm.TurnOff();
    }

}

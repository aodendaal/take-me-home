using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : SwitchBehaviour {

    [Header("Lightswitch")]
    public Light lighting;
    public Light[] emergencyLighting;


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

        if (IsOn)
        {
            lighting.enabled = true;
            foreach (var light in emergencyLighting)
            {
                light.enabled = false;
            }
        }
    }

    public override void TurnOff(bool noSound = false)
    {
        base.TurnOff(noSound);

        lighting.enabled = false;
        foreach (var light in emergencyLighting)
        {
            light.enabled = true;
        }
    }

}

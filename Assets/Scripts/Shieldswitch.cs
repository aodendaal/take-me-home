using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldswitch : SwitchBehaviour {

    [Header("Shieldswitch")]
    public GameObject shieldPrefab;

    // Use this for initialization
    void Start () {
        PowerConsumption = 40f;
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
            shieldPrefab.SetActive(true);
        }
    }

    public override void TurnOff(bool noSound = false)
    {
        base.TurnOff(noSound);

        shieldPrefab.SetActive(false);
    }
}

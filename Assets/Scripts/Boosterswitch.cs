using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosterswitch : SwitchBehaviour {

    ParticleSystem particleSystem;

    // Use this for initialization
    void Start()
    {
        particleSystem = FindObjectOfType<ParticleSystem>();

        PowerConsumption = 95f;
        TurnOff(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void TurnOn(bool noSound = false)
    {
        base.TurnOn(noSound);

        if (IsOn)
        {
            particleSystem.Play();
            var main = particleSystem.main;
            main.simulationSpeed = 5f;
            gameManager.IsBoosted = true;
        }
    }

    public override void TurnOff(bool noSound = false)
    {
        base.TurnOff(noSound);

        var main = particleSystem.main;
        main.simulationSpeed = 1f;

        gameManager.IsBoosted = false;
    }
}

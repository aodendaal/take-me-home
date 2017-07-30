using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosterswitch : SwitchBehaviour {

    ParticleSystem[] particleSystems;

    // Use this for initialization
    void Start()
    {
        particleSystems = FindObjectsOfType<ParticleSystem>();

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
            foreach (var p in particleSystems)
            {
                p.Play();
                var main = p.main;
                main.simulationSpeed = 5f;
            }

            gameManager.IsBoosted = true;
        }
    }

    public override void TurnOff(bool noSound = false)
    {
        base.TurnOff(noSound);

        foreach (var p in particleSystems)
        {
            var main = p.main;
            main.simulationSpeed = 1f;
        }

        gameManager.IsBoosted = false;
    }
}

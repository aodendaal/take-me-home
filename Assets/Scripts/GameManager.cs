using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Slider homeSlider;
    public Slider powerSlider;

    [Header("Power Meter")]
    [SerializeField]
    private Image powerFill;
    [SerializeField]
    private Color goodColor;
    [SerializeField]
    private Color okColor;
    [SerializeField]
    private Color badColor;
    [SerializeField]
    private Color offColor;

    [Header("UI")]
    [SerializeField]
    private GameObject introPanel;
    [SerializeField]
    private GameObject victoryPanel;

    float totalPower = 100f;
    public float UsedPower { get; private set; }
    
    float totalTime = 60f;
    float remainingTime = 0f;

    float multiplier = 0f;
    public bool IsBoosted { get; set; }

    ParticleSystem particleSystem;

    private void Awake()
    {
        UsedPower = 0;
        particleSystem = FindObjectOfType<ParticleSystem>();
        
    }

    // Use this for initialization
    void Start () {
        introPanel.SetActive(true);
        particleSystem.Pause();

        remainingTime = totalTime;    
        
    }

    // Update is called once per frame
    void Update() {        

        remainingTime -= Time.deltaTime * multiplier * ((IsBoosted) ? 2f : 1f);

        homeSlider.value = (totalTime - remainingTime) / totalTime;

        CheckVictory();
	}

    private void CheckVictory()
    {
        if (remainingTime <= 0f)
        {
            victoryPanel.SetActive(true);
            particleSystem.Pause();
        }
    }

    public bool CanPowerOn(float power)
    {
        return (UsedPower + power) <= 100f;
    }

    public void UpdatePowerConsumption(float power)
    {
        UsedPower += power;
        UsedPower = Mathf.Clamp(UsedPower, 0f, 100f);

        Debug.Log("Used Power: " + UsedPower.ToString());

        powerSlider.value = (totalPower - UsedPower) / totalPower;

        if (powerSlider.value > 0.66f)
        {
            multiplier = 1f;
            powerFill.color = goodColor;
            if (particleSystem.isPaused) particleSystem.Play();
        }
        else if (powerSlider.value > 0.5f)
        {
            multiplier = 0.5f;
            powerFill.color = okColor;
            if (particleSystem.isPaused) particleSystem.Play();
        }
        else if (powerSlider.value > 0.25f)
        {
            multiplier = 0.33f;
            powerFill.color = badColor;
            if (particleSystem.isPaused) particleSystem.Play();
        }
        else
        {
            powerFill.color = offColor;
            if (!particleSystem.isPaused) particleSystem.Pause();
        }
    }

    public void Click_StartGame()
    {
        introPanel.SetActive(false);
        particleSystem.Play();
    }

    public void Click_RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

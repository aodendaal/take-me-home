using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
public abstract class SwitchBehaviour : MonoBehaviour
{
    [Header("Switch Materials")]
    [SerializeField]
    protected Material turnOnMaterial;
    [SerializeField]
    protected Material turnOffMaterial;
    [Header("Switch Sounds")]
    [SerializeField]
    protected AudioClip switchOnClip;
    [SerializeField]
    protected AudioClip switchOffClip;
    [SerializeField]
    protected AudioClip errorClip;

    protected AudioSource source;

    protected MeshRenderer meshRenderer;

    protected GameManager gameManager;

    public float PowerConsumption { get; protected set; }

    private void Awake()
    {
        source = GetComponent<AudioSource>();

        meshRenderer = GetComponent<MeshRenderer>();

        gameManager = FindObjectOfType<GameManager>();
    }

    public bool IsOn { get; set; }

    public virtual void TurnOn(bool noSound = false)
    {
        if (gameManager.CanPowerOn(PowerConsumption))
        {
            IsOn = true;
            if (!noSound)
            {
                source.clip = switchOnClip;
                source.Play();
            }

            meshRenderer.material = turnOnMaterial;

            gameManager.UpdatePowerConsumption(PowerConsumption);
        }
        else
        {
            if (!noSound)
            {
                source.clip = errorClip;
                source.Play();
            }
        }
    }

    public virtual void TurnOff(bool noSound = false)
    {
        IsOn = false;
        if (!noSound)
        {
            source.clip = switchOffClip;
            source.Play();
        }

        meshRenderer.material = turnOffMaterial;

        if (gameManager.UsedPower >= PowerConsumption)
        {
            gameManager.UpdatePowerConsumption(-PowerConsumption);
        }
    }

    public virtual void Toggle()
    {
        if (IsOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }
}
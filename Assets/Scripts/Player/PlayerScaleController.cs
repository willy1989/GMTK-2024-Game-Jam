using UnityEngine;
using UnityEngine.Events;

public class PlayerScaleController : PlayerControllerBase
{
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private int maxNumberOfScaleChanges;

    [SerializeField] private SoundEffectPlayer soundEffectPlayer;

    public override event UnityAction OnActionMade;

    private float[] scaleValues;

    private int _scaleValueIndex;

    private int scaleValueIndex
    {
        get
        {
            return _scaleValueIndex;
        }

        set
        {
            if (value >= 0 && value <= scaleValues.Length-1)
            {
                _scaleValueIndex = value;
            }
        }
    }


    private void Awake()
    {
        scaleValues = ScaleValues(maxNumberOfScaleChanges);

        scaleValueIndex = maxNumberOfScaleChanges;
    }

    private void Update()
    {
        if (isFrozen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeScale(increment:1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeScale(increment: -1);
        }
    }

    private void ChangeScale(int increment)
    {
        scaleValueIndex += increment;

        float scaleValue = scaleValues[scaleValueIndex];

        transform.localScale = new Vector3(1, 1, 1) * scaleValue;
        rigidBody.mass = scaleValue;
        OnActionMade?.Invoke();
        soundEffectPlayer.PlaySoundEffect();
    }

    private float[] ScaleValues(int maxSteps)
    {
        int totalNumberOfSteps = maxSteps * 2 + 1;

        float[] result = new float[totalNumberOfSteps];

        float startNumber = 1f / Mathf.Pow(2, maxSteps);

        for (int i = 0; i < totalNumberOfSteps; i++)
        {
            result[i] = startNumber * Mathf.Pow(2, i);
        }

        return result;
    }
}

using UnityEngine;

public class CatapultBehaviour : MonoBehaviour
{
    [SerializeField] private SpringJoint2D springJoint;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private float maxStretch = 2.0f;
    [SerializeField] private float chargeRate = 1.0f;
    [SerializeField] private KeyCode launchKey = KeyCode.Space;
    [SerializeField] private ColliderWithCallback trigger;
    [SerializeField] private Rigidbody2D playerRb;

    private float currentStretch = 0.0f;
    private bool isCharging = false;

    private void Start()
    {
        trigger.Init(Attach);
        springJoint.autoConfigureDistance = false;
        springJoint.distance = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(launchKey))
        {
            StartCharging();
        }

        if (Input.GetKey(launchKey))
        {
            if (isCharging)
            {
                Charge();
            }
        }

        if (Input.GetKeyUp(launchKey))
        {
            if (isCharging)
            {
                Release();
            }
        }
    }

    private void StartCharging()
    {
        isCharging = true;
        currentStretch = 0.0f;
        // Disable until charged 
        springJoint.enabled = false;
    }

    private void Charge()
    {
        currentStretch += chargeRate * Time.deltaTime;
        currentStretch = Mathf.Clamp(currentStretch, 0, maxStretch);

        var stretchDirection = (Vector2)launchPoint.position - playerRb.position;
        stretchDirection.Normalize();
        playerRb.position = (Vector2)launchPoint.position - stretchDirection * currentStretch;

        springJoint.distance = currentStretch;
    }

    private void Release()
    {
        springJoint.enabled = true;
        isCharging = false;
        Debug.Log($"[Catapult] Launched with stretch {currentStretch}");
    }

    public void Attach()
    {
        springJoint.connectedBody = playerRb;
        springJoint.enabled = false;
    }
}

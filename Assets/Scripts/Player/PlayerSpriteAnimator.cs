using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAnimator : MonoBehaviour
{
    [SerializeField] GameObject target;

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        float yOffset = (target.transform.localScale.y / 2) + 0.8f;

        transform.position = new Vector2(target.transform.position.x, target.transform.position.y + yOffset);
    }
}

using UnityEngine;

public static class Utils
{
    public static bool ComparePlayerTag(this Collider2D collider)
    {
        return collider.CompareTag("Player");
    }
}

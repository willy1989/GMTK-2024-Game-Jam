using UnityEngine;

public static class Utils
{
    public static bool ComparePlayerTag(this Collider2D collider)
    {
        return collider.gameObject.ComparePlayerTag();
    }

    public static bool ComparePlayerTag(this GameObject gameObject)
    {
        return gameObject.CompareTag("Player");
    }
}

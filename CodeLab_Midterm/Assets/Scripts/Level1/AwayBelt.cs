using UnityEngine;

public class AwayBelt : MonoBehaviour
{
    public static bool sendAway = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Dragged"))
        {
            sendAway = true;
        }
    }
}

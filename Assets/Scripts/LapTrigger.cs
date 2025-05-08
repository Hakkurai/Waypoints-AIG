using UnityEngine;

public class LapTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AICar"))
        {
            LapTimer timer = other.GetComponent<LapTimer>();
            if (timer != null)
            {
                timer.CompleteLap();
            }
        }
    }
}

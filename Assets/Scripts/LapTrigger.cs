using UnityEngine;

public class LapTrigger : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AICar") || other.GetComponentInParent<LapTimer>() != null)
        {
            LapTimer timer = other.GetComponentInParent<LapTimer>();
            if (timer != null)
            {
                timer.CompleteLap();
            }
        }
    }

}

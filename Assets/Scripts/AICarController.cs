using UnityEngine;

public class AICarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 5f;
    public float waypointRadius = 2f;

    public WaypointManager waypointManager;
    private int currentWaypointIndex = 0;
    private Transform targetWaypoint;

    void Start()
    {
        if (waypointManager != null && waypointManager.waypoints.Length > 0)
        {
            targetWaypoint = waypointManager.waypoints[currentWaypointIndex];
        }
    }

    void Update()
    {
        if (targetWaypoint == null) return;

        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        if (distance < waypointRadius)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypointManager.waypoints.Length;
            targetWaypoint = waypointManager.waypoints[currentWaypointIndex];
        }
    }
}

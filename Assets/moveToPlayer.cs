// 12/6/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveToCameraRig : MonoBehaviour
{
    public Transform cameraRigTarget; // Assign the CenterEyeAnchor from the XR Rig here

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        cameraRigTarget = GameObject.Find("[BuildingBlock] Camera Rig").transform.Find("TrackingSpace").Find("CenterEyeAnchor");
        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (cameraRigTarget == null)
        {
            Debug.LogWarning("CameraRig target is not assigned!");
            return;
        }

        navMeshAgent.SetDestination(cameraRigTarget.position - (cameraRigTarget.position - transform.position).normalized * 3);
    }
}
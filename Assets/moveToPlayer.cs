// 12/6/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveToCameraRig : MonoBehaviour
{
    public Transform cameraRigTarget; // Assign the CenterEyeAnchor from the XR Rig here

    void Start()
    {
        return;
    }

    void Update()
    {
        if (cameraRigTarget == null)
        {
            Debug.LogWarning("CameraRig target is not assigned!");
            return;
        }

        Vector3 cameraPosition = cameraRigTarget.position;
        Vector3 enemyPosition = transform.position;
        Vector3 destination = new Vector3(cameraPosition.x, enemyPosition.y, cameraPosition.z);
        
        transform.position = Vector3.MoveTowards(enemyPosition, destination, 0.1f * Time.deltaTime);
    }
}
// 12/6/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveToCameraRig : MonoBehaviour
{
    public Transform cameraRigTarget; // Assign the CenterEyeAnchor from the XR Rig here
    public float enemyHeight = 0.3f;
    public float moveTowardsPlayerSpeed = 0.1f;
    public float riseFromLavaSpeed = 0.8f;

    private bool roseFromLava = false;

    void Update()
    {
        Vector3 enemyPosition = transform.position;

        if (roseFromLava)
        {
            if (cameraRigTarget == null)
            {
                Debug.LogWarning("CameraRig target is not assigned!");
                return;
            }

            Vector3 cameraPosition = cameraRigTarget.position;
            Vector3 destination = new Vector3(cameraPosition.x, enemyPosition.y, cameraPosition.z);

            transform.position = Vector3.MoveTowards(enemyPosition, destination, moveTowardsPlayerSpeed * Time.deltaTime);
        }
        else
        {
            if (enemyPosition.y < enemyHeight)
            {
                Vector3 destination = new Vector3(enemyPosition.x, enemyHeight, enemyPosition.z);

                transform.position = Vector3.MoveTowards(enemyPosition, destination, riseFromLavaSpeed * Time.deltaTime);
            }
            else
            {
                roseFromLava = true;
            }
        }
    }
}
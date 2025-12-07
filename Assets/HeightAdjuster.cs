using UnityEngine;

public class HeightAdjuster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform trackingSpace = transform.Find("TrackingSpace"); // Adjust path as needed

        if (trackingSpace != null)
        {
            Debug.Log("1234");
            // Adjust the local position of the TrackingSpace along the Y-axis
            Vector3 newPosition = trackingSpace.localPosition;
            newPosition.y = 0;
            trackingSpace.localPosition = newPosition;
        }
    }
}

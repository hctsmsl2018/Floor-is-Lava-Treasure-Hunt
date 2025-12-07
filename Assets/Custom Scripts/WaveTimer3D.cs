using UnityEngine;
using TMPro;

public class WaveTimer3D : MonoBehaviour
{
    [SerializeField] public float timeRemaining = 30f;
    [SerializeField] public TextMeshPro[] timerTexts;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            string display = Mathf.Ceil(timeRemaining).ToString();

            foreach (var t in timerTexts)
                t.text = display;
        }
        else
        {
            foreach (var t in timerTexts)
                t.text = "0";
        }
    }
}

using UnityEngine;
using TMPro;

public class not_working_3D_Wave_Timer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TextMeshPro[] timerTexts;

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

    //Simple timer
    /*
[SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
*/
}

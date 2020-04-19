/* Class to control the timer in the game scene.
Timer then continues onto level 2 once time count
ends
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeGame : MonoBehaviour
{
    // Variable to hold what level to continue to
    public string levelToLoad;
    // Timer variable
    private float timer = 20f;
    // Timer text on screen
    private Text timerSeconds;

    // Start is called before the first frame update
    void Start()
    {
        // Start the timer 
        timerSeconds = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        // Converting timer to text
        timerSeconds.text = timer.ToString("f0");

        /* When timer is less than or equal to 0
        then load next level 
        */
        if (timer <= 0)
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}

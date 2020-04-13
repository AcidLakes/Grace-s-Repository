/* Class enables the on screen icons functionality
to work.
Back icon - navigates to the main menu
pause icon - pauses the game
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Change game scene function
    public void changeScene(string scenename)
    {
        // Takes in the scene name in which to navigate to
        Application.LoadLevel (scenename);
    }
}


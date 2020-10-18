using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
   public void doExitGame()
{
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        print("Kevin");
} 

}





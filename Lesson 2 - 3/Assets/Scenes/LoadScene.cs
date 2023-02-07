using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
   public void loadSceneOne()
   {
      SceneManager.LoadScene(0);
      
      

   }
   public void loadSceneTwo()
   {
      SceneManager.LoadScene(1);
      Screen.orientation = ScreenOrientation.LandscapeLeft;
   }
}

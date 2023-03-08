
using UnityEngine.SceneManagement;
using UnityEngine;



public class Restart_Scene : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

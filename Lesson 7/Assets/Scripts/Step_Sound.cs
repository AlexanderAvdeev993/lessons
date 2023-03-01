
using UnityEngine;

public class Step_Sound : MonoBehaviour
{   
    public AudioClip[] soundWood;
    public AudioClip[] soundIron;
    AudioSource playerAudio;
    string surfaceType = "Wood";

    private void Awake() 
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        surfaceType = LayerMask.LayerToName(other.gameObject.layer);
    }
   
    
    void FootStep()
    {   
        switch(surfaceType)
        {
            case "Wood":
                playerAudio.PlayOneShot(soundWood[Random.Range(0, soundWood.Length)]); 
                break;
            case "Iron":
                playerAudio.PlayOneShot(soundIron[Random.Range(0, soundIron.Length)]);
                break;
            default:
                Debug.LogWarning("Unknown surface type: " + surfaceType);
                break;
        }
    }
}


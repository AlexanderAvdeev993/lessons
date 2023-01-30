
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportInterval = 0.5f;
    public float xPoint = 7f;
    public float yPoint = 2f;
    private float timer;

    void Start()
    {
        timer = teleportInterval;
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = teleportInterval;
            float x = Random.Range(-xPoint, xPoint);
            float y = Random.Range(-yPoint, yPoint);
            transform.position = new Vector3(x,y,Random.Range(0,5));
        }
    }
}


using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private float teleportInterval = 0.5f;
    [SerializeField] private float xPoint = 7f;
    [SerializeField] private float yPoint = 2f;
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

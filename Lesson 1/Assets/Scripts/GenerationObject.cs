
using System.Collections.Generic;
using UnityEngine;


public class GenerationObject : MonoBehaviour
{   
    [SerializeField] private List<GameObject> prefabs;
    private GameObject instance;
    private GameObject prefab;
     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (prefabs == null)
            {
                Debug.LogError("Prefab is NULL ! ! !");
                
            }

            prefab = prefabs[Random.Range( 0, prefabs.Count)];

            if (instance != null)
            {
                Destroy(instance);
            }

            var rotation = Quaternion.identity;
            var position = new Vector3(Random.Range(-5.0f , 5.0f), Random.Range(1.0f , 4.0f),Random.Range(1.0f , 5.0f));
            instance = Instantiate(prefab, position, rotation);
        }
    }
}


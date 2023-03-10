using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class NewBehaviorScript : MonoBehaviour
{   
    [SerializeField] private Button button;
    [SerializeField] private List<GameObject> objectOn;
    [SerializeField] private List<GameObject> objectOff;
    [SerializeField] private TextMeshProUGUI nameFolder;
    [SerializeField] private string newNameFolder;
    
    
    void Start()
    {
        button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        if(objectOff != null)
        {
            foreach (GameObject offObject in objectOff)
            {
                offObject.gameObject.SetActive(false);
            }
        }
        if(objectOn != null)
        {
            foreach (GameObject onObject in objectOn)
            {
                onObject.gameObject.SetActive(true);
            }
        }

        nameFolder.text = newNameFolder;
        
    }
   
}

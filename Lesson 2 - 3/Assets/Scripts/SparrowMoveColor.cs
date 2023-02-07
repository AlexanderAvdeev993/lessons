
using UnityEngine;
using UnityEngine.UI;


public class SparrowMoveColor : MonoBehaviour
{
      
    [SerializeField] private GameObject[] objects;       
    [SerializeField] private int currentIndex = 0;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    [SerializeField] private Button redButton;
    [SerializeField] private Button greenButton;
    [SerializeField] private Button blueButton;
    [SerializeField] private Button yellowButton;

    [SerializeField] private Material[] materials;
    
     
    

    
    private void Start()
    {   
        redButton.onClick.AddListener(ChangeMaterialRed);
        blueButton.onClick.AddListener(ChangeMaterialBlue);
        greenButton.onClick.AddListener(ChangeMaterialGreen);
        yellowButton.onClick.AddListener(ChangeMaterialYellow);
        
        leftButton.onClick.AddListener(previousObject);  
        rightButton.onClick.AddListener(NextObject);       
    }

    public void SelectObject() 
    {   
        GameObject anchor = GameObject.Find("Anchor");
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == currentIndex)
            {
                objects[i].SetActive(true);
                                     
            } 
            else 
            {
                objects[i].SetActive(false);
            }
            objects[currentIndex].transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anchor.transform.eulerAngles = new Vector3(0f,0f,0f);
            
        }
    }
   

    public void NextObject() 
    {   
        currentIndex++;       
        if (currentIndex >= objects.Length) 
        {
            currentIndex = 0;
        }
        SelectObject();        
    }
    public void previousObject()
    {
        currentIndex--;
        if (currentIndex < 0) 
        {
            currentIndex = objects.Length - 1;
        }
        SelectObject();
    }
    
    public void ChangeMaterialRed()
    {
        objects[currentIndex].GetComponent<Renderer>().material = materials[0];
    } 
     public void ChangeMaterialBlue()
    {
        objects[currentIndex].GetComponent<Renderer>().material = materials[1];
    }   
     public void ChangeMaterialGreen()
    {
        objects[currentIndex].GetComponent<Renderer>().material = materials[2];
    }   
     public void ChangeMaterialYellow()
    {
        objects[currentIndex].GetComponent<Renderer>().material = materials[3];
    }     
}
    
       



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthGUI : MonoBehaviour
{
    private TextMeshProUGUI healthStatus;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
         
        
        healthStatus = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        healthStatus.text = "Health: " + 100;
    }
}

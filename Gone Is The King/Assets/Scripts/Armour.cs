using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Armour : MonoBehaviour, IItem
{
    // Public properties for all Armours
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Sprite Design { get; set; }
    public double Defence { get; set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

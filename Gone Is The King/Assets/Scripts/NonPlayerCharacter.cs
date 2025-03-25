using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NonPlayerCharacter : MonoBehaviour, ICharacter
{
    // Public properties for all Consumables
    public int[] position {get;set;}
    public Sprite design {get;set;}
    public int moveSpeed {get;set;}
    public ArrayList inventory;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTo (int[] Position) {
        this.position = Position;
    }

}

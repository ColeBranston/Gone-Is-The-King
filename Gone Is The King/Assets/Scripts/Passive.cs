using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Passive : NonPlayerCharacter
{
    // Public properties for all Consumables
    public int[] position;
    public Sprite design;
    public int moveSpeed;
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
    public void Move(){}

}

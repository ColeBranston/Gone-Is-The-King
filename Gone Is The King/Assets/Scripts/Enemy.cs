using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : NonPlayerCharacter, IAttackable
{
    // Public properties for all Consumables
    public int[] position {get;set;}
    public Sprite design {get;set;}
    public int moveSpeed {get;set;}
    public ArrayList dropables;
    public Dictionary<IItem, double> itemDropChance;
    public double health {get;set;}
    public double strength {get;set;}
    public Armour armour {get;set;}
    
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
    public void Attack(){}
    public void TakeDammage(){}
}

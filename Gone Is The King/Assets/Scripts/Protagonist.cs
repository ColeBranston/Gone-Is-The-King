using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Protagonist : MonoBehaviour, ICharacter, IAttackable
{
    // Public properties for all Consumables

    public int[] position { get; set; }
    public int moveSpeed {get; set;}
    public Sprite design {get; set;}
    public string name;
    public double health { get; set; }
    public double strength { get; set; }
    public Armour armour { get; set; }
    public int exp;
    public Interaction interact;
    public ArrayList inventory; //will add/remove IItems to this
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleAnimations() {

    }

    public void Move() {

    }

    public void Attack() {

    }

    public int Sell (IItem item) {
        return item.Price; // Dummy return for now
    }

    public void Interact() {
        // will likely use interact.HandleKeyPress()
    }

    public void Pause() {

    }

    public void LevelUp() {

    }

    public void Heal (double amt) {
        this.health = this.health + amt; //possible method
    }

    public void AllocatePoints(int pts, string stat) {

    }

    public void Equip (IItem item) {
        // use inventory field
    }

}

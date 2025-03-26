using System.Collections;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public ArrayList Items = new ArrayList();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destock(IItem item, int num)
    {
        Items.Remove(item);
    }

    public void Stock(IItem item, int num)
    {
        Items.Add(item);
    }
    
}

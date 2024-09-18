using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType {note, card}

public class Item
{
    public ItemType itemtype;
    public string info;
    public Sprite icon;
    public void setinfo(string info, ItemType type) {
        this.info = info;
        this.itemtype = type;
        
    }
}
public class Inventory : MonoBehaviour
{
    int maxItems;
    public List<Item> inventoryItems = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        maxItems = slots.Count;
        
    }
    public void AddItem(Item item) {
        if (inventoryItems.Count <= maxItems) {
            //slots[inventoryItems.Count].setinfo(item.info, item.itemtype);
            inventoryItems.Add(item);
            slots[inventoryItems.Count].transform.GetChild(0).GetComponent<Image>().sprite=item.icon;

        }

    }
}


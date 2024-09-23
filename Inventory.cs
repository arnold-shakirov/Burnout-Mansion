using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType {note, card}
/*
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
*/
public class Item
{
    public ItemType itemtype;
    public string info;
    public Sprite icon;

    public void SetInfo(string info, ItemType type)
    {
        this.info = info;
        this.itemtype = type;
    }
}
//GET ITEMS IN SLOTS AND COMBINE THAT TO A DICTIONARY 
//OF SLOTS AND INVENTORY ITEMS, KEY - SLOTS AND ITEMS ARE A VALUE.
/*
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
*/
public class Inventory : MonoBehaviour
{
    int maxItems;
    public List<Item> inventoryItems = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    public Dict<GameObject, Item> slotItemDict = new Dictionary<GameObject, Item>();

    void Start()
    {
        maxItems = slots.Count;
    }

    public void AddItem(Item item)
    {
        if (inventoryItems.Count < maxItems)
        {
            // Add item to inventoryItems
            inventoryItems.Add(item);

            // Corresponding slot and set the icon
            GameObject slot = slots[inventoryItems.Count - 1];
            slot.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;

            // Add the slot and item to the dictionary
            slotItemDict[slot] = item;
        }
    }
    public Item GetItemBySlot(GameObject slot)
    {
        if (slotItemDict.ContainsKey(slot))
        {
            return slotItemDict[slot];
        }
        return null;
    }
}


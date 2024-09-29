using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType {note, card}

[System.Serializable]
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

public class Inventory : MonoBehaviour
{
    [SerializeField] private int maxItems;
    public List<Item> inventoryItems = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    public Dictionary<GameObject, Item> slotItemDict = new Dictionary<GameObject, Item>();

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


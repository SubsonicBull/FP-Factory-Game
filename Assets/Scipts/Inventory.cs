using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[4];
    public Slot[] slots = new Slot[4];

    public void AddItem (int type, int count)
    {
        int lowestcount = 9999;
        Slot slotwithlowestcount = null;
        foreach (Slot slot in slots)
        {
            if (slot.heldItem == null)
            {
                slotwithlowestcount = slot;
            }
        }
        if (slotwithlowestcount == null)
        {
            foreach (Slot slot in slots)
            {
                if (slot.heldItem.id == type)
                {
                    if (slot.count <= lowestcount)
                    {
                        slotwithlowestcount = slot;
                    }
                }
            }
        }
        slotwithlowestcount.heldItem = new Item();
        slotwithlowestcount.heldItem.id = type;
        slotwithlowestcount.count += count;
    }
    private void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            AddItem(1, 10);
        }
    }
}

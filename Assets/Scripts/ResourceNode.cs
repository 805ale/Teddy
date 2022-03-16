using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode : Interactable
{
    public Item item;
    private int k = 0;
    public override void Interact()
    {
        base.Interact();
        PickUpNode();
    }
    void PickUpNode()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        k++;
        Debug.Log(wasPickedUp);
        Debug.Log(k);
        if (wasPickedUp && (k == Random.Range(1,5)))
        {
            Destroy(gameObject);
        }
    }
}

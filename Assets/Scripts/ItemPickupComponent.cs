using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupComponent : MonoBehaviour
{
    [SerializeField]
    private ItemScriptable pickUpItem;

    [SerializeField, Tooltip("Manual override for drop amount, if left at -1 it will use the amount from the scriptable object")]
    private int amount = -1;

    [SerializeField]
    private MeshRenderer propMeshRenderer;
    [SerializeField]
    private MeshFilter propMeshFilter;

    private ItemScriptable itemInstance;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        itemInstance = Instantiate(pickUpItem);

        if (amount > 0)
            itemInstance.SetAmount(amount);

        ApplyMesh();
    }

    private void ApplyMesh()
    {
        if (propMeshFilter)
            propMeshFilter.mesh = pickUpItem.itemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
        if (propMeshRenderer)
            propMeshRenderer.materials = pickUpItem.itemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log($"{pickUpItem.name} - Picked Up");

            InventoryComponent playerInventory = other.GetComponent<InventoryComponent>();
            if(playerInventory)
                playerInventory.AddItem(itemInstance, amount);

            Destroy(gameObject);
        }
    }

    private void OnValidate()
    {
        ApplyMesh();
    }
}

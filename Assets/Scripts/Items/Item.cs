using SIS.Items.Enums;
using UnityEngine;
using System;

// Main class for Items
namespace SIS.Items
{
    public class Item : MonoBehaviour
    {
        [Header("Base Item info")]
        [SerializeField] private Sprite inventoryItemSprite;  //reference to this item image that can be shown in equipment 
        [SerializeField] private Sprite itemIcon; //reference to this item icon that can shown in inventory
        [SerializeField] private ItemTypes itemType;
        [SerializeField] private string itemName;
        [SerializeField] private string itemDescription;
        [SerializeField] private int itemID;

        // Item size if you want to have different item sizes and grid inventory
        [Header("Item Size"), Range(1, 10)] private Vector2Int itemSize = new Vector2Int(1, 1);

        // If item can be stackable e.g torches, potions
        [Header("Stack options")] private bool isStackable;
        [Range(1, 100), SerializeField] private int itemMaxStackSize = 1;    // Max stack size
        [Range(1, 100), SerializeField] private int itemStackSize = 1;   // Stack size counter
        
        public Action<Item> onUseItem;
        public Action<Item> onPickupItem;

        #region Properties

        public Sprite InventoryItemSprite { get => inventoryItemSprite; set => inventoryItemSprite = value; }
        public Sprite ItemIcon { get => itemIcon; set => itemIcon = value; }
        public ItemTypes ItemType { get => itemType; set => itemType = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string ItemDescription { get => itemDescription; set => itemDescription = value; }
        public int ItemID { get => itemID; set => itemID = value; }
        public Vector2Int ItemSize { get => itemSize; set => itemSize = value; }
        public bool IsStackable { get => isStackable; set => isStackable = value; }
        public int ItemMaxStackSize { get => itemMaxStackSize; set => itemMaxStackSize = value; }
        public int ItemStackSize { get => itemStackSize; set => itemStackSize = value; }

        #endregion
    }
}

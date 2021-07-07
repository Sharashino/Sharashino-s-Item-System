using UnityEngine;

// Auxiliary class for creating items of type Consumable
namespace SIS.Items
{
    public class ConsumableItem : Item
    {
        [Header("Consumable item details")]
        public int healingPower;
    }
}

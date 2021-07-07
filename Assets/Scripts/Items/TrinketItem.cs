using UnityEngine;

// Auxiliary class for creating items of type Trinket
namespace SIS.Items
{
    public class TrinketItem : Item
    {
        [Header("Trinket item details")] 
        public int healthBuff;
        public int staminaBuff;
        public int manaBuff;
    }
}

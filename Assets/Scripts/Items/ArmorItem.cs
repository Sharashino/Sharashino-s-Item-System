using SIS.Items.Enums;
using UnityEngine;

/// <summary>
/// Klasa pomocnicza do tworzenia przedmiotów typu armor
/// 
/// Napisane przez Sharashino
/// </summary>
namespace SIS.Items
{
    public class ArmorItem : Item
    {
        public ArmorTypes armorType;
        public Sprite armorInventorySprite;
        public int armorValue;
        public int armorLevel;
    }
}

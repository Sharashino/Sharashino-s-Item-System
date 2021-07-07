using SIS.Items;
using UnityEngine;

// Use this script on every object you want to pick up
// Has overwritble method from Interactables for changing interaction logic
namespace SIS.Actions.Interaction
{
    public class ItemPickup : Interactable
    {
        [SerializeField] private Item item = default;   //reference to an item

        public Item Item { get => item; set => item = value; }
        
        public override void Interact()
        {
            base.Interact();
            PickUp();
        }

        private void PickUp()
        {
            Debug.Log("Picking up item: " + item.name);
            
            /*
             *  Here you should put code that is responsible for
             *  putting items inside of players inventory
             */
        }
    }
}


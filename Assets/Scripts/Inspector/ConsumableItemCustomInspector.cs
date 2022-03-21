using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;
using SIS.Items;

namespace SIS.Inventory.Editors
{
    [CustomEditor(typeof(ConsumableItem))]
    public class ConsumableItemCustomInspector : Editor
    {
        private ConsumableItem consumableItem;  // Reference to ConsumableItem we're displaying

        public override void OnInspectorGUI()
        {
            consumableItem = target as ConsumableItem;  // Telling unity to target this object as ConsumableItem 
            
            if(consumableItem) DrawGeneralItem(); // Drawing all consumable fields
            
            var buttonStyle = new GUIStyle(GUI.skin.button);    // Style for our save changes button
            buttonStyle.normal.textColor = Color.red;
            buttonStyle.fontStyle = FontStyle.Bold;
            
            if (GUILayout.Button("Save changes", buttonStyle))
            {
                EditorUtility.SetDirty(consumableItem); // Marking this consumable item as dirty to ensure all changes are registered
                EditorSceneManager.MarkSceneDirty(consumableItem.gameObject.scene);   // Marking the scene as modified so it takes our changes
            }
        }

        public void DrawGeneralItem()
        {
            GUILayout.BeginVertical("HelpBox");
            GUILayout.Label("Basic Trinket Item Settings", EditorStyles.boldLabel);
            consumableItem.ItemName = EditorGUILayout.TextField("Consumable Name:", consumableItem.ItemName);   // Text field for consumable name
            consumableItem.ItemDescription = EditorGUILayout.TextField("Consumable Description:", consumableItem.ItemDescription);  // Text field for consumable description
            consumableItem.ItemIcon = (Sprite)EditorGUILayout.ObjectField("Consumable Icon:", consumableItem.ItemIcon, typeof(Sprite), false); // Object field of type sprite for consumable icon
            consumableItem.InventoryItemSprite = (Sprite)EditorGUILayout.ObjectField("Consumable Inventory Icon:", consumableItem.InventoryItemSprite, typeof(Sprite), false); // Object field of type sprite for consumable inventory image
            consumableItem.ItemID = EditorGUILayout.IntField("Consumable ID:", consumableItem.ItemID);  // Int field for consumable ID
            
            if (GUILayout.Button("Generate random consumable ID"))    // Generating random ID for consumable
            {
                consumableItem.ItemID = Random.Range(0, int.MaxValue);
            }
            
            GUILayout.Label("Inventory Consumable Settings:", EditorStyles.boldLabel);
            consumableItem.ItemSize = EditorGUILayout.Vector2IntField("Inventory Width:", consumableItem.ItemSize);    // Int field for inventory consumable width
            consumableItem.IsStackable = EditorGUILayout.Toggle("Stackable:", consumableItem.IsStackable);   // Toggle for consumable stackable

            if (consumableItem.IsStackable)
            {
                consumableItem.ItemMaxStackSize = EditorGUILayout.IntSlider("Max Stack Size:", consumableItem.ItemMaxStackSize, 1, 100); // Int field for consumable max stack size
            }
            
            GUILayout.EndVertical();

            GUILayout.Label("Detailed Consumable Item Settings", EditorStyles.boldLabel);
            GUILayout.BeginVertical("HelpBox");
            consumableItem.healingPower = EditorGUILayout.IntField("Consumable Healing Power:", consumableItem.healingPower);  // Int field for consumable healing power
            
            GUILayout.EndVertical();
        }
    }
}

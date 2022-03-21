using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;
using SIS.Items;

namespace SIS.Inventory.Editors
{
    [CustomEditor(typeof(Item))]
    public class ItemCustomInspector : Editor
    {
        private Item item;  //  Reference to Item we're displaying

        public override void OnInspectorGUI()
        {
            item = target as Item;  // Telling unity to target this object as Item 
            
            if(item) DrawGeneralItem(); // Drawing all item fields
            
            var style = new GUIStyle(GUI.skin.button);  // Style for our save changes button
            style.normal.textColor = Color.red;
            style.fontStyle = FontStyle.Bold;
            
            if (GUILayout.Button("Save changes?", style))   // Button for saving changes
            {
                EditorUtility.SetDirty(item); // Marking this item as dirty to ensure all changes are registered
                EditorSceneManager.MarkSceneDirty(item.gameObject.scene);   // Marking the scene as modified so it takes our changes
            }
        }

        public void DrawGeneralItem()
        {
            GUILayout.BeginVertical("HelpBox");
            GUILayout.Label("Basic Item Settings", EditorStyles.boldLabel);
            item.ItemName = EditorGUILayout.TextField("Item Name:", item.ItemName);   // Text field for item name
            item.ItemDescription = EditorGUILayout.TextField("Item Description:", item.ItemDescription);  // Text field for item description
            item.ItemIcon = (Sprite)EditorGUILayout.ObjectField("Item Icon:", item.ItemIcon, typeof(Sprite), false); // Object field of type sprite for item icon
            item.InventoryItemSprite = (Sprite)EditorGUILayout.ObjectField("Item Inventory Icon:", item.InventoryItemSprite, typeof(Sprite), false); // Object field of type sprite for item inventory image
            item.ItemID = EditorGUILayout.IntField("Item ID", item.ItemID);  // Int field for item id

            if (GUILayout.Button("Generate random ID?"))    
            {
                item.ItemID = Random.Range(0, int.MaxValue);
            }

            GUILayout.BeginVertical("GroupBox");
            GUILayout.Label("Inventory Item Settings", EditorStyles.boldLabel);
            item.ItemSize = EditorGUILayout.Vector2IntField("Inventory Width", item.ItemSize); // Int field for item inventory width
            GUILayout.EndVertical();
            
            item.IsStackable = EditorGUILayout.Toggle("Stackable", item.IsStackable); // Toggle for item stackable

            if (item.IsStackable)
            {
                item.ItemMaxStackSize = EditorGUILayout.IntSlider("Max Stack Size", item.ItemMaxStackSize, 1, 100); // Int field for item max stack size
            }
            
            GUILayout.EndVertical();
        }
    }
}

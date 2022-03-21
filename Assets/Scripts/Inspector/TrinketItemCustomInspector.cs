using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;
using SIS.Items;

namespace SIS.Inventory.Editors
{
    [CustomEditor(typeof(TrinketItem))]
    public class TrinketItemCustomInspector : Editor
    {
        private TrinketItem trinketItem;  // Reference to TrinketItem we're displaying

        public override void OnInspectorGUI()
        {
            trinketItem = target as TrinketItem;  // Telling unity to target this object as TrinketItem 
            
            if(trinketItem) DrawGeneralItem(); // Drawing all trinket fields
            
            var buttonStyle = new GUIStyle(GUI.skin.button);    // Style for our save changes button
            buttonStyle.normal.textColor = Color.red;
            buttonStyle.fontStyle = FontStyle.Bold;
            
            if (GUILayout.Button("Save changes", buttonStyle))
            {
                EditorUtility.SetDirty(trinketItem); // Marking this trinket item as dirty to ensure all changes are registered
                EditorSceneManager.MarkSceneDirty(trinketItem.gameObject.scene);   // Marking the scene as modified so it takes our changes
            }
        }

        public void DrawGeneralItem()
        {
            GUILayout.BeginVertical("HelpBox");
            GUILayout.Label("Basic Trinket Item Settings", EditorStyles.boldLabel);
            trinketItem.ItemName = EditorGUILayout.TextField("Trinket name:", trinketItem.ItemName);   // Text field for trinket name
            trinketItem.ItemDescription = EditorGUILayout.TextField("Trinket description:", trinketItem.ItemDescription);  // Text field for trinket description
            trinketItem.ItemIcon = (Sprite)EditorGUILayout.ObjectField("Trinket icon:", trinketItem.ItemIcon, typeof(Sprite), false); // Object field of type sprite for trinket icon
            trinketItem.InventoryItemSprite = (Sprite)EditorGUILayout.ObjectField("Inventory icon:", trinketItem.InventoryItemSprite, typeof(Sprite), false); // Object field of type sprite for trinket inventory image
            trinketItem.ItemID = EditorGUILayout.IntField("Trinket ID:", trinketItem.ItemID);  // Int field for trinket ID
            
            if (GUILayout.Button("Generate random trinket ID"))    // Generating random ID for trinket
            {
                trinketItem.ItemID = Random.Range(0, int.MaxValue);
            }
            
            GUILayout.Label("Inventory Trinket Settings", EditorStyles.boldLabel);
            trinketItem.ItemSize = EditorGUILayout.Vector2IntField("Inventory Width:", trinketItem.ItemSize);    // Int field for inventory trinket width
            trinketItem.IsStackable = EditorGUILayout.Toggle("Stackable", trinketItem.IsStackable);   // Toggle for trinket stackable

            if (trinketItem.IsStackable)
            {               
                trinketItem.ItemMaxStackSize = EditorGUILayout.IntSlider("Max stack size", trinketItem.ItemMaxStackSize, 1, 100); // Int field for trinket max stack size
            }
            
            GUILayout.EndVertical();

            GUILayout.Label("Detailed Trinket Item Settings", EditorStyles.boldLabel);
            GUILayout.BeginVertical("HelpBox");
            trinketItem.healthBuff = EditorGUILayout.IntField("Trinket health buff value:", trinketItem.healthBuff);  // Int field for trinket health buff value
            trinketItem.manaBuff = EditorGUILayout.IntField("Trinket mana buff value:", trinketItem.manaBuff);  // Int field for trinket mana buff value
            trinketItem.staminaBuff = EditorGUILayout.IntField("Trinket stamina buff value", trinketItem.staminaBuff);  // Int field for trinket stamina buff value
            
            GUILayout.EndVertical();
        }
    }
}

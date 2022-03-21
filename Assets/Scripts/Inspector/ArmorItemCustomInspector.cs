using SIS.Items;
using SIS.Items.Enums;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace SIS.Inventory.Editors
{
    [CustomEditor(typeof(ArmorItem))]
    public class ArmorItemCustomInspector : Editor
    {
        private ArmorItem armorItem;  // Reference to ArmorItem we're displaying

        public override void OnInspectorGUI()
        {
            armorItem = target as ArmorItem;  // Telling unity to target this object as ArmorItem 
            
            if(armorItem) DrawGeneralItem(); // Drawing all armor fields
            
            var buttonStyle = new GUIStyle(GUI.skin.button);    // Style for our save changes button
            buttonStyle.normal.textColor = Color.red;
            buttonStyle.fontStyle = FontStyle.Bold;
            
            if (GUILayout.Button("Save changes", buttonStyle))
            {
                EditorUtility.SetDirty(armorItem); // Marking this armor item as dirty to ensure all changes are registered
                EditorSceneManager.MarkSceneDirty(armorItem.gameObject.scene);   // Marking the scene as modified so it takes our changes
            }
        }

        public void DrawGeneralItem()
        {
            GUILayout.BeginVertical("HelpBox");
            GUILayout.Label("Basic Armor Item Settings", EditorStyles.boldLabel);
            armorItem.ItemName = EditorGUILayout.TextField("Armor name:", armorItem.ItemName);   // Text field for armor name
            armorItem.ItemDescription = EditorGUILayout.TextField("Armor description:", armorItem.ItemDescription);  // Text field for armor description
            armorItem.ItemIcon = (Sprite)EditorGUILayout.ObjectField("Armor icon:", armorItem.ItemIcon, typeof(Sprite), false); // Object field of type sprite for armor icon
            armorItem.InventoryItemSprite = (Sprite)EditorGUILayout.ObjectField("Inventory icon:", armorItem.InventoryItemSprite, typeof(Sprite), false); // Object field of type sprite for armor inventory image
            armorItem.ItemID = EditorGUILayout.IntField("Armor ID:", armorItem.ItemID);  // Int field for armor ID
            
            if (GUILayout.Button("Generate random armor ID"))    // Generating random ID for armor
            {
                armorItem.ItemID = Random.Range(0, int.MaxValue);
            }
            
            GUILayout.Label("Inventory Armor Settings", EditorStyles.boldLabel);
            armorItem.ItemSize = EditorGUILayout.Vector2IntField("Inventory Height:", armorItem.ItemSize); // Int field for inventory armor height
            armorItem.IsStackable = EditorGUILayout.Toggle("Stackable", armorItem.IsStackable);   // Toggle for armor stackable

            if (armorItem.IsStackable)
            {
                armorItem.ItemMaxStackSize = EditorGUILayout.IntSlider("Max stack size", armorItem.ItemMaxStackSize, 1, 100); // Int field for armor max stack size
            }
            
            GUILayout.EndVertical();

            GUILayout.Label("Detailed Armor Item Settings", EditorStyles.boldLabel);
            GUILayout.BeginVertical("HelpBox");
            armorItem.armorType = (ArmorTypes)EditorGUILayout.EnumPopup("Armor type:", armorItem.armorType);  // Enum popup field for armor type
            armorItem.armorValue = EditorGUILayout.IntField("Armor value:", armorItem.armorValue);  // Int field for armor damage
            armorItem.armorLevel = EditorGUILayout.IntField("Armor level:", armorItem.armorLevel);  // Int field for armor level
            GUILayout.EndVertical();
        }
    }
}

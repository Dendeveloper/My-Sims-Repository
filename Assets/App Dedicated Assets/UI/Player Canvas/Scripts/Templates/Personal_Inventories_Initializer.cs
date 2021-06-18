using UnityEngine;

namespace Assets.App_Dedicated_Assets.UI.Player_Canvas.Scripts.Templates
{
    using Inventories.Personal_Inventories.Scripts.Templates;

    public class Personal_Inventories_Initializer : MonoBehaviour
    {
        public Personal_Inventory_Manager[] Personal_Inventory_Managers_Ref;

        private void Awake()
        {
            for (int Manager_Index = 0; 
                Manager_Index < Personal_Inventory_Managers_Ref.Length;
                Manager_Index++)
            {
                Personal_Inventory_Manager Personal_Inventory_Manager_Ref =
                    Personal_Inventory_Managers_Ref[Manager_Index];
                Personal_Inventory_Manager_Ref.Initialize();
            }
        }
    }
}
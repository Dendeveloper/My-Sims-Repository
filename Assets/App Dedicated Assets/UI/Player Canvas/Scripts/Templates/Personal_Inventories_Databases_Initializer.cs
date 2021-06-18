using UnityEngine;

namespace Assets.App_Dedicated_Assets.UI.Player_Canvas.Scripts.Templates
{
    using Databases.Templates;

    public class Personal_Inventories_Databases_Initializer : MonoBehaviour
    {
        public Personal_Inventory_Database[] Personal_Inventory_Databases_Array_Ref;

        private void Awake()
        {
            for (int Database_Index = 0; 
                Database_Index < Personal_Inventory_Databases_Array_Ref.Length;
                Database_Index++)
            {
                Personal_Inventory_Databases_Array_Ref[Database_Index].Initialize();
            }

            Destroy(this);
        }
    }
}

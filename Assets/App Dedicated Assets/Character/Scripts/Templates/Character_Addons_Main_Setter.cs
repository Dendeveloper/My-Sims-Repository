using UnityEngine;

namespace Assets.App_Dedicated_Assets.Character.Scripts.Templates
{
    public class Character_Addons_Main_Setter : MonoBehaviour
    {
        public bool Dummy_Character_Flag;
        public Character_Part_Addons_Setter[] Character_Parts_Addons_Setters_Ref;

        public static Character_Addons_Main_Setter Non_Dummy_Character_Instance_Reference { get; private set; }
        public static Character_Addons_Main_Setter Dummy_Character_Instance_Reference { get; private set; }

        private void Awake()
        {
            if (!Dummy_Character_Flag)
                Non_Dummy_Character_Instance_Reference = this;
            else
                Dummy_Character_Instance_Reference = this;
        }

        public void Set_Addon(Object Addon_Prefab_Reference)
        {
            GameObject Addon_Reference = Instantiate(Addon_Prefab_Reference) as GameObject;

            for (int Sub_Setter_Index = 0; 
                Sub_Setter_Index < Character_Parts_Addons_Setters_Ref.Length; 
                Sub_Setter_Index++)
            {
                Character_Parts_Addons_Setters_Ref[Sub_Setter_Index].Set_Addon(Addon_Reference);
            }

            Destroy(Addon_Reference);
        }
    }
}

using UnityEngine.EventSystems;
using UnityEngine;

namespace Assets.App_Dedicated_Assets.UI.Inventories.Personal_Inventories
{
    namespace Items.Scripts.Templates
    {
        using Personal_Inventories.Scripts.Templates;
        using Character.Scripts.Templates;

        public class Item_Script : MonoBehaviour, IPointerClickHandler
        {
            public Object Attached_Prefab_Reference;

            public void OnPointerClick(PointerEventData Event_Data_Reference)
            {
                Transform Items_Container_Reference = transform.parent;
                Transform Personal_Inventory_Reference = Items_Container_Reference.parent;

                Personal_Inventory_Manager Personal_Inventory_Manager_Reference =
                    Personal_Inventory_Reference.GetComponent<Personal_Inventory_Manager>();
                GameObject Selected_Item_Reference = Personal_Inventory_Manager_Reference.Selected_Item_Reference;
                Transform Selected_Item_Trform_Ref = Selected_Item_Reference.transform;

                Transform Selected_Item_Marker_Ref = Selected_Item_Trform_Ref.GetChild(1);
                Selected_Item_Marker_Ref.SetParent(transform, false);

                Character_Addons_Main_Setter Character_Addons_Main_Setter_Ref =
                    Character_Addons_Main_Setter.Non_Dummy_Character_Instance_Reference;
                Character_Addons_Main_Setter_Ref.Set_Addon(Attached_Prefab_Reference);

                Character_Addons_Main_Setter Dummy_Character_Addons_Main_Setter_Ref =
                    Character_Addons_Main_Setter.Dummy_Character_Instance_Reference;
                Dummy_Character_Addons_Main_Setter_Ref.Set_Addon(Attached_Prefab_Reference);

                Personal_Inventory_Manager_Reference.Selected_Item_Reference = gameObject;
            }
        }
    }
}

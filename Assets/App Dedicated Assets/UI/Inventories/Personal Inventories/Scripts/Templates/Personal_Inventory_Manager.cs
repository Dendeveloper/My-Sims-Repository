using UnityEngine.UI;
using UnityEngine;

namespace Assets.App_Dedicated_Assets.UI.Inventories.Personal_Inventories
{
    namespace Scripts.Templates
    {
        using Databases.Templates;
        using Items.Scripts.Templates;

        public class Personal_Inventory_Manager : MonoBehaviour
        {
            public GameObject Selected_Item_Reference;
            public Personal_Inventory_Database Personal_Inventory_Database_Reference;

            public void Initialize()
            {
                Personal_Inventory_Database_Reference.Set_On_Item_Added_Event_Method
                    (On_Database_Item_Added_Event_Method);
                Initialize_First_Item();
            }

            private void On_Database_Item_Added_Event_Method(object[] Item_Objects_Array_Reference)
            {
                Create_Item(Item_Objects_Array_Reference);
            }

            private void Initialize_First_Item()
            {
                Transform Items_Container_Reference = transform.GetChild(0);
                Transform First_Item_Reference = Items_Container_Reference.GetChild(0);

                Transform First_Item_Icon_Holder_Reference = First_Item_Reference.GetChild(0);
                Image Icon_Image_Component_Ref = First_Item_Icon_Holder_Reference.GetComponent<Image>();
                Icon_Image_Component_Ref.sprite = Personal_Inventory_Database_Reference.Selected_Item_Sprite_Ref;
                Icon_Image_Component_Ref.preserveAspect = true;

                Item_Script First_Item_Script_Reference = First_Item_Reference.GetComponent<Item_Script>();
                First_Item_Script_Reference.Attached_Prefab_Reference = Personal_Inventory_Database_Reference.
                    Selected_Item_Attached_Prefab_Ref;
            }

            private void Create_Item(object[] Item_Objects_Array_Reference)
            {
                Transform Items_Container_Reference = transform.GetChild(0);
                Transform First_Item_Reference = Items_Container_Reference.GetChild(0);

                Transform New_Item_Reference = Instantiate(First_Item_Reference.gameObject, 
                    Items_Container_Reference).transform;

                Transform New_Item_Icon_Holder_Reference = New_Item_Reference.GetChild(0);
                Image Icon_Image_Component_Ref = New_Item_Icon_Holder_Reference.GetComponent<Image>();
                Icon_Image_Component_Ref.sprite = (Sprite)Item_Objects_Array_Reference[1];
                Icon_Image_Component_Ref.preserveAspect = true;

                Item_Script New_Item_Script_Reference = New_Item_Reference.GetComponent<Item_Script>();
                New_Item_Script_Reference.Attached_Prefab_Reference = (Object)Item_Objects_Array_Reference[2];

                if (New_Item_Reference.childCount == 1)
                    return;

                Transform Unnecessary_Marker_Reference = New_Item_Reference.GetChild(1);
                Destroy(Unnecessary_Marker_Reference.gameObject);
            }
        }
    }
}

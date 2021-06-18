using UnityEngine;

namespace Assets.App_Dedicated_Assets.Databases.Templates
{
    using App_Dedicated_Assets.Templates;

    [CreateAssetMenu(fileName = "Personal Inventory Database", 
        menuName = "Personal Inventory Database", order = 2)]
    public class Personal_Inventory_Database : ScriptableObject
    {
        public string Items_Tag_Reference;
        public Sprite Selected_Item_Sprite_Ref;
        public Object Selected_Item_Attached_Prefab_Ref;

        private static Delegate_Method_w_Object_Parameters On_Item_Received_Event_Method_Ref;
        private Delegate_Method_w_Object_Parameters On_Item_Added_Event_Method_Ref;


        public static void Receive_Item(object[] Item_Objects_Array_Reference)
        {
            On_Item_Received_Event_Method_Ref?.Invoke(Item_Objects_Array_Reference);
        }

        public void Set_On_Item_Added_Event_Method
            (Delegate_Method_w_Object_Parameters On_Item_Added_Event_Method_Ref)
        {
            this.On_Item_Added_Event_Method_Ref += On_Item_Added_Event_Method_Ref;
        }

        public void Initialize()
        {
            On_Item_Received_Event_Method_Ref += On_Item_Received_Event_Method;
        }

        private void On_Item_Received_Event_Method(object[] Item_Objects_Array_Reference)
        {
            string Item_Tag_Reference = Item_Objects_Array_Reference[0].ToString();
            if (Item_Tag_Reference != Items_Tag_Reference)
                return;

            // Assume it is added.
            On_Item_Added_Event_Method_Ref?.Invoke(Item_Objects_Array_Reference);
        }
    }
}

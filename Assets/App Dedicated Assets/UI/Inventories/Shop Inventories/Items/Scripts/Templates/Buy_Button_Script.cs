using UnityEngine;

namespace Assets.App_Dedicated_Assets.UI.Inventories.Shop_Inventories
{
    using Databases.Templates;
    using Player.Scripts.Templates;
    using Player_Canvas.Error_Message_Holder.Scripts.Templates;

    namespace Items.Scripts.Templates
    {
        public class Buy_Button_Script : MonoBehaviour
        {
            public void On_Click_Event_Method()
            {
                Transform Item_Reference = transform.parent;
                Item_Properties_Holder Item_Properties_Holder_Ref = Item_Reference.GetComponent<Item_Properties_Holder>();
                double Item_Price = Item_Properties_Holder_Ref.Price;

                Player_Money_Manager Player_Money_Manager_Ref = Player_Money_Manager.Instance_Manager_Reference;
                bool Operation_Result = Player_Money_Manager_Ref.Try_Reduce_Money(Item_Price);

                if (!Operation_Result)
                {
                    Error_Message_Holder_Script Error_Message_Holder_Script_Ref =
                        Error_Message_Holder_Script.Instance_Reference;
                    Error_Message_Holder_Script_Ref.Show_Error_Message("Insufficient funds.");
                    return;
                }

                Destroy(Item_Reference.gameObject);

                object[] Item_Objects_Array_Reference = new object[] 
                {
                    Item_Reference.tag,
                    Item_Properties_Holder_Ref.Icon_Reference,
                    Item_Properties_Holder_Ref.Attached_Prefab_Reference
                };

                Personal_Inventory_Database.Receive_Item(Item_Objects_Array_Reference);
            }
        }
    }
}
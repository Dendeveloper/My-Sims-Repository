using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Assets.App_Dedicated_Assets.UI.Inventories.Shop_Inventories.Templates
{
    using Databases.Templates;
    using Items.Scripts.Templates;

    public class Shop_Inventory_Manager : MonoBehaviour
    {
        public Shop_Inventory_Database Shop_Inventory_Database_Ref;

        private void Awake()
        {
            Create_Items();
            Destroy(this);
        }

        private void Create_Items()
        {
            double[] Items_Prices_Array_Ref = Shop_Inventory_Database_Ref.Items_Prices_Array_Ref;
            Sprite[] Items_Icons_Array_Ref = Shop_Inventory_Database_Ref.Items_Icons_Array_Ref;
            Object[] Items_Attached_Prefabs_Array_Ref = Shop_Inventory_Database_Ref.Items_Attached_Prefabs_Array_Ref;

            Transform Items_Container_Reference = transform.GetChild(0);
            Transform Template_Item_Reference = Items_Container_Reference.GetChild(0);

            for (int Item_Index = 0;
                Item_Index < Items_Prices_Array_Ref.Length;
                Item_Index++)
            {
                GameObject Item_Reference = Instantiate(Template_Item_Reference.gameObject,Items_Container_Reference);
                Transform Item_Transform_Reference = Item_Reference.transform;

                int Item_Icon_Index = 0;
                Transform Item_Icon_Holder_Reference = Item_Transform_Reference.GetChild(Item_Icon_Index);
                Image Item_Image_Component_Ref = Item_Icon_Holder_Reference.GetComponent<Image>();
                Item_Image_Component_Ref.sprite = Items_Icons_Array_Ref[Item_Index];
                Item_Image_Component_Ref.preserveAspect = true;

                int Item_Price_Holder_Index = 1;
                Transform Item_Price_Holder_Reference = Item_Transform_Reference.GetChild(Item_Price_Holder_Index);
                TextMeshProUGUI Item_Price_Component_Ref = Item_Price_Holder_Reference.GetComponent<TextMeshProUGUI>();
                Item_Price_Component_Ref.text = "$" + string.Format("{0:N2}", Items_Prices_Array_Ref[Item_Index]);

                Item_Properties_Holder Item_Properties_Holder_Ref = Item_Reference.GetComponent<Item_Properties_Holder>();
                Item_Properties_Holder_Ref.Price = Items_Prices_Array_Ref[Item_Index];
                Item_Properties_Holder_Ref.Icon_Reference = Items_Icons_Array_Ref[Item_Index];
                Item_Properties_Holder_Ref.Attached_Prefab_Reference = Items_Attached_Prefabs_Array_Ref[Item_Index];
            }

            Destroy(Template_Item_Reference.gameObject);
        }
    }
}

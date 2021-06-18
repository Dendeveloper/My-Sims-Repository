using UnityEngine;

namespace Assets.App_Dedicated_Assets.Databases.Templates
{
    [CreateAssetMenu(fileName = "Shop Inventory Database", menuName = "Shop Inventory Database", order = 1)]
    public class Shop_Inventory_Database : ScriptableObject
    {
        public double[] Items_Prices_Array_Ref;
        public Sprite[] Items_Icons_Array_Ref;
        public Object[] Items_Attached_Prefabs_Array_Ref;
    }
}

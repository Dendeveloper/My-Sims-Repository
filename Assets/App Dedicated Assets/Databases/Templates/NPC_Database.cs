using UnityEngine;

namespace Assets.App_Dedicated_Assets.Databases.Templates
{
    [CreateAssetMenu(fileName = "NPC Database", menuName = "NPC Database", order = 3)]
    public class NPC_Database : ScriptableObject
    {
        public string NPC_Name_Reference;
        public string[] Dialogues_Array_Reference;
    }
}
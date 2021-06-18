using UnityEngine;
using TMPro;

namespace Assets.App_Dedicated_Assets.NPC_Dialogue_Canvas.Scripts.Templates
{
    using Databases.Templates;

    public class NPC_Dialogue_Canvas_Initializer : MonoBehaviour
    {
        public NPC_Database NPC_Database_Reference;
        public TextMeshProUGUI Name_Component_Reference;
        public TextMeshProUGUI Dialogue_Component_Reference;

        private void OnEnable()
        {
            Name_Component_Reference.text = NPC_Database_Reference.NPC_Name_Reference;
            string[] Dialogues_Array_Reference = NPC_Database_Reference.Dialogues_Array_Reference;

            int Random_Dialogue_Index = Random.Range(0, Dialogues_Array_Reference.Length);
            Dialogue_Component_Reference.text = Dialogues_Array_Reference[Random_Dialogue_Index];
        }
    }
}
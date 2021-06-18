using TMPro;
using UnityEngine;

namespace Assets.App_Dedicated_Assets.UI.Player_Canvas
{
    namespace Error_Message_Holder.Scripts.Templates
    {
        public class Error_Message_Holder_Script : MonoBehaviour
        {
            public static Error_Message_Holder_Script Instance_Reference { get; private set; }

            private void Awake()
            {
                Instance_Reference = this;
                gameObject.SetActive(false);
            }

            public void Show_Error_Message(string Error_Message_Reference)
            {
                gameObject.SetActive(true);

                TextMeshProUGUI Text_Component_Reference = GetComponent<TextMeshProUGUI>();
                Text_Component_Reference.text = Error_Message_Reference;

                Animator Animator_Component_Reference = GetComponent<Animator>();
                Animator_Component_Reference.Play(0, 0, 0);
            }

            public void On_Animator_End_Event_Method()
            {
                gameObject.SetActive(false);
            }
        }
    }
}
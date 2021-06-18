using UnityEngine;
using UnityEngine.Events;

namespace Assets.App_Dedicated_Assets.Scripts.Templates
{
    public class On_Trigger_Enter_Exit_Event_Handler : MonoBehaviour
    {
        public UnityEvent On_Trigger_Enter_Event_Method_Ref;
        public UnityEvent On_Trigger_Exit_Event_Method_Ref;

        private void OnTriggerEnter2D(Collider2D Component_Reference)
        {
            On_Trigger_Enter_Event_Method_Ref?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D Component_Reference)
        {
            On_Trigger_Exit_Event_Method_Ref?.Invoke();
        }
    }
}

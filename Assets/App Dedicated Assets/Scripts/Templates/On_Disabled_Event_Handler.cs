using UnityEngine.Events;
using UnityEngine;

namespace Assets.App_Dedicated_Assets.Scripts.Templates
{
    public class On_Disabled_Event_Handler : MonoBehaviour
    {
        public UnityEvent Event_Methods_Reference;

        private void OnDisable()
        {
            Event_Methods_Reference?.Invoke();
        }
    }
}

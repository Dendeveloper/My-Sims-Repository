using UnityEngine.Events;
using UnityEngine;

namespace Assets.App_Dedicated_Assets.Scripts.Templates
{
    public class On_Enabled_Event_Handler : MonoBehaviour
    {
        public UnityEvent Event_Methods_Reference;

        private void OnEnable()
        {
            Event_Methods_Reference?.Invoke();
        }
    }
}

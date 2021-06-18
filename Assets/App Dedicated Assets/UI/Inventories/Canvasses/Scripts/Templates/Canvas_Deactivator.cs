using UnityEngine.EventSystems;
using UnityEngine;

namespace Assets.App_Dedicated_Assets.UI.Inventories.Canvasses
{
    namespace Scripts.Templates
    {
        public class Canvas_Deactivator : MonoBehaviour, IPointerClickHandler
        {
            public void OnPointerClick(PointerEventData Pointer_Event_Data_Reference)
            {
                gameObject.SetActive(false);
            }
        }
    }
}

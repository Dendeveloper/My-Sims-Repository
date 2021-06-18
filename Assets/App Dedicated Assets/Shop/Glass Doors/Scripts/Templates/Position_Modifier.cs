using System.Collections;
using UnityEngine;

namespace Assets.App_Dedicated_Assets.Shop.Glass_Doors.Scripts.Templates
{
    public class Position_Modifier : MonoBehaviour
    {
        public float Movement_Speed_Seconds;
        public Transform[] Pointers_Array_Reference;
        private Coroutine Coroutine_Method_Reference;
        private bool Detected_Flag;

        public void On_Triggerrer_Detected_Event_Method()
        {
            Detected_Flag = true;
            if (Coroutine_Method_Reference == null)
                Coroutine_Method_Reference = StartCoroutine(Coroutine_Method());
        }

        public void On_Triggerrer_Detection_Lost_Event_Method()
        {
            Detected_Flag = false;
            if (Coroutine_Method_Reference == null)
                Coroutine_Method_Reference = StartCoroutine(Coroutine_Method());
        }

        private IEnumerator Coroutine_Method()
        {
            while (true)
            {
                yield return null;

                Transform Pointer_Reference = Detected_Flag ?
                    Pointers_Array_Reference[1] : Pointers_Array_Reference[0];

                transform.position = Vector2.MoveTowards(transform.position, 
                    Pointer_Reference.position, Movement_Speed_Seconds * Time.deltaTime);

                if (transform.position == Pointer_Reference.position)
                    break;
            }

            Coroutine_Method_Reference = null;
        }
    }
}

using UnityEngine;

namespace Assets.App_Dedicated_Assets.Camera.Scripts.Templates
{
    public class Follow_Target_Script : MonoBehaviour
    {
        public Transform Target_Transform_Reference;
        public Vector2 Target_Position_Addend;
        public float Lerp_Multiplier;

        private void LateUpdate()
        {
            Vector2 Target_Position = Target_Transform_Reference.position;
            Target_Position.x += Target_Position_Addend.x;
            Target_Position.y += Target_Position_Addend.y;

            Vector3 New_Position = Vector2.Lerp(transform.position, Target_Position, 
                Lerp_Multiplier * Time.deltaTime);
            New_Position.z = transform.position.z;

            transform.position = New_Position;
        }
    }
}

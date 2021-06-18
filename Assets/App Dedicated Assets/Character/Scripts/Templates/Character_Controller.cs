using UnityEngine;

namespace Assets.App_Dedicated_Assets.Character.Scripts.Templates
{
    public class Character_Controller : MonoBehaviour
    {
        public float Movement_Speed_Seconds;
        public Rigidbody2D Rigidbody_2D_Reference;
        private Animator Current_Animator_Reference;
        private KeyCode Current_Keycode;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Transform Front_Part_Transform_Reference = transform.GetChild(0);
                Transform Back_Part_Transform_Reference = transform.GetChild(1);
                Transform Side_Part_Transform_Reference = transform.GetChild(2);

                Front_Part_Transform_Reference.gameObject.SetActive(false);
                Back_Part_Transform_Reference.gameObject.SetActive(true);
                Side_Part_Transform_Reference.gameObject.SetActive(false);

                Current_Animator_Reference = Back_Part_Transform_Reference.GetComponent<Animator>();
                Current_Animator_Reference.SetBool("Walk Flag", true);

                Rigidbody_2D_Reference.velocity = Vector2.up * Movement_Speed_Seconds;
                Current_Keycode = KeyCode.W;
                return;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Transform Front_Part_Transform_Reference = transform.GetChild(0);
                Transform Back_Part_Transform_Reference = transform.GetChild(1);
                Transform Side_Part_Transform_Reference = transform.GetChild(2);

                Front_Part_Transform_Reference.gameObject.SetActive(true);
                Back_Part_Transform_Reference.gameObject.SetActive(false);
                Side_Part_Transform_Reference.gameObject.SetActive(false);

                Current_Animator_Reference = Front_Part_Transform_Reference.GetComponent<Animator>();
                Current_Animator_Reference.SetBool("Walk Flag", true);

                Rigidbody_2D_Reference.velocity = Vector2.down * Movement_Speed_Seconds;
                Current_Keycode = KeyCode.S;
                return;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Transform Front_Part_Transform_Reference = transform.GetChild(0);
                Transform Back_Part_Transform_Reference = transform.GetChild(1);
                Transform Side_Part_Transform_Reference = transform.GetChild(2);

                Front_Part_Transform_Reference.gameObject.SetActive(false);
                Back_Part_Transform_Reference.gameObject.SetActive(false);
                Side_Part_Transform_Reference.gameObject.SetActive(true);

                Current_Animator_Reference = Side_Part_Transform_Reference.GetComponent<Animator>();
                Current_Animator_Reference.SetBool("Walk Flag", true);

                transform.localScale = new Vector3(1, 1, 1);
                Rigidbody_2D_Reference.velocity = Vector2.left * Movement_Speed_Seconds;
                Current_Keycode = KeyCode.A;
                return;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Transform Front_Part_Transform_Reference = transform.GetChild(0);
                Transform Back_Part_Transform_Reference = transform.GetChild(1);
                Transform Side_Part_Transform_Reference = transform.GetChild(2);

                Front_Part_Transform_Reference.gameObject.SetActive(false);
                Back_Part_Transform_Reference.gameObject.SetActive(false);
                Side_Part_Transform_Reference.gameObject.SetActive(true);

                Current_Animator_Reference = Side_Part_Transform_Reference.GetComponent<Animator>();
                Current_Animator_Reference.SetBool("Walk Flag", true);

                transform.localScale = new Vector3(-1, 1, 1);
                Rigidbody_2D_Reference.velocity = Vector2.right * Movement_Speed_Seconds;
                Current_Keycode = KeyCode.D;
                return;
            }

            if (!Input.GetKeyUp(Current_Keycode))
                return;

            Current_Animator_Reference.SetBool("Walk Flag", false);
            Rigidbody_2D_Reference.velocity = Vector2.zero;
        }

        public void Temporary_Stop_Character()
        {
            if (Current_Animator_Reference != null)
                Current_Animator_Reference.SetBool("Walk Flag", false);

            Rigidbody_2D_Reference.velocity = Vector2.zero;
            enabled = false;
        }

        public void Resume_Controller()
        {
            enabled = true;
        }
    }
}

using UnityEngine;

namespace Assets.App_Dedicated_Assets.Character.Scripts.Templates
{
    public class Character_Properties_Holder : MonoBehaviour
    {
        public Transform Torso_Bone_Reference;
        public Transform[] Arms_Bones_Array_Reference;
        public Transform[] Legs_Bones_Array_Reference;

        public GameObject[] Torso_Addons_Array_Reference;
        public GameObject[] Legs_Addons_Array_Reference;
        public GameObject[] Foot_Addons_Array_Reference;
    }
}

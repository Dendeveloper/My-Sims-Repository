using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Assets.App_Dedicated_Assets.Character.Scripts.Templates
{
    using App_Dedicated_Assets.Templates;

    public class Character_Part_Addons_Setter : MonoBehaviour
    {
        public void Set_Addon(GameObject Addon_Reference)
        {
            Character_Properties_Holder Character_Properties_Holder_Reference = 
                GetComponent<Character_Properties_Holder>();

            switch (Addon_Reference.tag)
            {
                case Tags_Container.Torso_Item_Tag_Reference:

                    GameObject[] Torso_Addons_Array_Reference =
                        Character_Properties_Holder_Reference.Torso_Addons_Array_Reference;
                    Remove_Addons(Torso_Addons_Array_Reference);

                    Set_Torso_Addon(Addon_Reference);
                    break;

                case Tags_Container.Legs_Item_Tag_Reference:

                    GameObject[] Legs_Addons_Array_Reference =
                        Character_Properties_Holder_Reference.Legs_Addons_Array_Reference;
                    Remove_Addons(Legs_Addons_Array_Reference);

                    Set_Legs_Addon(Addon_Reference);
                    break;

                case Tags_Container.Foot_Item_Tag_Reference:

                    GameObject[] Foot_Addons_Array_Reference =
                        Character_Properties_Holder_Reference.Foot_Addons_Array_Reference;
                    Remove_Addons(Foot_Addons_Array_Reference);

                    Set_Foot_Addon(Addon_Reference);
                    break;
            }
        }

        private void Remove_Addons(GameObject[] Addons_Array_Reference)
        {
            for (int Addon_Index = 0; 
                Addon_Index < Addons_Array_Reference.Length; 
                Addon_Index++)
            {
                GameObject Addon_Reference = Addons_Array_Reference[Addon_Index];

                if (Addon_Reference != null)
                {
                    SpriteSkin Addon_Component_Reference = Addon_Reference.GetComponent<SpriteSkin>();

                    if (Addon_Component_Reference != null)
                    {
                        Transform[] Bones_Array_Reference = Addon_Component_Reference.boneTransforms;

                        for (int Bone_Index = 0; Bone_Index < Bones_Array_Reference.Length; Bone_Index++)
                        {
                            Transform Bone_Reference = Bones_Array_Reference[Bone_Index];
                            Destroy(Bone_Reference.gameObject);
                        }
                    }

                    Destroy(Addon_Reference);
                }
            }
        }

        private void Set_Torso_Addon(GameObject Addon_Reference)
        {
            // Hardly typed, running out of time...

            Character_Properties_Holder Character_Properties_Holder_Ref =
                GetComponent<Character_Properties_Holder>();

            Transform Addon_Part_Reference = Addon_Reference.transform.GetChild
                (transform.GetSiblingIndex());


            Transform Torso_Addon_Reference = Addon_Part_Reference.GetChild(0);
            Torso_Addon_Reference.SetParent(Character_Properties_Holder_Ref.Torso_Bone_Reference, false);
            Character_Properties_Holder_Ref.Torso_Addons_Array_Reference[0] = Torso_Addon_Reference.gameObject;

            Torso_Addon_Reference.localPosition = Vector3.zero;
            Torso_Addon_Reference.localEulerAngles = Vector3.zero;


            Torso_Addon_Reference = Addon_Part_Reference.GetChild(0);
            SpriteSkin Addon_Component_Reference = Torso_Addon_Reference.GetComponent<SpriteSkin>();

            Transform[] Torso_Addon_Bones_Array_Reference = Addon_Component_Reference.boneTransforms;
            Torso_Addon_Bones_Array_Reference[0].SetParent(Character_Properties_Holder_Ref.Arms_Bones_Array_Reference[0], false);
            Torso_Addon_Bones_Array_Reference[1].SetParent(Character_Properties_Holder_Ref.Arms_Bones_Array_Reference[1], false);

            Torso_Addon_Bones_Array_Reference[0].localPosition = Vector3.zero;
            Torso_Addon_Bones_Array_Reference[0].localEulerAngles = Vector3.zero;
            Torso_Addon_Bones_Array_Reference[1].localPosition = Vector3.zero;
            Torso_Addon_Bones_Array_Reference[1].localEulerAngles = Vector3.zero;

            Character_Properties_Holder_Ref.Torso_Addons_Array_Reference[1] = Torso_Addon_Reference.gameObject;
            Torso_Addon_Reference.SetParent(transform, false);


            Torso_Addon_Reference = Addon_Part_Reference.GetChild(0);
            Addon_Component_Reference = Torso_Addon_Reference.GetComponent<SpriteSkin>();

            Torso_Addon_Bones_Array_Reference = Addon_Component_Reference.boneTransforms;
            Torso_Addon_Bones_Array_Reference[0].SetParent(Character_Properties_Holder_Ref.Arms_Bones_Array_Reference[2], false);
            Torso_Addon_Bones_Array_Reference[1].SetParent(Character_Properties_Holder_Ref.Arms_Bones_Array_Reference[3], false);

            Torso_Addon_Bones_Array_Reference[0].localPosition = Vector3.zero;
            Torso_Addon_Bones_Array_Reference[0].localEulerAngles = Vector3.zero;
            Torso_Addon_Bones_Array_Reference[1].localPosition = Vector3.zero;
            Torso_Addon_Bones_Array_Reference[1].localEulerAngles = Vector3.zero;

            Character_Properties_Holder_Ref.Torso_Addons_Array_Reference[2] = Torso_Addon_Reference.gameObject;
            Torso_Addon_Reference.SetParent(transform, false);
        }

        private void Set_Legs_Addon(GameObject Addon_Reference)
        {
            Character_Properties_Holder Character_Properties_Holder_Ref =
                GetComponent<Character_Properties_Holder>();

            bool Side_Part_Flag = transform.GetSiblingIndex() == 2;

            if (!Side_Part_Flag)
            {
                Transform Legs_Addon_Reference = Addon_Reference.transform.GetChild(0);
                Character_Properties_Holder_Ref.Legs_Addons_Array_Reference[0] = Legs_Addon_Reference.gameObject;
                Legs_Addon_Reference.SetParent(transform, false);

                SpriteSkin Legs_Addon_Component_Ref = Legs_Addon_Reference.GetComponent<SpriteSkin>();
                Transform[] Legs_Addon_Bones_Array_Ref = Legs_Addon_Component_Ref.boneTransforms;

                for (int Bone_Index = 0; Bone_Index < Legs_Addon_Bones_Array_Ref.Length; Bone_Index++)
                {
                    Transform Bone_Transform_Reference = Legs_Addon_Bones_Array_Ref[Bone_Index];
                    Bone_Transform_Reference.SetParent(Character_Properties_Holder_Ref.Legs_Bones_Array_Reference[Bone_Index], false);
                    Bone_Transform_Reference.localPosition = Vector3.zero;
                    Bone_Transform_Reference.localEulerAngles = Vector3.zero;
                }
            }
            else
            {
                Transform Addon_Part_Transform_Reference = Addon_Reference.transform.GetChild(0);

                Transform Legs_Addon_Reference = Addon_Part_Transform_Reference.GetChild(0);
                SpriteSkin Addon_Component_Reference = Legs_Addon_Reference.GetComponent<SpriteSkin>();
                Transform[] Addon_Bones_Array_Reference = Addon_Component_Reference.boneTransforms;

                Addon_Bones_Array_Reference[0].SetParent(Character_Properties_Holder_Ref.Legs_Bones_Array_Reference[0], false);
                Addon_Bones_Array_Reference[1].SetParent(Character_Properties_Holder_Ref.Legs_Bones_Array_Reference[1], false);

                Addon_Bones_Array_Reference[0].localPosition = Vector3.zero;
                Addon_Bones_Array_Reference[0].localEulerAngles = Vector3.zero;
                Addon_Bones_Array_Reference[1].localPosition = Vector3.zero;
                Addon_Bones_Array_Reference[1].localEulerAngles = Vector3.zero;

                Character_Properties_Holder_Ref.Legs_Addons_Array_Reference[0] = Legs_Addon_Reference.gameObject;
                Legs_Addon_Reference.SetParent(transform, false);


                Legs_Addon_Reference = Addon_Part_Transform_Reference.GetChild(0);
                Addon_Component_Reference = Legs_Addon_Reference.GetComponent<SpriteSkin>();
                Addon_Bones_Array_Reference = Addon_Component_Reference.boneTransforms;

                Addon_Bones_Array_Reference[0].SetParent(Character_Properties_Holder_Ref.Legs_Bones_Array_Reference[2], false);
                Addon_Bones_Array_Reference[1].SetParent(Character_Properties_Holder_Ref.Legs_Bones_Array_Reference[3], false);

                Addon_Bones_Array_Reference[0].localPosition = Vector3.zero;
                Addon_Bones_Array_Reference[0].localEulerAngles = Vector3.zero;
                Addon_Bones_Array_Reference[1].localPosition = Vector3.zero;
                Addon_Bones_Array_Reference[1].localEulerAngles = Vector3.zero;

                Character_Properties_Holder_Ref.Legs_Addons_Array_Reference[1] = Legs_Addon_Reference.gameObject;
                Legs_Addon_Reference.SetParent(transform, false);
            }
        }

        private void Set_Foot_Addon(GameObject Addon_Reference)
        {
            Character_Properties_Holder Character_Properties_Holder_Ref =
                GetComponent<Character_Properties_Holder>();

            Transform Addon_Part_Reference = Addon_Reference.transform.GetChild
                (transform.GetSiblingIndex());

            Transform Foot_Addon_Reference = Addon_Part_Reference.GetChild(0);
            Character_Properties_Holder_Ref.Foot_Addons_Array_Reference[0] = Foot_Addon_Reference.gameObject;
            Foot_Addon_Reference.SetParent(Character_Properties_Holder_Ref.Legs_Bones_Array_Reference[1], false);
            Foot_Addon_Reference.localPosition = Vector3.zero;
            Foot_Addon_Reference.localEulerAngles = new Vector3(0, 0, 90);

            Foot_Addon_Reference = Addon_Part_Reference.GetChild(0);
            Character_Properties_Holder_Ref.Foot_Addons_Array_Reference[1] = Foot_Addon_Reference.gameObject;
            Foot_Addon_Reference.SetParent(Character_Properties_Holder_Ref.Legs_Bones_Array_Reference[3], false);
            Foot_Addon_Reference.localPosition = Vector3.zero;
            Foot_Addon_Reference.localEulerAngles = new Vector3(0, 0, 90);
        }
    }
}

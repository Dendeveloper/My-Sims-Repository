using System;
using UnityEngine;
using TMPro;

namespace Assets.App_Dedicated_Assets.Player.Scripts.Templates
{
    using Databases.Templates;

    public class Player_Money_Manager : MonoBehaviour
    {
        public static Player_Money_Manager Instance_Manager_Reference { get; private set; }
        public Money_Database Money_Database_Reference;
        public TextMeshProUGUI Money_Component_Reference;

        private void Awake()
        {
            if (Instance_Manager_Reference != null)
            {
                Destroy(this);
                return;
            }

            Instance_Manager_Reference = this;
            Display_Money();
        }

        public bool Try_Reduce_Money(double Subtrahend)
        {
            double Player_Money = Money_Database_Reference.Money;
            if (Subtrahend > Player_Money)
                return false;

            Money_Database_Reference.Money -= Subtrahend;
            Display_Money();
            return true;
        }

        private void Display_Money()
        {
            double Player_Money = Money_Database_Reference.Money;
            double Money_with_Shifted_Point = Player_Money * 100;
            double Truncated_Money_with_Shifted_Point = Math.Truncate(Money_with_Shifted_Point);
            double Money_with_Returned_Point = Truncated_Money_with_Shifted_Point / 100;

            Money_Component_Reference.text = "$" + string.Format("{0:N2}", Money_with_Returned_Point);
        }
    }
}
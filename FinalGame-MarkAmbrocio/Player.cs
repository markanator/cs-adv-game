/*
 * Escape Hanoi Hilton
 * By: Mark Ambrocio
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using Pastel;

namespace FinalGame_MarkAmbrocio
{
    class Player
    {
        public string PlayerName { get; private set; } = "Castel";
        public int PlayerHealth { get; private set; }
        public bool HasRegDoorKey { get; private set; }
        public bool HasBossKey { get; private set; }
        public int RegKeyCount { get; private set; }
        public int POWRescued { get; private set; }
        public int Morality { get; private set; }
        private int MaxHealth;

        public enum KEYTYPE
        {
            REG, //0
            BOSS //1
        }

        public Player()
        {
            MaxHealth = 8;
            PlayerHealth = 6;
            HasRegDoorKey = false;
            HasBossKey = false;
            RegKeyCount = 0;
            POWRescued = 0; // max 6
            Morality = 5; // max 
        }
        
        public void TakeDamage(int damageAmount)
        {
            PlayerHealth -= damageAmount;
        }

        public void RestoreHealth(int healAmount)
        {
            PlayerHealth += healAmount;
            if (PlayerHealth > MaxHealth)
            {
                PlayerHealth = MaxHealth;
            }
        }

        public void PickupKey(KEYTYPE keyType)
        {
            if (keyType == KEYTYPE.REG)
            {
                RegKeyCount++;
            } 
            else if (keyType == KEYTYPE.BOSS)
            {
                HasBossKey = true;
            }

            if (RegKeyCount > 0)
            {
                HasRegDoorKey = true;
            } else
            {
                HasRegDoorKey = false;
            }
        }
    
        public void UseKey(KEYTYPE key)
        {
            if (key == KEYTYPE.REG)
            {
                RegKeyCount--;
            }
            else if (key == KEYTYPE.BOSS)
            {
                HasBossKey = false;
            }

            if (RegKeyCount > 0)
            {
                HasRegDoorKey = true;
            }
            else
            {
                HasRegDoorKey = false;
                RegKeyCount = 0;
            }
        }

        public void RescuePOW(int amountRescued)
        {
            if (amountRescued > 6 || POWRescued > 6)
            {
                POWRescued = 6;
            }

            POWRescued += amountRescued;
        }
    
        public void UpdateMorality(int amount, string addOrSub)
        {
            if(addOrSub == "add")
            {
                Morality += amount;
            } else
            {
                Morality -= amount;
            }


            if (Morality > 10)
            {
                Morality = 10;
            } 
            else if (Morality < 0)
            {
                Morality = 0;
            }
        }

        public void DisplayStatBar()
        {
            //WriteLine(Enum.GetName(typeof(KEYTYPE), KEYTYPE.
            string bkey = HasBossKey ? "1" : "0";
            Write("\nStats: ");
            DisplayHealth();
            Write($"Keys: {RegKeyCount} | Boss Key: {bkey} | ");
            DisplayRescued();
        }

        private void DisplayHealth()
        {
            Write("HP: [");
            for (int i = 0; i < MaxHealth + 1; i++)
            {
                if (i < PlayerHealth)
                {
                    Write("#".Pastel("#fc352b"));
                }
                else
                {
                    Write("#".Pastel("#420907"));
                }
            }
            Write("] | ");
        }
    
        private void DisplayRescued()
        {
            string moralColor = Morality >= 5 ? "#18baa2" : "#8217b0";
            string moralColorBG = Morality >= 5 ? "#05241f" : "#3a094f";
            Write("Rescued: [");
            for (int i = 0; i < 6 + 1; i++)
            {
                if (i < POWRescued)
                {
                    // light
                    Write("&".Pastel(moralColor));
                }
                else
                {
                    // dark
                    Write("&".Pastel(moralColorBG));
                }
            }
            WriteLine("]");
        }

        public void ResetStats()
        {
            MaxHealth = 8;
            PlayerHealth = 6;
            HasRegDoorKey = false;
            HasBossKey = false;
            RegKeyCount = 0;
            POWRescued = 0; // max 6
            Morality = 5; // max 10
        }
    }
}

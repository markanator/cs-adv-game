/*
 * Escape Hanoi Hilton
 * By: Mark Ambrocio
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalGame_MarkAmbrocio
{
    class Player
    {
        public string PlayerName { get; private set; } = "Castel";
        public byte PlayerHealth { get; private set; }
        public bool HasRegDoorKey { get; private set; }
        public bool HasBossKey { get; private set; }
        public byte RegKeyCount { get; private set; }
        public byte POWRescued { get; private set; }
        public byte Morality { get; private set; }

        public Player()
        {
            PlayerHealth = 4;
            HasRegDoorKey = false;
            HasBossKey = false;
            RegKeyCount = 0;
            POWRescued = 0;
            Morality = 5;
        }
        
        public void TakeDamage(byte damageAmount)
        {
            PlayerHealth -= damageAmount;
        }

        public void RestoreHealth(byte healAmount)
        {
            PlayerHealth += healAmount;
        }

        public void PickupKey(string keyType)
        {
            if (keyType == "reg")
            {
                RegKeyCount++;
            } 
            else if (keyType == "boss")
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
    
        public void RescuePOW(byte amountRescued)
        {
            POWRescued += amountRescued;
        }
    
        public void UpdateMorality(byte amount, string addOrSub)
        {
            if(addOrSub == "add")
            {
                Morality += amount;
            } else
            {
                Morality -= amount;
            }
        }
    
    }
}

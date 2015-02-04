using System;
using System.Collections.Generic;
using TheSlum.Characters;
using TheSlum.Items;
using System.Linq;

namespace TheSlum.GameEngine
{
    public class WarriorMageHealerBattleEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    PrintCharactersStatus(characterList);
                    break;
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
                default:
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character = null;
            string typeOfCharacter = inputParams[1];
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = (Team)Enum.Parse(typeof(Team), inputParams[5], true);

            switch(typeOfCharacter)
            {
                case "warrior":
                    character = new Warrior(id, x, y, team);
                    break;
                case "mage":
                    character = new Mage(id, x, y, team);
                    break;
                case "healer":
                    character = new Healer(id, x, y, team);
                    break;
                default:
                    throw new ArgumentException("Invalid type of character");
            }

            characterList.Add(character);
        }

        protected new void AddItem(string[] inputParams)
        {
            Item item = null;
            string character = inputParams[1];
            string typeOfItem = inputParams[2];
            string itemId = inputParams[3];

            switch (typeOfItem)
            {
                case "axe":
                    item = new Axe(itemId);
                    break;
                case "shield":
                    item = new Shield(itemId);
                    break;
                case "injection":
                    item = new Injection(itemId);
                    break;
                case "pill":
                    item = new Pill(itemId);
                    break;
                default:
                    throw new ArgumentException("Invalid type of item");
            }

            for (int i = 0; i < characterList.Count; i++)
            {
                if (characterList[i].Id == character)
                {
                    characterList[i].AddToInventory(item);
                }
            }
            

        }
    }
}

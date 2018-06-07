using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IDOfMonstersToSlay { get; set; }
        public int NumberOfMonstersToSlay { get; set; }
        public int IDOfItemsToCollect { get; set; }
        public int NumberOfItemsToCollect { get; set; }
        public int IDOfNPCToSpeak { get; set; }
        public int IDOfRewardItems { get; set; }
        public int NumberOfRewardItems { get; set; }
        public int RewardExp { get; set; }
        public int RewardGold { get; set; }
        public string DialogueOfNPCToSpeak { get; set; }
        public Quest(int id, string name,int idofmonsterstoslay, int numberofmonsterstoslay, int idofitemstocollect, int numberofitemstocollect,
                     int idofnpctospeak, string dialogueofnpctospeak, int idofrewarditems, int numberofrewarditems, int rewardexp, int rewardgold)
        {
            ID = id;
            Name = name;
            IDOfItemsToCollect = idofitemstocollect;
            NumberOfItemsToCollect = numberofitemstocollect;
            IDOfMonstersToSlay = idofmonsterstoslay;
            NumberOfMonstersToSlay = numberofmonsterstoslay;
            IDOfNPCToSpeak = idofnpctospeak;
            IDOfRewardItems = idofrewarditems;
            NumberOfRewardItems = numberofrewarditems;
            RewardExp = rewardexp;
            RewardGold = rewardgold;
            DialogueOfNPCToSpeak = dialogueofnpctospeak;
        }
    }
}

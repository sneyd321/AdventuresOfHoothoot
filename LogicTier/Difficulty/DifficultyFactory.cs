using ProjectProposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier
{

    public enum DifficultyType{
        easy,
        medium,
        hard
    }

    public class DifficultyFactory : AbstractFactory
    {

        public Difficulty GetDifficulty(DifficultyType difficultyType)
        {
            switch (difficultyType)
            {
                case DifficultyType.easy:
                    return new EasyDifficulty();
                case DifficultyType.medium:
                    return new MediumDifficulty();
                case DifficultyType.hard:
                    return new HardDifficulty();
                default:
                    return null;
       
            }
        }



    }
}

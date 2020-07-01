using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier
{


    public enum FactoryType
    {
        Background,
        Difficulty
    }

    public abstract class AbstractFactory
    {

        public static AbstractFactory getFactory(FactoryType factoryType)
        {
            switch(factoryType)
            {
                case FactoryType.Background:
                    return new BackgroundFactory();
                case FactoryType.Difficulty:
                    return new DifficultyFactory();
                default:
                    return null;
            }
        }


    }
}

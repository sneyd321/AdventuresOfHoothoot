using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier
{

    public enum BackgroundType
    {
        Rainbow,
        BlackAndWhite,
        Sunset
    }

    public class BackgroundFactory : AbstractFactory
    {
        public GradientBackground GetBackground(BackgroundType backgroundType)
        {
            switch (backgroundType)
            {
                case BackgroundType.Rainbow:
                    return new RainbowBackground();
                case BackgroundType.BlackAndWhite:
                    return new BlackWhiteBackground();
                case BackgroundType.Sunset:
                    return new SunsetBackground();
                default:
                    return null;
            }
        }


    }
}

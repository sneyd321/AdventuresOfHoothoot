using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicTier;
using ProjectProposal;
using Windows.UI.Xaml.Controls;

namespace LogicTier
{
    public class HootHoot
    {
        const float FallingSpeed = 9.81f; //The Falling speed of the bird is a fixed speed

        Image OwlUi;

        double _startLocation;


        /// <summary>
        /// Hoot Hoot The Owl Character object init
        /// </summary>
        /// <param name="HootHootTheOwl"></param>
        /// <param name="startLocation"></param>
        public HootHoot(Image HootHootTheOwl)
        {
            OwlUi = HootHootTheOwl;


        }



    }
}

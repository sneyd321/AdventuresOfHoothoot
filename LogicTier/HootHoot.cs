using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicTier;
using ProjectProposal;
using Windows.UI.Xaml.Shapes;

namespace LogicTier
{
    public class HootHoot
    {
        

        private Game _game;

        private Rectangle _hoothoot;

        public HootHoot(Rectangle testHoothoot, Game game)
        {
            _game = game;

            _hoothoot = testHoothoot;
            
            
        }

        /// <summary>
        /// Checks if hoothoot has collided with an obsticle
        /// </summary>
        public void OnHoothootDies()
        {

            for (int i = 0; i < _game.map.obsticleListOnTop.Count; i++)
            {
                _game.map.obsticleListOnTop[i].Collision(_hoothoot, _game.map.obsticleListOnTop[i].getObsticle);
                
            }

            for (int i = 0; i < _game.map.topPipeTop.Count; i++)
            {
                _game.map.topPipeTop[i].Collision(_hoothoot, _game.map.topPipeTop[i].getObsticle);
                
            }


            for (int i = 0; i < _game.map.obsticleListOnBottom.Count; i++)
            {
                _game.map.obsticleListOnBottom[i].Collision(_hoothoot, _game.map.obsticleListOnBottom[i].getObsticle);
                
            }

            for (int i = 0; i < _game.map.bottomPipeTop.Count; i++)
            {
                _game.map.bottomPipeTop[i].Collision(_hoothoot, _game.map.bottomPipeTop[i].getObsticle);
                
            }
        }

        

    }
}

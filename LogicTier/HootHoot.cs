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

        public void OnHoothootDies()
        {
            for (int i = 0; i < _game.obsticleListOnTop.Count; i++)
            {
                _game.obsticleListOnTop[i].Collision(_hoothoot, _game.obsticleListOnTop[i].getObsticle);
            }

            for (int i = 0; i < _game.obsticleListOnBottom.Count; i++)
            {
                _game.obsticleListOnBottom[i].Collision(_hoothoot, _game.obsticleListOnBottom[i].getObsticle);
            }
        }

    }
}

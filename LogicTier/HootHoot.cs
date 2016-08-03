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
        private Map _map; 

        private Rectangle _hoothoot;

        public HootHoot(Rectangle testHoothoot, Map map)
        {
            _map = map;

            _hoothoot = testHoothoot;
            
        }

        /// <summary>
        /// Checks if hoothoot has collided with an obsticle
        /// </summary>
        public void OnHoothootDies()
        {

            for (int i = 0; i < _map.obsticleListOnTop.Count; i++)
            {
                _map.obsticleListOnTop[i].Collision(_hoothoot, _map.obsticleListOnTop[i].getObsticle);
            }

            for (int i = 0; i < _map.topPipeTop.Count; i++)
            {
                _map.topPipeTop[i].Collision(_hoothoot, _map.topPipeTop[i].getObsticle);
            }


            for (int i = 0; i < _map.obsticleListOnBottom.Count; i++)
            {
                _map.obsticleListOnBottom[i].Collision(_hoothoot, _map.obsticleListOnBottom[i].getObsticle);
            }

            for (int i = 0; i < _map.bottomPipeTop.Count; i++)
            {
                _map.bottomPipeTop[i].Collision(_hoothoot, _map.bottomPipeTop[i].getObsticle);
            }
        }

    }
}

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

        public void OnHoothootDies()
        {
            for (int i = 0; i < _map.obsticleListOnTop.Count; i++)
            {
                _map.obsticleListOnTop[i].Collision(_hoothoot, _map.obsticleListOnTop[i].getObsticle);
            }

            for (int i = 0; i < _map._topPipeTopsList.Count; i++)
            {
                _map._topPipeTopsList[i].Collision(_hoothoot, _map._topPipeTopsList[i].getObsticle);
            }


            for (int i = 0; i < _map.obsticleListOnBottom.Count; i++)
            {
                _map.obsticleListOnBottom[i].Collision(_hoothoot, _map.obsticleListOnBottom[i].getObsticle);
            }

            for (int i = 0; i < _map._bottomPipeTopsList.Count; i++)
            {
                _map._bottomPipeTopsList[i].Collision(_hoothoot, _map._bottomPipeTopsList[i].getObsticle);
            }
        }

    }
}

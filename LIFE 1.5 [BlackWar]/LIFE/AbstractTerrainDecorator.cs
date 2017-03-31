using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIFE
    {
    abstract class AbstractTerrainDecorator : Terrain
        {
        protected Terrain terrain;

        public AbstractTerrainDecorator ()
            {
            }

        public void SetTerrain (Terrain terrain)
            {
            this.terrain = terrain;
            }

        }
    }

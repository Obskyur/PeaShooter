using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaShooter
{
    internal interface IBuilder
    {
        public void Reset();
        public void SetAccessory(Accessory accessory);
        public IDamageable GetProduct();
    }
}

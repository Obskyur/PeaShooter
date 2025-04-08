using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaShooter
{
    internal class Bucket : Accessory
    {
        public override int Health { get; set; } = 100;
        public new bool isMetal = true;
        public override ZType Type => ZType.Bucket;
    }
}

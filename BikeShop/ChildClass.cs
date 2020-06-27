using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop
{
    class ChildClass : BaseClass, iParent
    {
        public ChildClass()
        {

        }

        public double GiveAccount()
        {
            throw new NotImplementedException();
        }
    }
}

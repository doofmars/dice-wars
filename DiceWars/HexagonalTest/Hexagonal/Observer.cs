using System;
using System.Collections.Generic;
using System.Text;

namespace Hexagonal
{
    public abstract class Observer
    {
        public abstract void Update(Subject sub);
    }
}

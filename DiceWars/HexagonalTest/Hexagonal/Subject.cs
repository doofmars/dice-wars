using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Hexagonal
{
    public abstract class Subject
    {
        private ArrayList observers = new ArrayList();

        public void Attach(DiceLabels observer)
        {
            observers.Add(observer);
        }

        public void Detach(DiceLabels observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (DiceLabels o in observers)
            {
                o.Update(this);
            }
        }
    }
}

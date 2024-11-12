using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsAndFleas.ConApp
{
    public class Dog : Pet
    {
        public int HuntedAnimals { get; private set; }
        public DateTime LastCall { get; private set; }

        public bool HuntAnimal()
        {
            DateTime currentCall = DateTime.Now;
            bool result = false;
            if (currentCall != LastCall)
            {
                TimeSpan difference = currentCall - LastCall;
                if (difference.TotalSeconds > 1)
                {
                    HuntedAnimals++;
                    result = true;

                }
            }
            LastCall = currentCall;
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsAndFleas.ConApp
{
    public class Flea
    {
        public int AmountBites { get; private set; }
        public Pet? ActualPet { get; private set; }

        public int BitePet(int amount)
        {
            try
            {
                int result = 0;
                if (ActualPet != null)
                {
                    result = ActualPet.GetBiten(amount);
                    AmountBites += result;
                }
                else
                {
                    return 0;
                }
                return result;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void JumpOnPet(Pet pet)
        {
            try
            {
                if (pet == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    ActualPet = pet;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

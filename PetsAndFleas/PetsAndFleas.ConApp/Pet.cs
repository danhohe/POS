using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsAndFleas.ConApp
{
    public class Pet
    {
        #region fields
        private int _petId = 0;
        private int _remainingBites = 100;
        public static readonly int LastPetID;
        #endregion fields

        #region properties

        public int RemainingBites
        {
            get { return _remainingBites; }
            private set { _remainingBites = value; }
        }
        public int PetID
        {
            get { return _petId; }
        }
        #endregion properties

        #region constructor
        public Pet()
        {
            _petId = PetID + 1;
        }
        #endregion constructor

        #region methods
        public int GetBiten(int amount)
        {
            int result = 0;
            try
            {
                if (amount > 0)
                {
                    if (amount <= RemainingBites)
                    {
                        result = amount;
                        RemainingBites -= amount;
                    }
                    else if (amount > RemainingBites)
                    {
                        result = RemainingBites;
                        RemainingBites = 0;
                    }
                }
                else if (amount <= 0)
                {
                    throw new ArgumentException("");
                }
                return result;
            }
            catch (ArgumentException ex)
            {
                return 0;
            }

            
        }
        #endregion methods
    }
}

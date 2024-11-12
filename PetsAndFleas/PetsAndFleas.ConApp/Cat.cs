using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetsAndFleas.ConApp
{
    public class Cat : Pet
    {
        private bool _isOnTree = false;
        public int TreesClimbed { get; private set; }

        public bool ClimbDown()
        {
            bool result = false;
            if (_isOnTree)
            {
                result = true;
                _isOnTree = false;
            }
            return result;
        }

        public bool ClimbOnTree()
        {
            bool result = false;
            if (!_isOnTree)
            {
                result = true;
                _isOnTree = true;
                TreesClimbed++;
            }
            return result;
        }
    }
}

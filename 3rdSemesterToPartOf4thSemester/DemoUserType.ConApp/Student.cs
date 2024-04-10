using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserType.ConApp
{
    internal class Student
    {
        #region fields
        private string _firstName;
        private string _lastName;
        private DateTime _birthday;
        #endregion fields

        #region properties
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }
        }
        public string Fullname
        {
            get
            {
                return $"{LastName} {FirstName}";
            }
        }

        private string _matrNumber;
        private string matNumber2;

        public string MatNumber
        {
            get { return _matrNumber; }
            set { _matrNumber = value; }
        }
        public string MatNumber2 { get => matNumber2; set => matNumber2 = value; }
        #endregion properties
    }
}
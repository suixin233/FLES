using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class test
    {
        public test(int _Id, string _Password, string _Name)
        {
            this._Id = _Id;
            this._Password = _Password;
            this._Name = _Name;
        }

        #region Model
        private int _Id;
        private string _Password;
        private string _Name;



        public int ID
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        #endregion Model
    }
}

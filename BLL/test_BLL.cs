using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    [System.ComponentModel.DataObject]
    public class test_BLL
    {
        static DAL.test_DAL dal = new DAL.test_DAL();

        public List<test> GetAlltest()
        {
            return dal.GetAlltest();
        }

        public void Add(int ID, string Password, string Name)
        {
            dal.add(new Model.test(ID, Password, Name));
        }

        public void Update(int ID, string Password, string Name)
        {
            dal.update(new Model.test(ID, Password, Name));
        }

        public void Delete(int Original_ID)
        {
            dal.Delete(Original_ID);
        }
    }
}

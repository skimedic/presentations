#region copyright
// Copyright Information
// ==============================
// PatternsExamples - LightCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

using System.Collections.Generic;
using System.Text;
using BehavioralPatterns.Command;

namespace BehavioralPatterns.Memento
{
    public class ChangeCustomerCommand : IDbCommand
    {
        public Customer Customer { get; private set; }

        //NOTE: This example will potentially use a LOT of memory!
        private readonly List<MementoForCustomerEntity> _mementos = 
            new List<MementoForCustomerEntity>();
        public ChangeCustomerCommand(Customer customer)
        {
            Customer = customer;
        }

        public void Execute(string newName)
        {
            _mementos.Add(new MementoForCustomerEntity(Customer));
            Customer.Name = newName;
        }


        public void UnExecute()
        {
            //Should add error checking here
            Customer = (_mementos[_mementos.Count - 1].GetCustomer());
            _mementos.RemoveAt(_mementos.Count-1);
        }
    }
}
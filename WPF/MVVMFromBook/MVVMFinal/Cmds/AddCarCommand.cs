using System.Collections.Generic;
using System.Linq;
using AutoLotDAL.Models;

namespace MVVM.Cmds
{
    internal class AddCarCommand : CommandBase
    {
        private readonly IList<Inventory> _cars;

        public AddCarCommand(IList<Inventory> cars)
        {
            _cars = cars;
        }

        public override void Execute(object parameter)
        {
            var maxCount = _cars?.Max(x => x.CarId) ?? 0;
            _cars?.Add(new Inventory { CarId = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie", IsChanged = false });
        }

        public override bool CanExecute(object parameter) => true;
    }

}
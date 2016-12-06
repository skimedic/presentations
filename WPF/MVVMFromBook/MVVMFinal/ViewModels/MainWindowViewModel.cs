using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using MVVM.Cmds;

namespace MVVM.ViewModels
{
    public class MainWindowViewModel
    {
        private ICommand _changeColorCommand = null;
        public ICommand ChangeColorCmd =>
            _changeColorCommand ?? (_changeColorCommand = new ChangeColorCommand());

        private ICommand _addCarCommand = null;
        public ICommand AddCarCmd =>
            _addCarCommand ?? (_addCarCommand = new AddCarCommand(Cars));

        private ICommand _removeCarCommand = null;
        public ICommand RemoveCarCmd =>
            _removeCarCommand ?? (_removeCarCommand = new RemoveCarCommand(Cars));

        public IList<Inventory> Cars { get; set; }

        public MainWindowViewModel()
        {
            Cars = new ObservableCollection<Inventory>(new InventoryRepo().GetAll());
        }
    }
}

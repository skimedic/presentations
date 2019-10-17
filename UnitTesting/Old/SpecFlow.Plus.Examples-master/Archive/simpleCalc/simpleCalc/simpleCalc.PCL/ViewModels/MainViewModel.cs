using System.Windows.Input;

namespace simpleCalc.PCL
{
    public class MainViewModel : ViewModel
    {
        private double _operand1;
        private double _operand2;
        private string _result;
        private bool _plusOperator;
        private bool _minusOperator;
        private bool _multiplyOperator;
        private bool _divideOperator;

        public MainViewModel()
        {
            CalcCommand = new Command(Calc);
        }

        private void Calc()
        {
            double result = 0;
            if (PlusOperator)
            {
                result = Operand1 + Operand2;
            }

            if (MinusOperator)
            {
                result = Operand1 - Operand2;
            }

            if (MultiplyOperator)
            {
                result = Operand1*Operand2;
            }

            if (DivideOperator)
            {
                result = Operand1/Operand2;
            }

            Result = result.ToString("0.00");
        }

        public ICommand CalcCommand { get; set; }


        public bool PlusOperator
        {
            get { return _plusOperator; }
            set
            {
                if (value == _plusOperator) return;
                _plusOperator = value;
                _minusOperator = !_plusOperator;
                _multiplyOperator = !_plusOperator;
                _divideOperator = !_plusOperator;
                OnPropertyChanged();
                NotifyOperator();

            }
        }

        public bool MinusOperator
        {
            get { return _minusOperator; }
            set
            {
                if (value == _minusOperator) return;
                _minusOperator = value;
                _plusOperator = !_minusOperator;
                _multiplyOperator = !_minusOperator;
                _divideOperator = !_minusOperator;
                OnPropertyChanged();
                NotifyOperator();

            }
        }

        public bool MultiplyOperator
        {
            get { return _multiplyOperator; }
            set
            {
                if (value == _multiplyOperator) return;
                _multiplyOperator = value;
                _plusOperator = !_multiplyOperator;
                _minusOperator = !_multiplyOperator;
                _divideOperator = !_multiplyOperator;
                OnPropertyChanged();
                NotifyOperator();

            }
        }

        public bool DivideOperator
        {
            get { return _divideOperator; }
            set
            {
                if (value == _divideOperator) return;
                _divideOperator = value;
                _plusOperator = !_divideOperator;
                _minusOperator = !_divideOperator;
                _multiplyOperator = !_divideOperator;
                OnPropertyChanged();
                NotifyOperator();
            }
        }

        private void NotifyOperator()
        {
            OnPropertyChanged(nameof(PlusOperator));
            OnPropertyChanged(nameof(MinusOperator));
            OnPropertyChanged(nameof(MultiplyOperator));
            OnPropertyChanged(nameof(DivideOperator));
        }

        public double Operand1
        {
            get { return _operand1; }
            set
            {
                if (value.Equals(_operand1)) return;
                _operand1 = value;
                OnPropertyChanged();
            }
        }

        public double Operand2
        {
            get { return _operand2; }
            set
            {
                if (value.Equals(_operand2)) return;
                _operand2 = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                if (value.Equals(_result)) return;
                _result = value;
                OnPropertyChanged();
            }
        }
    }
}

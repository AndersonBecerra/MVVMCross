using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Core.Services;

namespace TipCalculator.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _CalculationService;
        private decimal _subTotal;
        private int _generosity;
        private decimal _tip;

        public TipViewModel(ICalculationService calculationService)
        {
            _CalculationService = calculationService;
        }

        public decimal SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);
                Recalculate();
            }
        }

        public decimal Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);
                Recalculate();
            }
        }
        public async override Task Initialize()
        {
            await base.Initialize();
            _subTotal = 100;
            _generosity = 10;
            Recalculate();
        }

        private void Recalculate()
        {
            Tip = _CalculationService.TipAmount(_subTotal, _generosity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using App.Helper;
using App.Model;
using Caliburn.Micro;
using ControleDeMassa;

namespace ControleDePedido.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>
    {
        private static TemperoPickerViewModel temperosPVM;
        private static MolhoPickerViewModel molhosPVM;
        private static MassaPickerViewModel massasPVM;
        private static ToppingPickerViewModel toppingsPVM;

        private int _currentIndex;
        private SolidColorBrush _nextButtonColor;
        private SolidColorBrush _nextPanelColor;

        private List<BaseViewModel> _pickers;
        private SolidColorBrush _previousButtonColor;
        private SolidColorBrush _previousPanelColor;
        private readonly List<MassasControlViewModel> listaDeMassas = new List<MassasControlViewModel>();
        private readonly List<MolhosControlViewModel> listaDeMolhos = new List<MolhosControlViewModel>();
        private readonly List<TemperosControlViewModel> listaDeTemperos = new List<TemperosControlViewModel>();
        private readonly List<ToppingControlViewModel> listaDeToppings = new List<ToppingControlViewModel>();
        private readonly StatusEstoque statusEstoque;

        public ShellViewModel()
        {
            new ControleDeAlimentos.ControleDeAlimentos().CriaEstoque();

            statusEstoque = ControleDeAlimentos.ControleDeAlimentos.enviaStatusEstoque();
            preencheObjetos();
            IniciaPickerViewModel();
            ActiveItem = _pickers[_currentIndex];
            RebuildColors(_currentIndex);
        }

        #region Navegação


        public Visibility IsMassaPicker
        {
            get { return _currentIndex > 0 ? Visibility.Visible : Visibility.Hidden; }
        }

        public SolidColorBrush PreviousPanelColor
        {
            get { return _previousPanelColor; }
            set
            {
                if (Equals(value, _previousPanelColor)) return;
                _previousPanelColor = value;
                NotifyOfPropertyChange(() => PreviousPanelColor);
            }
        }

        public SolidColorBrush PreviousButtonColor
        {
            get { return _previousButtonColor; }
            set
            {
                if (Equals(value, _previousButtonColor)) return;
                _previousButtonColor = value;
                NotifyOfPropertyChange(() => PreviousButtonColor);
            }
        }

        public SolidColorBrush NextPanelColor
        {
            get { return _nextPanelColor; }
            set
            {
                if (Equals(value, _nextPanelColor)) return;
                _nextPanelColor = value;
                NotifyOfPropertyChange(() => NextPanelColor);
            }
        }

        public SolidColorBrush NextButtonColor
        {
            get { return _nextButtonColor; }
            set
            {
                if (Equals(value, _nextButtonColor)) return;
                _nextButtonColor = value;
                NotifyOfPropertyChange(() => NextButtonColor);
            }
        }

        //MassaPickerViewModel mPVM = new MassaPickerViewModel();

        private void preencheObjetos()
        {
            foreach (var tempero in statusEstoque.estoqueDeTemperos)
            {
                listaDeTemperos.Add(new TemperosControlViewModel { Tempero = tempero, Checked = false });
            }

            foreach (var molho in statusEstoque.estoqueDeMolhos)
            {
                listaDeMolhos.Add(new MolhosControlViewModel { Molho = molho, Checked = false });
            }

            foreach (var massa in statusEstoque.estoqueDeMassas)
            {
                listaDeMassas.Add(new MassasControlViewModel { Massa = massa, Checked = false });
            }

            foreach (var topping in statusEstoque.estoqueDeToppings)
            {
                listaDeToppings.Add(new ToppingControlViewModel { Topping = topping, Checked = false });
            }
        }

        private void IniciaPickerViewModel()
        {
            temperosPVM = new TemperoPickerViewModel(2, 0, ColorBrushHelper.ColorBrushFromRgb(205, 198, 108),
                ColorBrushHelper.ColorBrushFromRgb(201, 190, 46), listaDeTemperos);
            molhosPVM = new MolhoPickerViewModel(1, 3, ColorBrushHelper.ColorBrushFromRgb(108, 205, 147),
                ColorBrushHelper.ColorBrushFromRgb(47, 195, 106), listaDeMolhos);
            massasPVM = new MassaPickerViewModel(null, 1, ColorBrushHelper.ColorBrushFromRgb(107, 171, 203),
                ColorBrushHelper.ColorBrushFromRgb(68, 146, 185), listaDeMassas);
            toppingsPVM = new ToppingPickerViewModel(0, 2, ColorBrushHelper.ColorBrushFromRgb(108, 205, 189),
                ColorBrushHelper.ColorBrushFromRgb(47, 191, 167), listaDeToppings);

            _pickers = new List<BaseViewModel>
            {
                massasPVM,
                toppingsPVM,
                molhosPVM,
                temperosPVM
            };
        }

        private void RebuildColors(int currentIndex)
        {
            if (currentIndex == 0)
            {
                PreviousPanelColor = new SolidColorBrush(Colors.DarkGray);
                PreviousButtonColor = new SolidColorBrush(Colors.Gray);
            }
            else
            {
                PreviousPanelColor = _pickers[currentIndex - 1].BackgroundColor;
                PreviousButtonColor = _pickers[currentIndex - 1].ButtonColor;
            }

            try
            {
                NextPanelColor = _pickers[currentIndex + 1].BackgroundColor;
                NextButtonColor = _pickers[currentIndex + 1].ButtonColor;
            }
            catch (Exception)
            {
                NextPanelColor = new SolidColorBrush(Colors.MediumSeaGreen);
                NextButtonColor = new SolidColorBrush(Colors.ForestGreen);
            }
        }

        public void Close()
        {
            TryClose();
        }

        public void Previous()
        {
            if (!_pickers[_currentIndex].PreviousPicker.HasValue)
            {
                RebuildColors(_currentIndex + 1);

                return;
            }

            _currentIndex = (int)_pickers[_currentIndex].PreviousPicker;
            ActiveItem = _pickers[_currentIndex];

            RebuildColors(_currentIndex);
            NotifyOfPropertyChange(() => IsMassaPicker);
        }

        public void Advance()
        {
            if (_currentIndex == 3)
                FinishPedido();

            _currentIndex = (int)_pickers[_currentIndex].NextPicker;
            ActiveItem = _pickers[_currentIndex];

            RebuildColors(_currentIndex);
            NotifyOfPropertyChange(() => IsMassaPicker);
        }

        #endregion

        /// <summary>
        /// Monta o pedido de acordo com os itens escolhidos e manda para a próxima página
        /// </summary>
        private void FinishPedido()
        {
            try
            {
                var pedido = new Pedido
                {
                    Massa = (_pickers[0] as MassaPickerViewModel).Massas.Single(x => x.Checked).Massa,
                    Toppings =
                        (_pickers[1] as ToppingPickerViewModel).Toppings.Where(x => x.Checked)
                            .Select(x => x.Topping)
                            .ToList(),
                    Molho = (_pickers[2] as MolhoPickerViewModel).Molhos.Single(x => x.Checked).Molho,
                    Temperos =
                        (_pickers[3] as TemperoPickerViewModel).Temperos.Where(x => x.Checked)
                            .Select(x => x.Tempero)
                            .ToList()
                };
                
                //Inicia o módulo seguinte ao pedido.
                Task.Run(() => Program.Main());

                //Envia pedido para o controle de alimentos para ser efetuada a subtração da quantidade dos ingredientes.
                new ControleDeAlimentos.ControleDeAlimentos().recebePedido(pedido);

                //Envia o pedido para o controle de massas para começar o processo de produção do pedido.
                Program.IniciarFila(pedido);

                TryClose();

                GC.Collect();
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}
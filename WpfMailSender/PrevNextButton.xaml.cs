using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для PrevNextButton.xaml
    /// </summary>
    public partial class PrevNextButton : UserControl
    {
        public event RoutedEventHandler btnNextClick;
        public event RoutedEventHandler btnPreviousClick;
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            btnNextClick?.Invoke(sender, e);
        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            btnPreviousClick?.Invoke(sender, e);
        }
        public PrevNextButton()
        {
            InitializeComponent();
        }
        private bool bHidebtnPrevious = false;
        private bool bHideBtnNext = false;

        public bool IsHidebtnPrevious
        {
            get { return bHidebtnPrevious; }
            set
            {
                bHidebtnPrevious = value;
                SetButtons(); // метод, который отвечает на отрисовку кнопок
            }
        }// IsHidebtnPrevious
        public bool IsHideBtnNext
        {
            get { return bHideBtnNext; }
            set
            {
                bHideBtnNext = value;
                SetButtons(); // метод, который отвечает за отрисовку кнопок
            }
        }// IsHidebtnNext
        private void BtnNextTruebtnPreviousFalse()
        {
            btnNext.Visibility = Visibility.Hidden;
            btnPrev.Visibility = Visibility.Visible;
            //btnPrev.Width = 60;
            //btnNext.Width = 0;
            btnPrev.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
        private void btnPreviousTrueBtnNextFalse()
        {
            btnPrev.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            //btnNext.Width = 60;
            //btnPrev.Width = 0;
            btnNext.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
        private void btnPreviousFalseBtnNextFalse()
        {
            btnNext.Visibility = Visibility.Visible;
            btnPrev.Visibility = Visibility.Visible;
            //btnNext.Width = 30;
            //btnPrev.Width = 30;
        }
        private void btnPreviousTrueBtnNextTrue()
        {
            btnPrev.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод, который отвечает за отрисовку кнопок.
        /// Есть три варианта: когда обе кнопки доступны; доступна одна и недоступна вторая; обе кнопки недоступны
        /// </summary>
        private void SetButtons()
        {
            if (bHidebtnPrevious && bHideBtnNext) btnPreviousTrueBtnNextTrue();
            else if (!bHideBtnNext && !bHidebtnPrevious) btnPreviousFalseBtnNextFalse();
            else if (bHideBtnNext && !bHidebtnPrevious) BtnNextTruebtnPreviousFalse();
            else if (!bHideBtnNext && bHidebtnPrevious) btnPreviousTrueBtnNextFalse();
        }
    }
}

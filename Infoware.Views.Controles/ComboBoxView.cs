using System;
using System.Collections;
using System.Windows.Forms;

namespace Infoware.Views.Controles
{
    public class ComboBoxView : ComboBox
    {
        private IBindingSourceView _bindingSourceView;

        public void SetBindingSourceView(IBindingSourceView bindingSourceView)
        {
            _bindingSourceView = bindingSourceView;
            DataSource = bindingSourceView.BindingSource;
        }

        public void LoadData()
        {
            DataSource = null;
            DisplayMember = _bindingSourceView.DisplayMember;
            ValueMember = _bindingSourceView.ValueMember;
            _bindingSourceView.LoadData(Text);
            DataSource = _bindingSourceView.BindingSource;
        }

        private Timer timerUpdate;
        public ComboBoxView()
        {
            timerUpdate = new Timer()
            {
                Enabled = false,
                Interval = 2500,
            };
            timerUpdate.Tick += TimerUpdate_Tick;
        }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            timerUpdate.Stop();
            Search();
        }

        public void Search()
        {
            if (Text.Length > 2)
            {
                LoadData();
                HandleTextChanged();
            }
        }

        private void HandleTextChanged()
        {
            var text = Text;
            if (((IList)DataSource).Count > 1)
            {
                //var sText = typeof(TView).GetProperty(DisplayMember).GetValue(Items[0]).ToString();
                SelectionStart = _selectionstart;
                SelectionLength = text.Length - _selectionstart;
                DroppedDown = true;
                return;
            }
            else
            {
                DroppedDown = false;
                SelectionStart = _selectionstart;
            }
        }

        private int _selectionstart;
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)13)
            {
                _selectionstart = SelectionStart;
                RestartTimer();
            }

        }

        private void RestartTimer()
        {
            timerUpdate.Stop();
            timerUpdate.Start();
        }
    }
}

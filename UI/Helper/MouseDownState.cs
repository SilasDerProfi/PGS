namespace PGS.UI
{
    internal record MouseDownState
    {
        internal Point Location { get; private set; }
        internal MouseButtons Button { get; private set; }
        internal MouseDownAction Action = MouseDownAction.None;
        private bool _interactionAllowed = true;

        internal bool IsClick => Action == MouseDownAction.Click;
        internal bool IsActive { get; private set; }

        internal void MouseDown(object? sender, MouseEventArgs e)
        {
            if (IsActive || e.Button != MouseButtons.Left && e.Button != MouseButtons.Right || !_interactionAllowed)
                return;
         
            Location = e.Location;
            Button = e.Button;
            Action = MouseDownAction.Click;
            IsActive = true;
        }


        internal void MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button != Button || !IsActive)
                return;

            Cursor.Current = Cursors.Default;

            if (IsClick && Button == MouseButtons.Left)
                ClickedLeft?.Invoke(this, e);
            else if (IsClick && Button == MouseButtons.Right)
                ClickedRight?.Invoke(this, e);
            else if (!IsClick && Button == MouseButtons.Left)
                EndHoldLeft?.Invoke(this, e);
            else if (!IsClick && Button == MouseButtons.Right)
                EndHoldRight?.Invoke(this, e);

            IsActive = false;
        }

        public enum MouseDownAction
        {
            None, Click, Move
        }

        public event MouseEventHandler? ClickedRight;
        public event MouseEventHandler? ClickedLeft;
        public event MouseEventHandler? BeginHoldLeft;
        public event MouseEventHandler? EndHoldLeft;
        public event MouseEventHandler? BeginHoldRight;
        public event MouseEventHandler? EndHoldRight;

        internal void MouseMove(object? sender, MouseEventArgs e)
        {
            if (!IsActive || Action == MouseDownAction.Move || e.Location.Distance(Location) <= Settings.MaxDistanceForClick)
                return;

            Action = MouseDownAction.Move;
            
            if (Button == MouseButtons.Left)
                BeginHoldLeft?.Invoke(this, e);
            else if (Button == MouseButtons.Right)
                BeginHoldRight?.Invoke(this, e);
        }

        internal void SetInteractionEnabled(bool enabled) => _interactionAllowed = enabled;
        internal bool IsInteractionEnabled => _interactionAllowed;
    }
}

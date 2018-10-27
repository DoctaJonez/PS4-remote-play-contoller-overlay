﻿using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.DualShock4;
using System;
using System.Collections.Generic;
using System.Device.Location;
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
using System.Windows.Threading;

namespace DoctaJonez.Windows.PS4Overlay
{
    public class Ds4State
    {
        public event Action StateChanged;

        private void RaiseStateChanged()
        {
            if (StateChanged != null)
            {
                foreach (var subscriber in StateChanged.GetInvocationList())
                {
                    if (subscriber.Target is DispatcherObject)
                    {
                        Dispatcher.CurrentDispatcher.Invoke(subscriber);
                    }
                    else
                    {
                        subscriber.DynamicInvoke(null);
                    }
                }
            }
        }

        private bool _dPadUp;
        public bool DPadUp
        {
            get => _dPadUp;
            set
            {
                _dPadUp = value;
                RaiseStateChanged();
            }
        }
        private bool _dPadDown;
        public bool DPadDown
        {
            get => _dPadDown;
            set
            {
                _dPadDown = value;
                RaiseStateChanged();
            }
        }
        private bool _dPadLeft;
        public bool DPadLeft
        {
            get => _dPadLeft;
            set
            {
                _dPadLeft = value;
                RaiseStateChanged();
            }
        }
        private bool _dPadLeftUp;
        public bool DPadLeftUp
        {
            get => _dPadLeftUp;
            set
            {
                _dPadLeftUp = value;
                RaiseStateChanged();
            }
        }
        private bool _dPadLeftDown;
        public bool DPadLeftDown
        {
            get => _dPadLeftDown;
            set
            {
                _dPadLeftDown = value;
                RaiseStateChanged();
            }
        }
        private bool _dPadRight;
        public bool DPadRight
        {
            get => _dPadRight;
            set
            {
                _dPadRight = value;
                RaiseStateChanged();
            }
        }
        private bool _dPadRightUp;
        public bool DPadRightUp
        {
            get => _dPadRightUp;
            set
            {
                _dPadRightUp = value;
                RaiseStateChanged();
            }
        }
        private bool _dPadRightDown;
        public bool DPadRightDown
        {
            get => _dPadRightDown;
            set
            {
                _dPadRightDown = value;
                RaiseStateChanged();
            }
        }
        private bool _cross;
        public bool Cross
        {
            get => _cross;
            set
            {
                _cross = value;
                RaiseStateChanged();
            }
        }
        private bool _square;
        public bool Square
        {
            get => _square;
            set
            {
                _square = value;
                RaiseStateChanged();
            }
        }
        private bool _triangle;
        public bool Triangle
        {
            get => _triangle;
            set
            {
                _triangle = value;
                RaiseStateChanged();
            }
        }
        private bool _circle;
        public bool Circle
        {
            get => _circle;
            set
            {
                _circle = value;
                RaiseStateChanged();
            }
        }
        private bool _share;
        public bool Share
        {
            get => _share;
            set
            {
                _share = value;
                RaiseStateChanged();
            }
        }
        private bool _options;
        public bool Options
        {
            get => _options;
            set
            {
                _options = value;
                RaiseStateChanged();
            }
        }
        private bool _l1;
        public bool L1
        {
            get => _l1;
            set
            {
                _l1 = value;
                RaiseStateChanged();
            }
        }
        private bool _l2;
        public bool L2
        {
            get => _l2;
            set
            {
                _l2 = value;
                RaiseStateChanged();
            }
        }
        private bool _r1;
        public bool R1
        {
            get => _r1;
            set
            {
                _r1 = value;
                RaiseStateChanged();
            }
        }
        private bool _r2;
        public bool R2
        {
            get => _r2;
            set
            {
                _r2 = value;
                RaiseStateChanged();
            }
        }
        private bool _playStation;
        public bool PlayStation
        {
            get => _playStation;
            set
            {
                _playStation = value;
                RaiseStateChanged();
            }
        }
        private bool _touchpad;
        public bool Touchpad
        {
            get => _touchpad;
            set
            {
                _touchpad = value;
                RaiseStateChanged();
            }
        }
        private byte _lStickX = 127;
        public byte LStickX
        {
            get => _lStickX;
            set
            {
                _lStickX = value;
                RaiseStateChanged();
            }
        }

        private byte _lStickY = 127;
        public byte LStickY
        {
            get => _lStickY;
            set
            {
                _lStickY = value;
                RaiseStateChanged();
            }
        }
        private byte _rStickX = 127;
        public byte RStickX
        {
            get => _rStickX;
            set
            {
                _rStickX = value;
                RaiseStateChanged();
            }
        }
        private byte _rStickY = 127;
        public byte RStickY
        {
            get => _rStickY;
            set
            {
                _rStickY = value;
                RaiseStateChanged();
            }
        }
        private bool _thumbLeft = false;
        public bool ThumbLeft
        {
            get => _thumbLeft;
            set
            {
                _thumbLeft = value;
                RaiseStateChanged();
            }
        }
        private bool _thumbRight = false;
        public bool ThumbRight
        {
            get => _thumbRight;
            set
            {
                _thumbRight = value;
                RaiseStateChanged();
            }
        }
    }

    public class ReportFactory
    {
        public DualShock4Report GetReport(Ds4State state)
        {
            var report = new DualShock4Report();

            report.SetDPad(GetDpad(state));
            report.SetButtons(GetButtons(state));
            report.SetSpecialButtons(GetSpecialButtons(state));
            report.SetAxis(DualShock4Axes.LeftThumbX, state.LStickX);
            report.SetAxis(DualShock4Axes.LeftThumbY, state.LStickY);
            report.SetAxis(DualShock4Axes.RightThumbX, state.RStickX);
            report.SetAxis(DualShock4Axes.RightThumbY, state.RStickY);
            report.SetAxis(DualShock4Axes.LeftTrigger, state.L2 ? byte.MaxValue : byte.MinValue);
            report.SetAxis(DualShock4Axes.RightTrigger, state.R2 ? byte.MaxValue : byte.MinValue);

            return report;
        }

        private DualShock4SpecialButtons[] GetSpecialButtons(Ds4State state)
        {
            return GetSpecialButtonsIterator(state).ToArray();
        }

        private IEnumerable<DualShock4SpecialButtons> GetSpecialButtonsIterator(Ds4State state)
        {
            if (state.PlayStation)
            {
                yield return DualShock4SpecialButtons.Ps;
            }
            if (state.Touchpad)
            {
                yield return DualShock4SpecialButtons.Touchpad;
            }
        }

        private DualShock4Buttons[] GetButtons(Ds4State state)
        {
            return GetButtonsIterator(state).ToArray();
        }

        private IEnumerable<DualShock4Buttons> GetButtonsIterator(Ds4State state)
        {
            if (state.Circle)
            {
                yield return DualShock4Buttons.Circle;
            }

            if (state.Cross)
            {
                yield return DualShock4Buttons.Cross;
            }

            if (state.Triangle)
            {
                yield return DualShock4Buttons.Triangle;
            }

            if (state.Square)
            {
                yield return DualShock4Buttons.Square;
            }

            if (state.L1)
            {
                yield return DualShock4Buttons.ShoulderLeft;
            }

            if (state.L2)
            {
                yield return DualShock4Buttons.TriggerLeft;
            }

            if (state.R1)
            {
                yield return DualShock4Buttons.ShoulderRight;
            }

            if (state.R2)
            {
                yield return DualShock4Buttons.TriggerRight;
            }

            if (state.Share)
            {
                yield return DualShock4Buttons.Share;
            }

            if (state.Options)
            {
                yield return DualShock4Buttons.Options;
            }

            if (state.ThumbLeft)
            {
                yield return DualShock4Buttons.ThumbLeft;
            }

            if (state.ThumbRight)
            {
                yield return DualShock4Buttons.ThumbRight;
            }
        }

        private DualShock4DPadValues GetDpad(Ds4State state)
        {
            if (state.DPadDown)
            {
                return DualShock4DPadValues.South;
            }
            else if (state.DPadLeft)
            {
                return DualShock4DPadValues.West;
            }
            else if (state.DPadLeftDown)
            {
                return DualShock4DPadValues.Southwest;
            }
            else if (state.DPadLeftUp)
            {
                return DualShock4DPadValues.Northwest;
            }
            else if (state.DPadRight)
            {
                return DualShock4DPadValues.East;
            }
            else if (state.DPadRightDown)
            {
                return DualShock4DPadValues.Southeast;
            }
            else if (state.DPadRightUp)
            {
                return DualShock4DPadValues.Northeast;
            }
            else if (state.DPadUp)
            {
                return DualShock4DPadValues.North;
            }
            else
            {
                return DualShock4DPadValues.None;
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViGEmClient _client;
        private readonly DualShock4Controller _controller;
        private readonly ReportFactory _reportFactory;
        private readonly Ds4State _ds4State = new Ds4State();

        public MainWindow()
        {
            InitializeComponent();

            _client = new ViGEmClient();
            _controller = new DualShock4Controller(_client);
            _reportFactory = new ReportFactory();
        }

        private void _ds4State_StateChanged()
        {
            ReportState();
        }

        private void MainWindow_OnDeactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _controller.Disconnect();
            _controller.Dispose();
            _client.Dispose();
        }

        private void ReportState()
        {
            var report = _reportFactory.GetReport(_ds4State);
            _controller.SendReport(report);
        }

        private void Left_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.DPadLeft = true;
        }

        private void Left_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.DPadLeft = false;
        }

        private void Up_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.DPadUp = true;
        }

        private void Up_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.DPadUp = false;
        }

        private void Right_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.DPadRight = true;
        }

        private void Right_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.DPadRight = false;
        }

        private void Down_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.DPadDown = true;
        }

        private void Down_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.DPadDown = false;
        }

        private void Square_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.Square = true;
        }

        private void Square_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.Square = false;
        }

        private void Triangle_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.Triangle = true;
        }

        private void Triangle_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.Triangle = false;
        }

        private void Circle_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.Circle = true;
        }

        private void Circle_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.Circle = false;
        }

        private void Cross_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.Cross = true;
        }

        private void Cross_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.Cross = false;
        }

        private void LeftDown_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.DPadLeftDown = true;
        }

        private void LeftDown_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.DPadLeftDown = false;
        }

        private void RightDown_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.DPadRightDown = true;
        }

        private void RightDown_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.DPadRightDown = false;
        }

        private void LeftUp_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.DPadLeftUp = true;
        }

        private void LeftUp_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.DPadLeftUp = false;
        }

        private void RightUp_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.DPadRightUp = true;
        }

        private void RightUp_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.DPadRightUp = false;
        }

        private void L1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.L1 = true;
        }

        private void L1_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.L1 = false;
        }

        private void L2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.L2 = true;
        }

        private void L2_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.L2 = false;
        }

        private void R1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.R1 = true;
        }

        private void R1_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.R1 = false;
        }

        private void R2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.R2 = true;
        }

        private void R2_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.R2 = false;
        }

        private void Options_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.Options = true;
        }

        private void Options_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.Options = false;
        }

        private void Share_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.Share = true;
        }

        private void Share_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.Share = false;
        }

        private void PlayStation_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.PlayStation = true;
        }

        private void PlayStation_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.PlayStation = false;
        }
                
        private TouchPoint _lStickStart = null;
        private TouchPoint _lStickCurrent = null;

        private void LStick_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _lStickStart = e.GetTouchPoint(this);
            _lStickCurrent = _lStickStart;
        }

        private void LStick_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _lStickStart = null;
            _lStickCurrent = null;

            bool leftStickMoved = _leftDeltaMin < (-_deadzone) || _deadzone < _leftDeltaMax;

            if (!leftStickMoved)
            {
                _ds4State.ThumbLeft = true;
                _ds4State.ThumbLeft = false;
            }

            _leftDeltaMin = 0;
            _leftDeltaMax = 0;
            _ds4State.LStickX = 127;
            _ds4State.LStickY = 127;
        }

        private TouchPoint _rStickStart = null;
        private TouchPoint _rStickCurrent = null;

        private void RStick_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _rStickStart = e.GetTouchPoint(this);
            _rStickCurrent = _rStickStart;
        }

        private double _rightDeltaMin = 0;
        private double _rightDeltaMax = 0;
        private double _leftDeltaMin = 0;
        private double _leftDeltaMax = 0;

        private void RStick_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _rStickStart = null;
            _rStickCurrent = null;

            bool rightStickMoved = _rightDeltaMin < (-_deadzone) || _deadzone < _rightDeltaMax;

            if (!rightStickMoved)
            {
                _ds4State.ThumbRight = true;
                _ds4State.ThumbRight = false;
            }

            _rightDeltaMin = 0;
            _rightDeltaMax = 0;
            _ds4State.RStickX = 127;
            _ds4State.RStickY = 127;
        }

        private void LStick_TouchMove(object sender, TouchEventArgs e)
        { 
            _lStickCurrent = e.GetTouchPoint(this);
            _lStickStart = _lStickStart ?? _lStickCurrent;

            var x = _lStickCurrent.Position.X - _lStickStart.Position.X;
            var y = _lStickCurrent.Position.Y - _lStickStart.Position.Y;

            if (x < _leftDeltaMin)
            {
                _leftDeltaMin = x;
            }
            if (y < _leftDeltaMin)
            {
                _leftDeltaMin = y;
            }
            if (_leftDeltaMax < x)
            {
                _leftDeltaMax = x;
            }
            if (_leftDeltaMax < y)
            {
                _leftDeltaMax = y;
            }

            _ds4State.LStickX = MassageDelta(x);
            _ds4State.LStickY = MassageDelta(y);
        }

        private int _deadzone = 1;

        private byte MassageDelta(double delta)
        {
            // if the delta is within the deadzone, set it to zero
            if (-_deadzone <= delta && delta <= _deadzone)
            {
                delta = 0;
            }

            // remove the deadzone margin from the delta, so the stick doesn't jump 
            // by the deadzone value once it's out of the deadzone
            // delta is positive
            if (0 < delta)
            {
                delta = delta - _deadzone;
            }
            // delta is negative
            else if (delta < 0)
            {
                delta = delta + _deadzone;
            }

            delta = delta * 1.5d;

            // "zero" is 127
            delta = delta + 127;

            if (delta > byte.MaxValue)
            {
                delta = byte.MaxValue;
            }
            else if (delta < byte.MinValue)
            {
                delta = byte.MinValue;
            }

            return (byte)delta;
        }

        private void RStick_TouchMove(object sender, TouchEventArgs e)
        {
            _rStickCurrent = e.GetTouchPoint(this);
            _rStickStart = _rStickStart ?? _rStickCurrent;
                        
            var x = _rStickCurrent.Position.X - _rStickStart.Position.X;
            var y = _rStickCurrent.Position.Y - _rStickStart.Position.Y;

            if (x < _rightDeltaMin)
            {
                _rightDeltaMin = x;
            }
            if (y < _rightDeltaMin)
            {
                _rightDeltaMin = y;
            }
            if (_rightDeltaMax < x)
            {
                _rightDeltaMax = x;
            }
            if (_rightDeltaMax < y)
            {
                _rightDeltaMax = y;
            }

            _ds4State.RStickX = MassageDelta(x);
            _ds4State.RStickY = MassageDelta(y);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ds4State.StateChanged += _ds4State_StateChanged;

            _controller.Connect();
        }

        private void TouchPad_TouchMove(object sender, TouchEventArgs e)
        {

        }

        private void TouchPad_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            _ds4State.Touchpad = false;
        }

        private void TouchPad_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            _ds4State.Touchpad = true;
        }
    }
}
using Honeycomb.UI.BaseComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Honeycomb.UI.Utils;
namespace Honeycomb.UI
{
   

    public class HoneycombComboBox : ValidateOnEnterComboBox, ISelectable
    {
        const bool ALLOW_COMBOBOX_SCROLL = false;

      

        private readonly object _lock = new();
        private readonly ISelectable _iSelectable;


        //This is only used for ComboBoxes with DropDownStyle = DropDownList
        private (int Index, string Text, Rectangle Bounds) _lastHighlightedItem = (-1, string.Empty, Rectangle.Empty);


        private Action<EventArgs> _onDropDownClosedAction = delegate { };
        private Action<EventArgs> _onDropDownAction = delegate { };
        private Action<DrawItemEventArgs> _onDrawItemAction = delegate { };

        public HoneycombComboBox()
        {
            _iSelectable = this;

            OnDropDownStyleChanged(EventArgs.Empty); //Initialize event handlers
        }

        //public event EventHandler<IsEmptyChangedEventArgs> IsEmptyChanged = delegate { };

        [DefaultValue(true)]
        public bool Selectable { get; set; } = true;

      


        protected override void OnDropDownStyleChanged(EventArgs e)
        {
            base.OnDropDownStyleChanged(e);

            switch (DropDownStyle)
            {
                case ComboBoxStyle.DropDownList:
                    DrawMode = DrawMode.OwnerDrawFixed;
                    _onDropDownAction = OnDropDown_DropDownList;
                    _onDrawItemAction = OnDrawItem_DropDownList;
                    _onDropDownClosedAction = OnDropDownClosed_DropDownList;
                    break;

                default:
                    DrawMode = default;
                    _onDropDownAction = base.OnDropDown;
                    _onDrawItemAction = base.OnDrawItem;
                    _onDropDownClosedAction = base.OnDropDownClosed;
                    break;
            }

            AdjustControlSize();
        }


       

        protected override void OnDropDownClosed(EventArgs e)
        {
            base.OnDropDownClosed(e);        
        }

        protected override void OnDropDown(EventArgs e)
        {
            _onDropDownAction(e);
        }
      

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            _onDrawItemAction(e);
        }

        protected virtual void OnDropDown_DropDownList(EventArgs e)
        {
            base.OnDropDown(e);
            
        }

        protected virtual void OnDropDownClosed_DropDownList(EventArgs e)
        {
            base.OnDropDownClosed(e);
        }

        readonly Color HOT_COLOR = Color.LightBlue;
        readonly Color BACK_COLOR = Color.White;

        protected virtual void OnDrawItem_DropDownList(DrawItemEventArgs e)
        {

            var Brush = Brushes.Black;
            Color _backColor;

            string _text = e.Index != -1 ? Items[e.Index].ToString()! : this.Text;

            if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
            {     
                _backColor = this.HasMouse()? HOT_COLOR : BACK_COLOR;

                e.Graphics.FillRectangle(new SolidBrush(_backColor), e.Bounds);
                e.Graphics.DrawString(_text, Font, Brush, e.Bounds, StringFormat.GenericDefault);
                //ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
            }
            else if (e.Index != _lastHighlightedItem.Index)
            {
                SuspendLayout();
                //If we are opening the dropdown, we prevent the control from highlighting the last item
                if (DroppedDown & e.Index == Items.Count-1)
                {
                   
                    _backColor = BACK_COLOR;
                }
                else
                {
                    _backColor = HOT_COLOR;
                }
               
                e.Graphics.FillRectangle(new SolidBrush(_backColor), e.Bounds);
                e.Graphics.DrawString(_text, Font, Brush, e.Bounds, StringFormat.GenericDefault);

                e.Graphics.FillRectangle(new SolidBrush(BACK_COLOR), _lastHighlightedItem.Bounds);
                e.Graphics.DrawString(_lastHighlightedItem.Text, Font, Brush, _lastHighlightedItem.Bounds, StringFormat.GenericDefault);

                _lastHighlightedItem = (e.Index, _text, e.Bounds);
                ResumeLayout();
            }
            else if (e.Bounds != _lastHighlightedItem.Bounds)
            {
                e.Graphics.FillRectangle(new SolidBrush(BACK_COLOR), e.Bounds);
                e.Graphics.DrawString(_text, Font, Brush, e.Bounds, StringFormat.GenericDefault);
            }

            //Console.WriteLine($"currentIndex: {e.Index} \t pos: {e.Bounds.GetCenter()} ");
        }

        private void AdjustControlSize()
        {
            // Calculate the height of the control based on the font size and the padding
            ItemHeight = (int)this.Font.GetHeight() + this.Padding.Top + this.Padding.Bottom + 2;

           
        }
  
      
       

        protected override void WndProc(ref Message m)
        {
            _iSelectable.WndProc(ref m);
            base.WndProc(ref m);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (!ALLOW_COMBOBOX_SCROLL) 
            {
                ((HandledMouseEventArgs)e).Handled = true;
            }
            base.OnMouseWheel(e);
        }
    }

}

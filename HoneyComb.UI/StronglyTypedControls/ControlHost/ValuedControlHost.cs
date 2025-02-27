using Honeycomb.UI.BaseComponents;
using Honeycomb.UI.BaseComponents.TextBoxParsers;
using Honeycomb.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Honeycomb.UI.BaseComponents.TextBoxVerifiers;
using Honeycomb.UI.StronglyTypedControls.ControlHost;
using System.Diagnostics.CodeAnalysis;
using HoneyComb.UI.StronglyTypedControls;
using HoneyComb.UI.BaseComponents.MultiSelect;

namespace Honeycomb.UI.StronglyTypedControls
{
    public abstract class ValuedControlHost<TControl, T> : ContainerControl, IValuedControlHost<TControl, T> , IHighlightableText
        where TControl : Control, new()
        where T : struct, IEquatable<T>
    {

        /// <summary>
        /// Null corresponds to a valid previous value that failed to parse. This allows us to update the UI correctly whenever 
        /// the user/sms inputs a defaut value for a particular datatype 
        /// </summary>
        private T? _prevValue = null;

       

        private bool _available = true;

        protected bool _highlighted = IHighlightable.HIGHLIGHTED_;
        protected Font _defaultFont = (Font)new FontConverter().ConvertFromString(IHighlightableText.DEFAULT_FONT)!;
        protected Font _highlightedFont = (Font)new FontConverter().ConvertFromString(IHighlightableText.HIGHLIGHTED_FONT)!;
        protected Color _defaultBackColor = (Color)new ColorConverter().ConvertFromString(IHighlightable.DEFAULT_BACK_COLOR)!;
        protected Color _defaultForeColor = (Color)new ColorConverter().ConvertFromString(IHighlightable.DEFAULT_FORE_COLOR)!;
        protected Color _highlightedBackColor = (Color)new ColorConverter().ConvertFromString(IHighlightable.HIGHLIGHTED_BACK_COLOR)!;
        protected Color _highlightedForeColor = (Color)new ColorConverter().ConvertFromString(IHighlightable.HIGHLIGHTED_FORE_COLOR)!;

        public event EventHandler HighlightedChanged = delegate { };

    
        public ValuedControlHost(IControlParser<T> parser, Dictionary<Guid, IControlVerifier<T>>?miscVerifiers = null)
        {
            Child = new();
            RegisterChildHandlers(Child);

            Parser = parser;
            Verifiers = new Dictionary<Guid, IControlVerifier<T>>()
            {
                {RequiredControlVerifier.TypeId, new RequiredControlVerifier<T>(enabled: true) },
            }
            .Concat(miscVerifiers ?? new Dictionary<Guid, IControlVerifier<T>>()).
            ToDictionary(x => x.Key, x=> x.Value);


            foreach (IControlVerifier<T> verifier in Verifiers.Values)
            {
                verifier.Parent = this;
            }

            this.Tag = new StronglyTypedTag() { PasteableFromExcel = true };
        }

        /// <summary>
        /// Value that will be removed from <see cref="ComboBox.Items"/> the next time Child text changes.  
        /// </summary>
        /// <remarks>
        /// Only used when <see cref="Child"/> inherits from <see cref="ComboBox"/> and has <see cref="ComboBox.DropDownStyle"/> set to <see cref="ComboBoxStyle.DropDownList"/>
        /// </remarks>
        public string? TemporaryText { get; set; } = null;

        /// <summary>
        /// Flag indicating if there is a valid _prevValue when <see cref="TryGetValue(out T)"/> is called or if control instead needs to run parsing + verifying logic
        /// </summary>
        /// <remarks>
        /// This is mainly used as an optimization to prevent redundant parsing + verifying
        /// </remarks>
        public virtual bool Dirty 
        { 
            get; 
            protected set; 
        } = false;


        public virtual T? Value
        {
            get
            {
                if (TryGetValue(out T value))
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }   
            set
            {
                if (value.HasValue)
                {
                    SetValue(value.Value);
                }
            }
        }

        public  Dictionary<Guid,IControlVerifier<T>> Verifiers { get; }

        public  IControlParser<T> Parser { get; }


        public event EventHandler AvailabilityChanged = delegate { };

        protected void SetChildText(in string newValue)
        {
            switch (Child)
            {
                case ComboBox cBox:   
                    
                    //If the current comboBox is registered as a dropDownList, we cannot set the text to anything that isn't inside the textbox's items
                    //This is an awful workaround to that specific corner case
                    if (cBox.DropDownStyle == ComboBoxStyle.DropDownList)
                    {     
                        //Remove temporary items from dropdown(if needed)
                        if( TemporaryText != null && cBox.Items.Contains(TemporaryText))
                        {
                            cBox.Items.Remove(TemporaryText);
                        }

                        if (!cBox.Items.Contains(newValue))
                        {
                            cBox.Items.Add(newValue);

                            //Mark that this value needs to be removed from Items next time child text changes
                            TemporaryText = newValue;
                        }
                        else
                        {
                            TemporaryText = null;
                        }
                    }

                    cBox.Text = newValue;
                    break;

                default: 
                    Child.Text = newValue;
                    break;

                case null:
                    break;
            }
        }

        public void SetPrevValue(in T? value)
        {
            _prevValue = value;

            Dirty = false;
        }

        bool TryGetPrevValue(out T value)
        {
            if (!Dirty && _prevValue.HasValue)
            {
                value = _prevValue.Value;
                return true;
            }
            else
            {
                value = default; 
                return false; 
            }
        }

        public void SetValue(in T value)
        {
            //Do nothing if we are not actually updating anything in a meaningful way
            if(_prevValue.HasValue && value.Equals(_prevValue.Value)){ return; }

            //Update actual text that is shown
            SetChildText(Parser.ConvertToString(value));

            _prevValue = value;
        }

        public virtual bool TryGetValue(out T value)
        {          
            //If control is not available we automatically assume that we cannot get a value out of it
            if(!Available)
            {
                value = default;
                return false;
            }
            if (TryGetPrevValue(out value))
            {
                return true;             
            }

            bool couldParse = Parser.TryParse(Text, out value);
            if (couldParse)
            {
                //Check to see if we need to apply formatting to value if we can parse it
                string newText = Parser.ConvertToString(value);
                if (Text != newText)
                {
                    SetChildText(newText);
                }
            }

            bool couldVerify = Verify((couldParse, value));
            if (couldVerify)
            {
                SetPrevValue(couldParse? value: default);                
            }
         
            return couldVerify;
        }

        public bool Verify(in (bool couldParse, T parsedValue) tryParseResult)
        {
            
            bool couldVerify = true;

            IEnumerable<IControlVerifier<T>> enabledVerifiers =
                from verifier in Verifiers.Values
                where verifier.Enabled
                select verifier;

            foreach (var verifier in enabledVerifiers)
            {
                couldVerify &= verifier.Verify(tryParseResult);
            }

            return couldVerify;
        }


        public bool Available { 
            get => _available;
            set
            {
                if(value != _available) 
                {
                    _available = value;
                    OnAvailibilityChanged(EventArgs.Empty);
                }
            }
        }

        [DefaultValue(true)]
        public bool PasteableFromExcel
        {
            get=> (Tag as IExcelPasteTarget)!.PasteableFromExcel;
            set => (Tag as IExcelPasteTarget)!.PasteableFromExcel = value;
        }

        [DefaultValue(RequiredControlVerifier.IS_REQUIRED_DEFAULT)]
        public bool IsRequired
        {
            get => (Verifiers[RequiredControlVerifier.TypeId] as RequiredControlVerifier<T>)!.IsRequired;
            set => (Verifiers[RequiredControlVerifier.TypeId] as RequiredControlVerifier<T>)!.IsRequired = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TControl Child { get; set; }

     
        [DefaultValue(IControlParser.DEFAULT_SUFFIX)]
        public string Suffix 
        { 
            get => Parser.Suffix; 
            set => Parser.Suffix = value; 
        } 

        [DefaultValue(IControlParser.DEFAULT_PREFIX)]
        public string Prefix 
        {
            get => Parser.Prefix;
            set => Parser.Prefix = value;
        }

        protected virtual void OnAvailibilityChanged(EventArgs e)
        {

            if (Available)
            {
                Visible = true;
            }
            else
            {
                Visible = false;
            }
            AvailabilityChanged?.Invoke(this, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    OnValidating(new());
                    e.Handled = true;
                    break;
            }
        }

        #region IHighlightedChanged

        [Category("Appearance")]
        [DefaultValue(false)]
        public virtual bool Highlighted
        {
            get => _highlighted;
            set
            {
                (this as IHighlightableText).SetHighlighted(ref _highlighted, value);
                OnHighlightChanged(EventArgs.Empty);
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Font), IHighlightableText.DEFAULT_FONT)]
        public new Font DefaultFont
        {
            get => _defaultFont;
            set => (this as IHighlightableText).SetDefaultFont(ref _defaultFont, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Font), IHighlightableText.HIGHLIGHTED_FONT)]
        public Font HighlightedFont
        {
            get => _highlightedFont;
            set => (this as IHighlightableText).SetHighlightedFont(ref _highlightedFont, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.DEFAULT_FORE_COLOR)]
        public new Color DefaultForeColor
        {
            get => _defaultForeColor;
            set => (this as IHighlightableText).SetDefaultForeColor(ref _defaultForeColor, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.DEFAULT_BACK_COLOR)]
        public new Color DefaultBackColor
        {
            get => _defaultBackColor;
            set => (this as IHighlightableText).SetDefaultBackColor(ref _defaultBackColor, value);
        }


        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.HIGHLIGHTED_FORE_COLOR)]
        public Color HighlightedForeColor
        {
            get => _highlightedForeColor;
            set => (this as IHighlightableText).SetHighlightedForeColor(ref _highlightedForeColor, value);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), IHighlightable.HIGHLIGHTED_BACK_COLOR)]
        public Color HighlightedBackColor
        {
            get => _highlightedBackColor;
            set => (this as IHighlightableText).SetHighlightedBackColor(ref _highlightedBackColor, value);
        }

        protected virtual void OnHighlightChanged(EventArgs e)
        {
            Invalidate();
            HighlightedChanged?.Invoke(this, e);
        }

        #endregion

        #region Child Handlers + Utilities

        public new Size Size
        {
            get => Child.Size;
            set => Child.Size = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get => Child.Text;
            set
            {
                if (value != this.Text)
                {
                    Dirty = true;
                    SetChildText(value);
                }   
            } 
        }

        public override Font Font
        {
            get => base.Font;
            set => Child.Font = value;
        }

        public override Color BackColor
        {
            get => base.BackColor;
            set => Child.BackColor = value;
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set => Child.ForeColor = value;
        }


        public void SelectAll()
        {
            switch (Child)
            {
                case ComboBox child: child.SelectAll(); break;
                case TextBoxBase child: child.SelectAll(); break;
                default: break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Size = base.Size;
        }

        protected virtual void OnChildBackColorChanged(object? sender, EventArgs e)
        {
            base.BackColor = Child.BackColor;
        }
        protected virtual void OnChildFontChanged(object? sender, EventArgs e)
        {
            base.Font = Child.Font;
        }
        protected virtual void OnChildForeColorChanged(object? sender, EventArgs e)
        {
            base.ForeColor = Child.ForeColor;
        }
        protected virtual void OnChildSizeChanged(object? sender, EventArgs e)
        {
            base.Size = Child.Size;
        }

        protected virtual void OnChildKeyPress(object? sender, KeyPressEventArgs e) => OnKeyPress(e);

        protected virtual void OnChildResize(object? sender, EventArgs e) => OnResize(e);
        protected virtual void OnChildTextChanged(object? sender, EventArgs e)  => OnTextChanged(e);
        protected virtual void OnChildValidated(object? sender, EventArgs e) { }// OnValidated(e);
        protected virtual void OnChildValidating(object? sender, CancelEventArgs e)          
        {
            OnValidating(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            Dirty = true;
            if (TryGetValue(out T result))
            {              
                base.OnValidating(e);
                SetChildText(Parser.ConvertToString(result));
            };
        }


        protected virtual void RegisterChildHandlers(TControl child)
        {
            Controls.Add(child);

            child.BackColorChanged += OnChildBackColorChanged;         
            child.FontChanged += OnChildFontChanged;
            child.ForeColorChanged += OnChildForeColorChanged;          
            child.Resize += OnChildResize;
            child.SizeChanged += OnChildSizeChanged;
            child.KeyPress += OnChildKeyPress;
            child.Validating += OnChildValidating;
            OnChildSizeChanged(this, EventArgs.Empty); 
        }

        #endregion
    }

}

using Honeycomb.UI.BaseComponents.TextBoxParsers;
using HoneyComb.UI.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.ControlHost
{
    public static class ComboBoxHostExtension 
    {
        public const string NULL_LABEL_DEFAULT = "--";
        public const bool AUTO_SORT_DEFAULT = true;
        public const bool PREPEND_NULL_VALUE_DEFAULT = true;
    }

    public sealed class ComboBoxHostExtension<TControl, T>
        where TControl : ComboBox, new()
        where T : struct, IEquatable<T>
    {
     

        private T[] _rawValues;

        public ComboBoxHostExtension(ValuedControlHost<TControl, T> parent, ComboBox child)
        {
            Parent = parent;
            Child = child;
            Child.SelectedValueChanged += ChildSelectedValueChanged;


            _rawValues = Array.Empty<T>();


            Child.DropDownClosed += (object? sender, EventArgs e) =>
            {
                CanValidateOnSelectedValueChange = true;
            };

            Child.MouseEnter += (object? sender, EventArgs e) =>
            {
                CanValidateOnSelectedValueChange = true;
            };
        }

        public ComboBox Child { get; }
        public ValuedControlHost<TControl, T> Parent { get; }

        //This is a safeguard to prevent runaway validation loops
        private bool CanValidateOnSelectedValueChange { get; set; } = true;

        public string NullLabel { get; set; } = ComboBoxHostExtension.NULL_LABEL_DEFAULT;
        public bool AutoSort { get; set; } = ComboBoxHostExtension.AUTO_SORT_DEFAULT;
        public bool PrependNullValue { get; set; } = ComboBoxHostExtension.PREPEND_NULL_VALUE_DEFAULT;
    
        //public Func<bool>? TryUpdateRawValuesCallback;
        public Func<IEnumerable<T>, IEnumerable<T>>? AutoSortCallback { get; set; } = x => x.Order();
 
       
        public IEnumerable<T> RawValues { 
            get => _rawValues.AsEnumerable();
            set
            {
                switch (Child.DropDownStyle)
                {
                    case ComboBoxStyle.DropDownList:
                        var prevChildText = Child.Text;

                        _rawValues = value.ToArray();
                        Child.Items.Clear();
                        Child.Items.AddRange(GenItems(_rawValues));
                        Child.DropDownWidth = CalcDropdownWidth(Child);

                        //Mark that we no longer have to clear temporary text if it now a valid value within dropdown
                        if (Child.Items.Contains(Parent.TemporaryText))
                        {
                            Parent.TemporaryText = null;
                        }

                        Child.Text = prevChildText;
                        break;

                    default:
                        _rawValues = value.ToArray();                   
                        Child.Items.Clear();
                        Child.Items.AddRange(GenItems(_rawValues));
                        Child.DropDownWidth = CalcDropdownWidth(Child);

                        break;
                }              
            } 
        }



        private string[] GenItems(in IEnumerable<T> values)
        {
            return values
                .Distinct()
                .If(AutoSort && AutoSortCallback!=null, AutoSortCallback!)          //Sort passed value if flag is set
                .Select(value => Parent.Parser.ConvertToString(value))              //Convert sorted values to labels that TextBox will show
                .If(PrependNullValue, labels => labels.Prepend(NullLabel))          //Prepend null value if necessary
                .ToArray();                                                         //Dump results to array

        }

        private static int CalcDropdownWidth(ComboBox child)
        {
            int maxWidth = child.Width, currentWidth = 0;
            foreach (var obj in child.Items)
            {
                currentWidth = TextRenderer.MeasureText(obj.ToString() + "  ", child.Font).Width;
                if (currentWidth > maxWidth)
                {
                    maxWidth = currentWidth;
                }
            }
            return maxWidth;
        }

        void ChildSelectedValueChanged(object? sender, EventArgs e) 
        {
            if(CanValidateOnSelectedValueChange)
            {
                Parent.Validate();
                CanValidateOnSelectedValueChange = false;
            }
        }



    }
}

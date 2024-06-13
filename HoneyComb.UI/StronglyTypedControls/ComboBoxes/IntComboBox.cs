using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel;
using Honeycomb.UI.Interfaces;
using Honeycomb.UI.BaseComponents.TextBoxVerifiers;
using Honeycomb.UI.StronglyTypedControls.ControlHost;
using Honeycomb.UI.BaseComponents;

namespace Honeycomb.UI.StronglyTypedControls.ComboBoxes
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class IntComboBox : NumericControlHost<HoneycombComboBox, int>
    {
        public IntComboBox(Dictionary<Guid, ITextBoxVerifier<int>>? miscVerifiers = null) : base(
           new Dictionary<Guid, ITextBoxVerifier<int>>()
           {
                {ComboBoxRangeVerifier.TypeId, new ComboBoxRangeVerifier<HoneycombComboBox,int>(enabled: true) }
           }
           .Concat(miscVerifiers ?? new Dictionary<Guid, ITextBoxVerifier<int>>())
           .ToDictionary(x => x.Key, x => x.Value))
        {
            ComboBoxExtension = new(this, Child);

            //Now that required extension object has been instantiated, we pass it to verifier so that it actually calculate valid ranges properly
            (Verifiers[ComboBoxRangeVerifier.TypeId] as ComboBoxRangeVerifier<HoneycombComboBox, int>)!.ComboBoxExtension = ComboBoxExtension;
        }

        public ComboBoxHostExtension<HoneycombComboBox, int> ComboBoxExtension { get; }


        [DefaultValue(ComboBoxRangeVerifier.AUTO_CALCULATE_VALID_RANGE_DEFAULT)]
        public bool AutoCalculateValidRange
        {
            get => Verifiers[ComboBoxRangeVerifier.TypeId].Enabled;
            set => Verifiers[ComboBoxRangeVerifier.TypeId].Enabled = value;
        }

        public override string FormatString
        {
            get => base.FormatString;
            set
            {
                base.FormatString = value;
                (Verifiers[ComboBoxRangeVerifier.TypeId] as ComboBoxRangeVerifier<HoneycombComboBox, int>)!.FormatString = value;
            }
        }

        [DefaultValue(ComboBoxHostExtension.NULL_LABEL_DEFAULT)]
        public string NullLabel
        {
            get => ComboBoxExtension.NullLabel;
            set => ComboBoxExtension.NullLabel = value;
        }

        [DefaultValue(ComboBoxHostExtension.PREPEND_NULL_VALUE_DEFAULT)]
        public bool PrependNullValue
        {
            get => ComboBoxExtension.PrependNullValue;
            set => ComboBoxExtension.PrependNullValue = value;
        }

        [DefaultValue(ComboBoxHostExtension.AUTO_SORT_DEFAULT)]
        public bool AutoSort
        {
            get => ComboBoxExtension.AutoSort;
            set => ComboBoxExtension.AutoSort = value;
        }

        public IEnumerable<int> RawValues
        {
            get => ComboBoxExtension.RawValues;
            set => ComboBoxExtension.RawValues = value;
        }

        public int SelectedIndex
        {
            get => Child.SelectedIndex;
            set => Child.SelectedIndex = value;
        }

        public ComboBoxStyle DropdownStyle
        {
            get => Child.DropDownStyle;
            set => Child.DropDownStyle = value;
        }

        public ComboBox.ObjectCollection Items => Child.Items;
    }
}

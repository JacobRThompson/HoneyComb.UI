using Honeycomb.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Honeycomb.UI.BaseComponents;

namespace Honeycomb.UI.StronglyTypedControls.TextBoxes
{
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class StringTextBox: StringControlHost<ValidateOnEnterTextBox> , ISelectable
    {
        public bool Selectable
        {
            get => Child.Selectable;
            set => Child.Selectable = value;
        }   
    }

}


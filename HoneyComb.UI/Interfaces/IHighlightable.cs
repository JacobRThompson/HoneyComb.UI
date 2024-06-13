using Honeycomb.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public interface IHighlightable: IColored
    {
        public const bool HIGHLIGHTED_ = false;

        public const string DEFAULT_BACK_COLOR = "ControlLight";
        public const string DEFAULT_FORE_COLOR = "ControlText";
        public const string HIGHLIGHTED_BACK_COLOR = "Info";
        public const string HIGHLIGHTED_FORE_COLOR = DEFAULT_FORE_COLOR;


        public event EventHandler HighlightedChanged;
    

        public bool Highlighted { get; set; }
       
        public Color DefaultForeColor { get; set; }
        public Color DefaultBackColor { get; set; }

        public Color HighlightedForeColor { get; set; }
        public Color HighlightedBackColor { get; set; }

        public void SetHighlighted(ref bool _highlighted, bool value)
        {
            _highlighted = value;
            ForeColor = value? HighlightedForeColor : DefaultForeColor;  
            BackColor = value? HighlightedBackColor : DefaultBackColor;
        }

        public void SetHighlightedBackColor(ref Color _highlightedBackColor, Color value)
        {
            _highlightedBackColor = value;
            if (Highlighted) 
            { 
                BackColor = value; 
            }
        }

        public void SetHighlightedForeColor(ref Color _highlightedForeColor, Color value)
        {
            _highlightedForeColor = value;
            if (Highlighted) 
            {
                ForeColor = value; 
            }
        }

        public void SetDefaultBackColor(ref Color _defaultBackColor, Color value)
        {
            _defaultBackColor = value;
            if (!Highlighted) 
            {
                BackColor = value;
            }
        }

        public void SetDefaultForeColor(ref Color _defaultForeColor, Color value)
        {
            _defaultForeColor = value;
            if (!Highlighted) 
            { 
                ForeColor = value; 
            }
        }



    }

    public static class IHighlightableExtensions
    {
        public static Color GetIconForeColor(this IHighlightable obj) => obj.Highlighted ? SystemColors.HighlightText.ToAlpha(obj.ForeColor.A) : obj.ForeColor;

        public static Color GetIconBackColor(this IHighlightable obj) => obj.Highlighted ? SystemColors.Highlight.ToAlpha(obj.BackColor.A) : obj.BackColor;

    }
}

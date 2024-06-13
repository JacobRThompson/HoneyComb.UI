using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.Utils
{
    public static class Win32Extensions
    {
        // Constants used by the Win32 API functions
        private const int CB_GETCOMBOBOXINFO = 0x164;  // Get information about the combobox control
        private const int CBI_STYLE = 0x2;             // Style bit indicating that the dropdown list is visible
        private const int CBN_DROPDOWN = 7;            // Notification message indicating that the dropdown list is about to be shown
        private const int WM_COMMAND = 0x111;          // Windows message indicating that a command event has occurred
        private const int LBN_SELCHANGE = 1;           // Notification message indicating that the selection in a listbox has changed
        private const int GW_CHILD = 5;                // Get the first child window
        private const int GW_HWNDNEXT = 2;             // Get the next window in the z-order

        // Struct used by the GetComboBoxInfo function to return information about the combobox control
        [StructLayout(LayoutKind.Sequential)]
        private struct COMBOBOXINFO
        {
            public int cbSize;      // Size of the structure in bytes
            public RECT rcItem;     // Coordinates of the editable area of the combobox
            public RECT rcButton;   // Coordinates of the dropdown button
            public int stateButton; // State of the dropdown button (pressed or not)
            public IntPtr hwndCombo; // Handle to the combobox control
            public IntPtr hwndEdit; // Handle to the edit control (if there is one)
            public IntPtr hwndList; // Handle to the listbox control (if there is one)
        }

        // Struct used by the COMBOBOXINFO struct to represent a rectangular area
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;        // Left coordinate of the rectangle
            public int top;         // Top coordinate of the rectangle
            public int right;       // Right coordinate of the rectangle
            public int bottom;      // Bottom coordinate of the rectangle
        }

        // Win32 API function that retrieves information about the combobox control
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref COMBOBOXINFO pcbi);

        // Win32 API function that retrieves the handle of a window that is a child of the specified window
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);

        // Win32 API function that sends a message to a window and waits for the window to process the message
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        // Public method that gets the ListBox control associated with a ComboBox control
        public static ListBox GetListBoxFromComboBox(ComboBox comboBox)
        {
            COMBOBOXINFO info = new COMBOBOXINFO();    // Create a COMBOBOXINFO structure to receive information about the combobox control
            info.cbSize = Marshal.SizeOf(info);        // Set the size of the structure

            // Call the GetComboBoxInfo function to get information about the combobox control
            if (GetComboBoxInfo(comboBox.Handle, ref info))
            {
                // Check if the dropdown list is visible
                if (info.stateButton != 0 & CBI_STYLE != 0)
                {
                    // Send the CBN_DROPDOWN message to the combobox control to get the handle of the listbox control
                    //SendMessage(info.hwndCombo, WM_COMMAND, new IntPtr(CBN_DROPDOWN), IntPtr.Zero);

                    // Get the handle of the listbox control
                    //IntPtr hwndList = GetWindow(info.hwndCombo, GW_HWNDNEXT);
                    if (info.hwndList != IntPtr.Zero)
                    {
                        // Create a ListBox control object from the handle
                        var listBox = Control.FromHandle(info.hwndList);

                        // Check if the ListBox control is the child of the combobox control
                        if (listBox?.Parent == comboBox)
                        {
                            return null;
                        }
                    }
                }
            }

            // If we got here, we were unable to get the ListBox control
            return null;
        }
    }
}

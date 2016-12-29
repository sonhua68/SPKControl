using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SPKControl
{
    class FormatItemFixed
    {
        //Code use format
        public string formatCD { get; set; } //Format Code        
        public int lengthMax { get; set; } //MaxLength Item        
        public string inputCD { get; set; } //Input Method
        public string inputMode { get; set; } //Control input        
        public bool del { get; set; } //Delete?        
        public string itemAlign { get; set; } //Align

        /// <summary>
        /// Code use display
        /// </summary>
        public string itemNM { get; set; } //Name of Item

        public DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("formatCD", typeof(string));
            table.Columns.Add("MaxLength", typeof(int));
            table.Columns.Add("InputMethod", typeof(string));
            table.Columns.Add("InputMode", typeof(string));
            table.Columns.Add("DelMode", typeof(string));
            table.Columns.Add("Align", typeof(string));
            table.Columns.Add("ItemName", typeof(string));
            return table;
        }

        public Boolean GetTextBoxProperty()
        {
            return true;
        }
    }
}

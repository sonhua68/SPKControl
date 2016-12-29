using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ECONOSAVE.General;
using SPKControl;

namespace SPKControl
{
    

    public partial class SPKTxtBox : TextBox
    {
        #region Thuộc tính
        private string myInput;
        private int myIndex;
        private string myFormat;
        private string myType;
        private int dc_place;


        public int DC_Place
        {
            get { return dc_place; }
            set { dc_place = value; }
        }


        public string MyType
        {
            get { return myType; }
            set { myType = value; }
        }

        public string MyFormat
        {
            get { return myFormat; }
            set { myFormat = value; }
        }

        public int IndexPos
        {
            get { return myIndex; }
            set { myIndex = value; }
        }

        public string InputMode
        {
            get { return myInput; }
            set { myInput = value; }
        }

        #endregion

        #region Xử lý màu sắc
        Color RDO_Color = Color.White;
        Color Sts_Error = Color.Red;
        Color Paint_DL1 = Color.Aquamarine;
        Color Paint_DL2 = Color.GreenYellow;
        #endregion

        #region Xử lý Sự kiện 
        protected override void OnLeave(EventArgs e)
        {
            switch (myType)
            {
                case "Code":
                    Text = FillCode(this.Text);
                    break;
                case "Number":
                    Text = FormatNumber(this.Text, dc_place);
                    break;
            }
            base.OnLeave(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                if (CheckInputMode() == true)
                {
                    CanInput(e);
                }
            }
            else
            {
                TabStop = false;
                Enabled = false;
                TabStop = true;
                Enabled = true;
            }            
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (myInput == "FINP" || myInput == "MINP" || myInput == "FRDO")
            {
                TabStop = true;
                Enabled = true;
            }
            else
            {
                //BackColor = RDO_Color;
                ReadOnly = true;
            }
            switch (myType)
            {
                case "Code":
                    TextAlign = HorizontalAlignment.Left;
                    break;
                case "Number":
                    TextAlign = HorizontalAlignment.Right;
                    break;
                case "Name":
                    TextAlign = HorizontalAlignment.Left;
                    break;
            }
            base.OnGotFocus(e);
        }
        #endregion

        #region Xử lý về format
        private string DuplicateCode(string txt, int num)
        {
            return txt.PadRight(num, Convert.ToChar(txt));
        }
        private string FillCode(string txt)
        {
            string rtnStr = "";
            if (myFormat.StartsWith("0"))
            {
                rtnStr = Trim(txt).PadLeft(this.MaxLength, Convert.ToChar("0"));                
            }
            return rtnStr;
        }

        private string FormatNumber(string txt, int dc_place)
        {
            if (Trim(txt) != "")
            {
                if (Convert.ToDecimal(txt) == 0)
                {
                    return "";
                }
                else
                {
                    if (dc_place < 1)
                    {
                        decimal num = Convert.ToDecimal(txt);
                        return String.Format("{0:C}", num);
                    }
                    else
                    {
                        decimal num = Convert.ToDecimal(txt);
                        return String.Format("{0:." + DuplicateCode("#", dc_place) + "}", num);
                    }
                }
            }
            else
            {
                return "";
            }            
        }
        #endregion

        #region Xử lý Input
        private bool CheckInputMode()
        {
            bool rtn = true;
            switch (myInput)
            {
                case "MINP":
                    rtn = true;
                    break;
                case "FINP":
                    rtn = true;
                    break;
                case "RDOL":
                    rtn = false;
                    break;
                case "FRDO":
                    rtn = false;
                    break;
            }
            return rtn;
        }

        private void CanInput(KeyPressEventArgs e)
        {
            if (myType == "Code" && myFormat.StartsWith("0") || myType == "Number")
            {
                if ((e.KeyChar > (char)Keys.D9 || e.KeyChar < (char)Keys.D0) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (myType == "name" || myInput == "FRDO")
                {
                    e.Handled = false;
                }
            }            
        }
        #endregion
    }
}

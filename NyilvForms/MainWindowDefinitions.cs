using NyilvLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyilvForms
{
    public partial class MainWindow : Form
    {
        //Type definitions -----------------------------------------------------------------------------------
        enum ImportCaller { Ceg, Dokumentum };  // Enum for importcommand
        class ComboboxItem
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public ComboboxItem(int id, string name) { ID = id; Name = name; }

            public ComboboxItem(Guid id, string name)
            {
                byte [] bt = id.ToByteArray();
                ID = BitConverter.ToInt32(bt,0);
                Name = name;
            }

            public override string ToString() { return Name; }
        }

        class ObjectDataField
        {
            protected System.Type type;
            public Label Label { get; set; }
            public int Number { get; set; }
            public Control DataObj { get; set; }
            public ObjectDataField(Point label, int num,string name)
            {
                Number = num;

                Label = new Label();
                Label.Location = label;
                Label.Text = name;

                var labelsize = new Size(NyilvConstants.CONTROL_XPOS_BASE - NyilvConstants.LABEL_XPOS_BASE - NyilvConstants.LABEL_MARGIN, 0);
                Label.MinimumSize = labelsize;
                Label.MaximumSize = labelsize;
                Label.AutoSize = true;
                
                Label.TextAlign = ContentAlignment.MiddleRight;                
            }

            
        }
        class TextBoxDataField : ObjectDataField
        {

           public TextBox Data { get; set; }
           public TextBoxDataField(int num, Point data, Point label, Size size, string name, object value, bool isreadonly = false)
                : base(label,num,name)
            {
                this.Data = new TextBox();
                this.Data.Location = data;
                this.Data.Size = size;
                this.Data.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
                this.Data.ReadOnly = isreadonly;

              /* BindingSource b = new BindingSource();
               b.DataSource = value;
               this.Data.DataBindings.Add("Value",b);*/

                if (value != null)
                {
                    type = value.GetType();

                    if (value is string)
                    {
                        this.Data.Text = value as string;
                    }
                    else
                    {
                        this.Data.Text = value.ToString();
                    }                    
                }
                else
                {
                    string s = "";
                    type = s.GetType();
                    this.Data.Text = s;
                }
               

                DataObj = (Control)Data;
            }
        }
        class RichTextBoxDataField : ObjectDataField
        {

            public RichTextBox Data { get; set; }
            public RichTextBoxDataField(int num, Point data, Point label, Size size, string name, object value, bool isreadonly = false)
                : base(label, num, name)
            {
                this.Data = new RichTextBox();
                this.Data.Location = data;
                this.Data.Size = size;
                this.Data.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
                this.Data.ReadOnly = isreadonly;

                if (value != null)
                {
                    type = value.GetType();

                    if (value is string)
                    {
                        this.Data.Text = value as string;
                    }
                    else
                    {
                        this.Data.Text = value.ToString();
                    }
                }
                else
                {
                    string s = "";
                    type = s.GetType();
                    this.Data.Text = s;
                }
                DataObj = (Control)Data;
            }
        }
        class ComboBoxDataField : ObjectDataField
        {
            public ComboBox Data { get; set; }
            ComboboxChangeHandlerDelegate handler;
            public ComboBoxDataField(int num, Point data, Point label, Size size , string Name, List<ComboboxItem> list, object value, ComboboxChangeHandlerDelegate handlerFunction = null)
                : base(label, num,Name)
            {
               Data = new ComboBox
                    {
                       
                        Location = data,
                        Size = size, 
                        
                    };
               foreach (var item in list)
               {
                   Data.Items.Add(item);
               }

               Data.SelectedItem = list.Where(c => c.Name == (value as string)).FirstOrDefault();

               DataObj = (Control)Data;
               this.Data.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

               //Events
               if (handlerFunction != null)
               {
                   handler = handlerFunction;
                   Data.SelectedValueChanged += Data_SelectedValueChanged;
               }

            }



            public ComboBoxDataField(int num, Point data, Point label, Size size, string Name, ComboBox c, ComboboxChangeHandlerDelegate handlerFunction = null)
                : base(label, num, Name)
            {
                Data = c;
                Data.Location = data;
                Data.Size = size;

                DataObj = (Control)Data;
                this.Data.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

                //Events
                if (handlerFunction != null)
                {
                    handler = handlerFunction;
                    Data.SelectedValueChanged += Data_SelectedValueChanged;
                }
            }
            void Data_SelectedValueChanged(object sender, EventArgs e)
            {
                handler(Data.SelectedItem.ToString());
            }


        }

        class DateTimeDataField : ObjectDataField
        {

            public DateTimePicker Data { get; set; }
            public DateTimeDataField(int num, Point data, Point label, Size size, string name, object value)
                : base(label, num, name)
            {
                this.Data = new DateTimePicker();
                this.Data.Location = data;
                this.Data.Size = size;
                this.Data.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

                if (value != null)
                {
                    type = value.GetType();

                    if (value is string)
                    {
                        this.Data.Text = value as string;
                    }
                    else if (value is DateTime)
                    {
                        this.Data.Text = ((DateTime)value).ToShortDateString();
                    }
                    else
                    {
                        this.Data.Text = value.ToString();
                    }
                }
                else
                {
                    string s = "";
                    type = s.GetType();
                    this.Data.Text = s;
                }
                DataObj = (Control)Data;
            }
        }

        class CheckBoxDataField : ObjectDataField
        {

            public CheckBox Data { get; set; }
            public CheckBoxDataField(int num, Point data, Point label, Size size, string name, object value)
                : base(label, num, name)
            {
                this.Data = new CheckBox();
                this.Data.Location = data;
                this.Data.Size = size;
                this.Data.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

                if (value != null)
                {
                    this.Data.Checked = (bool)value;
                }
                else
                {
                    this.Data.Checked = false;
                }
                DataObj = (Control)Data;
            }
        }


        //Delegate for comboboxChanged events
        public delegate void ComboboxChangeHandlerDelegate(object current);

    }
}

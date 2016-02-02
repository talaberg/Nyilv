using NyilvLib;
using NyilvLib.Forms;
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
            public string sID { get; set; }
            public string Name { get; set; }

            public ComboboxItem(int id, string name) { ID = id; Name = name; sID = id.ToString(); }
            public ComboboxItem(string id, string name) 
            {
                sID = id;
                Name = name;
                ParseID(); 
            }

            public ComboboxItem(Guid id, string name)
            {
                byte [] bt = id.ToByteArray();
                ID = BitConverter.ToInt32(bt,0);
                Name = name;
                sID = id.ToString();
            }
            private void ParseID()
            {
                int num;
                bool result = int.TryParse(sID, out num);
                ID = result ? num : -1;
            }

            public override string ToString() { return Name; }
        }
        //----------------------------------------------------------------------
        // Definition of the parent object of the datafields
        //----------------------------------------------------------------------
        class ObjectDataField
        {
            protected System.Type type;
            public Label Label { get; set; }
            public int Number { get; set; }
            public Control DataObj { get; set; }
            protected ComboboxUpdateHandlerDelegate handler2;
            public ObjectDataField(Point label, int num, string name, ComboboxUpdateHandlerDelegate h = null)
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

                if (handler2 != null)
                {
                    handler2 = h;
                }
                
            }

            
        }
        //----------------------------------------------------------------------
        // Definition of TextBox fields
        //----------------------------------------------------------------------
        class TextBoxDataField : ObjectDataField
        {

           public TextBox Data { get; set; }
           
           public TextBoxDataField(int num, Point data, Point label, Size size, string name, object value, bool isreadonly = false, ComboboxUpdateHandlerDelegate updatehandler = null)
               : base(label, num, name, updatehandler)
            {
                this.Data = new TextBox();
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

                if (updatehandler != null)
                {
                    handler2 = updatehandler;
                    Data.Leave += Data_SelectedValueChanged;
                }
            }
           void Data_SelectedValueChanged(object sender, EventArgs e)
           {
               handler2(this, new EventArgs());
           }
        }
        //----------------------------------------------------------------------
        // Definition of RicTextBox fields
        //----------------------------------------------------------------------
        class RichTextBoxDataField : ObjectDataField
        {
            public RichTextBox Data { get; set; }
            public RichTextBoxDataField(int num, Point data, Point label, Size size, string name, object value, bool isreadonly = false, ComboboxUpdateHandlerDelegate updatehandler = null)
                : base(label, num, name, updatehandler)
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

                if (updatehandler != null)
                {
                    handler2 = updatehandler;
                    Data.TextChanged += Data_SelectedValueChanged;
                }
            }
            void Data_SelectedValueChanged(object sender, EventArgs e)
            {
                handler2(this, e);
            }
        }
        //----------------------------------------------------------------------
        // Definition of DateTime fields
        //----------------------------------------------------------------------
        class DateTimeDataField : ObjectDataField
        {
            public DateTimePicker Data { get; set; }
            public DateTimeDataField(int num, Point data, Point label, Size size, string name, object value, ComboboxUpdateHandlerDelegate updatehandler = null)
                : base(label, num, name, updatehandler)
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

                if (updatehandler != null)
                {
                    handler2 = updatehandler;
                    Data.LostFocus += Data_SelectedValueChanged;
                }
            }
            void Data_SelectedValueChanged(object sender, EventArgs e)
            {
                handler2(this, e);
            }
        }
        //----------------------------------------------------------------------
        // Definition of CheckBox fields
        //----------------------------------------------------------------------
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
        //----------------------------------------------------------------------
        // Definition of ComboBox fields
        //----------------------------------------------------------------------
        class ComboBoxDataField : ObjectDataField, IDisposable
        {
            // Variables-------------
            public ComboBox Data { get; set; }
            ComboboxChangeHandlerDelegate handler;

            protected Button addButton;
            protected Button removeButton;
            
            //Functions -------------
            public ComboBoxDataField(int num, Point data, Point label, Size size, string Name, List<ComboboxItem> list, object value, ComboboxChangeHandlerDelegate handlerFunction = null)
                : base(label, num, Name)
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

                // Buttons
                //ButtonsInit(label);

                DataObj = InitDataObj(true);
                this.Data.Anchor = (AnchorStyles.Left | AnchorStyles.Top);

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
                ComboxInit(c, data, size);
                
                // Buttons
                ButtonsInit(label);

                DataObj = InitDataObj(false);

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
            Control InitDataObj(bool simpleCombobox)
            {
                if (simpleCombobox)
                {
                    return Data;
                }
                else
                {
                    Panel p = new Panel();
                    p.AutoSize = true;

                    p.Controls.Add(removeButton);
                    p.Controls.Add(addButton);
                    p.Controls.Add(Data);

                    p.Show();
                    return p;
                }
            }
            void ComboxInit(ComboBox c, Point data, Size size)
            {
                if (Data != null)
                {
                    Data.Items.Clear();
                }
                Data = c;
                Data.Location = data;
                Data.Size = size;
                Data.Anchor = ( AnchorStyles.Left | AnchorStyles.Top);
            }

            public void Reload(ComboBox c)
            {
                ComboxInit(c, Data.Location, Data.Size);
            }

            private void Add(object sender, EventArgs e)
            {                
            }
            private void Remove(object sender, EventArgs e)
            {
            }
            private void ButtonsInit(Point pos)
            {
                addButton = new Button();
                addButton.Text = GuiConstants.ComboBoxButtonText.Add;
                addButton.Location = pos;
                addButton.Size = new Size(NyilvConstants.COMBOXBUTTON_SIZE, NyilvConstants.CONTROL_HEIGHT);
                addButton.Click += this.Add;
                
                pos.X += NyilvConstants.COMBOXBUTTON_PADDING;

                removeButton = new Button();
                removeButton.Text = GuiConstants.ComboBoxButtonText.Delete;
                removeButton.Location = pos;
                removeButton.Size = new Size(NyilvConstants.COMBOXBUTTON_SIZE, NyilvConstants.CONTROL_HEIGHT);
                removeButton.Click += this.Remove;

                this.Label.Hide();

                

            }
            private void ButtonsRemove()
            {
            }

            public void Dispose()
            {
                
            }

        }

        //Delegate for comboboxChanged events
        public delegate void ComboboxChangeHandlerDelegate(object current);
        public delegate void ComboboxUpdateHandlerDelegate(object sender, EventArgs e);

    }
}

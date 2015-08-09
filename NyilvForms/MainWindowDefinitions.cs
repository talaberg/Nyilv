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
            public ComboboxItem(int id, string text) { ID = id; Name = text; }
            public int ID { get; set; }
            public string Name { get; set; }
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
                Label.TextAlign = ContentAlignment.MiddleRight;
            }

            
        }
        class TextBoxDataField : ObjectDataField
        {

           public TextBox Data { get; set; }
            public TextBoxDataField(int num, Point data, Point label, string name, object value)
                : base(label,num,name)
            {
                this.Data = new TextBox();
                this.Data.Location = data;
                this.Data.Size = new Size(120, 20);

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
            public ComboBoxDataField(int num, Point data, Point label, string Name, List<ComboboxItem> list, object value)
                : base(label, num,Name)
            {
               Data = new ComboBox
                    {
                       
                        Location = data,
                        Size = new Size(120, 20),
                        //SelectedIndex = 3 //list.Where(c => c.Name == (value as string)).FirstOrDefault()                     
                    };
               foreach (var item in list)
               {
                   Data.Items.Add(item);
               }
               Data.SelectedItem = list.Where(c => c.Name == (value as string)).FirstOrDefault();

               DataObj = (Control)Data;

            }
            public ComboBoxDataField(int num, Point data, Point label, string Name, ComboBox c)
                : base(label, num, Name)
            {
                Data = c;
                Data.Location = data;
                Data.Size = new Size(120, 20);

                DataObj = (Control)Data;
            }

        }
    }
}

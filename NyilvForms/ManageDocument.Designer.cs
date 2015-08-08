namespace NyilvForms
{
    partial class ManageDocument
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label datumLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDocument));
            System.Windows.Forms.Label dokumentum_tipusLabel;
            System.Windows.Forms.Label megjegyzesLabel;
            this.datumDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dokumentum_tipusTextBox = new System.Windows.Forms.TextBox();
            this.megjegyzesTextBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dokumentumokBindingSource = new System.Windows.Forms.BindingSource(this.components);
            datumLabel = new System.Windows.Forms.Label();
            dokumentum_tipusLabel = new System.Windows.Forms.Label();
            megjegyzesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dokumentumokBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // datumLabel
            // 
            resources.ApplyResources(datumLabel, "datumLabel");
            datumLabel.Name = "datumLabel";
            // 
            // dokumentum_tipusLabel
            // 
            resources.ApplyResources(dokumentum_tipusLabel, "dokumentum_tipusLabel");
            dokumentum_tipusLabel.Name = "dokumentum_tipusLabel";
            // 
            // megjegyzesLabel
            // 
            resources.ApplyResources(megjegyzesLabel, "megjegyzesLabel");
            megjegyzesLabel.Name = "megjegyzesLabel";
            // 
            // datumDateTimePicker
            // 
            resources.ApplyResources(this.datumDateTimePicker, "datumDateTimePicker");
            this.datumDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dokumentumokBindingSource, "Datum", true));
            this.datumDateTimePicker.Name = "datumDateTimePicker";
            // 
            // dokumentum_tipusTextBox
            // 
            resources.ApplyResources(this.dokumentum_tipusTextBox, "dokumentum_tipusTextBox");
            this.dokumentum_tipusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dokumentumokBindingSource, "Dokumentum_tipus", true));
            this.dokumentum_tipusTextBox.Name = "dokumentum_tipusTextBox";
            // 
            // megjegyzesTextBox
            // 
            resources.ApplyResources(this.megjegyzesTextBox, "megjegyzesTextBox");
            this.megjegyzesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dokumentumokBindingSource, "Megjegyzes", true));
            this.megjegyzesTextBox.Name = "megjegyzesTextBox";
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dokumentumokBindingSource
            // 
            this.dokumentumokBindingSource.DataSource = typeof(NyilvLib.Entities.Dokumentumok);
            // 
            // ManageDocument
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(datumLabel);
            this.Controls.Add(this.datumDateTimePicker);
            this.Controls.Add(dokumentum_tipusLabel);
            this.Controls.Add(this.dokumentum_tipusTextBox);
            this.Controls.Add(megjegyzesLabel);
            this.Controls.Add(this.megjegyzesTextBox);
            this.Name = "ManageDocument";
            ((System.ComponentModel.ISupportInitialize)(this.dokumentumokBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dokumentumokBindingSource;
        private System.Windows.Forms.DateTimePicker datumDateTimePicker;
        private System.Windows.Forms.TextBox dokumentum_tipusTextBox;
        private System.Windows.Forms.TextBox megjegyzesTextBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}
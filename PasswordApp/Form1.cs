using PasswordLibrary.Config;
using PasswordLibrary.PasswordService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordApp
{
    public partial class Form1 : Form
    {
        private TextBox txtKey;
        private Label label1;
        private Panel panel1;
        private CheckBox chkIncludeUpperLower;
        private CheckBox chkIncludeEspecialChar;
        private CheckBox chkIncludeNumbers;
        private Label label4;
        private Label label2;
        private Button button1;
        private TextBox txtPassword;
        private Label label3;
        private ComboBox cmbService;
        private MaskedTextBox mskSize;
        private CheckBox chkOnlyNumbers;
        private Button btnCalc;

        public Form1()
        {
            InitializeComponent();           
            InitData();
        }

        public void InitData()
        {
            this.cmbService.Items.AddRange(ServiceUtil.ServiceConfig.Services.Select(x => x.Name).ToArray<String>());
        }

        private void InitializeComponent()
        {
            this.btnCalc = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOnlyNumbers = new System.Windows.Forms.CheckBox();
            this.mskSize = new System.Windows.Forms.MaskedTextBox();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.chkIncludeUpperLower = new System.Windows.Forms.CheckBox();
            this.chkIncludeEspecialChar = new System.Windows.Forms.CheckBox();
            this.chkIncludeNumbers = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(438, 58);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(105, 23);
            this.btnCalc.TabIndex = 40;
            this.btnCalc.Text = "&Calc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.BtnCalc_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(124, 28);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(284, 20);
            this.txtKey.TabIndex = 1;
            this.txtKey.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clave Maestra:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkOnlyNumbers);
            this.panel1.Controls.Add(this.mskSize);
            this.panel1.Controls.Add(this.cmbService);
            this.panel1.Controls.Add(this.chkIncludeUpperLower);
            this.panel1.Controls.Add(this.chkIncludeEspecialChar);
            this.panel1.Controls.Add(this.chkIncludeNumbers);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(25, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 142);
            this.panel1.TabIndex = 3;
            // 
            // chkOnlyNumbers
            // 
            this.chkOnlyNumbers.AutoSize = true;
            this.chkOnlyNumbers.Location = new System.Drawing.Point(268, 63);
            this.chkOnlyNumbers.Name = "chkOnlyNumbers";
            this.chkOnlyNumbers.Size = new System.Drawing.Size(92, 17);
            this.chkOnlyNumbers.TabIndex = 35;
            this.chkOnlyNumbers.Text = "Only Numbers";
            this.chkOnlyNumbers.UseVisualStyleBackColor = true;
            this.chkOnlyNumbers.CheckedChanged += new System.EventHandler(this.ChkOnlyNumbers_CheckedChanged);
            // 
            // mskSize
            // 
            this.mskSize.Location = new System.Drawing.Point(99, 33);
            this.mskSize.Mask = "99";
            this.mskSize.Name = "mskSize";
            this.mskSize.Size = new System.Drawing.Size(26, 20);
            this.mskSize.TabIndex = 10;
            this.mskSize.Text = "15";
            this.mskSize.ValidatingType = typeof(int);
            // 
            // cmbService
            // 
            this.cmbService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(99, 6);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(284, 21);
            this.cmbService.TabIndex = 5;
            this.cmbService.SelectedIndexChanged += new System.EventHandler(this.CmbService_SelectedIndexChanged);
            this.cmbService.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbService_KeyPress);
            // 
            // chkIncludeUpperLower
            // 
            this.chkIncludeUpperLower.AutoSize = true;
            this.chkIncludeUpperLower.Checked = true;
            this.chkIncludeUpperLower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeUpperLower.Location = new System.Drawing.Point(99, 109);
            this.chkIncludeUpperLower.Name = "chkIncludeUpperLower";
            this.chkIncludeUpperLower.Size = new System.Drawing.Size(150, 17);
            this.chkIncludeUpperLower.TabIndex = 30;
            this.chkIncludeUpperLower.Text = "Include Upper Lower Char";
            this.chkIncludeUpperLower.UseVisualStyleBackColor = true;
            // 
            // chkIncludeEspecialChar
            // 
            this.chkIncludeEspecialChar.AutoSize = true;
            this.chkIncludeEspecialChar.Checked = true;
            this.chkIncludeEspecialChar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeEspecialChar.Location = new System.Drawing.Point(99, 86);
            this.chkIncludeEspecialChar.Name = "chkIncludeEspecialChar";
            this.chkIncludeEspecialChar.Size = new System.Drawing.Size(129, 17);
            this.chkIncludeEspecialChar.TabIndex = 25;
            this.chkIncludeEspecialChar.Text = "Include Especial Char";
            this.chkIncludeEspecialChar.UseVisualStyleBackColor = true;
            // 
            // chkIncludeNumbers
            // 
            this.chkIncludeNumbers.AutoSize = true;
            this.chkIncludeNumbers.Checked = true;
            this.chkIncludeNumbers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeNumbers.Location = new System.Drawing.Point(99, 63);
            this.chkIncludeNumbers.Name = "chkIncludeNumbers";
            this.chkIncludeNumbers.Size = new System.Drawing.Size(106, 17);
            this.chkIncludeNumbers.TabIndex = 20;
            this.chkIncludeNumbers.Text = "Include Numbers";
            this.chkIncludeNumbers.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Servicio:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "&Copy";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(124, 202);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(284, 20);
            this.txtPassword.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(572, 239);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnCalc);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            var serviceAdd = new Service()
            {
                Name = this.cmbService.Text,
                Size = Int32.Parse(this.mskSize.Text),
                IncludeEspecialChar = this.chkIncludeEspecialChar.Checked,
                IncludeNumbers = this.chkIncludeNumbers.Checked,
                IncludeUpperLower = this.chkIncludeUpperLower.Checked,
                OnlyNumbers = this.chkOnlyNumbers.Checked
            };
            ServiceUtil.Add(serviceAdd);
            InitData();
            this.txtPassword.Text = PasswordServiceUtil.GetPassword(serviceAdd, this.txtKey.Text);
            Clipboard.SetText(this.txtPassword.Text);
        }

        private void CmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            var serviceGet = ServiceUtil.Get(cmbService.Text);
            if (serviceGet != null)
            {
                this.cmbService.Text = serviceGet.Name;
                this.mskSize.Text = serviceGet.Size.ToString();
                this.chkIncludeEspecialChar.Checked = serviceGet.IncludeEspecialChar;
                this.chkIncludeNumbers.Checked = serviceGet.IncludeNumbers;
                this.chkIncludeUpperLower.Checked = serviceGet.IncludeUpperLower;
            }
        }

        private void CmbService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void ChkOnlyNumbers_CheckedChanged(object sender, EventArgs e)
        {
            chkIncludeEspecialChar.Enabled = !chkOnlyNumbers.Checked;
            chkIncludeNumbers.Enabled = !chkOnlyNumbers.Checked;
            chkIncludeUpperLower.Enabled = !chkOnlyNumbers.Checked;
        }
    }
}

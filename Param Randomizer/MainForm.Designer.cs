namespace Param_Randomizer
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            weapon_requirement = new CheckBox();
            weapon_weight = new CheckBox();
            talk = new CheckBox();
            confirm = new Button();
            browse = new Button();
            TextBox = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            seed = new NumericUpDown();
            weapon_weight_tooltip = new ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)seed).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(weapon_requirement);
            panel1.Controls.Add(weapon_weight);
            panel1.Controls.Add(talk);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(307, 368);
            panel1.TabIndex = 0;
            // 
            // weapon_requirement
            // 
            weapon_requirement.AutoSize = true;
            weapon_requirement.Location = new Point(34, 57);
            weapon_requirement.Name = "weapon_requirement";
            weapon_requirement.Size = new Size(228, 21);
            weapon_requirement.TabIndex = 3;
            weapon_requirement.Text = "EquipParamWeapon(Requirement)";
            weapon_requirement.UseVisualStyleBackColor = true;
            // 
            // weapon_weight
            // 
            weapon_weight.AutoSize = true;
            weapon_weight.Checked = true;
            weapon_weight.CheckState = CheckState.Checked;
            weapon_weight.Location = new Point(51, 30);
            weapon_weight.Name = "weapon_weight";
            weapon_weight.Size = new Size(195, 21);
            weapon_weight.TabIndex = 2;
            weapon_weight.Text = "EquipParamWeapon(Weight)";
            weapon_weight.UseVisualStyleBackColor = true;
            weapon_weight.MouseEnter += Weapon_weight_MouseEnter;
            weapon_weight.MouseLeave += Weapon_weight_MouseLeave;
            // 
            // talk
            // 
            talk.Anchor = AnchorStyles.Top;
            talk.AutoSize = true;
            talk.Checked = true;
            talk.CheckState = CheckState.Checked;
            talk.Location = new Point(104, 3);
            talk.Name = "talk";
            talk.Size = new Size(92, 21);
            talk.TabIndex = 1;
            talk.Text = "Talk Param";
            talk.UseVisualStyleBackColor = true;
            // 
            // confirm
            // 
            confirm.Location = new Point(244, 415);
            confirm.Name = "confirm";
            confirm.Size = new Size(75, 23);
            confirm.TabIndex = 1;
            confirm.Text = "Confirm";
            confirm.UseVisualStyleBackColor = true;
            confirm.Click += confirm_Click;
            // 
            // browse
            // 
            browse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browse.Location = new Point(244, 386);
            browse.Name = "browse";
            browse.Size = new Size(75, 23);
            browse.TabIndex = 2;
            browse.Text = "Browse";
            browse.UseVisualStyleBackColor = true;
            browse.Click += browse_Click;
            // 
            // TextBox
            // 
            TextBox.Location = new Point(12, 386);
            TextBox.Name = "TextBox";
            TextBox.ReadOnly = true;
            TextBox.Size = new Size(226, 23);
            TextBox.TabIndex = 2;
            TextBox.Text = " Waiting for regulation";
            TextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Regulation File|regulation.bin|All Files|*.*";
            openFileDialog1.Title = "Open \"regulation.bin\"";
            // 
            // seed
            // 
            seed.Location = new Point(12, 416);
            seed.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            seed.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
            seed.Name = "seed";
            seed.Size = new Size(226, 23);
            seed.TabIndex = 3;
            seed.TextAlign = HorizontalAlignment.Center;
            seed.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 450);
            Controls.Add(seed);
            Controls.Add(TextBox);
            Controls.Add(browse);
            Controls.Add(confirm);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "Param Randomizer";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)seed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private CheckBox talk;
        private Button confirm;
        private Button browse;
        private TextBox TextBox;
        private OpenFileDialog openFileDialog1;
        private NumericUpDown seed;
        private CheckBox weapon_weight;
        private ToolTip weapon_weight_tooltip;
        private CheckBox weapon_requirement;
    }
}
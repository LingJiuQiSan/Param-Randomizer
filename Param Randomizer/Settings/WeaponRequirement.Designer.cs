namespace Param_Randomizer.Settings
{
    partial class WeaponRequirement
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
            Strength = new Label();
            Dexterity = new Label();
            Intelligence = new Label();
            Faith = new Label();
            Arcane = new Label();
            StrengthI = new NumericUpDown();
            DexterityI = new NumericUpDown();
            IntelligenceI = new NumericUpDown();
            FaithI = new NumericUpDown();
            ArcaneI = new NumericUpDown();
            Confirm = new Button();
            ((System.ComponentModel.ISupportInitialize)StrengthI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DexterityI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IntelligenceI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FaithI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ArcaneI).BeginInit();
            SuspendLayout();
            // 
            // Strength
            // 
            Strength.AutoSize = true;
            Strength.Location = new Point(10, 15);
            Strength.Name = "Strength";
            Strength.Size = new Size(64, 17);
            Strength.TabIndex = 0;
            Strength.Text = "Strength: ";
            // 
            // Dexterity
            // 
            Dexterity.AutoSize = true;
            Dexterity.Location = new Point(12, 44);
            Dexterity.Name = "Dexterity";
            Dexterity.Size = new Size(66, 17);
            Dexterity.TabIndex = 1;
            Dexterity.Text = "Dexterity: ";
            // 
            // Intelligence
            // 
            Intelligence.AutoSize = true;
            Intelligence.Location = new Point(11, 73);
            Intelligence.Name = "Intelligence";
            Intelligence.Size = new Size(81, 17);
            Intelligence.TabIndex = 2;
            Intelligence.Text = "Intelligence: ";
            // 
            // Faith
            // 
            Faith.AutoSize = true;
            Faith.Location = new Point(10, 102);
            Faith.Name = "Faith";
            Faith.Size = new Size(42, 17);
            Faith.TabIndex = 3;
            Faith.Text = "Faith: ";
            // 
            // Arcane
            // 
            Arcane.AutoSize = true;
            Arcane.Location = new Point(11, 131);
            Arcane.Name = "Arcane";
            Arcane.Size = new Size(55, 17);
            Arcane.TabIndex = 4;
            Arcane.Text = "Arcane: ";
            // 
            // StrengthI
            // 
            StrengthI.Location = new Point(98, 9);
            StrengthI.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            StrengthI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            StrengthI.Name = "StrengthI";
            StrengthI.Size = new Size(120, 23);
            StrengthI.TabIndex = 5;
            StrengthI.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DexterityI
            // 
            DexterityI.Location = new Point(98, 38);
            DexterityI.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            DexterityI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            DexterityI.Name = "DexterityI";
            DexterityI.Size = new Size(120, 23);
            DexterityI.TabIndex = 6;
            DexterityI.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // IntelligenceI
            // 
            IntelligenceI.Location = new Point(98, 67);
            IntelligenceI.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            IntelligenceI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            IntelligenceI.Name = "IntelligenceI";
            IntelligenceI.Size = new Size(120, 23);
            IntelligenceI.TabIndex = 7;
            IntelligenceI.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // FaithI
            // 
            FaithI.Location = new Point(98, 96);
            FaithI.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            FaithI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            FaithI.Name = "FaithI";
            FaithI.Size = new Size(120, 23);
            FaithI.TabIndex = 8;
            FaithI.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ArcaneI
            // 
            ArcaneI.Location = new Point(98, 125);
            ArcaneI.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            ArcaneI.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ArcaneI.Name = "ArcaneI";
            ArcaneI.Size = new Size(120, 23);
            ArcaneI.TabIndex = 9;
            ArcaneI.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Confirm
            // 
            Confirm.Location = new Point(72, 154);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(75, 23);
            Confirm.TabIndex = 10;
            Confirm.Text = "Confirm";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += Confirm_Click;
            // 
            // WeaponRequirement
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 185);
            Controls.Add(Confirm);
            Controls.Add(ArcaneI);
            Controls.Add(FaithI);
            Controls.Add(IntelligenceI);
            Controls.Add(DexterityI);
            Controls.Add(StrengthI);
            Controls.Add(Arcane);
            Controls.Add(Faith);
            Controls.Add(Intelligence);
            Controls.Add(Dexterity);
            Controls.Add(Strength);
            Name = "WeaponRequirement";
            Text = "Weapon Requirement Setting";
            ((System.ComponentModel.ISupportInitialize)StrengthI).EndInit();
            ((System.ComponentModel.ISupportInitialize)DexterityI).EndInit();
            ((System.ComponentModel.ISupportInitialize)IntelligenceI).EndInit();
            ((System.ComponentModel.ISupportInitialize)FaithI).EndInit();
            ((System.ComponentModel.ISupportInitialize)ArcaneI).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Strength;
        private Label Dexterity;
        private Label Intelligence;
        private Label Faith;
        private Label Arcane;
        private NumericUpDown StrengthI;
        private NumericUpDown DexterityI;
        private NumericUpDown IntelligenceI;
        private NumericUpDown FaithI;
        private NumericUpDown ArcaneI;
        private Button Confirm;
    }
}
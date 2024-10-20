namespace Param_Randomizer.Settings
{
    public partial class WeaponRequirement : Form
    {
        
        public int[] Requirement = new int[5];

        public WeaponRequirement()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            Requirement[0] = (int)StrengthI.Value;
            Requirement[1] = (int)DexterityI.Value;
            Requirement[2] = (int)IntelligenceI.Value;
            Requirement[3] = (int)FaithI.Value;
            Requirement[4] = (int)ArcaneI.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

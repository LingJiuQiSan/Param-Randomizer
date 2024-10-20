using Param_Randomizer.Settings;
using SoulsFormats;

namespace Param_Randomizer;

public partial class MainForm : Form
{
    private float MaxWeaponWeight = 1000.0F;
    public int[] WeaponRequirement = [99, 99, 99, 99, 99];

    public MainForm()
    {
        InitializeComponent();
    }

    private void confirm_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.FileName == "")
        {
            MessageBox.Show("No file Selected!", "Error", MessageBoxButtons.OK);
            return;
        }
        if (
            talk.Checked == false &&
            weapon_weight.Checked == false &&
            weapon_requirement.Checked == false
            )
        {
            MessageBox.Show("No Param Selected!", "Error", MessageBoxButtons.OK);
            return;
        }


        int rngSeed = (int)seed.Value;
        if (rngSeed == -1)
        {
            //if no seed was provided, generate a new one
            Random newSeed = new Random();
            seed.Value = newSeed.Next(1, 999999999);
            rngSeed = (int)seed.Value;
        }
        Random rng = new(rngSeed);

        string regulationPath = openFileDialog1.FileName;

        UpdateConsole("Decrypting Regulation");

        BND4 paramBND = SFUtil.DecryptERRegulation(regulationPath);

        if (talk.Checked) paramBND = randTalk(rng, paramBND);
        if (weapon_weight.Checked) paramBND = rngWeaponWeight(rng, paramBND);
        if (weapon_requirement.Checked) paramBND = rngWeaponRequirement(rng, paramBND);

        SFUtil.EncryptERRegulation(regulationPath, paramBND);

        GC.Collect(); //free memory

        UpdateConsole("Finished!");
        System.Media.SystemSounds.Exclamation.Play(); //make noise
        MessageBox.Show("All done!", "Randomization Finished", MessageBoxButtons.OK);
    }

    private BND4 rngWeaponRequirement(Random rng, BND4 paramBND)
    {
        Dictionary<string, PARAM> paramList = new();

        UpdateConsole("Loading ParamDefs");

        List<PARAMDEF> paramdefs = new List<PARAMDEF>();
        PARAMDEF paramdef = PARAMDEF.XmlDeserialize($@"{Directory.GetCurrentDirectory()}\Paramdex\EquipParamWeapon.xml");
        paramdefs.Add(paramdef);

        UpdateConsole("Handling Params");

        foreach (BinderFile file in paramBND.Files)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);
            var param = PARAM.Read(file.Bytes);

            if (param.ApplyParamdefCarefully(paramdefs))
                paramList[name] = param;
        }

        UpdateConsole("Modifying Params");

        PARAM weaponParam = paramList["EquipParamWeapon"];

        for (int i = 0; i < weaponParam.Rows.Count; i++)
        {
            PARAM.Row row = weaponParam.Rows[i];

            if ((int)row["sortId"].Value == 9999999)
            {
                continue;
            }

            row["properStrength"].Value = rng.Next(0, WeaponRequirement[0] + 1);
            row["properAgility"].Value = rng.Next(0, WeaponRequirement[1] + 1);
            row["properMagic"].Value = rng.Next(0, WeaponRequirement[2] + 1);
            row["properFaith"].Value = rng.Next(0, WeaponRequirement[3] + 1);
            row["properLuck"].Value = rng.Next(0, WeaponRequirement[4] + 1);
        }

        UpdateConsole("Exporting Params");

        foreach (BinderFile file in paramBND.Files)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);
            if (paramList.ContainsKey(name))
                file.Bytes = paramList[name].Write();
        }

        return paramBND;
    }

    private BND4 rngWeaponWeight(Random rng, BND4 paramBND)
    {
        Dictionary<string, PARAM> paramList = new();

        UpdateConsole("Loading ParamDefs");

        List<PARAMDEF> paramdefs = new List<PARAMDEF>();
        PARAMDEF paramdef = PARAMDEF.XmlDeserialize($@"{Directory.GetCurrentDirectory()}\Paramdex\EquipParamWeapon.xml");
        paramdefs.Add(paramdef);

        UpdateConsole("Handling Params");

        foreach (BinderFile file in paramBND.Files)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);
            var param = PARAM.Read(file.Bytes);

            if (param.ApplyParamdefCarefully(paramdefs))
                paramList[name] = param;
        }

        UpdateConsole("Modifying Params");

        PARAM weaponParam = paramList["EquipParamWeapon"];

        for (int i = 0; i < weaponParam.Rows.Count; i++)
        {
            PARAM.Row row = weaponParam.Rows[i];

            if ((int)row["sortId"].Value == 9999999)
            {
                continue;
            }

            row["weight"].Value = rng.Next(0, (int)(MaxWeaponWeight * 10) + 1) / 10.0;
        }

        UpdateConsole("Exporting Params");

        foreach (BinderFile file in paramBND.Files)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);
            if (paramList.ContainsKey(name))
                file.Bytes = paramList[name].Write();
        }

        return paramBND;
    }

    private BND4 randTalk(Random rng, BND4 paramBND)
    {
        Dictionary<string, PARAM> paramList = new();

        UpdateConsole("Loading ParamDefs");

        List<PARAMDEF> paramdefs = new List<PARAMDEF>();
        PARAMDEF paramdef = PARAMDEF.XmlDeserialize($@"{Directory.GetCurrentDirectory()}\Paramdex\TalkParam.xml");
        paramdefs.Add(paramdef);

        UpdateConsole("Handling Params");

        foreach (BinderFile file in paramBND.Files)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);
            var param = PARAM.Read(file.Bytes);

            if (param.ApplyParamdefCarefully(paramdefs))
                paramList[name] = param;
        }

        UpdateConsole("Modifying Params");

        PARAM talkParam = paramList["TalkParam"];


        List<int> goodIDs = new();
        for (int i = 0; i < talkParam.Rows.Count; i++)
        {
            PARAM.Row row = talkParam.Rows[i];

            if (row.ID is 100 or 200)
            {
                continue;
            }

            goodIDs.Add((int)row["msgId"].Value);
            goodIDs.Add((int)row["msgId_female"].Value);

            row["msgId"].Value = -1;
            row["msgId_female"].Value = -1;
        }

        for (int i = 0; i < talkParam.Rows.Count; i++)
        {
            PARAM.Row row = talkParam.Rows[i];

            if (row.ID is 100 or 200)
            {
                continue;
            }

            row["msgId"].Value = goodIDs[rng.Next(0, goodIDs.Count)];
            row["msgId_female"].Value = goodIDs[rng.Next(0, goodIDs.Count)];
        }

        UpdateConsole("Exporting Params");

        foreach (BinderFile file in paramBND.Files)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);
            if (paramList.ContainsKey(name))
                file.Bytes = paramList[name].Write();
        }

        return paramBND;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    private void browse_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            string? directory = Path.GetDirectoryName(openFileDialog1.FileName);
            if (directory != null && File.Exists(directory + "\\eldenring.exe"))
            {
                //user is loading the regulation next to eldenring.exe, yell at them

                DialogResult result = MessageBox.Show(
                    "Warning: Modifying the Regulation.bin directly used by Elden Ring is ill-advised, as it's possible you may be banned."
                    + " \nIt's highly recommended you instead use Mod Engine 2 and modify a copy of Regulation.bin."
                    + " \n\nAre you sure you want to load the Regulation.bin you selected?"
                    , "Confirm Regulation.bin Selection", MessageBoxButtons.OKCancel);
                if (result != DialogResult.OK)
                {
                    openFileDialog1.FileName = "";
                    return;
                }
            }

            UpdateConsole("Selected Regulation.bin");
        }
    }

    public void UpdateConsole(string text)
    {
        TextBox.Text = text;
        Application.DoEvents();
    }

    private void WeaponWeightSetting_Click(object sender, EventArgs e)
    {
        WeaponWeight weaponWeight = new WeaponWeight();
        if (weaponWeight.ShowDialog() == DialogResult.OK)
        {
            MaxWeaponWeight = weaponWeight.UserInput;
        }
    }

    private void WeaponRequirementSetting_Click(object sender, EventArgs e)
    {
        WeaponRequirement requirement = new WeaponRequirement();
        if (requirement.ShowDialog() == DialogResult.OK)
        {
            WeaponRequirement = requirement.Requirement;
        }
    }
}
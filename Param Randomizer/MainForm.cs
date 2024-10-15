using SoulsFormats;

namespace Param_Randomizer;

public partial class MainForm : Form
{
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
        if (talk.Checked == false)
        {
            MessageBox.Show("No Param Selected!", "Error", MessageBoxButtons.OK);
            return;
        }

        if (talk.Checked == true)
        {
            int rngSeed = (int)seed.Value;
            if (rngSeed == -1)
            {
                //if no seed was provided, generate a new one
                Random newSeed = new Random();
                seed.Value = newSeed.Next(1, 999999999);
                rngSeed = (int)seed.Value;
            }
            Random rng = new(rngSeed);
            randtalk(rng);
        }

        GC.Collect(); //free memory

        UpdateConsole("Finished!");
        System.Media.SystemSounds.Exclamation.Play(); //make noise
        MessageBox.Show("All done!", "Randomization Finished", MessageBoxButtons.OK);
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

    private void randtalk(Random rng)
    {
        Dictionary<string, PARAM> paramList = new();
        string regulationPath = openFileDialog1.FileName;

        UpdateConsole("Decrypting Regulation");

        BND4 paramBND = SFUtil.DecryptERRegulation(regulationPath);

        UpdateConsole("Loading ParamDefs");

        var paramdefs = new List<PARAMDEF>();
        var paramdef = PARAMDEF.XmlDeserialize($@"{Directory.GetCurrentDirectory()}\Paramdex\TalkParam.xml");
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

        SFUtil.EncryptERRegulation(regulationPath, paramBND);
    }
}
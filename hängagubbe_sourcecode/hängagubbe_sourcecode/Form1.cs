using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace hängagubbe_sourcecode
{
    public partial class hänga_Gubbe : Form
    {
        private Bitmap[] liv = {hängagubbe_sourcecode.Properties.Resources.liv1,
                                hängagubbe_sourcecode.Properties.Resources.liv2,
                                hängagubbe_sourcecode.Properties.Resources.liv3,
                                hängagubbe_sourcecode.Properties.Resources.liv4,
                                hängagubbe_sourcecode.Properties.Resources.liv5,
                                hängagubbe_sourcecode.Properties.Resources.liv6,
                                hängagubbe_sourcecode.Properties.Resources.liv7,
                                hängagubbe_sourcecode.Properties.Resources.liv8};
        Random slumpOrd = new Random();
        private int felGissningar = 0;
        private string ord;
        private string nuvarandeOrd = "";
        private string kopiaOrd = "";
        private int indexLedtråd = 0;
        private int gissningar = 8;
        private double antalSpel;
        private double vinster;
        private double winrate;

        public hänga_Gubbe()
        {
            InitializeComponent();
        }

        private void väljOrd()
        {
            felGissningar = 0;
            pbHänga.Image = liv[felGissningar];
            nuvarandeOrd = ord;
            kopiaOrd = "";
            for (int i = 0; i < nuvarandeOrd.Length; i++)
            {
                kopiaOrd += "_";
            }
            visaKopia();

        }

        private void visaKopia()
        {
            lblOrdet.Text = "";
            for (int i = 0; i < kopiaOrd.Length; i++)
            {
                lblOrdet.Text += kopiaOrd.Substring(i, 1);
                lblOrdet.Text += " ";
            }

        }

        private void btnGissa(object sender, EventArgs e)
        {
            Button val = sender as Button;
            val.Enabled = false;
            if (nuvarandeOrd.Contains(val.Text))
            {
                char[] temp = kopiaOrd.ToCharArray();
                char[] hitta = nuvarandeOrd.ToCharArray();
                char gissaBokstav = val.Text.ElementAt(0);
                for (int i = 0; i < hitta.Length; i++)
                {
                    if (hitta[i] == gissaBokstav)
                    {
                        temp[i] = gissaBokstav;
                    }
                }
                kopiaOrd = new string(temp);
                visaKopia();
            }
            else
            {
                felGissningar++;
                gissningar--;
                lblGissningar.Text = gissningar.ToString();
            }

            if (felGissningar < 8)
            {
                pbHänga.Image = liv[felGissningar];
            }
            else
            {
                lblOrdet.Text = "Gubben är hängd!";
                tbxTidigare.AppendText(nuvarandeOrd.ToString() + "\n");
                gbxKnappar.Enabled = false;
                btnOmstart.Enabled = true;
                antalSpel++;
                
            }
            if (kopiaOrd.Equals(nuvarandeOrd))
            {
                lblOrdet.Text = "Du gissade rätt!";
                gbxKnappar.Enabled = false;
                tbxTidigare.AppendText(nuvarandeOrd.ToString() + "\n");
                btnOmstart.Enabled = true;
                btnLedtråd.Enabled = false;
                antalSpel++;
                vinster++;
            }
        }

        private void hänga_Gubbe_Load(object sender, EventArgs e)
        {
            string[] läs = File.ReadAllLines("ordlista.txt");
            ord = läs[slumpOrd.Next(1, 7)];
            väljOrd();
            indexLedtråd = 0;
            tbxLedtråd.Text = "";
            tbxTidigare.Text = "";
            gbxKnappar.Enabled = false;
            btnOmstart.Enabled = false;
            btnLedtråd.Enabled = false;
            

        }

        private void btnOmstart_Click(object sender, EventArgs e)
        {
            string[] läs = File.ReadAllLines("ordlista.txt");
            ord = läs[slumpOrd.Next(1, 7)];
            btnOmstart.Enabled = false;
            väljOrd();
            indexLedtråd = 0;
            tbxLedtråd.Text = "";
            lblGissningar.Text = "";
            btnLvl1.Enabled = true;
            btnLvl2.Enabled = true;
            btnLvl3.Enabled = true;
            gbxKnappar.Enabled = false;
            btnLedtråd.Enabled = false;
            winrate = (vinster / antalSpel) * 100;
            tbxWinrate.Text = winrate.ToString("#,##") + "%";
        }

        private void btnLedtråd_Click(object sender, EventArgs e)
        {
            
            string ledtråd = nuvarandeOrd;
            char ledtrådBokstav = ledtråd[indexLedtråd];
            tbxLedtråd.AppendText(ledtrådBokstav.ToString());
            indexLedtråd++;
            if (indexLedtråd == nuvarandeOrd.Length)
            {
                btnLedtråd.Enabled = false;
            }
        }

        private void btnLvl1_Click(object sender, EventArgs e)
        {
            string[] läs = File.ReadAllLines("ordlista.txt");
            ord = läs[slumpOrd.Next(1, 7)];
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            btnE.Enabled = true;
            btnF.Enabled = true;
            btnG.Enabled = true;
            btnH.Enabled = true;
            btnI.Enabled = true;
            btnJ.Enabled = true;
            btnK.Enabled = true;
            btnL.Enabled = true;
            btnM.Enabled = true;
            btnN.Enabled = true;
            btnO.Enabled = true;
            btnP.Enabled = true;
            btnQ.Enabled = true;
            btnR.Enabled = true;
            btnS.Enabled = true;
            btnT.Enabled = true;
            btnU.Enabled = true;
            btnV.Enabled = true;
            btnW.Enabled = true;
            btnX.Enabled = true;
            btnY.Enabled = true;
            btnZ.Enabled = true;
            btnLedtråd.Enabled = true;
            väljOrd();
            indexLedtråd = 0;
            tbxLedtråd.Text = "";
            felGissningar = 0;
            gissningar = 8;
            lblGissningar.Text = gissningar.ToString();
            gbxKnappar.Enabled = true;
            btnOmstart.Enabled = false;
            btnLvl1.Enabled = false;
            btnLvl2.Enabled = false;
            btnLvl3.Enabled = false;

        }

        private void btnLvl2_Click(object sender, EventArgs e)
        {

            string[] läs = File.ReadAllLines("ordlista.txt");
            ord = läs[slumpOrd.Next(1, 7)];
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            btnE.Enabled = true;
            btnF.Enabled = true;
            btnG.Enabled = true;
            btnH.Enabled = true;
            btnI.Enabled = true;
            btnJ.Enabled = true;
            btnK.Enabled = true;
            btnL.Enabled = true;
            btnM.Enabled = true;
            btnN.Enabled = true;
            btnO.Enabled = true;
            btnP.Enabled = true;
            btnQ.Enabled = true;
            btnR.Enabled = true;
            btnS.Enabled = true;
            btnT.Enabled = true;
            btnU.Enabled = true;
            btnV.Enabled = true;
            btnW.Enabled = true;
            btnX.Enabled = true;
            btnY.Enabled = true;
            btnZ.Enabled = true;
            väljOrd();
            indexLedtråd = 0;
            btnLedtråd.Enabled = true;
            tbxLedtråd.Text = "";
            felGissningar = 2;
            pbHänga.Image = liv[felGissningar];
            gissningar = 6;
            lblGissningar.Text = gissningar.ToString();
            gbxKnappar.Enabled = true;
            btnOmstart.Enabled = false;
            btnLvl1.Enabled = false;
            btnLvl2.Enabled = false;
            btnLvl3.Enabled = false;
        }

        private void btnLvl3_Click(object sender, EventArgs e)
        {
            string[] läs = File.ReadAllLines("ordlista.txt");
            ord = läs[slumpOrd.Next(1, 7)];
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            btnE.Enabled = true;
            btnF.Enabled = true;
            btnG.Enabled = true;
            btnH.Enabled = true;
            btnI.Enabled = true;
            btnJ.Enabled = true;
            btnK.Enabled = true;
            btnL.Enabled = true;
            btnM.Enabled = true;
            btnN.Enabled = true;
            btnO.Enabled = true;
            btnP.Enabled = true;
            btnQ.Enabled = true;
            btnR.Enabled = true;
            btnS.Enabled = true;
            btnT.Enabled = true;
            btnU.Enabled = true;
            btnV.Enabled = true;
            btnW.Enabled = true;
            btnX.Enabled = true;
            btnY.Enabled = true;
            btnZ.Enabled = true;
            väljOrd();
            indexLedtråd = 0;
            btnLedtråd.Enabled = true;
            tbxLedtråd.Text = "";
            felGissningar = 4;
            pbHänga.Image = liv[felGissningar];
            gissningar = 4;
            lblGissningar.Text = gissningar.ToString();
            gbxKnappar.Enabled = true;
            btnOmstart.Enabled = false;
            btnLvl1.Enabled = false;
            btnLvl2.Enabled = false;
            btnLvl3.Enabled = false;
        }

        private void btnAvsluta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

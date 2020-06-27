using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Globalization;

namespace zors
{
    public partial class Pregled : System.Web.UI.Page
    {
        private string cekiranizors1 = string.Empty; 
   
        protected void Page_Load(object sender, EventArgs e)
        {

           
            if (!IsPostBack)
            {
                grid1();
                //grid_korak2_sadasnjiGM();
                //grid_korak3_buducidir();
                //grid_korak4_buducigm();       
         
                //grid_jelena5();

                //grid_korak6_izvrsni();
                //grid_korak7_generalni();

            }
            
        }

        public void selectData1()
        {
            foreach (GridViewRow row in GridViewRN1.Rows)
            {
                Label idTxt = (Label)row.FindControl("ID") as Label;
                RadioButton check = (RadioButton)row.FindControl("check") as RadioButton;
                bool CheckTrue = check.Checked;
                int id = int.Parse(idTxt.Text);

                if (CheckTrue == true)
                {
                    
                    //CEKIRANJE PRVOG GRIDA
                    cekiranizors1 = idTxt.Text;

                    OracleCommand oda;
                    OracleConnection con = new OracleConnection();
                    OracleDataAdapter adapter;
                    DataSet results;
                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
                    con.Open();

                    oda = new OracleCommand("select IME_PODNOSIOCA, MBR_PODNOSIOCA, DATUM_PODNOSENJA, IME, MBR, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR, OBRAZOVANJE, MESTOSTUDIRANJA, SMERODSEK, PROSECNAOCENA, OCENADIPLOMSKI, NAPOMENA, DATUMDIPLOMIRANJA, MB_GM_SADASNJECELINE, IME_GM_SADASNJECELINE, ID from ZORS_MAIN where ID = '" + cekiranizors1 + "'");
                    oda.Connection = con;
                    oda.CommandType = CommandType.Text;
                    adapter = new OracleDataAdapter(oda);
                    results = new DataSet();
                    adapter.Fill(results);
                    OracleDataReader read = oda.ExecuteReader();
                    if (read.Read())
                    {
                        LabelImePodnosioca.Text = read.GetValue(0).ToString();
                        LabelMBRpodnosioca.Text = read.GetValue(1).ToString();                        
                        LabelDatum.Text = read.GetValue(2).ToString();
                        LabelIme.Text = read.GetValue(3).ToString();
                        LabelMBR.Text = read.GetValue(4).ToString();
                        LabelSkola.Text = read.GetValue(5).ToString();
                        LabelSchool.Text = read.GetValue(6).ToString();
                        LabelStrucnaSprema.Text = read.GetValue(7).ToString();
                        LabelSadasnjaCelina.Text = read.GetValue(8).ToString();
                        LabelSadasnjaCelinaEN.Text = read.GetValue(9).ToString();
                        LabelSIFRACELINE.Text = read.GetValue(10).ToString();
                        LabelSadasnjiPosao.Text = read.GetValue(11).ToString();
                        LabelSadasnjiPosaoEN.Text = read.GetValue(12).ToString();
                        LabelKodPosla.Text = read.GetValue(13).ToString();
                        LabelSadasnjiKoef.Text = read.GetValue(14).ToString();
                        LabelNovaOrgCelina.Text = read.GetValue(15).ToString();
                        LabelNovaOrgCelinaENG.Text = read.GetValue(16).ToString();
                        LabelNoviPosao.Text = read.GetValue(17).ToString();
                        LabelNoviPosaoENG.Text = read.GetValue(18).ToString();
                        LabelKodPoslaNovi.Text = read.GetValue(19).ToString();
                        LabelQualLevel.Text= read.GetValue(20).ToString();
                        LabelNovikoef.Text = read.GetValue(21).ToString();
                        LabelDropDownList1.Text = read.GetValue(22).ToString();
                        LabelDropDownList2.Text = read.GetValue(23).ToString();
                        LabelPocetakSmene.Text = read.GetValue(24).ToString();
                        TextBox2.Text = read.GetValue(25).ToString();
                        LabelMBdir1.Text = read.GetValue(26).ToString();
                        LabelIMEdirSadasnjeOrgCeline.Text = read.GetValue(27).ToString();
                        Labelmbdir2.Text = read.GetValue(28).ToString();
                        LabelDirektor2ime.Text = read.GetValue(29).ToString();
                        LabelMBgm2.Text = read.GetValue(30).ToString();
                        LabelGM2ime.Text = read.GetValue(31).ToString();
                        IzvrsniDirektorMB.Text = read.GetValue(32).ToString();
                        IzvrsniDirektorIme.Text = read.GetValue(33).ToString();
                        
                        LabelObrazovanje.Text = read.GetValue(34).ToString();
                        LabelSmerOdsek.Text = read.GetValue(35).ToString();
                        LabelMestoStudiranja.Text = read.GetValue(36).ToString();
                        LabelProsecnaOcena.Text = read.GetValue(37).ToString();
                        LabelOcenaDiplomski.Text = read.GetValue(38).ToString();
                        LabelNapomena.Text = read.GetValue(39).ToString();

                        if (Convert.ToString(read[40]) != String.Empty)
                        {
                            LabelDatumDiplomiranja.Text = Convert.ToString(read[40]).Remove(Convert.ToString(read[40]).Length - 8, 8);
                        }
                        else
                        {
                            LabelDatumDiplomiranja.Text = String.Empty;
                        }

                        LabelMBgm1.Text = read.GetValue(41).ToString();
                        LabelIMEgmSadasnjeOrgCeline.Text = read.GetValue(42).ToString();
                        LabelID.Text = read.GetValue(43).ToString();


                        LabelGeneralniIme.Text="Zhao Jun";
                        LabelGeneralniMaticni.Text = "63018";
                        LabelKodPoslaNovi2.Text = LabelKodPoslaNovi.Text;
                        LabelPomocnikGeneralnog1.Text = "Wang Lianxi";
                        LabelPomocnikGeneralnogMB1.Text ="63008";
                        //LabelPomocnikGeneralnog2.Text = "Nataša Tijanić";
                        //LabelPomocnikGeneralnogMB2.Text = "42880";

                        //OfarbajPotpise_i_blokirajDugme();
                    }
                    else
                    {
                        Response.Redirect(Request.RawUrl);
                    }

                    con.Close();
                }
            }
        }

        protected void grid1()
        {
            OracleConnection con = new OracleConnection();
            OracleDataAdapter adapter;
            DataSet results;

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();

            if (StorageSession.Current.JobID == "434")
            {
                OracleCommand oda = new OracleCommand("select id, mbr_podnosioca, ime_podnosioca,  mbr, ime, datum_podnosenja from ZORS_MAIN where (MB_DIR_SADASNJECELINE = '" + StorageSession.Current.EmployeeId + "' and DIR_SADASNJECELINE_ODOBRIO_1 is null) OR (MB_DIR_BUDUCECELINE = '" + StorageSession.Current.EmployeeId + "' and DIR_BUDUCECELINE_ODOBRIO_3 is null) ");
                oda.Connection = con;
                //oda.CommandType = CommandType.Text;
                adapter = new OracleDataAdapter(oda);
                results = new DataSet();
                adapter.Fill(results);
                this.GridViewRN1.DataSource = results;
                this.GridViewRN1.DataBind();
                con.Close();
            }
            if (StorageSession.Current.JobID == "50")
            {
                OracleCommand oda = new OracleCommand("select id, mbr_podnosioca, ime_podnosioca,  mbr, ime, datum_podnosenja from ZORS_MAIN where (MB_GM_SADASNJECELINE = '" + StorageSession.Current.EmployeeId + "' and GM_SADASNJECELINE_ODOBRIO_2 is null) OR (MB_GM_BUDUCECELINE = '" + StorageSession.Current.EmployeeId + "' and GM_BUDUCECELINE_ODOBRIO_4 is null) ");
                oda.Connection = con;
                //oda.CommandType = CommandType.Text;
                adapter = new OracleDataAdapter(oda);
                results = new DataSet();
                adapter.Fill(results);
                this.GridViewRN1.DataSource = results;
                this.GridViewRN1.DataBind();
                con.Close();
            }
            if (StorageSession.Current.JobID == "439")
            {
                OracleCommand oda = new OracleCommand("select id, mbr_podnosioca, ime_podnosioca,  mbr, ime, datum_podnosenja from ZORS_MAIN where (MB_DIR_SADASNJECELINE = '" + StorageSession.Current.EmployeeId + "' and DIR_SADASNJECELINE_ODOBRIO_1 is null) OR (MB_DIR_BUDUCECELINE = '" + StorageSession.Current.EmployeeId + "' and DIR_BUDUCECELINE_ODOBRIO_3 is null) or (MB_GM_SADASNJECELINE = '" + StorageSession.Current.EmployeeId + "' and GM_SADASNJECELINE_ODOBRIO_2 is null) OR (MB_GM_BUDUCECELINE = '" + StorageSession.Current.EmployeeId + "' and GM_BUDUCECELINE_ODOBRIO_4 is null) ");
                oda.Connection = con;
                //oda.CommandType = CommandType.Text;
                adapter = new OracleDataAdapter(oda);
                results = new DataSet();
                adapter.Fill(results);
                this.GridViewRN1.DataSource = results;
                this.GridViewRN1.DataBind();
                con.Close();
            }

            con.Close();

            //CEKIRANJE PRVOG GRIDA
            //
            if (cekiranizors1 != string.Empty)
            {
                foreach (GridViewRow row in GridViewRN1.Rows)
                {
                    Label id = (Label)row.FindControl("ID") as Label;
                    if (id.Text.Equals(cekiranizors1))
                    {
                        RadioButton check = (RadioButton)row.FindControl("check");
                        check.Checked = true;
                    }
                }
            }
        }

        protected void GridViewRN1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRN1.PageIndex = e.NewPageIndex;
        }

        protected void check_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewRN1.Rows)
            {
                Label idTxt = (Label)row.FindControl("ID") as Label;
                RadioButton check = (RadioButton)row.FindControl("check") as RadioButton;
                bool CheckTrue = check.Checked;

                if (CheckTrue == true)
                {
                    selectData1();
                    PanelPregled.Visible = true;

                }
            }
        }

        protected void ButtonODOBRI_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewRN1.Rows)
            {
                Label idTxt = (Label)row.FindControl("ID") as Label;
                RadioButton check = (RadioButton)row.FindControl("check") as RadioButton;
                bool CheckTrue = check.Checked;
 
                if (CheckTrue == true)
                {
                    int id = int.Parse(idTxt.Text);
                    string cekiranizors1 = idTxt.Text;
                    korak1(cekiranizors1);

                }

            }

        }


        public void korak1(string cekiranizors1)
        {
           OracleCommand oda;
           OracleConnection con = new OracleConnection();
           OracleDataAdapter adapter;
           DataSet results;
           con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
           con.Open();
           oda = new OracleCommand("select MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, DIR_SADASNJECELINE_ODOBRIO_1, DIR_SADASNJECEL_RAZLOGODBIJ, MB_GM_SADASNJECELINE, IME_GM_SADASNJECELINE, GM_SADASNJECELINE_ODOBRIO_2, GM_SADASNJECELINE_RAZLOGODBIJ, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, DIR_BUDUCECELINE_ODOBRIO_3, DIR_BUDUCECELINE_RAZLOGODBIJ, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, GM_BUDUCECELINE_ODOBRIO_4, GM_BUDUCECELINE_RAZLOGODBIJ from ZORS_MAIN where ID = '" + cekiranizors1 + "'");
           oda.Connection = con;
           oda.CommandType = CommandType.Text;
           adapter = new OracleDataAdapter(oda);
           results = new DataSet();
           adapter.Fill(results);
           OracleDataReader read = oda.ExecuteReader();
           if (read.Read())
           {
              string mb_dir_sadasnjeceline = read.GetValue(0).ToString();
              string ime_dir_sadasnjeceline = read.GetValue(1).ToString();
              string dir_sadasnjeceline_odobrio_1 = read.GetValue(2).ToString();
              string dir_sadasnjeceline_razlog_odbij = read.GetValue(3).ToString();

              string mb_gm_sadasnjeceline = read.GetValue(4).ToString();
              string ime_gm_sadasnjeceline = read.GetValue(5).ToString();
              string gm_sadasnjeceline_odobrio_2 = read.GetValue(6).ToString();
              string gm_sadasnjeceline_razlog_odbij = read.GetValue(7).ToString();

               string mb_dir_buduceceline = read.GetValue(8).ToString();
               string ime_dir_buduceceline = read.GetValue(9).ToString();
               string dir_buduceceline_odobrio_3 = read.GetValue(10).ToString();
               string dir_buduceceline_razlog_odbij = read.GetValue(11).ToString();

               string mb_gm_buduceceline = read.GetValue(12).ToString();
               string ime_gm_buduceceline = read.GetValue(13).ToString();
               string gm_buduceceline_odobrio_4 = read.GetValue(14).ToString();
               string gm_buduceceline_razlog_odbij = read.GetValue(15).ToString();
               
               
               if(string.IsNullOrEmpty(dir_sadasnjeceline_odobrio_1))
               {
                   if (mb_dir_sadasnjeceline == StorageSession.Current.EmployeeId)
                   {
                       UpisiDA_dirsadasnjeceline1();
                   }
                   else
                   {
                       con.Close();
                       //poruka - nije odobreno na koraku br.1 (od strane direktora sadasnje celine)
                       //exit
                   }
               }
               else
                   {
                       if (dir_sadasnjeceline_odobrio_1 == "NE")
                       {
                           //poruka - direktor sadasnje celine ja odbio
                           //exit
                       }
                       else
                       {
                           korak2();
                       }
                   }
               }
               else
               {

               }
           }
        }
               
           
        

        //public void ispitajpotpisezadatizors(string cekiranizors1)
        //{

        //            OracleCommand oda;
        //            OracleConnection con = new OracleConnection();
        //            OracleDataAdapter adapter;
        //            DataSet results;
        //            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
        //            con.Open();

        //            oda = new OracleCommand("select MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, DIR_SADASNJECELINE_ODOBRIO_1, DIR_SADASNJECEL_RAZLOGODBIJ, MB_GM_SADASNJECELINE, IME_GM_SADASNJECELINE, GM_SADASNJECELINE_ODOBRIO_2, GM_SADASNJECELINE_RAZLOGODBIJ, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, DIR_BUDUCECELINE_ODOBRIO_3, DIR_BUDUCECELINE_RAZLOGODBIJ, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, GM_BUDUCECELINE_ODOBRIO_4, GM_BUDUCECELINE_RAZLOGODBIJ from ZORS_MAIN where ID = '" + cekiranizors1 + "'");
        //            oda.Connection = con;
        //            oda.CommandType = CommandType.Text;
        //            adapter = new OracleDataAdapter(oda);
        //            results = new DataSet();
        //            adapter.Fill(results);
        //            OracleDataReader read = oda.ExecuteReader();
        //            if (read.Read())
        //            {
        //                string mb_dir_sadasnjeceline = read.GetValue(0).ToString();
        //                string ime_dir_sadasnjeceline = read.GetValue(1).ToString();
        //                string dir_sadasnjeceline_odobrio_1 = read.GetValue(2).ToString();
        //                string dir_sadasnjeceline_razlog_odbij = read.GetValue(3).ToString();
                        
        //                string mb_gm_sadasnjeceline = read.GetValue(4).ToString();
        //                string ime_gm_sadasnjeceline = read.GetValue(5).ToString();
        //                string gm_sadasnjeceline_odobrio_2 = read.GetValue(6).ToString();
        //                string gm_sadasnjeceline_razlog_odbij = read.GetValue(7).ToString();

        //                string mb_dir_buduceceline = read.GetValue(8).ToString();
        //                string ime_dir_buduceceline = read.GetValue(9).ToString();
        //                string dir_buduceceline_odobrio_3 = read.GetValue(10).ToString();
        //                string dir_buduceceline_razlog_odbij = read.GetValue(11).ToString();

        //                string mb_gm_buduceceline = read.GetValue(12).ToString();
        //                string ime_gm_buduceceline = read.GetValue(13).ToString();
        //                string gm_buduceceline_odobrio_4 = read.GetValue(14).ToString();
        //                string gm_buduceceline_razlog_odbij = read.GetValue(15).ToString();

        //                con.Close();

        //                 // if (string.IsNullOrEmpty(dir_sadasnjeceline_odobrio_1))
        //                if (StorageSession.Current.EmployeeId == mb_dir_sadasnjeceline) 
        //                    {
        //                        dir_sadasnjeceline_odobrio_1 = "DA"
        //                    { 
                        
        //                else
                               

        //            }
        //            con.Close();
        //    }
       
           















        //1 DA
        protected void UpisiDA_dirsadasnjeceline1()
        {
          
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (DIR_SADASNJECELINE_ODOBRIO_1) VALUES (:DIR_SADASNJECELINE_ODOBRIO_1)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":DIR_SADASNJECELINE_ODOBRIO_1", "DA");

                cmd1.ExecuteNonQuery();
                con.Close();
                
//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        //2 DA
        protected void UpisiDA_gmsadasnjeceline2()
        {
          
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (GM_SADASNJECELINE_ODOBRIO_2) VALUES (:GM_SADASNJECELINE_ODOBRIO_2)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":GM_SADASNJECELINE_ODOBRIO_2", "DA");

                cmd1.ExecuteNonQuery();
                con.Close();
                
//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        //3 DA
        protected void UpisiDA_dirbuduceceline3()
        {
          
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (DIR_BUDUCECELINE_ODOBRIO_3) VALUES (:DIR_BUDUCECELINE_ODOBRIO_3)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":DIR_BUDUCECELINE_ODOBRIO_3", "DA");

                cmd1.ExecuteNonQuery();
                con.Close();
                
//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        //4 DA
        protected void UpisiDA_gmbuduceceline4()
        {
          
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (GM_BUDUCECELINE_ODOBRIO_4) VALUES (:GM_BUDUCECELINE_ODOBRIO_4)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":GM_BUDUCECELINE_ODOBRIO_4", "DA");

                cmd1.ExecuteNonQuery();
                con.Close();
                
//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        //5 DA
        protected void UpisiDA_izvrsni5()
        {

            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (IZVRSNIDIR_ODOBRIO_5) VALUES (:IZVRSNIDIR_ODOBRIO_5)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":IZVRSNIDIR_ODOBRIO_5", "DA");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        //1 NE
        protected void UpisiNE_dirsadasnjeceline1()
        {

            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (DIR_SADASNJECELINE_ODOBRIO_1) VALUES (:DIR_SADASNJECELINE_ODOBRIO_1)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":DIR_SADASNJECELINE_ODOBRIO_1", "NE");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        //2 NE
        protected void UpisiNE_gmsadasnjeceline2()
        {

            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (GM_SADASNJECELINE_ODOBRIO_2) VALUES (:GM_SADASNJECELINE_ODOBRIO_2)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":GM_SADASNJECELINE_ODOBRIO_2", "NE");

                cmd1.ExecuteNonQuery();
                con.Close();

//               PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        //3 NE
        protected void UpisiNE_dirbuduceceline3()
        {

            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (DIR_BUDUCECELINE_ODOBRIO_3) VALUES (:DIR_BUDUCECELINE_ODOBRIO_3)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":DIR_BUDUCECELINE_ODOBRIO_3", "NE");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        //4 NE
        protected void UpisiNE_gmbuduceceline4()
        {

            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (GM_BUDUCECELINE_ODOBRIO_4) VALUES (:GM_BUDUCECELINE_ODOBRIO_4)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":GM_BUDUCECELINE_ODOBRIO_4", "NE");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        //5 NE
        protected void UpisiNE_izvrsni5()
        {

            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (IZVRSNIDIR_ODOBRIO_5) VALUES (:IZVRSNIDIR_ODOBRIO_5)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":IZVRSNIDIR_ODOBRIO_5", "NE");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }


        //Čeda&Ćamilović odobravanje

        protected void UpisiDA_HR1()
        {
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (HR1_ODOBRIO) VALUES (:HR1_ODOBRIO)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":HR1_ODOBRIO", "DA");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        protected void UpisiDA_HR2()
        {
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (HR2_ODOBRIO) VALUES (:HR1_ODOBRIO)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":HR2_ODOBRIO", "DA");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        protected void UpisiNE_HR1()
        {
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (HR1_ODOBRIO) VALUES (:HR1_ODOBRIO)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":HR1_ODOBRIO", "NE");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        protected void UpisiNE_HR2()
        {
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (HR2_ODOBRIO) VALUES (:HR2_ODOBRIO)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":HR2_ODOBRIO", "NE");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }


        //JELENA

        protected void UpisiDA_HR_Jelena()
        {
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (HR_Jelena_ODOBRENO) VALUES (:HR_Jelena_ODOBRENO)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":HR_Jelena_ODOBRENO", "DA");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        protected void UpisiNE_HR_Jelena()
        {
            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (HR_Jelena_ODOBRENO) VALUES (:HR_Jelena_ODOBRENO)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":HR1_ODOBRIO", "NE");

                cmd1.ExecuteNonQuery();
                con.Close();

//                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

            //// 1.
            //protected string PronadjiDaLiJeMBUtabeliZORSMainDIR1(string mb)
            //{
            //    string count = "";
            //    OracleCommand comm;
            //    OracleConnection con = new OracleConnection();
            //    OracleDataAdapter adapter;
            //    DataSet results;
            //    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            //    con.Open();
            //    comm = new OracleCommand("select COUNT(MBR) from ZORS_MAIN where MB_DIR_SADASNJECELINE = '" + mb + "' and DIR_SADASNJECELINE_ODOBRIO_1 is null");
            //    comm.Connection = con;
            //    adapter = new OracleDataAdapter(comm);
            //    results = new DataSet();
            //    adapter.Fill(results);
            //    OracleDataReader read = comm.ExecuteReader();            
            //    while (read.Read())
            //    {
            //        count = Convert.ToString(read[0]);
            //    }
            //    con.Close();
            //    return count;
            //}
            //// 2.
            //protected string PronadjiDaLiJeMBUtabeliZORSMainDIR2(string mb)
            //{
            //    string count = "";
            //    OracleCommand comm;
            //    OracleConnection con = new OracleConnection();
            //    OracleDataAdapter adapter;
            //    DataSet results;
            //    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            //    con.Open();
            //    comm = new OracleCommand("select COUNT(MBR) from ZORS_MAIN where MB_DIR_BUDUCECELINE = '" + mb + "' and DIR_BUDUCECELINE_ODOBRIO_3 is null");
            //    comm.Connection = con;
            //    adapter = new OracleDataAdapter(comm);
            //    results = new DataSet();
            //    adapter.Fill(results);
            //    OracleDataReader read = comm.ExecuteReader();
            //    while (read.Read())
            //    {
            //        count = Convert.ToString(read[0]);
            //    }
            //    con.Close();
            //    return count;
            //}

            //// 3.
            //protected string PronadjiDaLiJeMBUtabeliZORSMainGM1(string mb)
            //{
            //    string count = "";
            //    OracleCommand comm;
            //    OracleConnection con = new OracleConnection();
            //    OracleDataAdapter adapter;
            //    DataSet results;
            //    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            //    con.Open();
            //    comm = new OracleCommand("select COUNT(MBR) from ZORS_MAIN where MB_GM_SADASNJECELINE = '" + mb + "' and GM_SADASNJECELINE_ODOBRIO_2 is null");
            //    comm.Connection = con;
            //    adapter = new OracleDataAdapter(comm);
            //    results = new DataSet();
            //    adapter.Fill(results);
            //    OracleDataReader read = comm.ExecuteReader();
            //    while (read.Read())
            //    {
            //        count = Convert.ToString(read[0]);
            //    }
            //    con.Close();
            //    return count;
            //}

            //// 4.
            //protected string PronadjiDaLiJeMBUtabeliZORSMainGM2(string mb)
            //{
            //    string count = "";
            //    OracleCommand comm;
            //    OracleConnection con = new OracleConnection();
            //    OracleDataAdapter adapter;
            //    DataSet results;
            //    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            //    con.Open();
            //    comm = new OracleCommand("select COUNT(MBR) from ZORS_MAIN where MB_GM_BUDUCECELINE = '" + mb + "' and GM_BUDUCECELINE_ODOBRIO_4 is null");
            //    comm.Connection = con;
            //    adapter = new OracleDataAdapter(comm);
            //    results = new DataSet();
            //    adapter.Fill(results);
            //    OracleDataReader read = comm.ExecuteReader();
            //    while (read.Read())
            //    {
            //        count = Convert.ToString(read[0]);
            //    }
            //    con.Close();
            //    return count;
            //}

        }
}
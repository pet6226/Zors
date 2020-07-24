using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using zors.Entities;

namespace zors.Repositories
{
    public class CreationRequestRepository : ICreationRequestRepository
    {
        public List<Employee> SelectEmployeesByMbr(OracleConnection connection, string mbr)
        {
            List<Employee> employees = new List<Employee>();

            OracleCommand comm;
            OracleDataAdapter adapter;
            DataSet results;
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
            connection.Open();
            comm = new OracleCommand("select ime, mbr, OBRAZOVANJE, zanimanje, strucnasprema, SMERODSEK, MESTOSTUDIRANJA, DATUMDIPLOMIRANJA, PROSECNAOCENA, OCENADIPLOMSKI, NAPOMENA, kodposla, koefzarade  from ECR1 where MBR = '" + this.TextBox3.Text + "'");

            comm.Connection = connection;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);
            OracleDataReader read = comm.ExecuteReader();
            int n = 0;
            while (read.Read())
            {
                Employee employee = new Employee
                {
                    //EmployeeMbr = Convert.ToString(read[1]),
                    //EmployeeSchool = Convert.ToString(read[2]),
                    //nastavi
                    EmployeeName = Convert.ToString(read[0]),
                    EmployeeMbr = Convert.ToString(read[1]),
                    EmployeeSchool = Convert.ToString(read[2]),
                    EmployeeProfessionalQualification = Convert.ToString(read[3]),
                    EmployeeEducation = Convert.ToString(read[4]),
                    EmployeeEducationSection = Convert.ToString(read[5]),
                    EmployeeEducationCityPlace = Convert.ToString(read[6]),
                    EmployeeEducationDate = Convert.ToString(read[7]),
                    EmployeeEducationAverageMark = Convert.ToString(read[8]),
                    EmployeeEducationAverageGraduateMark = Convert.ToString(read[9]),
                    EmployeeEducationReference = Convert.ToString(read[10]),
                    EmployeeCurrentDepartmentID = Convert.ToString(read[11]),
                    EmployeeCurrentCoefficient = Convert.ToString(read[12])
                };

                employees.Add(employee);
            }
            connection.Close();

            return employees;
        }
        

        public List<Organization> SelectOrganizationByMbr(OracleConnection connection, string mbr)
        {
            List<Organization> organizations = new List<Organization>();

            OracleCommand comm;
            OracleDataAdapter adapter;
            DataSet results;
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
            connection.Open();
            comm = new OracleCommand("select nazivcel, nazivcelineeng, nazivposla, nazivposlaeng, kodposla  from ECR1 where MBR = '" + this.TextBox3.Text + "'");
      
            comm.Connection = connection;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);
            OracleDataReader read = comm.ExecuteReader();
            int n = 0;
            while (read.Read())
            {
                Organization organization = new Organization
                {
                    OrganisationDepartmentNameSer = Convert.ToString(read[0]),
                    OrganisationDepartmentNameEng = Convert.ToString(read[1]),
                    JobNameSer = Convert.ToString(read[2]),
                    JobNameEng = Convert.ToString(read[3]),
                    JobID = Convert.ToString(read[4])                    
                };

                organizations.Add(organization);
            }
            connection.Close();

            return organizations;
        }

        List<Employee> ICreationRequestRepository.SelectEmployeesByMbr(OracleConnection connection, string mbr)
        {
            throw new NotImplementedException();
        }

        List<Organization> ICreationRequestRepository.SelectOrganiyationByMbr(OracleConnection connection, string mbr)
        {
            throw new NotImplementedException();
        }
    }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text != "")
            {
                // TextBox1.Text = DateTime.Now.ToShortDateString();

                OracleCommand comm;
                OracleConnection con = new OracleConnection();
                OracleDataAdapter adapter;
                DataSet results;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
                con.Open();
                comm = new OracleCommand("select ime, mbr, zanimanje, zanimanjeen, strucnasprema, celina, nazivcel, nazivcelineeng, nazivposla, nazivposlaeng, kodposla, koefzarade, mbrdir from ECR1 where MBR = '" + this.TextBox3.Text + "'");
                comm.Connection = con;
                adapter = new OracleDataAdapter(comm);
                results = new DataSet();
                adapter.Fill(results);
                OracleDataReader read = comm.ExecuteReader();
                int n = 0;
                while (read.Read())
                {
                    n = n + 1;
                }
                con.Close();

                if (n == 1)
                {

                    OracleCommand comm2;
                    OracleConnection con2 = new OracleConnection();
                    OracleDataAdapter adapter2;
                    DataSet results2;
                    con2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
                    con2.Open();
                    comm2 = new OracleCommand("select ime, mbr, zanimanje, zanimanjeen, strucnasprema, celina, nazivcel, nazivcelineeng, nazivposla, nazivposlaeng, kodposla, koefzarade, mbrdir, OBRAZOVANJE, MESTOSTUDIRANJA, SMERODSEK, PROSECNAOCENA, OCENADIPLOMSKI, NAPOMENA, DATUMDIPLOMIRANJA from ECR1 where MBR = '" + this.TextBox3.Text + "'");
                    comm2.Connection = con2;
                    adapter2 = new OracleDataAdapter(comm2);
                    results2 = new DataSet();
                    //adapter2.Fill(results2);
                    OracleDataReader reader2 = comm2.ExecuteReader();
                    while (reader2.Read())
                    {
                        LabelIme.Text = Convert.ToString(reader2[0]);
                        LabelMBR.Text = Convert.ToString(reader2[1]);
                        LabelSkola.Text = Convert.ToString(reader2[2]);
                        LabelSchool.Text = Convert.ToString(reader2[3]);
                        LabelStrucnaSprema.Text = Convert.ToString(reader2[4]);

                        LabelSadasnjaCelina.Text = Convert.ToString(reader2[6]);
                        LabelSadasnjaCelinaEN.Text = Convert.ToString(reader2[7]);
                        LabelSadasnjiPosao.Text = Convert.ToString(reader2[8]);
                        LabelSadasnjiPosaoEN.Text = Convert.ToString(reader2[9]);
                        LabelKodPosla.Text = Convert.ToString(reader2[10]);
                        LabelSadasnjiKoef.Text = Convert.ToString(reader2[11]);

                        string MBdirSadasnjeOrgCeline = Convert.ToString(reader2[12]);

                        LabelObrazovanje.Text = Convert.ToString(reader2[13]);
                        LabelSmerOdsek.Text = Convert.ToString(reader2[14]);
                        LabelMestoStudiranja.Text = Convert.ToString(reader2[15]);
                        LabelProsecnaOcena.Text = Convert.ToString(reader2[16]);
                        LabelOcenaDiplomski.Text = Convert.ToString(reader2[17]);
                        LabelNapomena.Text = Convert.ToString(reader2[18]);
                        if (Convert.ToString(reader2[19]) != String.Empty)
                        {
                            LabelDatumDiplomiranja.Text = Convert.ToString(reader2[19]).Remove(Convert.ToString(reader2[19]).Length - 8, 8);
                        }
                        else
                        {
                            LabelDatumDiplomiranja.Text = String.Empty;
                        }
                        //  LabelDatumDiplomiranja.Text = DateTime.ParseExact(Convert.ToString(reader2[19]), "dd'.'MM'.'yyyy", CultureInfo.InvariantCulture).ToString("yyyy'/'MM'/'dd");

                        LabelIMEdirSadasnjeOrgCeline.Text = VratiIme(MBdirSadasnjeOrgCeline);
                        LabelMBdir1.Text = MBdirSadasnjeOrgCeline;
                    }
                    LabelIMEgmSadasnjeOrgCeline.Text = PronadjiSadasnjegGMime(LabelMBR.Text);
                    LabelMBgm1.Text = PronadjiSadasnjegGMMBR(LabelMBR.Text);
                    labelmsm.Visible = false;
                    con2.Close();
                }

                else
                {
                    labelmsm.Visible = true;
                    labelmsm.Text = "* Upisali ste pogresan matični broj";
                    TextBox3.Text = "";
                    con.Close();
                    con.Close();
                }
                read.Close();
                con.Close();

            }
            else
            {
                labelmsm.Visible = true;
                labelmsm.Text = "* Matični broj mora biti upisan";
                //LabelName.Text = null;
                //LabelDepart.Text = null;
            }

            if (TextBox3.Text == StorageSession.Current.EmployeeId)
            {
                labelmsm.Visible = true;
                labelmsm.Text = "* Ne možete podneti zahtev o radnom statusu za svoj matični broj.";
                LabelIme.Text = String.Empty;
                LabelMBR.Text = String.Empty;
                LabelSkola.Text = String.Empty;
                LabelSchool.Text = String.Empty;
                LabelStrucnaSprema.Text = String.Empty;

                LabelSadasnjaCelina.Text = String.Empty;
                LabelSadasnjaCelinaEN.Text = String.Empty;
                LabelSadasnjiPosao.Text = String.Empty;
                LabelSadasnjiPosaoEN.Text = String.Empty;
                LabelKodPosla.Text = String.Empty;
                LabelSadasnjiKoef.Text = String.Empty;
                LabelIMEdirSadasnjeOrgCeline.Text = String.Empty;

                LabelObrazovanje.Text = String.Empty;
                LabelSmerOdsek.Text = String.Empty;
                LabelMestoStudiranja.Text = String.Empty;
                LabelProsecnaOcena.Text = String.Empty;
                LabelOcenaDiplomski.Text = String.Empty;
                LabelNapomena.Text = String.Empty;
            }

            else
            {
                //  labelmsm.Visible = false;
            }

        }

        protected string VratiIme(string mb)
        {
            string ime = "";
            OracleCommand comm;
            OracleConnection con = new OracleConnection();
            OracleDataAdapter adapter;
            DataSet results;
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
            con.Open();
            comm = new OracleCommand("select ime from ECR1 where MBR = '" + mb + "'");
            comm.Connection = con;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);
            OracleDataReader read = comm.ExecuteReader();
            int n = 0;
            while (read.Read())
            {
                n = n + 1;
            }
            con.Close();
            read.Close();

            if (n == 1)
            {

                OracleCommand comm2;
                OracleConnection con2 = new OracleConnection();
                OracleDataAdapter adapter2;
                DataSet results2;
                con2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
                con2.Open();
                comm2 = new OracleCommand("select ime from ECR1 where MBR = '" + mb + "'");
                comm2.Connection = con2;
                adapter2 = new OracleDataAdapter(comm2);
                results2 = new DataSet();
                //adapter2.Fill(results2);
                OracleDataReader reader2 = comm2.ExecuteReader();
                while (reader2.Read())
                {
                    ime = Convert.ToString(reader2[0]);
                }
                con.Close();
                return ime;
            }

            else
            {
                con.Close();
                return ime;
            }


        }

        protected string nadjIMEizvrsnogdirektora(string mb)
        {
            string ime = "";
            string prezime = "";
            string izvrsni = "";
            OracleCommand comm;
            OracleConnection con = new OracleConnection();
            OracleDataAdapter adapter;
            DataSet results;
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            con.Open();
            comm = new OracleCommand("select IME_NADREDJENOG, PREZIME_NADREDJENOG from prekovremeni_sasa@citacbreza.zelsd.rs where MATICNI_BROJ = '" + mb + "'");
            comm.Connection = con;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);
            OracleDataReader read = comm.ExecuteReader();
            int n = 0;
            while (read.Read())
            {
                n = n + 1;
            }
            con.Close();
            read.Close();

            if (n == 1)
            {

                OracleCommand comm2;
                OracleConnection con2 = new OracleConnection();
                OracleDataAdapter adapter2;
                DataSet results2;
                con2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
                con2.Open();
                comm2 = new OracleCommand("select IME_NADREDJENOG, PREZIME_NADREDJENOG from prekovremeni_sasa@citacbreza.zelsd.rs where MATICNI_BROJ = '" + mb + "'");
                comm2.Connection = con2;
                adapter2 = new OracleDataAdapter(comm2);
                results2 = new DataSet();
                //adapter2.Fill(results2);
                OracleDataReader reader2 = comm2.ExecuteReader();
                while (reader2.Read())
                {
                    ime = Convert.ToString(reader2[0]);
                    prezime = Convert.ToString(reader2[1]);
                    izvrsni = ime + " " + prezime;

                }
                con.Close();
                return izvrsni;
            }

            else
            {
                con.Close();
                return izvrsni;
            }
        }

        protected string nadjMBizvrsnogdirektora(string mb)
        {
            string izvrsnimb = "";
            OracleCommand comm;
            OracleConnection con = new OracleConnection();
            OracleDataAdapter adapter;
            DataSet results;
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            con.Open();
            comm = new OracleCommand("select MATICNI_BROJ_NADREDJENOG from prekovremeni_sasa@citacbreza.zelsd.rs where MATICNI_BROJ = '" + mb + "'");
            comm.Connection = con;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);
            OracleDataReader read = comm.ExecuteReader();
            int n = 0;
            while (read.Read())
            {
                n = n + 1;
            }
            con.Close();
            read.Close();

            if (n == 1)
            {

                OracleCommand comm2;
                OracleConnection con2 = new OracleConnection();
                OracleDataAdapter adapter2;
                DataSet results2;
                con2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
                con2.Open();
                comm2 = new OracleCommand("select MATICNI_BROJ_NADREDJENOG from prekovremeni_sasa@citacbreza.zelsd.rs where MATICNI_BROJ = '" + mb + "'");
                comm2.Connection = con2;
                adapter2 = new OracleDataAdapter(comm2);
                results2 = new DataSet();
                //adapter2.Fill(results2);
                OracleDataReader reader2 = comm2.ExecuteReader();
                while (reader2.Read())
                {
                    izvrsnimb = Convert.ToString(reader2[0]);

                }
                con.Close();
                return izvrsnimb;
            }

            else
            {
                con.Close();
                return izvrsnimb;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox5.Text != "")
            {
                // TextBox1.Text = DateTime.Now.ToShortDateString();

                OracleCommand comm;
                OracleConnection con = new OracleConnection();
                OracleDataAdapter adapter;
                DataSet results;
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
                con.Open();
                comm = new OracleCommand("select nazivceline, nazivengceline, navivposla, engnazivposla, sss, sifra_dir, sifra_gm from ecr2 where kodposla = '" + this.TextBox5.Text + "'");
                comm.Connection = con;
                adapter = new OracleDataAdapter(comm);
                results = new DataSet();
                adapter.Fill(results);
                OracleDataReader read = comm.ExecuteReader();
                int n = 0;
                while (read.Read())
                {
                    n = n + 1;
                }
                con.Close();

                if (n == 1)
                {

                    OracleCommand comm2;
                    OracleConnection con2 = new OracleConnection();
                    OracleDataAdapter adapter2;
                    DataSet results2;
                    con2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
                    con2.Open();
                    comm2 = new OracleCommand("select nazivceline, nazivengceline, navivposla, kodposla, engnazivposla, sss, sifra_dir, sifra_gm from ecr2 where kodposla = '" + this.TextBox5.Text + "'");
                    comm2.Connection = con2;
                    adapter2 = new OracleDataAdapter(comm2);
                    results2 = new DataSet();
                    //adapter2.Fill(results2);
                    OracleDataReader reader2 = comm2.ExecuteReader();
                    while (reader2.Read())
                    {
                        LabelNovaOrgCelina.Text = Convert.ToString(reader2[0]);
                        LabelNovaOrgCelinaENG.Text = Convert.ToString(reader2[1]);
                        LabelNoviPosao.Text = Convert.ToString(reader2[2]);
                        LabelKodPoslaNovi.Text = Convert.ToString(reader2[3]);
                        LabelNoviPosaoENG.Text = Convert.ToString(reader2[4]);
                        LabelQualLevel.Text = Convert.ToString(reader2[5]);

                        string mbdir2 = Convert.ToString(reader2[6]);
                        string mbgm2 = Convert.ToString(reader2[7]);

                        Labelmbdir2.Text = mbdir2;
                        LabelMBgm2.Text = mbgm2;
                        LabelDirektor2ime.Text = VratiIme(mbdir2);
                        LabelGM2ime.Text = VratiIme(mbgm2);

                        IzvrsniDirektorIme.Text = nadjIMEizvrsnogdirektora(mbgm2);
                        IzvrsniDirektorMB.Text = nadjMBizvrsnogdirektora(mbgm2);

                        loadDDList3(LabelKodPoslaNovi.Text);
                    }
                    labelmsm2.Visible = false;
                    con2.Close();
                }

                else
                {
                    labelmsm2.Visible = true;
                    labelmsm2.Text = "Upisani kod posla ne postoji u bazi podataka";
                    TextBox3.Text = "";
                    DropDownList3.Visible = false;
                    Labelddl.Visible = false;

                    con.Close();
                    con.Close();
                }
                read.Close();
                con.Close();

            }
            else
            {
                labelmsm2.Visible = true;
                labelmsm2.Text = "*";
                //LabelName.Text = null;
                //LabelDepart.Text = null;
                DropDownList3.Visible = false;
                Labelddl.Visible = false;
            }

        }

        protected void ButtonSAVE_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text != "") && (LabelIme.Text != "") && (LabelNovaOrgCelina.Text != "") && (TextBox4.Text != "") && (TextBox6.Text != "") && (TextBox2.Text != "") && (LabelImePodnosioca.Text != ""))
            {
                UpisiUbazu();
            }
            else
            {
                labelmsmupis.Visible = true;
            }
        }

        protected void UpisiUbazu()
        {
            String validDate1 = TextBox1.Text;
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            dateInfo.ShortDatePattern = "MM/dd/yyyy";
            DateTime datum = Convert.ToDateTime(validDate1, dateInfo);

            OracleConnection con = new OracleConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringZORS"].ConnectionString;
            con.Open();
            {
                string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR, MB_POMOCNIKGENERALNOG, MB_GENERALNI, DATUM_SYS, DATUM_PODNOSENJA, MB_GM_SADASNJECELINE, IME_GM_SADASNJECELINE, OBRAZOVANJE, SMERODSEK, MESTOSTUDIRANJA, PROSECNAOCENA, OCENADIPLOMSKI, NAPOMENA, DATUMDIPLOMIRANJA) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR, :MB_POMOCNIKGENERALNOG, :MB_GENERALNI, :DATUM_SYS, :DATUM_PODNOSENJA, :MB_GM_SADASNJECELINE, :IME_GM_SADASNJECELINE, :OBRAZOVANJE, :SMERODSEK, :MESTOSTUDIRANJA, :PROSECNAOCENA, :OCENADIPLOMSKI, :NAPOMENA, :DATUMDIPLOMIRANJA)";
                //string upit = "INSERT INTO ZORS_MAIN (MBR_PODNOSIOCA, IME_PODNOSIOCA, MBR, IME, SKOLA, SKOLA_EN, STRUCNA_SPREMA, SADASNJA_CELINA, SADASNJA_CELINA_EN, SIFRA_CELINE, SADASNJI_POSAO, SADASNJI_POSAO_EN, KOD_POSLA_SADASNJI, KOEF_SADASNJI, NOVA_ORG_CELINA, NOVA_ORG_CELINA_ENG, NOVI_POSAO, NOVI_POSAO_ENG, KOD_POSLA_NOVI, QUAL_LEVEL_NOVOGPOSLA, KOEF_NOVI, RAZLOG_PODNOSENJA, REZIM_RADA, POCETAK_SMENE, OBRAZLOZENJE, MB_DIR_SADASNJECELINE, IME_DIR_SADASNJECELINE, MB_DIR_BUDUCECELINE, IME_DIR_BUDUCECELINE, MB_GM_BUDUCECELINE, IME_GM_BUDUCECELINE, MB_IZVRSNIDIR, IME_IZVRSNIDIR) VALUES (:MBR_PODNOSIOCA, :IME_PODNOSIOCA, :MBR, :IME, :SKOLA, :SKOLA_EN, :STRUCNA_SPREMA, :SADASNJA_CELINA, :SADASNJA_CELINA_EN, :SIFRA_CELINE, :SADASNJI_POSAO, :SADASNJI_POSAO_EN, :KOD_POSLA_SADASNJI, :KOEF_SADASNJI, :NOVA_ORG_CELINA, :NOVA_ORG_CELINA_ENG, :NOVI_POSAO, :NOVI_POSAO_ENG, :KOD_POSLA_NOVI, :QUAL_LEVEL_NOVOGPOSLA, :KOEF_NOVI, :RAZLOG_PODNOSENJA, :REZIM_RADA, :POCETAK_SMENE, :OBRAZLOZENJE, :MB_DIR_SADASNJECELINE, :IME_DIR_SADASNJECELINE, :MB_DIR_BUDUCECELINE, :IME_DIR_BUDUCECELINE, :MB_GM_BUDUCECELINE, :IME_GM_BUDUCECELINE, :MB_IZVRSNIDIR, :IME_IZVRSNIDIR)";

                OracleCommand cmd1 = new OracleCommand(upit, con);

                cmd1.Parameters.AddWithValue(":MBR_PODNOSIOCA", LabelMBRpodnosioca.Text);
                cmd1.Parameters.AddWithValue(":IME_PODNOSIOCA", LabelImePodnosioca.Text);
                cmd1.Parameters.AddWithValue(":MBR", LabelMBR.Text);
                cmd1.Parameters.AddWithValue(":IME", LabelIme.Text);
                cmd1.Parameters.AddWithValue(":SKOLA", LabelSkola.Text);
                cmd1.Parameters.AddWithValue(":SKOLA_EN", LabelSchool.Text);
                cmd1.Parameters.AddWithValue(":STRUCNA_SPREMA", LabelStrucnaSprema.Text);
                cmd1.Parameters.AddWithValue(":SADASNJA_CELINA", LabelSadasnjaCelina.Text);
                cmd1.Parameters.AddWithValue(":SADASNJA_CELINA_EN", LabelSadasnjaCelinaEN.Text);
                cmd1.Parameters.AddWithValue(":SIFRA_CELINE", LabelSIFRACELINE.Text);
                cmd1.Parameters.AddWithValue(":SADASNJI_POSAO", LabelSadasnjiPosao.Text);
                cmd1.Parameters.AddWithValue(":SADASNJI_POSAO_EN", LabelSadasnjiPosaoEN.Text);
                cmd1.Parameters.AddWithValue(":KOD_POSLA_SADASNJI", LabelKodPosla.Text);
                cmd1.Parameters.AddWithValue(":KOEF_SADASNJI", LabelSadasnjiKoef.Text);
                cmd1.Parameters.AddWithValue(":NOVA_ORG_CELINA", LabelNovaOrgCelina.Text);
                cmd1.Parameters.AddWithValue(":NOVA_ORG_CELINA_ENG", LabelNovaOrgCelinaENG.Text);
                cmd1.Parameters.AddWithValue(":NOVI_POSAO", LabelNoviPosao.Text);
                cmd1.Parameters.AddWithValue(":NOVI_POSAO_ENG", LabelNoviPosaoENG.Text);
                cmd1.Parameters.AddWithValue(":KOD_POSLA_NOVI", LabelKodPoslaNovi.Text);
                cmd1.Parameters.AddWithValue(":QUAL_LEVEL_NOVOGPOSLA", LabelQualLevel.Text);
                cmd1.Parameters.AddWithValue(":KOEF_NOVI", TextBox4.Text);
                cmd1.Parameters.AddWithValue(":RAZLOG_PODNOSENJA", DropDownList1.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue(":REZIM_RADA", DropDownList2.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue(":POCETAK_SMENE", TextBox6.Text);
                cmd1.Parameters.AddWithValue(":OBRAZLOZENJE", TextBox2.Text);
                cmd1.Parameters.AddWithValue(":MB_DIR_SADASNJECELINE", LabelMBdir1.Text);
                cmd1.Parameters.AddWithValue(":IME_DIR_SADASNJECELINE", LabelIMEdirSadasnjeOrgCeline.Text);
                cmd1.Parameters.AddWithValue(":MB_DIR_BUDUCECELINE", Labelmbdir2.Text);
                cmd1.Parameters.AddWithValue(":IME_DIR_BUDUCECELINE", LabelDirektor2ime.Text);
                cmd1.Parameters.AddWithValue(":MB_GM_BUDUCECELINE", LabelMBgm2.Text);
                cmd1.Parameters.AddWithValue(":IME_GM_BUDUCECELINE", LabelGM2ime.Text);
                cmd1.Parameters.AddWithValue(":MB_IZVRSNIDIR", IzvrsniDirektorMB.Text);
                cmd1.Parameters.AddWithValue(":IME_IZVRSNIDIR", IzvrsniDirektorIme.Text);
                //UPISANA NATASA TIJANIC, POSTAVITI IZUZETKE KADA SE LOGUJE Wang Lianxi
                //cmd1.Parameters.AddWithValue(":MB_POMOCNIKGENERALNOG", LabelPomocnikGeneralnogMB2.Text);
                cmd1.Parameters.AddWithValue(":MB_GENERALNI", LabelGeneralniMaticni.Text);
                cmd1.Parameters.AddWithValue(":DATUM_SYS", DateTime.Now);
                cmd1.Parameters.AddWithValue(":DATUM_PODNOSENJA", datum);

                cmd1.Parameters.AddWithValue(":MB_GM_SADASNJECELINE", LabelMBgm1.Text);
                cmd1.Parameters.AddWithValue(":IME_GM_SADASNJECELINE", LabelIMEgmSadasnjeOrgCeline.Text);

                cmd1.Parameters.AddWithValue(":OBRAZOVANJE", LabelObrazovanje.Text);
                cmd1.Parameters.AddWithValue(":SMERODSEK", LabelSmerOdsek.Text);
                cmd1.Parameters.AddWithValue(":MESTOSTUDIRANJA", LabelMestoStudiranja.Text);
                cmd1.Parameters.AddWithValue(":PROSECNAOCENA", LabelProsecnaOcena.Text);
                cmd1.Parameters.AddWithValue(":OCENADIPLOMSKI", LabelOcenaDiplomski.Text);
                cmd1.Parameters.AddWithValue(":NAPOMENA", LabelNapomena.Text);
                cmd1.Parameters.AddWithValue(":DATUMDIPLOMIRANJA", LabelDatumDiplomiranja.Text);



                cmd1.ExecuteNonQuery();
                con.Close();

                PosaljiMejlDirektoru();
                Response.Redirect("~/Forma.aspx");

            }
            con.Close();
        }

        protected void PosaljiMejlDirektoru()
        {
            string saljinamejlDIR = PronadjiMEJLDirektora1(LabelMBdir1.Text);

            MailMessage message = new MailMessage();
            message.From = new MailAddress("ZORSnotification@hbisserbia.rs");
            message.To.Add(new MailAddress("SasaPetrovic@hbisserbia.rs"));
            // message.To.Add(new MailAddress(saljinamejlDIR));

            message.Subject = "Kreiran je ZORS: " + LabelIme.Text + " - " + LabelMBR.Text + "  ";
            //message.Body = "Podnet je zahtev za prekovremeni rad:" + "\r\n\r\n" + "http://localhost:60770/" + kljuc + "\r\n\r\n" + "Podnosilac:" + LabelSef.Text;
            //message.Body = "Podnet je zahtev za prekovremeni rad:" + "\r\n\r\n" + Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/") + 1) + "DirektorForma.aspx?ID=" + this.kljuc.ToString() + "\r\n\r\n" + "Podnosilac:" + LabelSef.Text;
            message.Body = "KREIRAN je ZORS za zaposlenog:" + "\r\n" + LabelIme.Text + " - " + LabelMBR.Text + "\r\n\r\n" + TextBox2.Text + "\r\n\r\n" + "Podnosilac:" + LabelImePodnosioca.Text + " - " + LabelMBRpodnosioca.Text;

            SmtpClient client = new SmtpClient();
            client.Send(message);
        }



        protected string PronadjiMEJLDirektora1(string mb)
        {
            string dir1mail = "";
            OracleCommand comm;
            OracleConnection con = new OracleConnection();
            OracleDataAdapter adapter;
            DataSet results;
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            con.Open();
            comm = new OracleCommand("select EMAIL from prekovremeni_sasa@citacbreza.zelsd.rs where MATICNI_BROJ = '" + mb + "'");
            comm.Connection = con;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);
            OracleDataReader read = comm.ExecuteReader();
            int n = 0;
            while (read.Read())
            {
                dir1mail = Convert.ToString(read[0]);
            }
            return dir1mail;
            read.Close();
            con.Close();
        }


        public void loadDDList3(string kodposlanovi)
        {
            DropDownList3.Visible = true;
            Labelddl.Visible = true;

            OracleCommand comm;
            OracleConnection con = new OracleConnection();
            OracleDataAdapter adapter;
            DataSet results;
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
            con.Open();

            comm = new OracleCommand("select distinct KOEFZARADE from ECR1 where kodposla = '" + kodposlanovi + "' order by KOEFZARADE desc");
            comm.Connection = con;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);

            DataTable sqlTa = new DataTable();
            adapter.Fill(sqlTa);

            using (OracleDataAdapter da = new OracleDataAdapter(comm))
                da.Fill(results, "AUser");
            DropDownList3.DataSource = results.Tables["AUser"];
            DropDownList3.DataValueField = "KOEFZARADE";
            DropDownList3.DataTextField = "KOEFZARADE";
            DropDownList3.DataBind();
            con.Close();
        }

        protected string PronadjiSadasnjegGMime(string mb)
        {
            string ime = "";
            string prezime = "";
            string imegm1 = "";
            OracleCommand comm;
            OracleConnection con = new OracleConnection();
            OracleDataAdapter adapter;
            DataSet results;
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            con.Open();
            comm = new OracleCommand("select GM_IME, GM_PREZIME from prekovremeni_sasa@citacbreza.zelsd.rs where MATICNI_BROJ = '" + mb + "'");
            comm.Connection = con;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);
            OracleDataReader read = comm.ExecuteReader();
            int n = 0;
            while (read.Read())
            {
                ime = Convert.ToString(read[0]);
                prezime = Convert.ToString(read[1]);
                imegm1 = prezime + " " + ime;
            }
            return imegm1;
            read.Close();
            con.Close();
        }

        protected string PronadjiSadasnjegGMMBR(string mb)
        {
            string mbgm1 = "";
            OracleCommand comm;
            OracleConnection con = new OracleConnection();
            OracleDataAdapter adapter;
            DataSet results;
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            con.Open();
            comm = new OracleCommand("select MBR_GM from prekovremeni_sasa@citacbreza.zelsd.rs where MATICNI_BROJ = '" + mb + "'");
            comm.Connection = con;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);
            OracleDataReader read = comm.ExecuteReader();
            int n = 0;
            while (read.Read())
            {
                mbgm1 = Convert.ToString(read[0]);
            }
            return mbgm1;
            read.Close();
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox4.Text != "")
            {
                // decimal novikoe = decimal.Parse(TextBox4.Text);
                string novikoe = (Convert.ToDouble(TextBox4.Text)).ToString("0.000");
                decimal baznazrada = Convert.ToDecimal(148.75) * Convert.ToDecimal(Pronadjibrojradnihsati()) * Convert.ToDecimal(novikoe);
                LabelBaznaZarada.Text = Decimal.Round(baznazrada, 2).ToString();
            }
        }

        protected string Pronadjibrojradnihsati()
        {
            string brradnihdana = "168";


            OracleCommand comm;
            OracleConnection con = new OracleConnection();
            OracleDataAdapter adapter;
            DataSet results;
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringUSSZAR"].ConnectionString;
            con.Open();
            comm = new OracleCommand("select BRSATI from MESECGODINA where MMGG = (SELECT trunc(sysdate) - (to_number(to_char(sysdate,'DD')) - 1) FROM dual)");

            comm.Connection = con;
            adapter = new OracleDataAdapter(comm);
            results = new DataSet();
            adapter.Fill(results);
            OracleDataReader read = comm.ExecuteReader();
            while (read.Read())
            {
                brradnihdana = Convert.ToString(read[0]);
            }
            return brradnihdana;
            con.Close();
        }
    }
}
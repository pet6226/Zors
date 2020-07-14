using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using zors.Entities;
using zors.Repositories;

namespace zors.Services
{
    public class CreationRequestService : ICreationRequestService
    {
        private ICreationRequestRepository creationRequestRepository;

        public CreationRequestService()
        {
            this.creationRequestRepository = new CreationRequestRepository();
        }
        public Employee GetEmployeeCurrent(string mbr)
        {
            if (String.IsNullOrEmpty(mbr))
            {
                // TextBox1.Text = DateTime.Now.ToShortDateString();
                OracleConnection connection = new OracleConnection();
                //otvaranje i zatvaranje konekcije vrsis u Repozitorijumu, ne ovde u servisu
                //sva biznis logika je u servisima (if, for... i bilo koji proracun) a manipulacija sa bazom u repozitorijima i tamo smestas while reader i upite
                List<Employee> employees = this.creationRequestRepository.SelectEmployeesByMbr(connection, mbr);
                if (employees.Count == 0)
                {
                    return new EmployeeNotExist
                    {
                        Message = "*Ne postoji korisnik sa tim maticnim br."
                    };
                }
                if (employees.Count == 1)
                {

                    /*OracleCommand comm2;
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
                    }*/
                    //LabelIMEgmSadasnjeOrgCeline.Text = PronadjiSadasnjegGMime(LabelMBR.Text);
                    //LabelMBgm1.Text = PronadjiSadasnjegGMMBR(LabelMBR.Text);
                    //labelmsm.Visible = false;
                    //con2.Close();
                    if (mbr == StorageSession.Current.EmployeeId)
                    {
                        return employees.Single();
                    }
                    else
                    {
                        return new EmployeeWrongSession
                        {
                            Message = "* Ne možete podneti zahtev o radnom statusu za svoj matični broj."
                        };
                    }

                }

                else
                {
                    return new EmployeeWrongMbr
                    {
                        Message = "* Upisali ste pogresan matični broj"
                    };
                    /*labelmsm.Visible = true;
                    labelmsm.Text = "* Upisali ste pogresan matični broj";
                    TextBox3.Text = "";
                    con.Close();
                    con.Close();*/
                }
                //read.Close();
                //con.Close();

            }
            else
            {
                return new EmployeeNotExisitngMbr
                {
                    Message = "* Matični broj mora biti upisan"
                };
                //labelmsm.Visible = true;
                //labelmsm.Text = "* Matični broj mora biti upisan";
                //LabelName.Text = null;
                //LabelDepart.Text = null;
            }



            /*if (TextBox3.Text == StorageSession.Current.EmployeeId)
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
            }*/
        }
        public Organization GetOrganization(string jobcode)
        {
            return new Organization();
        }
        public double CalculateNewSalary(double newCoeff)
        {
            return 0.0;
        }
        public void CreateRequest()
        {
        }
    }
}
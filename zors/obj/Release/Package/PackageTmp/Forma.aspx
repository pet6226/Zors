<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forma.aspx.cs" Inherits="zors.Forma" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;          
        }
        .auto-style2 {
            color: #0033CC;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">    
    <div style="margin-left: 10px">
    <table class="auto-style1">
        <tr>
            <td colspan="2">Podnosilac zahteva: 
                <asp:Label ID="LabelImePodnosioca" runat="server" Text="" style="font-weight: 700"></asp:Label>
&nbsp;<asp:Label ID="LabelMBRpodnosioca" runat="server" Text="" style="font-weight: 700"></asp:Label>
            <td>

        </tr>
        <tr>
            <td colspan="2" style="text-align: center">QMS.PO.KP-712-01-01<br />
                <br />
                <span class="auto-style2"><strong>HBIS GROUP Serbia Iron &amp; Steel d.o.o. Beograd</strong></span><strong><br class="auto-style2" />
                </strong>ZORS-Zahtev o radnom statusu / ECR - Employment Change Request</td>
        </tr>
        <tr>
            <td>Datum primene/Effective date: </td>            
            <td>    
                <asp:TextBox ID="TextBox1" runat="server" Height="18px" Width="68px" ></asp:TextBox>  
                <asp:CalendarExtender ID="TextBox1_CalendarExtender0" runat="server" TargetControlID="TextBox1">
                </asp:CalendarExtender>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="TextBox1"></asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="2" ErrorMessage ="* Datum je obavezno polje" ForeColor="Red" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>  
                   
        <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
            TargetControlID="TextBox1" FirstDayOfWeek="Monday">
        </asp:CalendarExtender>

            </td>
        </tr>
        <tr>
            <td>Ime i prezime zaposlenog/Employee first and last name:
                <br />
                Matični broj/ID No <asp:TextBox ID="TextBox3" runat="server" Width="90px"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" /><br/>
                <asp:Label ID="labelmsm" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LabelIme" runat="server" Text=""></asp:Label>&nbsp;
                <asp:Label ID="LabelMBR" runat="server" Text=""></asp:Label>
                <br/>
                <asp:Label ID="LabelSkola" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="LabelStrucnaSprema" runat="server" Text=""></asp:Label>
                <br/>
                <asp:Label ID="LabelSchool" runat="server" Text=""></asp:Label>&nbsp;
                <br/>
            </td>
        </tr>
        <tr>
            <td>Sadašnja org. celina/Current org. unit:</td>
            <td>
                <asp:Label ID="LabelSadasnjaCelina" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Label ID="LabelSIFRACELINE" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="LabelSadasnjaCelinaEN" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Sadašnji posao/Current job:</td>
            <td>
                <asp:Label ID="LabelSadasnjiPosao" runat="server" Text=""></asp:Label>
                &nbsp;
                <asp:Label ID="LabelKodPosla" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="LabelSadasnjiPosaoEN" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Sadašnji koeficijent/Current coefficient:</td>
            <td>
                <asp:Label ID="LabelSadasnjiKoef" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td><b>Nova org. celina/New org. unit:</b></td>
            <td>
                <asp:Label ID="LabelNovaOrgCelina" runat="server" Text="" style="font-weight: 700"></asp:Label>
                <br />
                <asp:Label ID="LabelNovaOrgCelinaENG" runat="server" Text="" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><b>Novi posao/New job:</b></td>
            <td>
                <asp:Label ID="LabelNoviPosao" runat="server" Text="" style="font-weight: 700"></asp:Label>
                &nbsp;
                <asp:Label ID="LabelKodPoslaNovi" runat="server" Text="" style="font-weight: 700"></asp:Label>
                <br />
                <asp:Label ID="LabelNoviPosaoENG" runat="server" Text="" style="font-weight: 700"></asp:Label>
            &nbsp;</td>
        </tr>
        <tr>
            <td><b></b></td>
            <td><strong>Job code:&nbsp;<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="OK" OnClick="Button2_Click" />
                </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Qual.level:
                <asp:Label ID="LabelQualLevel" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="labelmsm2" runat="server" Text="" ForeColor="#FF3300" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><b>Novi koeficijent/New coefficient: </b>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style4" Width="50px"></asp:TextBox>
            &nbsp;<asp:Label ID="labelmsmnovikeof" runat="server" style="color: #FF0000" Text="* obavezno polje" Visible="false"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><b>Razlog podnošenja zahteva/Reason for request:</b></td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="490px">
                    <asp:ListItem Value="A01">Rad na neodredjeno vreme/Indefinite period of time employment</asp:ListItem>
                    <asp:ListItem Value="A02">Povratak sa odsuženja vojnog roka/Return from military service</asp:ListItem>
                    <asp:ListItem Value="A03">Pripravnički staž/Traineeship</asp:ListItem>
                    <asp:ListItem Value="A04">Rad na odredjeno vreme/Definite period of time employment</asp:ListItem>
                    <asp:ListItem Value="A05">Povratak iz zatvora/Return from prison</asp:ListItem>
                    <asp:ListItem Value="A06">Povratak sa placene funkcije/Return from paid function</asp:ListItem>
                    <asp:ListItem Value="A07">Vraćanje na posao odlukom suda/Return to work by court decision</asp:ListItem>
                    <asp:ListItem Value="A08">PRELAZAK NA DRUGE POSLOVE/Transfer To Other Job Positions</asp:ListItem>
                    <asp:ListItem Value="A09">PROMENA KOEFICIJENTA ZARADE/Payroll Coefficient Change</asp:ListItem>
                </asp:DropDownList>
                <br />
                <strong>Izmena ugovorenih uslova rada / Change of employment contract terms</strong></td>
        </tr>
        <tr>
            <td><b></b></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><b>Režim rada/Work regime:</b></td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="250px">
                    <asp:ListItem Value="0">dnevna smena/daily shift</asp:ListItem>
                    <asp:ListItem Value="1">dve smene/two shifts</asp:ListItem>
                    <asp:ListItem Value="2">tri smene/three shifts</asp:ListItem>
                    <asp:ListItem Value="3">turnus/brigade system</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><b>Početak smene/Beginning of shift:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Width="35px"></asp:TextBox>
                <b>časova/o&#39;clock.</b>
                <asp:Label ID="labelmsmclock" runat="server" style="color: #FF0000" Text="* obavezno polje" Visible="false"></asp:Label>
                </td>
        </tr>
        <tr>
            <td><b></b></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><b>Obrazloženje zahteva/Explanation for request:</b></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="100px" MaxLength="700" TextMode="MultiLine" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="labelmsmkomentar" runat="server" style="color: #FF0000" Text="* obavezno polje" Visible="false"></asp:Label>
            </td>
        </tr>
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><strong>Direktor org. celine/ Direktor of unit
                </strong>
                <br />
                <asp:Label ID="LabelDirektor2ime" runat="server" Text=""></asp:Label>
            &nbsp;
                <asp:Label ID="Labelmbdir2" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><strong>Direktor sadašnje org. celine/Director od current unit:</strong><br />
                <asp:Label ID="LabelIMEdirSadasnjeOrgCeline" runat="server" Text=""></asp:Label>
            &nbsp;
                <asp:Label ID="LabelMBdir1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td><strong>Generalni menadžer/General Manager</strong><br />
                <asp:Label ID="LabelGM2ime" runat="server" Text=""></asp:Label>
            &nbsp;
                <asp:Label ID="LabelMBgm2" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2"><strong>Izvršni direktor/Executive director<br />
                </strong>
                <asp:Label ID="IzvrsniDirektorIme" runat="server" Text=""></asp:Label>
                <strong>&nbsp; </strong>
                <asp:Label ID="IzvrsniDirektorMB" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2"><strong>Pomoćnik Generalnog direktora/Izvršni direktor-Deputy General Director/General Counsel</strong><br />
                <asp:Label ID="LabelPomocnikGeneralnog1" runat="server" Text="Wang Lianxi"></asp:Label>
&nbsp;<asp:Label ID="LabelPomocnikGeneralnogMB1" runat="server" Text="63008"></asp:Label>
&nbsp;/
                <asp:Label ID="LabelPomocnikGeneralnog2" runat="server" Text="Nataša Tijanić"></asp:Label>
&nbsp;<asp:Label ID="LabelPomocnikGeneralnogMB2" runat="server" Text="42880"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2"><strong>Generalni Direktor/General Director HBIS GROUP Serbia Iron &amp; Steel d.o.o. Beograd (Zhao Jun)<br />
                </strong>
                <asp:Label ID="LabelGeneralniIme" runat="server" Text="Zhao Jun"></asp:Label>
            &nbsp;
                <asp:Label ID="LabelGeneralniMaticni" runat="server" Text="63018"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Button ID="ButtonSAVE" runat="server" Text="KREIRAJ / CREATE" Width="190px" OnClick="ButtonSAVE_Click" />
                <br />
                <asp:Label ID="labelmsmupis" runat="server" Text="Niste popunili sva polja/You have not completed all required fields" Visible="false" style="color: #FF0000"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

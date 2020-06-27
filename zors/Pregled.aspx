<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pregled.aspx.cs" Inherits="zors.Pregled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script type="text/javascript">

         function RadioCheck(rb) {

             var gv = document.getElementById("<%=GridViewRN1.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }
    </script>
     <style type="text/css">
        .auto-style1 {
            width: 100%; 
            border-color: gray; 
            border-style:inset;        
        }
        .auto-style2 {
            color: #0033CC;
        }
        .auto-style3 {
            text-align: center;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width: 100%;">
        <tr>
            <td colspan="2">
                <p>
                    <asp:Panel ID="Panel2" runat="server"></asp:Panel>
                    <asp:GridView ID="GridViewRN1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" 
                        onpageindexchanging="GridViewRN1_PageIndexChanging" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButton ID="check" runat="server" GroupName="check" onclick="RadioCheck(this);" AutoPostBack="True" OnCheckedChanged="check_CheckedChanged" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="ID" runat="server" Text='<%#Eval ("ID") %>' Visible="false" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" Visible="false" />

                            <asp:BoundField DataField="mbr_podnosioca" HeaderText="MBR PODNOSIOCA" SortExpression="mbr_podnosioca">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="ime_podnosioca" HeaderText="IME PODNOSIOCA" SortExpression="ime_podnosioca">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="mbr" HeaderText="MBR ZAPOSLENOG" SortExpression="mbr">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="ime" HeaderText="IME ZAPOSLENOG" SortExpression="ime">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="datum_podnosenja" HeaderText="DATUM PODNOSENJA" DataFormatString="{0:dd.MM.yyyy}" SortExpression="datum_podnosenja">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            
                         </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </p>
            </td>
        </tr>
      </table>
    <br>
    <hr>
    <br>
    <asp:Panel ID="PanelPregled" runat="server" Visible="false">
        <div style="margin-left: 10px">
    <table class="auto-style1">
        <tr>
            <td colspan="2">Podnosilac zahteva: 
                <asp:Label ID="LabelImePodnosioca" runat="server" Text="" style="font-weight: 700"></asp:Label>
&nbsp;<asp:Label ID="LabelMBRpodnosioca" runat="server" Text="" style="font-weight: 700"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelID" runat="server" Text=""></asp:Label>
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

                <asp:Label ID="LabelDatum" runat="server" Text=""></asp:Label>

            </td>
        </tr>
        <tr>
            <td>Ime i prezime zaposlenog/Employee first and last name:
                <br />
               <%-- Matični broj/ID No &nbsp;<asp:Label ID="LabelMBR1" runat="server" Text=""></asp:Label>--%>
                <br/>
            </td>
            <td>
                <asp:Label ID="LabelIme" runat="server" Text=""></asp:Label>&nbsp;
                <asp:Label ID="LabelMBR" runat="server" Text=""></asp:Label>
                <br/>
                <asp:Label ID="LabelSkola" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="LabelStrucnaSprema" runat="server" Text=""></asp:Label>
                <br/>
                <asp:Label ID="LabelSchool" runat="server" Text=""></asp:Label>&nbsp;
                <br />
                <asp:Label ID="LabelObrazovanje" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;<asp:Label ID="LabelSmerOdsek" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Label ID="LabelMestoStudiranja" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Label ID="LabelDatumDiplomiranja" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="LabelProsecnaOcena" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Label ID="LabelOcenaDiplomski" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Label ID="LabelNapomena" runat="server" Text=""></asp:Label>
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
            <td><strong>Job code:&nbsp;</strong>&nbsp;&nbsp;<asp:Label ID="LabelKodPoslaNovi2" runat="server" Text=""></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Qual.level:
                <asp:Label ID="LabelQualLevel" runat="server" Text=""></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td><b>Novi koeficijent/New coefficient: </b>
            &nbsp;</td>
            <td>
                <asp:Label ID="LabelNovikoef" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><b>Razlog podnošenja zahteva/Reason for request:</b></td>
            <td>
                <asp:Label ID="LabelDropDownList1" runat="server" Text=""></asp:Label>               
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
                <asp:Label ID="LabelDropDownList2" runat="server" Text="" style="font-weight: 700"></asp:Label> 
            </td>
        </tr>
        <tr>
            <td><b>Početak smene/Beginning of shift:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></td>
            <td>
                <asp:Label ID="LabelPocetakSmene" runat="server" Text="" style="font-weight: 700"></asp:Label> 
                <b>&nbsp; </b>
                časova/o&#39;clock.
                </td>
        </tr>
        <tr>
            <td><b></b></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><b>Obrazloženje zahteva/Explanation for request:</b></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="100px" MaxLength="700" TextMode="MultiLine" Width="500px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
       <tr>
            <td><strong>Direktor sadašnje org. celine/Director of current unit:</strong><br />
                <asp:Label ID="LabelIMEdirSadasnjeOrgCeline" runat="server" Text=""></asp:Label>
            &nbsp;
                <asp:Label ID="LabelMBdir1" runat="server" Text=""></asp:Label>
             </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><strong>Generalni menadžer sadašnje org. celine/General Manager of current unit:<br />
                </strong>
                <asp:Label ID="LabelIMEgmSadasnjeOrgCeline" runat="server" Text=""></asp:Label>
                <strong>&nbsp;&nbsp;</strong><asp:Label ID="LabelMBgm1" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><strong>Direktor org. celine/ Direktor of unit
                </strong>
                <br />
                <asp:Label ID="LabelDirektor2ime" runat="server" Text=""></asp:Label>
            &nbsp;
                <asp:Label ID="Labelmbdir2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><strong>Generalni menadžer/General Manager</strong><br />
                <asp:Label ID="LabelGM2ime" runat="server" Text=""></asp:Label>
            &nbsp;
                <asp:Label ID="LabelMBgm2" runat="server" Text=""></asp:Label>
            </td>
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
&nbsp;
               <%-- <asp:Label ID="LabelPomocnikGeneralnog2" runat="server" Text="Nataša Tijanić"></asp:Label>
&nbsp;<asp:Label ID="LabelPomocnikGeneralnogMB2" runat="server" Text="42880"></asp:Label>--%>
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
                <asp:Button ID="ButtonODOBRI" runat="server" Text="ODOBRI / APPROVE" Width="190px" style="color: #006600; font-weight: 700" OnClick="ButtonODOBRI_Click" />
                &nbsp;<asp:Button ID="ButtonODBIJ" runat="server" Text="ODBIJ / DENY "  Width="190px" style="color: #FF0000; font-weight: 700" />
                <br />
                <asp:TextBox ID="TextBox7" runat="server" Height="40px" MaxLength="500" TextMode="MultiLine" Width="250px"></asp:TextBox>
                <br />
                Razlog odbijanja / Rejection Reason
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
        </div>



    </asp:Panel>

</asp:Content>

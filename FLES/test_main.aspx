<%@ Page Title="" Language="C#" MasterPageFile="~/test.Master" AutoEventWireup="true" CodeBehind="test_main.aspx.cs" Inherits="FLES.test_main" %>
<%@ Register assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="width: 100%">
        <tr>
            <td style="height: 27px; text-align: Left; font-weight: bold;" colspan="4" valign="bottom">
                Applicant Information
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 27px; text-align: right">
                User Name:&nbsp;&nbsp;
            </td>
            <td style="width: 35%; height: 27px; text-align: left">
                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
            </td>
            <td style="width: 15%; height: 27px; text-align: right">
                Password:&nbsp;&nbsp;
            </td>
            <td style="width: 35%; height: 27px; text-align: left">
                <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 27px; text-align: right">
                Organization:&nbsp;&nbsp;
            </td>
            <td style="width: 35%; height: 27px; text-align: left">
                <asp:Label ID="Organization" runat="server" Text="Organization"></asp:Label>
            </td>
            <td style="width: 15%; height: 27px; text-align: right">
                CostCenter:&nbsp;&nbsp;
            </td>
            <td style="width: 35%; height: 27px; text-align: left">
                <asp:Label ID="CostCenter" runat="server" Text="CostCenter"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 27px; text-align: Left; font-weight: bold;" colspan="4" valign="bottom">
                Request Information
            </td>
        </tr>      
    </table>
    <table style="width: 100%">
        <tr>
            <td>

                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Add" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAlltest" TypeName="BLL.test_BLL" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ID" Type="Int32" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="Name" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ID" Type="Int32" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="Name" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" EnableTheming="True" KeyFieldName="ID" OnRowDeleting="ASPxGridView1_RowDeleting" OnRowInserting="ASPxGridView1_RowInserting" OnRowUpdating="ASPxGridView1_RowUpdating" Theme="Aqua">
                    <Settings ShowFilterRow="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Password" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn Caption="command" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="3">
                        </dx:GridViewCommandColumn>
                    </Columns>
                </dx:ASPxGridView>

            </td>
        </tr>
    </table>
</asp:Content>

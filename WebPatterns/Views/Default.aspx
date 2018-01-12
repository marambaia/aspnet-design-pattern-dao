<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPatterns.Views.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width: 800px; position: absolute; left: 50%; margin-left: -400px;">
        <div style="text-align: center;">
            <h1>Administração de Filmes</h1>
        </div>
        <div style="margin: 10px;">
            <asp:HiddenField ID="hdfId" runat="server" Value="0" />
            <label class="label">Nome:</label>
            <br />
            <asp:TextBox ID="txtName" runat="server" Width="400px"></asp:TextBox>
            <br />
            <br />
            <label class="label">Preço:</label>
            <br />
            <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>
            <br />
            <br />
            <label class="label">Ano:</label>
            <br />
            <asp:TextBox ID="txtYear" runat="server" Width="140px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Salvar" Width="140px" 
                onclick="btnRegister_Click" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="140px" 
                onclick="btnCancel_Click" />
            <br />
        </div>
        <div style="margin: 10px;">
            <asp:ObjectDataSource ID="DataSourceFilms" runat="server" 
                DataObjectTypeName="WebPatterns.Entities.Film" DeleteMethod="Delete" 
                SelectMethod="List" TypeName="WebPatterns.Business.Films"></asp:ObjectDataSource>
            <asp:GridView ID="gvFilms" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None" Width="100%" AllowPaging="True" 
                AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="DataSourceFilms">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Nome do filme" 
                        SortExpression="name" />
                    <asp:BoundField DataField="price" HeaderText="Preço (R$)" 
                        SortExpression="price" />
                    <asp:BoundField DataField="photo" HeaderText="Capa do filme" 
                        SortExpression="photo" />
                    <asp:BoundField DataField="year" HeaderText="Ano de Lançamento" 
                        SortExpression="year" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                CommandName="Delete" 
                                onclientclick="if(confirm('Deseja excluir esse filme?')){ return true; }else{ return false; }" 
                                Text="Excluir"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="id" 
                        DataNavigateUrlFormatString="Default.aspx?id={0}" Text="Editar" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />

            </asp:GridView>
        </div>
    </form>
</body>
</html>

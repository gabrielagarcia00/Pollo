﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Mestra.Master" AutoEventWireup="true" CodeBehind="chocadeira.aspx.cs" Inherits="Pollo.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="../estilos/cadastro.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <h1>Cadastro Chocadeira </h1>
        <br />

        <div class="comp">
            <label class="lbl">Chocadeira</label>
            <asp:TextBox runat="server" ID="txtNomeChocadeira" class="txt"/>    
        </div>

        <div class="comp">
            <label class="lbl">Ovo abrigado</label> 
            <asp:DropDownList runat="server" ID="ddlCod_ovo" class="ddl">  
                <asp:ListItem Text="" />
            </asp:DropDownList> 
         </div>

        <div class="comp">
            <label class="lbl">Quantidade</label> 
            <asp:TextBox runat="server" ID="txtQtdOvos" class="txt"/>
        </div>

        <asp:Button Text="Prosseguir" runat="server" ID= "btnCadastrar" class="btn" onclick="btnCadastrar_Click"/>
        <asp:Label Text="" runat="server" ID="lblErro" />
    
</asp:Content>

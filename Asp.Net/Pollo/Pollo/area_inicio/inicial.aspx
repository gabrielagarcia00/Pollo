﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicial.aspx.cs" Inherits="Pollo.area_inicio.inicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../estilos/inicial.css"/>
		<link rel="stylesheet" type="text/css" href="../estilos/scroll.css"/>
		<link rel="icon" type="image/x-icon" href="../imagens/ico.png"/>
		<link rel="icon" type="image/icon" href="../imagens/ico.png"/>
		<meta charset="utf-8"/>
		<script lang="javascript" src="../js/inicial.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <header>
		
			<div class="abrirMenu" id="abrirMenu" onclick="mostrar_menu()">
				<img id="perfil" src="../imagens/list.png" width="40px" height="40px" />
			</div>
		
			<div class="titulo-pagina">
				<p class="titulo-pagina-p">Bem vindo</p>
			</div>
			
			<div class="perfil">
				<img src="../imagens/user.png" width="40px" height="40px"/>
			</div>
				
			<div class="border"></div>
		</header>

				
		
		<main>
	
			<div class="menu" id="menu1">
				<div class="itemMenu-pollo" id="bundinha" onclick="abrirFrame('bundinha')">
					<img class="menu-icon-pollo" src="../imagens/pollo_bundinha.png" title="Chocadeiras">
					<p class="menu-title-pollo"> Pollo </p>
				</div>
			
				<div class="itemMenu" id="chocadeira" onclick="abrirFrame('chocadeira')">
					<img class="menu-icon" src="../imagens/icones/incubadora.png" title="Chocadeiras">
					<p class="menu-title"> Chocadeiras </p>
				</div>
					
				<div class="itemMenu" id="grafico" onclick="abrirFrame('ovo')">
					<img class="menu-icon" id="ovo" src="../imagens/icones/ovo.png" title="Ovo" 
					onmouseover="troca_icon('ovo')" onmouseout="esconde_icon('ovo')">
					<p class="menu-title"> Ovos </p>
				</div> 
				
				<div class="itemMenu" id="dispositivo" onclick="abrirFrame('dispositivo')">
					<img class="menu-icon" src="../imagens/icones/usb.png" title="Dipositivos">
					<p class="menu-title"> Dipositivos </p>
				</div>
				
				<div class="itemMenu" id="grafico" onclick="abrirFrame('grafico')">
					<img class="menu-icon" id="graph" src="../imagens/icones/grafico.png" title="Analytics" 
					onmouseover="troca_icon('graph')" onmouseout="esconde_icon('graph')">
					<p class="menu-title"> Analytics </p>
				</div> 

				<div class="itemMenu-logout" id="logout" onclick="abrirFrame('logout')">
					<img class="menu-icon" src="../imagens/icones/turn-off.png" title="Sair">
					<p class="menu-title"> Sair </p>
				</div>
				
			</div>
			
			<div class="submenu" id="submenu" onclick="esconder_menu()">
			
			</div>
				
			 <iframe src="monitor.html" id="frame"></iframe> 
			
		</main>
		
		<footer>
			
		</footer>
    </form>
</body>
</html>

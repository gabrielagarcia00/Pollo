﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Pollo.area_usuario
{
    public partial class cadastro : System.Web.UI.Page
    {
        string linkserver = "Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        int cod_pergunta;
        DateTime nascimento;
        int cont_user;
        int cont_email;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Verificando se o usuario está logado
            string cod_usuario = (string)Session["cod_usuario"];
            if (cod_usuario != null)
            {
                Response.Redirect("index.aspx");
            }
            #endregion

            if (IsPostBack == false)
            {
                using (SqlConnection conexao = new SqlConnection(linkserver))
                {

                    conexao.Open();
                    #region Alimentando a ddl das perguntas
                    using (SqlCommand cmd = new SqlCommand("SELECT cod_pergunta, pergunta FROM Pollo_Pergunta", conexao))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                cod_pergunta = reader.GetInt32(0);
                                string pergunta = reader.GetString(1);
                                ddlPergunta.Items.Add(new ListItem(pergunta, cod_pergunta + ""));
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            using (SqlConnection conexao = new SqlConnection(linkserver))
            {
                conexao.Open();

                    #region Verificação User repetido
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Usuario WHERE user_pollo= '" + txtUser.Text + "'", conexao))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                cont_user = 1;
                            }
                        }
                    }
                    #endregion

                    #region Verificação Email repetido
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pollo_Usuario WHERE email= '" + txtEmail.Text + "'", conexao))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                cont_email = 1;
                            }
                        }
                    }
                    #endregion

                    #region Verificação primeira parte cadastro
                    if (txtNome.Text.Length == 0)
                    {
                        txtNome.Focus();
                        return;
                    }
              
                    if (DateTime.TryParse(txtNasc.Text, out nascimento) == false)
                    {
                        txtNasc.Focus();
                        return;
                    }
                    string sexo = ddlSexo.SelectedValue;
                    if (sexo.Equals("0"))
                    {
                        ddlSexo.Focus();
                        return;
                    }

                    if (txtCelular.Text.Length == 0)
                    {
                        txtCelular.Focus();
                        return;
                    }
                    #endregion

                    #region Verificação segunda parte cadastro
                    if (txtUser.Text.Length == 0 || cont_user == 1)
                    {
                        txtUser.Focus();
                        return;
                    }

                    string email = txtEmail.Text.Trim();
                    int arroba, arroba2, ponto;

                    arroba = email.IndexOf('@');
                    arroba2 = email.LastIndexOf('@');
                    ponto = email.LastIndexOf('.');

                    if (arroba <= 0 || ponto <= (arroba + 1) || ponto == (email.Length - 1) || arroba2 != arroba || cont_email == 1)
                    {
                        txtEmail.Focus();
                        return;
                    }

                    if (txtSenha.Text.Length == 0)
                    {
                        txtSenha.Focus();
                        return;
                    }
                    #region Verificando se as senhas coincidem
                    if (txtSenha.Text != txtSenhaConfirm.Text)
                    {
                        txtSenhaConfirm.Focus();
                        return;
                    }
                    #endregion

                    #endregion

                    #region Verificação terceira parte cadastro
                    string pergunta = ddlPergunta.SelectedValue;

                    if (pergunta.Equals(""))
                    {
                        ddlPergunta.Focus();
                        return;
                    }


                    if (txtResposta.Text.Length == 0)
                    {
                        txtResposta.Focus();
                        return;
                    }
                    #endregion

                    #region Insert no banco
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Pollo_Usuario (nome, data_nasc, sexo, celular, user_pollo, email, senha, cod_pergunta, rec_resposta)  VALUES (@nome, @data_nasc, @sexo, @celular, @user_pollo, @email, @senha, @cod_pergunta, @rec_resposta )", conexao))
                    {

                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@data_nasc", txtNasc.Text);
                        cmd.Parameters.AddWithValue("@sexo", ddlSexo.Text);
                        cmd.Parameters.AddWithValue("@celular", txtCelular.Text);
                        cmd.Parameters.AddWithValue("@user_pollo", txtUser.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                        cmd.Parameters.AddWithValue("@cod_pergunta", ddlPergunta.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@rec_resposta", txtResposta.Text);
                        cmd.ExecuteNonQuery();

                        #region Limpando os campos
                        txtNome.Text = "";
                        txtNasc.Text = "";
                        txtCelular.Text = "";
                        ddlSexo.SelectedValue = "";
                        txtUser.Text = "";
                        txtEmail.Text = "";
                        txtSenha.Text = "";
                        txtSenhaConfirm.Text = "";
                        ddlPergunta.SelectedValue = "";
                        txtResposta.Text = "";
                        #endregion
                        #endregion

                    Response.Redirect("../index.aspx");
                }
            }
        }
    }
}

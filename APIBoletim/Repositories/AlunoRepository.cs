using APIBoletim.Boletim.Context.cs;
using APIBoletim.Domains;
using APIBoletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        BoletimContext conexao = new BoletimContext();

        SqlCommand cmd = new SqlCommand();

        //------------------------------------------------------------------
        //------------------------------------------------------------------
        public Aluno Alterar(Aluno a, int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "UPDATE Aluno" +
                "SET (Nome, RA, Idade) = (@Nome, @RA, @Idade)" +
                "WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;

        }

        //------------------------------------------------------------------
        //------------------------------------------------------------------

        public Aluno BuscarPorID(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Aluno WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Aluno aluno = new Aluno();

            while (dados.Read())
            {
                aluno.IdAluno = Convert.ToInt32(dados.GetValue(0));
                aluno.Nome = dados.GetValue(1).ToString();
                aluno.RA = dados.GetValue(2).ToString();
                aluno.Idade = Int32.Parse(dados.GetValue(3).ToString());
            }

            conexao.Desconectar();

            return aluno;
        }
        //------------------------------------------------------------------
        //------------------------------------------------------------------

        public Aluno Cadastrar(Aluno a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Aluno (Nome, RA, Idade) " +
                "VALUES" +
                "(@nome, @ra, @idade)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);
            cmd.Parameters.AddWithValue("@ra", a.RA);
            cmd.Parameters.AddWithValue("@idade", a.Idade);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;

        }

        //------------------------------------------------------------------
        //------------------------------------------------------------------

        public Aluno Excluir(Aluno a, int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE Aluno " +
                "WHERE IdAluno = @id";
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Desconectar();
            return a;

        }

        //------------------------------------------------------------------
        //------------------------------------------------------------------

        public List<Aluno> ListarTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Aluno";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Aluno> alunos = new List<Aluno>();

            while (dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Int32.Parse(dados.GetValue(3).ToString())
                    }
                );
            }
            conexao.Desconectar();

            return alunos;
        }
    }
}
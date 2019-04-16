using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoqueLibrary
{
    public class SqliteAcessoDados
    {
        public static List<T> LoadQuery<T>(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<T>(sql, new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveQuery<T>(T tableObject, string tableName, List<string> parameters)
        {
            /*Validators.PessoaValidator validator = new Validators.PessoaValidator();
            if (validator.Validate(tableObject).IsValid)
            {*/

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string fieldsString = "";
                string valuesString = "";

                foreach (var parameter in parameters)
                {
                    fieldsString += parameter;
                    valuesString += "@" + parameter;

                    if (!parameter.Equals(parameters.Last()))
                    {
                        fieldsString += ",";
                        valuesString += ",";
                    }
                }

                cnn.Execute("insert into " + tableName + "(" + fieldsString + ") values (" + valuesString + ")", tableObject);
            }
        }

        public static void UpdateQuery<T>(T tableObject, string tableName, List<string> parameters)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string result = "";

                foreach (var parameter in parameters)
                {
                    result += parameter + " = @" + parameter;

                    if (!parameter.Equals(parameters.Last()))
                    {
                        result += ",";
                    }
                }

                cnn.Execute("update " + tableName + " set " + result + " where ID == @ID", tableObject);
            }
        }

        public static int GetLastID(string table)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string cnnString = "SELECT seq FROM sqlite_sequence where name == '" + table + "'";
                return cnn.Query<int>(cnnString).FirstOrDefault();
            }
        }

        public static List<T> GetPesquisarTodos<T>(string sqlQuery, string tabela)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = "select * from " + tabela + " " + sqlQuery;
                var output = cnn.Query<T>(sql, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<T> GetPesquisarTodos<T>(string sqlQuery)
        {
            string tabela = "";

            if (typeof(T) == typeof(PessoaModelo))
            {
                tabela = "Pessoa";
            }

            if (typeof(T) == typeof(DepositoModelo))
            {
                tabela = "Deposito";
            }

            if (typeof(T) == typeof(ItemModelo))
            {
                tabela = "Item";
            }

            if (typeof(T) == typeof(PedidoModelo))
            {
                tabela = "Pedido";
            }

            if (typeof(T) == typeof(PraçaModelo))
            {
                tabela = "Praça";
            }

            if (typeof(T) == typeof(ProdutoModelo))
            {
                tabela = "Produto";
            }

            if (typeof(T) == typeof(VendedorModelo))
            {
                tabela = "Vendedor";
            }

            if (typeof(T) == typeof(VendedorPraçaModelo))
            {
                tabela = "VendedorPraça";
            }
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = "select * from " + tabela + " " + sqlQuery;
                var output = cnn.Query<T>(sql, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<T> GetPesquisarTodos<T>()
        {
            string tabela = "";

            if (typeof(T) == typeof(PessoaModelo))
            {
                tabela = "Pessoa";
            }

            if (typeof(T) == typeof(DepositoModelo))
            {
                tabela = "Deposito";
            }

            if (typeof(T) == typeof(ItemModelo))
            {
                tabela = "Item";
            }

            if (typeof(T) == typeof(PedidoModelo))
            {
                tabela = "Pedido";
            }

            if (typeof(T) == typeof(PraçaModelo))
            {
                tabela = "Praça";
            }

            if (typeof(T) == typeof(ProdutoModelo))
            {
                tabela = "Produto";
            }

            if (typeof(T) == typeof(VendedorModelo))
            {
                tabela = "Vendedor";
            }

            if (typeof(T) == typeof(VendedorPraçaModelo))
            {
                tabela = "VendedorPraça";
            }
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = "select * from " + tabela;
                var output = cnn.Query<T>(sql, new DynamicParameters());
                return output.ToList();
            }
        }

        public static void ExcluirQuery(int ID, string tableName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from " + tableName + " where ID == " + ID);
            }
        }

        public static void ExcluirQuery(int value, string tableName, string columnName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from " + tableName + " where " + columnName + " == " + value);
            }
        }

        public static bool RegistroExiste<T>(string columnName, string value)
        {
            string tableName = "";

            if (typeof(T) == typeof(PessoaModelo))
            {
                tableName = "Pessoa";
            }

            if (typeof(T) == typeof(DepositoModelo))
            {
                tableName = "Deposito";
            }

            if (typeof(T) == typeof(ItemModelo))
            {
                tableName = "Item";
            }

            if (typeof(T) == typeof(PedidoModelo))
            {
                tableName = "Pedido";
            }

            if (typeof(T) == typeof(PraçaModelo))
            {
                tableName = "Praça";
            }

            if (typeof(T) == typeof(ProdutoModelo))
            {
                tableName = "Produto";
            }

            if (typeof(T) == typeof(VendedorModelo))
            {
                tableName = "Vendedor";
            }

            if (typeof(T) == typeof(VendedorPraçaModelo))
            {
                tableName = "VendedorPraça";
            }

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                bool result = false;

                string query = "select * from " + tableName + " where " + tableName + "." + columnName + " == '" + value + "'";

                if (cnn.Query<T>(query, new DynamicParameters()).Count() > 0)
                {
                    result = true;
                }

                return result;
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}

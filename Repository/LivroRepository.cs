using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.WebAPI.Models;
using RepoDb;

namespace Biblioteca.WebAPI.Repository
{
    public class LivroRepository : BaseRepository<Livro, SqlConnection>
    {
        private readonly string _connectionString;

        public LivroRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Livro> GetLivros()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return connection.QueryAll<Livro>().ToList();                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Livro GetLivroById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return connection.Query<Livro>(l => l.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        
        public void CreateLivro(Livro livro)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    if(livro == null)
                    {
                        throw new ArgumentNullException(nameof(livro));
                    }

                    connection.Insert<Livro>(entity: livro);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void UpdateLivro(Livro livro)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    if (livro == null)
                    {
                        throw new ArgumentNullException(nameof(livro));
                    }

                    connection.Update<Livro>(livro);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void DeleteLivro(Livro livro)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    if (livro == null)
                    {
                        throw new ArgumentNullException(nameof(livro));
                    }

                    connection.Delete<Livro>(livro);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


    }
}

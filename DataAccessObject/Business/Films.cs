using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using DataAccessObject.DAO;
using DataAccessObject.DAO.Interfaces;
using DataAccessObject.Entities;

namespace DataAccessObject.Business
{
    public class Films
    {
        public bool Save(Film film)
        {
            IDataAccessObject<Film> dao = new FilmDAO();

            bool saved = false;

            if (film != null)
            {
                if (film.id > 0)
                {
                    if (dao.edit(film))
                        saved = true;
                }
                else
                {
                    if (dao.add(film))
                        saved = true;
                }
            }

            return saved;
        }

        public bool Delete(Film film)
        {
            IDataAccessObject<Film> dao = new FilmDAO();

            bool response = false;

            if (film != null && film.id > 0)
            {
                if (dao.delete(film))
                {
                    response = true;
                }
            }

            return response;
        }

        public Collection<Film> List()
        {
            IDataAccessObject<Film> dao = new FilmDAO();

            Collection<Film> colletion = new Collection<Film>();

            DataTable table = dao.getAll();

            foreach (DataRow row in table.Rows)
            {
                Film film = new Film
                {
                    id = int.Parse(row["id"].ToString()),
                    name = row["name"].ToString(),
                    price = Convert.ToDouble(row["price"].ToString()),
                    year = row["year"].ToString()
                };
                colletion.Add(film);
            }

            return colletion;
        }

        public Film ListUser(int id)
        {
            FilmDAO dao = new FilmDAO();

            SqlDataReader reader = dao.getById(id);

            Film film = new Film();

            while (reader.Read())
            {
                film.id = int.Parse(reader["id"].ToString());
                film.name = reader["name"].ToString();
                film.price = Convert.ToDouble(reader["price"].ToString());
                film.year = reader["year"].ToString();
            }

            return film;
        }
    }
}
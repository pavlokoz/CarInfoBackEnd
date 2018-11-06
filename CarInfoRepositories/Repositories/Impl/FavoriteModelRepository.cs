using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInfoInfrastructure.Constants;
using CarInfoModels.EntityModels;

namespace CarInfoRepositories.Repositories.Impl
{
    public class FavoriteModelRepository : IFavoriteModelRepository
    {
        public async Task<bool> CheckExistFavoriteUserModel(UserFavoriteModel userFavoriteModel)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("CheckExistFavoriteUserModel", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("UserId", userFavoriteModel.UserId));
                command.Parameters.Add(new SqlParameter("ModelId", userFavoriteModel.ModelId));

                return Convert.ToInt32(await command.ExecuteScalarAsync()) == 1;
            }
        }

        public Task<UserFavoriteModel> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Model>> GetUserFavoriteModels(int userId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetUserFavoriteModels", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("UserId", userId));

                List<Model> listToReturn = new List<Model>();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            listToReturn.Add(new Model
                            {
                                ModelId = Convert.ToInt64(reader["ModelId"]),
                                ModelName = reader["ModelName"].ToString(),
                                PhotoURL = reader["PhotoURL"].ToString(),
                                Brand = new Brand
                                {
                                    BrandName = reader["BrandName"].ToString()
                                }

                            });
                        }
                    }
                    return listToReturn;
                }
            }        
        }

        public async Task<IList<long>> GetUsersFavoriteModelIds(int userId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetUsersFavoriteModelIds", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("UserId", userId));

                List<long> listToReturn = new List<long>();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            listToReturn.Add(Convert.ToInt64(reader["ModelId"]));
                        }
                    }
                    return listToReturn;
                }
            }
        }

        public async Task<bool> SetUserFavoriteModel(UserFavoriteModel favoriteModel)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SetUserFavoriteModel", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("UserId", favoriteModel.UserId));
                command.Parameters.Add(new SqlParameter("ModelId", favoriteModel.ModelId));

                return await command.ExecuteNonQueryAsync() == 1;
            }
        }

        public async Task<bool> DeleteUserFavoriteModel(UserFavoriteModel favoriteModel)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteUserFavoriteModel", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("UserId", favoriteModel.UserId));
                command.Parameters.Add(new SqlParameter("ModelId", favoriteModel.ModelId));

                return await command.ExecuteNonQueryAsync() == 1;
            }
        }
    }
}

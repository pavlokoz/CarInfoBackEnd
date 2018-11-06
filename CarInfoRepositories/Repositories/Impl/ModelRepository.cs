using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CarInfoInfrastructure.Constants;
using CarInfoModels.EntityModels;

namespace CarInfoRepositories.Repositories.Impl
{
    public class ModelRepository : IModelRepository
    {
        public async Task<IList<Model>> GetBrandModels(long brandId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetBrandModels", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("BrandId", brandId));


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
                                },
                                Type = new CarInfoModels.EntityModels.Type
                                {
                                    TypeId = Convert.ToInt16(reader["TypeId"]),
                                    TypeName = reader["TypeName"].ToString(),
                                    CarType = new CarType
                                    {
                                        CarTypeName = reader["CarTypeName"].ToString()
                                    }
                                }
                            });
                        }
                    }
                    return listToReturn;
                }
            }
        }

        public async Task<Model> GetById(long id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetModelById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("ModelId", id));

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();
                        return new Model
                        {
                            ModelId = Convert.ToInt64(reader["ModelId"]),
                            ModelName = reader["ModelName"].ToString(),
                            PhotoURL = reader["PhotoURL"].ToString(),
                            AddInfo = reader["AddInfo"].ToString(),
                            Photos = reader["Photos"].ToString().Split(' ').ToList(),
                            Brand = new Brand
                            {
                                BrandName = reader["BrandName"].ToString()
                            },
                            Type = new CarInfoModels.EntityModels.Type
                            {
                                TypeId = Convert.ToInt16(reader["TypeId"]),
                                TypeName = reader["TypeName"].ToString(),
                                CarType = new CarType
                                {
                                    CarTypeName = reader["CarTypeName"].ToString()
                                }
                            }
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public async Task<IList<Model>> GetTopBrandModels(long brandId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetBrandTopModels", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("BrandId", brandId));


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
                                PhotoURL = reader["PhotoURL"].ToString()
                            });
                        }
                    }
                    return listToReturn;
                }
            }
        }
    }
}

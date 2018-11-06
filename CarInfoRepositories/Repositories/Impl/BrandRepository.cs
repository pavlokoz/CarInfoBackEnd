using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CarInfoInfrastructure.Constants;
using CarInfoModels.EntityModels;

namespace CarInfoRepositories.Repositories.Impl
{
    public class BrandRepository : IBrandRepository
    {
        public async Task<IList<Brand>> GetBrands()
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetBrands", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                List<Brand> listToReturn = new List<Brand>();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            listToReturn.Add(new Brand
                            {
                                BrandId = Convert.ToInt64(reader["BrandId"]),
                                BrandName = reader["BrandName"].ToString(),
                                Description = reader["Description"].ToString(),
                                PhotoURL = reader["PhotoURL"].ToString(),
                                Country = new Country
                                {
                                    CountryId = Convert.ToInt16(reader["CountryId"]),
                                    CountryName = reader["CountryName"].ToString()
                                }
                            });
                        }
                    }
                    return listToReturn;
                }
            }
        }

        public async Task<Brand> GetById(long id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetBrandById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("BrandId", id));

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();
                        return new Brand
                        {
                            BrandId = Convert.ToInt64(reader["BrandId"]),
                            BrandName = reader["BrandName"].ToString(),
                            Description = reader["Description"].ToString(),
                            PhotoURL = reader["PhotoURL"].ToString(),
                            Country = new Country
                            {
                                CountryId = Convert.ToInt16(reader["CountryId"]),
                                CountryName = reader["CountryName"].ToString()
                            }
                        };
                    }
                    return null;
                }
            }
        }

        public async Task<IList<Brand>> GetTopFourBrands()
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionStrings.DatabaseConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetTopFourBrands", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                List<Brand> listToReturn = new List<Brand>();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            listToReturn.Add(new Brand
                            {
                                BrandId = Convert.ToInt64(reader["BrandId"]),
                                BrandName = reader["BrandName"].ToString(),
                                Description = reader["Description"].ToString(),
                                PhotoURL = reader["PhotoURL"].ToString(),
                                Country = new Country
                                {
                                    CountryId = Convert.ToInt16(reader["CountryId"]),
                                    CountryName = reader["CountryName"].ToString()
                                }
                            });
                        }
                    }
                    return listToReturn;
                }
            }
        }
    }
}

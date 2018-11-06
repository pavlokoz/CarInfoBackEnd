using System.Web.Cors;

namespace CarInfoInfrastructure.Config
{
    /// <summary>
    ///    Cors Configuration
    /// </summary>
    public static class CORSConfig
    {
        /// <summary>
        ///   CORS Polisy for allow requests from FrontEnd
        /// </summary>
        public static CorsPolicy CorsPolicy = new CorsPolicy
        {
            AllowAnyHeader = true,
            AllowAnyMethod = true,
            SupportsCredentials = true,
            Origins = { Constants.Constants.CORSConstants.FrontEndUrl }
        };
    }
}

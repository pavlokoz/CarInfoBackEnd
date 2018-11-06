using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfoInfrastructure.Loggers
{
    public class Logger
    {
        #region Private Fields
        private static Logger logger;

        private static readonly Stream FileStream = new FileStream(
            Constants.Constants.LoggerConstants.PathForFileStream,
            FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);

        private readonly StreamWriter streamWriter = new StreamWriter(FileStream);

        #endregion

        #region Constructors
        static Logger()
        {
        }

        private Logger()
        {
        }

        #endregion

        #region Finalizer
        ~Logger()
        {
            this.streamWriter.FlushAsync();
            this.streamWriter.Dispose();
            FileStream.FlushAsync();
            FileStream.Dispose();
        }

        #endregion

        #region Public Methods
        public static Logger GetInstance()
        {
            return logger ?? (logger = new Logger());
        }

        public async void AsyncLogException(Exception ex)
        {
            await this.streamWriter.WriteLineAsync(DateTime.Now + "\n" + ex + "\n");
        }

        public async void AsyncLogMessage(string message)
        {
            await this.streamWriter.WriteLineAsync(DateTime.Now + "\n" + message + "\n");
        }

        #endregion
    }
}

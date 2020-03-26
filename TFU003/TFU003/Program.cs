using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using log4net;
using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json.Linq;
using TFU001;
using TwinCAT.Ads;
using TwinCAT.JsonExtension;

namespace TFU003
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        //const int SW_SHOW = 5;
        
        public static int Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);

        [Argument(0, "File")]
        public string FilePath { get; set; }
        [Argument(1, "Method")] public FileOperationMethod Method { get; set; }
        [Argument(2, "Field")] public string Field { get; set; }
        [Option(ShortName = "AdsNetId")] public string AdsNetId { get; set; } = "";
        [Option(ShortName = "AdsPort")] public int AdsPort { get; set; } = 851;

        private static void CreateLogger()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log.config"));
            LogManager.CreateRepository(Constants.LoggingRepositoryName);
        }
        public async Task OnExecute()
        {
            var adsClient = new TcAdsClient { Synchronize = false };
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            CreateLogger();
            var logger = LoggerFactory.GetLogger();

            try
            {

                logger.Debug("Starting Json Read Writer");
                logger.Debug($"Connecting to Beckhoff Port: {AdsPort} - AdsNet: '{AdsNetId}'");
                adsClient.Connect(AdsNetId, AdsPort);

                logger.Debug($"Method: {Method}");

                logger.Debug($"File: {FilePath}");
                
                logger.Debug($"Field: {Field}");

                logger.Debug($"Executing...");

                if (Method == FileOperationMethod.Write)
                {
                    var content = File.ReadAllText(FilePath);
                    logger.Debug($"Writing json into {Field}...");
                    var objectResponse = JObject.Parse(content);
                    await adsClient.WriteJson(Field, objectResponse);
                }
                else if (Method == FileOperationMethod.Read)
                {
                    var json = await adsClient.ReadJson(Field);
                    File.WriteAllText(FilePath, json.ToString());
                }
                else
                {
                    logger.Warn("Invalid Method");
                }

                adsClient.Disconnect();
            }
            catch (Exception e)
            {
                logger.Error($"Error while calling Json Parser: {e}", e);
                logger.Error($"{e.StackTrace}");
            }
            finally
            {
                adsClient?.Dispose();
            }
        }
    }

    public enum FileOperationMethod
    {
        Read,
        Write
    }
}

using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Chickenium
{
    // こんな感じで使います。
    //const string ConfigFileName = "App.Config.json";
    //const string ConfigClassName = "appSettings";
    //const string ConfigFieldName = "bot_setting";
    //Logger.log("設定ファイル'" + ConfigFileName + "'を読み込みます");
    //        SqlServerConnector connector = new Chickenium.SqlServerConnector(ConfigFileName, ConfigClassName, ConfigFieldName);
    //SqlConnection connection = connector.Connection;

    /// <summary>
    /// jsonから接続文字列を取得します。
    /// SqlServerに接続して、その接続情報を取得します。
    /// </summary>
    public class SqlServerConnector
    {
        #region フィールド
        /// <summary>
        /// 接続
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// 接続
        /// 1つのアプリに1つだけ
        /// </summary>
        public SqlConnection Connection
        {
            get { return connection; }
        }
        #endregion

        #region 初期化
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configFileName">jsonファイル名</param>
        /// <param name="className">クラス名</param>
        /// <param name="fieldName">フィールド名</param>
        public SqlServerConnector(string configFileName, string className, string fieldName)
        {
            Logger.Log("DBに接続します");

            // データベース接続の準備
            connection = GetConnection(configFileName, className, fieldName);

            // データベースの接続開始
            connection.Open();
        }
        #endregion

        #region GetConnection:DB接続を作成して取得する
        /// <summary>
        /// DB接続を作成して取得する
        /// </summary>
        /// <returns></returns>
        /// <param name="configFileName">jsonファイル名</param>
        /// <param name="className">クラス名</param>
        /// <param name="fieldName">フィールド名</param>
        public static SqlConnection GetConnection(string configFileName, string className, string fieldName)
        {
            string connectionString = GetConnectionString(configFileName, className, fieldName);
            return new SqlConnection(connectionString);
        }
        #endregion

        #region DbContextOptions:DB接続オプションを作成して取得する
        /// <summary>
        /// DB接続オプションを作成して取得する
        /// </summary>
        /// <returns></returns>
        /// <param name="configFileName">jsonファイル名</param>
        /// <param name="className">クラス名</param>
        /// <param name="fieldName">フィールド名</param>
        /// <param name="loggerProvider">ロガー</param>
        public static DbContextOptions GetDbContextOptions(string configFileName, string className, string fieldName, ILoggerProvider loggerProvider = null)
        {
            string connectionString = GetConnectionString(configFileName, className, fieldName);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder()
                .UseSqlServer(new SqlConnection(connectionString));

            // Logger
            if (loggerProvider != null)
            {
                var MyLoggerFactory = new LoggerFactory(new[] { new AppLoggerProvider() });
                dbContextOptionsBuilder.UseLoggerFactory(MyLoggerFactory);
            }

            return dbContextOptionsBuilder.Options;
        }
        #endregion

        #region GetConnectionString:接続文字列を取得する
        /// <summary>
        /// 接続文字列を取得する
        /// </summary>
        /// <param name="configFileName">jsonファイル名</param>
        /// <param name="className">クラス名</param>
        /// <param name="fieldName">フィールド名</param>
        public static string GetConnectionString(string configFileName, string className, string fieldName)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(configFileName, optional: true).Build();
            string connectionString = configuration[className + ":" + fieldName];
            Logger.Log("接続文字列:'" + connectionString + "'");
            return connectionString;
        }
        #endregion

        #region Close:データベースの接続終了
        /// <summary>
        /// データベースの接続終了
        /// </summary>
        public void Close()
        {
            // データベースの接続終了
            connection.Close();
        }
        #endregion
    }
}

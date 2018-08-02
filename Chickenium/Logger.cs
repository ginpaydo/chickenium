using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Chickenium
{
    /// <summary>
    /// ログを記録するためのメソッドを持ったクラス
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// 日付フォーマット
        /// </summary>
        public const string dateFormat = "yyyy/MM/dd HH:mm:ss";

        /// <summary>
        /// エラーログファイル名
        /// </summary>
        public const string errorLogFileName = "./error.log";

        /// <summary>
        /// デバッグログファイル名
        /// </summary>
        public const string debugLogFileName = "./debug.log";

        #region errorLog:エラーログの簡易ファイル出力
        /// <summary>
        /// とりあえずエラーをテキストで吐く時に呼ぶ
        /// 本実装ではなるべく呼ばない
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void ErrorLog(string message)
        {
            string data = DateTime.Now.ToString(Logger.dateFormat) + "," + message + Environment.NewLine;
            System.IO.File.AppendAllText(errorLogFileName, data);
        }
        #endregion

        #region debugLog:デバッグログの簡易ファイル出力
        /// <summary>
        /// とりあえずテキストで吐く時に呼ぶ
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void DebugLog(string message)
        {
            string data = DateTime.Now.ToString(Logger.dateFormat) + "," + message + Environment.NewLine;
            System.IO.File.AppendAllText(debugLogFileName, data);
        }
        #endregion

        #region log:とりあえずログ出力の仮メソッド、あとでDBに対応する
        /// <summary>
        /// とりあえずログ出力の仮メソッド
        /// </summary>
        /// <param name="message">メッセージ</param>
        public static void Log(string message)
        {
            string data = DateTime.Now.ToString(Logger.dateFormat) + "," + message;
            Console.WriteLine(data);
            //System.IO.File.AppendAllText("./macd.log", data, Encoding.Unicode);

        }
        #endregion

        // TODO:実行した行番号やファイルパスが取れるらしい。後で試して見ること。
        public static void GetLine_2([CallerLineNumber]int line = 0,
                                     [CallerMemberName]string name = "",
                                     [CallerFilePath]string path = "")
        {
            Console.WriteLine("行番号(2) = " + line);
            Console.WriteLine("名前(2) = " + name);
            Console.WriteLine("パス(2) = " + path);
        }
    }
}

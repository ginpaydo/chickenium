using System;
using Microsoft.Extensions.Logging;

namespace Chickenium
{
    // ロガープロバイダー
    public class AppLoggerProvider : ILoggerProvider
    {
        // ロガーを生成
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        public void Dispose()
        {
        }

        // ロガー
        private class ConsoleLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state) => null;
            public bool IsEnabled(LogLevel logLevel) => true;

            // ログを出力
            public void Log<TState>(
                LogLevel logLevel, EventId eventId,
                TState state, Exception exception,
                Func<TState, Exception, string> formatter)
            {
#if DEBUG
                // コンソールに出力
                //Console.WriteLine(formatter(state, exception));
#endif
            }
        }
    }
}

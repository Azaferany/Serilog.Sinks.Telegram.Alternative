// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TelegramSinkOptions.cs" company="H�mmer Electronics">
// The project is licensed under the MIT license.
// </copyright>
// <summary>
//   Container for all Telegram sink configurations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Serilog.Sinks.Telegram
{
    using System;

    using Serilog.Events;

    /// <summary>
    /// Container for all Telegram sink configurations.
    /// </summary>
    public class TelegramSinkOptions
    {
        /// <summary>
        /// The default batch size limit.
        /// </summary>
        private const int DefaultBatchSizeLimit = 1;

        /// <summary>
        /// The default period.
        /// </summary>
        private static readonly TimeSpan DefaultPeriod = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Initializes a new instance of the <see cref="TelegramSinkOptions"/> class.
        /// </summary>
        /// <param name="botToken">The Telegram bot token.</param>
        /// <param name="chatId">The Telegram chat id.</param>
        /// <param name="batchSizeLimit">The maximum number of events to post in a single batch; defaults to 1 if
        /// not provided i.e. no batching by default.</param>
        /// <param name="period">The time to wait between checking for event batches; defaults to 1 sec if not
        /// provided.</param>
        /// <param name="formatProvider">The format provider used for formatting the message.</param>
        /// <param name="minimumLogEventLevel">The minimum log event level to use.</param>
        /// <param name="sendBatchesAsSingleMessages">A value indicating whether the batches are sent as single messages or as one block of messages.</param>
        public TelegramSinkOptions(string botToken, string chatId, int? batchSizeLimit = null, TimeSpan? period = null, IFormatProvider formatProvider = null, LogEventLevel minimumLogEventLevel = LogEventLevel.Verbose, bool? includeStackTrace = true, bool ? sendBatchesAsSingleMessages = true)
        {
            if (botToken == null)
            {
                throw new ArgumentNullException(nameof(botToken));
            }

            if (string.IsNullOrEmpty(botToken))
            {
                throw new ArgumentException(nameof(botToken));
            }

            this.BotToken = botToken;
            this.ChatId = chatId;
            this.BatchSizeLimit = batchSizeLimit ?? DefaultBatchSizeLimit;
            this.Period = period ?? DefaultPeriod;
            this.FormatProvider = formatProvider;
            this.MinimumLogEventLevel = minimumLogEventLevel;
            this.SendBatchesAsSingleMessages = sendBatchesAsSingleMessages ?? true;
            this.IncludeStackTrace = includeStackTrace ?? true;
        }

        /// <summary>
        /// Gets the Telegram bot token.
        /// </summary>
        public string BotToken { get; }

        /// <summary>
        /// Gets the Telegram chat id.
        /// </summary>
        public string ChatId { get; }

        /// <summary>
        /// Gets the maximum number of events to post in a single batch.
        /// </summary>
        public int BatchSizeLimit { get; }

        /// <summary>
        /// Gets the time to wait between checking for event batches.
        /// </summary>
        public TimeSpan Period { get; }

        /// <summary>
        /// Gets the format provider used for formatting the message.
        /// </summary>
        public IFormatProvider FormatProvider { get; }

        /// <summary>
        /// Gets the minimum log event level.
        /// </summary>
        public LogEventLevel MinimumLogEventLevel { get; }

        /// <summary>
        /// Gets a value indicating whether the batches are sent as single messages or as one block of messages.
        /// </summary>
        public bool SendBatchesAsSingleMessages { get; }

        /// <summary>
		/// Gets whether stack traces should be sent with messages.
		/// </summary>
		public bool IncludeStackTrace { get; }
    }
}
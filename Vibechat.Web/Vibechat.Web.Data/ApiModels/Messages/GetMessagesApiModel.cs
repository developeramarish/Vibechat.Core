﻿namespace VibeChat.Web.ApiModels
{
    /// <summary>
    ///     Api request for receiving messages
    /// </summary>
    public class GetMessagesApiModel
    {
        public int ConversationID { get; set; }

        public int MessagesOffset { get; set; }

        public int Count { get; set; }

        /// <summary>
        ///     Return messages starting from this id, -1 if not used.
        /// </summary>
        public int MaxMessageId { get; set; }
    }
}
﻿namespace Vibechat.Web.Data.ApiModels.Conversation
{
    public class ChangeConversationNameRequest
    {
        public string Name { get; set; }

        public int ConversationId { get; set; }
    }
}
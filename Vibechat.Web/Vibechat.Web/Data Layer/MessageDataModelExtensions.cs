using System;
using VibeChat.Web.Data.DataModels;
using Vibechat.Web.Data_Layer.DataModels;
using Vibechat.Web.DTO.Messages;

namespace VibeChat.Web
{
    public static class MessageDataModelExtensions
    {
        public static MessageDataModel Create(this MessageDataModel value, AppUser user, int chatId)
        {
            value.User = user;
            value.ConversationID = chatId;
            value.TimeReceived = DateTime.UtcNow;
            value.State = MessageState.Delivered;
            return value;
        }
        
        public static MessageDataModel AsSecure(this MessageDataModel value, string payload)
        {
            value.Type = MessageType.Reserved;
            value.EncryptedPayload = payload;
            return value;
        }

        public static MessageDataModel AsText(this MessageDataModel value, string text)
        {
            value.MessageContent = text;
            value.Type = MessageType.Text;
            return value;
        }
        
        public static MessageDataModel AsForwarded(this MessageDataModel value, MessageDataModel forwardedMessage)
        {
            value.Type = MessageType.Forwarded;
            value.ForwardedMessage = forwardedMessage;
            return value;
        }
        
        public static MessageDataModel AsAttachment(this MessageDataModel value, MessageAttachmentDataModel attachment)
        {
            value.AttachmentInfo = attachment;
            value.Type = MessageType.Attachment;
            return value;
        }
        
        public static MessageDataModel AsEvent(this MessageDataModel value, ChatEventDataModel cEventDto)
        {
            value.Event = cEventDto;
            value.Type = MessageType.Event;
            return value;
        }
    }
}
﻿using System.Threading.Tasks;
using Vibechat.DataLayer.DataModels;
using Vibechat.Shared.DTO.Messages;

namespace Vibechat.DataLayer.Repositories
{
    public interface IAttachmentKindsRepository : IAsyncRepository<AttachmentKindDataModel>
    {
        ValueTask<AttachmentKindDataModel> GetById(AttachmentKind id);
    }
}
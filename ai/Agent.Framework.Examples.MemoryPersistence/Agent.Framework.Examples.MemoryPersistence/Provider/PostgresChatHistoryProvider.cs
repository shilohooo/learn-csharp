using Agent.Framework.Examples.MemoryPersistence.Context;
using Microsoft.Agents.AI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OpenAI.Chat;
using ChatMessage = Microsoft.Extensions.AI.ChatMessage;

namespace Agent.Framework.Examples.MemoryPersistence.Provider;

public class PostgresChatHistoryProvider(ChatMsgContext chatMsgContext) : ChatHistoryProvider
{
    /// <inheritdoc />
    protected override async ValueTask<IEnumerable<ChatMessage>> ProvideChatHistoryAsync(InvokingContext context,
        CancellationToken cancellationToken = new())
    {
        var chatMsgs = await chatMsgContext.ChatMessages.AsNoTracking()
            .Include(chatMsg => chatMsg.Contents)
            .ToListAsync(cancellationToken);

        return chatMsgs.Select(chatMsg =>
        {
            var chatMessage = new ChatMessage
            {
                MessageId = chatMsg.MsgId,
                Role = new ChatRole(chatMsg.Role),
                AuthorName = chatMsg.AuthorName,
                CreatedAt = chatMsg.CreatedAt,
                Contents = chatMsg.Contents.Select(chatMsgContent =>
                {
                    return new ChatMessageContent();
                }).ToList()
            };
            return chatMessage;
        }).ToList();
    }

    /// <inheritdoc />
    protected override async ValueTask StoreChatHistoryAsync(InvokedContext context,
        CancellationToken cancellationToken = new())
    {
        return base.StoreChatHistoryAsync(context, cancellationToken);
    }
}
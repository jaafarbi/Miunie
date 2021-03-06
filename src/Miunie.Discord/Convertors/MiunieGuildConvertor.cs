using Discord.WebSocket;
using Miunie.Core;
using System.Linq;

namespace Miunie.Discord.Convertors
{
    public class MiunieGuildConvertor
    {
        public MiunieGuild DiscordGuildToMiunieGuild(SocketGuild g)
            => new MiunieGuild
            {
                Id = g.Id,
                Name = g.Name,
                MemberCount = g.MemberCount,
                ChannelNames = g.Channels.Select(x => x.Name),
                TextChannelCount = g.Channels.Count(x => x is SocketTextChannel),
                VoiceChannelCount = g.Channels.Count(x => x is SocketVoiceChannel),
                CreationDate = g.CreatedAt.UtcDateTime,
                Roles = g.Roles.Select(r => r.DiscordRoleToMiunieRole())
            };
    }
}

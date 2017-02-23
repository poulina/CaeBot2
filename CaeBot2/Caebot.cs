using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace CaeBot2
{
    class Caebot
    {
        DiscordClient discord;
        // Bot settings
        private readonly String DISCORD_API_KEY = "Mjg0MDIxMTU0MTcwMTQyNzIw.C496Fg.4e9f9uqZIwnm2JkWDwwgZAxolho";
        private readonly char COMMAND_PREFIX = '!';
        private CommandService caebotCommands;

        // Raiding related strings
        private readonly String CAEDAS_LOGS = "https://www.warcraftlogs.com/guilds/51006";
        private readonly String CAEDAS_EPGP = "http://www.epgpweb.com/guild/us/Kil%27jaeden/Caedas/";

        // Raiding Strategies
        private readonly String NIGHTHOLD_OVERVIEW = "http://imgur.com/r/wow/DXkLS";

        // Class discord links
        private readonly String DISCORD_MAGE = "https://discord.gg/EYPPTyy";
        private readonly String DISCORD_DRUID = "https://discord.gg/0dWu0WkuetF87H9H";
        private readonly String DISCORD_DEATH_KNIGHT = "https://discord.gg/0ez1cFfUH3ingV96";
        private readonly String DISCORD_HUNTER = "https://discord.gg/yqer4BX";
        private readonly String DISCORD_SHAMAN = "https://discord.gg/0VcupJEQX0HuE5HH";
        private readonly String DISCORD_WARRIOR = "https://discord.gg/0pYY7932lTH4FHW6";
        private readonly String DISCORD_PALADIN = "https://discord.gg/0dvRDgpa5xZHFfnD";
        private readonly String DISCORD_ROGUE = "https://discord.gg/0h08tydxoNhfDVZf";
        private readonly String DISCORD_DEMON_HUNTER = "https://discord.gg/zGGkNGC";
        private readonly String DISCORD_PRIEST = "https://discord.gg/0f1Ta8lT8xXXEAIY";
        private readonly String DISCORD_MONK = "https://discord.gg/0dkfBMAxzTkWj21F";
        private readonly String DISCORD_WARLOCK = "https://discord.gg/0onXDymd9Wpc2CEu";

       public Caebot()
        {
            // Instantiate discord client
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            // Set prefix setting
            discord.UsingCommands(x =>
            {
                x.PrefixChar = COMMAND_PREFIX;
                x.AllowMentionPrefix = true;
            });

            // Instantiate command list
            caebotCommands = discord.GetService<CommandService>();

            // Create commands
            CreateCommand("logs", CAEDAS_LOGS);
            CreateCommand("epgp", CAEDAS_EPGP);
            CreateCommand("nh", NIGHTHOLD_OVERVIEW);
            CreateCommand("discord mage", DISCORD_MAGE);
            CreateCommand("discord dk", DISCORD_DEATH_KNIGHT);
            CreateCommand("discord dh", DISCORD_DEMON_HUNTER);
            CreateCommand("discord rogue", DISCORD_ROGUE);
            CreateCommand("discord druid", DISCORD_DRUID);
            CreateCommand("discord monk", DISCORD_MONK);
            CreateCommand("discord warlock", DISCORD_WARLOCK);
            CreateCommand("discord warrior", DISCORD_WARRIOR);
            CreateCommand("discord shaman", DISCORD_SHAMAN);
            CreateCommand("discord priest", DISCORD_PRIEST);
            CreateCommand("discord paladin", DISCORD_PALADIN);
            CreateCommand("discord hunter", DISCORD_HUNTER);

            // Initiate bot
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect(DISCORD_API_KEY, TokenType.Bot);
            });
        }

        // Creates a Caebot command using a command string and output string
        private void CreateCommand(String command, String output)
        {
            caebotCommands.CreateCommand(command)
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage(output);
                });
        }

        // Write to console
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

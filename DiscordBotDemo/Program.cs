// See https://aka.ms/new-console-template for more information
using DiscordBotDemo.Data;
using DiscordBotDemo.DataAccess;
using DSharpPlus;
using System;

Console.WriteLine("Hello, World!");

var db = new MongoConnect("joseph");

var discordClient = new DiscordClient(new DiscordConfiguration
{
    Token = "",
    TokenType = TokenType.Bot,
    Intents = DiscordIntents.All
});

discordClient.MessageCreated += DiscordClient_MessageCreated;

async Task DiscordClient_MessageCreated(DiscordClient client, DSharpPlus.EventArgs.MessageCreateEventArgs message)
{
    //Add
    if(message.Message.Content.Substring(0,4) == "http")
    {
        var links = await db.GetAllLinks("Links");
        //foreach(var link in links)
        //{
        //    if (link.Link == message.Message.Content)
        //        return;
        //}

        await db.AddLink("Links", message.Message.Content);
        await message.Message.RespondAsync("Link added");
    }

    if (message.Message.Content == "!trollme")
    {
        var links = await db.GetAllLinks("Links");

        var rnd = new Random();

        var index = rnd.Next(links.Count);

        await message.Message.RespondAsync(links[index].Link);
    }



}

await discordClient.ConnectAsync();
await Task.Delay(-1);
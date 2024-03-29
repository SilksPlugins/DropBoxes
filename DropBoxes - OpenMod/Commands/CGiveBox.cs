﻿extern alias JetBrainsAnnotations;
using Cysharp.Threading.Tasks;
using DropBoxes.API;
using DropBoxes.Chat;
using DropBoxes.Configuration;
using OpenMod.API.Prioritization;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Users;
using SilK.Unturned.Extras.Configuration;
using System;

namespace DropBoxes.Commands
{
    [Command("givebox", Priority = Priority.High)]
    [CommandSyntax("<player> <box>")]
    [CommandDescription("Give an online player a loot box.")]
    public class CGiveBox : LootBoxCommand
    {
        private readonly ILootBoxManager _lootBoxManager;
        private readonly IConfigurationParser<DropBoxesConfiguration> _configuration;

        public CGiveBox(IServiceProvider serviceProvider,
            ILootBoxManager lootBoxManager,
            IConfigurationParser<DropBoxesConfiguration> configuration) : base(serviceProvider)
        {
            _lootBoxManager = lootBoxManager;
            _configuration = configuration;
        }

        protected override async UniTask OnExecuteAsync()
        {
            var user = await Context.Parameters.GetAsync<UnturnedUser>(0);
            var lootBoxAsset = await GetLootBoxAsset(1);

            await _lootBoxManager.GiveLootBox(user.SteamId.m_SteamID, lootBoxAsset);

            await this.PrintMessageWithIconAsync(
                StringLocalizer["Commands:Success:GiveBox", new {User = user, LootBox = lootBoxAsset}],
                _configuration.Instance.IconUrl);

            await user.PrintMessageWithIconAsync(
                StringLocalizer["Commands:Success:ReceivedBox", new {LootBox = lootBoxAsset}],
                _configuration.Instance.IconUrl);
        }
    }
}

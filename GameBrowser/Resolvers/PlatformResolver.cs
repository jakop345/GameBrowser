﻿using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Resolvers;
using MediaBrowser.Model.Entities;
using System;
using System.Linq;

namespace GameBrowser.Resolvers
{
    /// <summary>
    /// Class ConsoleFolderResolver
    /// </summary>
    public class PlatformResolver : ItemResolver<GameSystem>
    {
        /// <summary>
        /// Resolves the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>ConsoleFolder.</returns>
        protected override GameSystem Resolve(ItemResolveArgs args)
        {
            if (args.IsDirectory)
            {
                var collectionType = args.GetCollectionType();

                if (!string.Equals(collectionType, CollectionType.Games, StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                var configuredSystems = Plugin.Instance.Configuration.GameSystems;

                if (configuredSystems == null)
                {
                    return null;
                }

                var system =
                    configuredSystems.FirstOrDefault(
                        s => string.Equals(args.Path, s.Path, StringComparison.OrdinalIgnoreCase));

                if (system != null)
                {
                    return new GameSystem();
                }
            }

            return null;
        }
    }
}

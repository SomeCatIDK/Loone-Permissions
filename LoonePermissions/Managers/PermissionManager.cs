﻿using System;
using System.Collections.Generic;

using Rocket.API;
using Rocket.API.Serialisation;
using Rocket.Core.Logging;

namespace ChubbyQuokka.LoonePermissions.Managers
{
    public static class PermissionManager
    {
        public static void Reload()
        {
            Logger.LogWarning("It is not necessary to reload permissions with this plugin!");
        }

        #region Blocking Calls
        public static RocketPermissionsProviderResult AddGroupBlocking(RocketPermissionsGroup group)
        {
            return MySqlManager.AddGroup(group);
        }

        public static RocketPermissionsProviderResult AddPlayerToGroupBlocking(string groupId, IRocketPlayer player) => MySqlManager.AddPlayerToGroup(groupId, player);

        public static RocketPermissionsProviderResult DeleteGroupBlocking(string groupId) => MySqlManager.DeleteGroup(groupId);

        public static RocketPermissionsGroup GetGroupBlocking(string groupId) => MySqlManager.GetGroup(groupId);

        public static List<RocketPermissionsGroup> GetGroupsBlocking(IRocketPlayer player, bool includeParentGroups) => MySqlManager.GetGroups(player, includeParentGroups);

        public static List<Permission> GetPermissionsBlocking(IRocketPlayer player) => MySqlManager.GetPermissions(player);

        public static List<Permission> GetPermissionsBlocking(IRocketPlayer player, List<string> requestedPermissions) => MySqlManager.GetPermissions(player, requestedPermissions);

        public static bool HasPermissionBlocking(IRocketPlayer player, List<string> requestedPermissions) => MySqlManager.HasPermission(player, requestedPermissions);

        public static RocketPermissionsProviderResult RemovePlayerFromGroupBlocking(string groupId, IRocketPlayer player) => MySqlManager.RemovePlayerFromGroup(groupId, player);

        public static RocketPermissionsProviderResult SaveGroupBlocking(RocketPermissionsGroup group) => MySqlManager.SaveGroup(group);

        #endregion
        #region Async Calls

        public static void AddGroupAsync(RocketPermissionsGroup group, Action<RocketPermissionsProviderResult> callback)
        {
            Action async = () =>
            {
                RocketPermissionsProviderResult result = AddGroupBlocking(group);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }

        public static void AddPlayerToGroupAsync(string groupId, IRocketPlayer player, Action<RocketPermissionsProviderResult> callback)
        {
            Action async = () =>
            {
                RocketPermissionsProviderResult result = AddPlayerToGroupBlocking(groupId, player);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }

        public static void DeleteGroupAsync(string groupId, Action<RocketPermissionsProviderResult> callback)
        {
            Action async = () =>
            {
                RocketPermissionsProviderResult result = DeleteGroupBlocking(groupId);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }

        public static void GetGroupAsync(string groupId, Action<RocketPermissionsGroup> callback)
        {
            Action async = () =>
            {
                RocketPermissionsGroup result = GetGroupBlocking(groupId);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }

        public static void GetGroupsAsync(IRocketPlayer player, bool includeParentGroups, Action<List<RocketPermissionsGroup>> callback)
        {
            Action async = () =>
            {
                List<RocketPermissionsGroup> result = GetGroupsBlocking(player, includeParentGroups);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }

        public static void GetPermissionsAsync(IRocketPlayer player, Action<List<Permission>> callback)
        {
            Action async = () =>
            {
                List<Permission> result = GetPermissionsBlocking(player);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }

        public static void GetPermissionsAsync(IRocketPlayer player, List<string> requestedPermissions, Action<List<Permission>> callback)
        {
            Action async = () =>
            {
                List<Permission> result = GetPermissionsBlocking(player, requestedPermissions);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }

        public static void HasPermissionAsync(IRocketPlayer player, List<string> requestedPermissions, Action<bool> callback)
        {
            Action async = () =>
            {
                bool result = HasPermissionBlocking(player, requestedPermissions);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }
   
        public static void RemovePlayerFromGroupAsync(string groupId, IRocketPlayer player, Action<RocketPermissionsProviderResult> callback)
        {
            Action async = () =>
            {
                RocketPermissionsProviderResult result = RemovePlayerFromGroupBlocking(groupId, player);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }

        public static void SaveGroupAsync(RocketPermissionsGroup group, Action<RocketPermissionsProviderResult> callback)
        {
            Action async = () =>
            {
                RocketPermissionsProviderResult result = SaveGroupBlocking(group);

                Action _callback = () =>
                {
                    callback.Invoke(result);
                };

                ThreadedWorkManager.EnqueueMainThread(_callback);
            };

            ThreadedWorkManager.EnqueueWorkerThread(async);
        }
#endregion
    }
}
// <copyright file="MaterialSynthesisSettingsUserControlModel.cs" company="MaaAssistantArknights">
// Part of the MaaWpfGui project, maintained by the MaaAssistantArknights team (Maa Team)
// Copyright (C) 2021-2025 MaaAssistantArknights Contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License v3.0 only as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
// </copyright>

#nullable enable
using System.Collections.Generic;
using MaaWpfGui.Configuration.Single.MaaTask;

namespace MaaWpfGui.ViewModels.UserControl.TaskQueue;

public class MaterialSynthesisSettingsUserControlModel : TaskSettingsViewModel, MaterialSynthesisSettingsUserControlModel.ISerialize
{
    static MaterialSynthesisSettingsUserControlModel()
    {
        Instance = new();
    }

    public static MaterialSynthesisSettingsUserControlModel Instance { get; }

    public override void RefreshUI(BaseTask baseTask)
    {
        // 材料合成任务暂无需要刷新的 UI 数据。
    }

    public override (bool? IsSuccess, IEnumerable<int> TaskId) SerializeTask(BaseTask? baseTask, int? taskId = null)
        => (this as ISerialize).Serialize(baseTask, taskId);

    private interface ISerialize : ITaskQueueModelSerialize
    {
        (bool? IsSuccess, IEnumerable<int> TaskId) ITaskQueueModelSerialize.Serialize(BaseTask? baseTask, int? taskId)
        {
            // 材料合成任务：暂无实际逻辑，返回 null 表示跳过，运行队列时会显示为已跳过。
            _ = (baseTask, taskId);
            return (null, []);
        }
    }
}

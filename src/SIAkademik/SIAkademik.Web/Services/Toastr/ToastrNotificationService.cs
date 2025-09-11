﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using SIAkademik.Web.Models;

namespace SIAkademik.Web.Services.Toastr;

public class ToastrNotificationService : IToastrNotificationService
{
    private readonly string _tempDataKey = "ToastrTempData";

    private readonly ITempDataDictionary _tempDataDictionary;

    public ToastrNotificationService(IHttpContextAccessor httpContextAccessor,
        ITempDataDictionaryFactory tempDataDictionaryFactory)
    {
        _tempDataDictionary = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
    }

    public void AddNotification(ToastrNotification notification)
    {
        var notifications = GetTempData();

        notifications.Add(notification);

        var json = JsonConvert.SerializeObject(notifications, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
        });

        _tempDataDictionary[_tempDataKey] = json;
        _tempDataDictionary.Keep(_tempDataKey);
    }

    private List<ToastrNotification> GetTempData()
    {
        var tempData = _tempDataDictionary[_tempDataKey];

        if (tempData is null) return new();

        if (tempData is not string notificationsJson) return new();

        var notifications = JsonConvert.DeserializeObject<List<ToastrNotification>>(notificationsJson);

        return notifications ?? new();
    }

    public string? GetNotificationJson()
    {
        var notifications = _tempDataDictionary[_tempDataKey];
        _tempDataDictionary.Remove(_tempDataKey);

        return notifications is not null && notifications is string json ? json : null;
    }

    public void AddSuccess(string message, string? title = null, ToastrOptions? toastrOptions = null) =>
        AddNotification(new ToastrNotification
        {
            Message = message,
            Title = title,
            Options = toastrOptions,
            Type = ToastrNotificationType.Success
        });

    public void AddInformation(string message, string? title = null, ToastrOptions? toastrOptions = null) =>
        AddNotification(new ToastrNotification
        {
            Message = message,
            Title = title,
            Options = toastrOptions,
            Type = ToastrNotificationType.Info
        });

    public void AddWarning(string message, string? title = null, ToastrOptions? toastrOptions = null) =>
        AddNotification(new ToastrNotification
        {
            Message = message,
            Title = title,
            Options = toastrOptions,
            Type = ToastrNotificationType.Warning
        });

    public void AddError(string message, string? title = null, ToastrOptions? toastrOptions = null) =>
        AddNotification(new ToastrNotification
        {
            Message = message,
            Title = title,
            Options = toastrOptions,
            Type = ToastrNotificationType.Error
        });
}

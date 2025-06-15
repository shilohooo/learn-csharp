using Avalonia.PageNavigationSample.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.PageNavigationSample.Messages;

/// <summary>
///     当前页面变更消息
/// </summary>
public class CurrentPageChangedMessage(ViewModelBase? currentPage) : ValueChangedMessage<ViewModelBase?>(currentPage);
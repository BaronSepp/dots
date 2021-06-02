#r "WORKSPACER_PATH\workspacer.Shared.dll"
#r "WORKSPACER_PATH\plugins\workspacer.Bar\workspacer.Bar.dll"
#r "WORKSPACER_PATH\plugins\workspacer.ActionMenu\workspacer.ActionMenu.dll"
#r "WORKSPACER_PATH\plugins\workspacer.FocusIndicator\workspacer.FocusIndicator.dll"

using System;
using workspacer;
using workspacer.Bar;
using workspacer.ActionMenu;
using workspacer.FocusIndicator;

Action<IConfigContext> doConfig = (context) =>
{
    // Workspace names
    const string ws1 = "🌍"; // Web
    const string ws2 = "📧"; // Social
    const string ws3 = "💻"; // Development
    const string ws4 = "📝"; // Notes
    const string ws5 = "📊"; // Data
    const string ws6 = "🏷"; // Other
    
    // Release System
    context.Branch = Branch.Stable;

    // Bar
    context.AddBar();
    context.AddFocusIndicator();
    var actionMenu = context.AddActionMenu();

    // Workspaces
    context.DefaultLayouts = () => new ILayoutEngine[] {new VertLayoutEngine()};
    context.WorkspaceContainer.CreateWorkspaces(ws1, ws2, ws3, ws4, ws5, ws6);

    // Routing
    context.WindowRouter.AddRoute((window) => window.Title.Contains("Firefox") ? context.WorkspaceContainer[ws1] : null);
    context.WindowRouter.AddRoute((window) => window.Title.Contains("Teams") ? context.WorkspaceContainer[ws2] : null);
    context.WindowRouter.AddRoute((window) => window.Title.Contains("Outlook") ? context.WorkspaceContainer[ws2] : null);
    context.WindowRouter.AddRoute((window) => window.Title.Contains("Visual Studio") ? context.WorkspaceContainer[ws3] : null);
    context.WindowRouter.AddRoute((window) => window.Title.Contains("OneNote") ? context.WorkspaceContainer[ws4] : null);
    context.WindowRouter.AddRoute((window) => window.Title.Contains("Data Studio") ? context.WorkspaceContainer[ws5] : null);
    context.WindowRouter.AddRoute((window) => window.Title.Contains("SQL Server Management") ? context.WorkspaceContainer[ws5] : null);

    // Keybinds
    KeyModifiers mod = KeyModifiers.Alt;
    context.Keybinds.UnsubscribeAll();

    context.Keybinds.Subscribe(mod, Keys.Q, () => context.Workspaces.FocusedWorkspace.CloseFocusedWindow());
    context.Keybinds.Subscribe(mod, Keys.Enter, () => System.Diagnostics.Process.Start(@"cmd.exe"));
    context.Keybinds.Subscribe(mod, Keys.D1, () => context.Workspaces.SwitchToWorkspace(0));
    context.Keybinds.Subscribe(mod, Keys.D2, () => context.Workspaces.SwitchToWorkspace(1));
    context.Keybinds.Subscribe(mod, Keys.D3, () => context.Workspaces.SwitchToWorkspace(2));
    context.Keybinds.Subscribe(mod, Keys.D4, () => context.Workspaces.SwitchToWorkspace(3));
    context.Keybinds.Subscribe(mod, Keys.D5, () => context.Workspaces.SwitchToWorkspace(4));
    context.Keybinds.Subscribe(mod, Keys.D6, () => context.Workspaces.SwitchToWorkspace(5));
};
return doConfig;

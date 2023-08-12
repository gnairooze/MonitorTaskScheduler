IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Task] (
    [HostName] nvarchar(200) NOT NULL,
    [TaskName] nvarchar(700) NOT NULL,
    [Next_Run_Time] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [Logon_Mode] nvarchar(max) NOT NULL,
    [Last_Run_Time] nvarchar(max) NOT NULL,
    [Last_Result] nvarchar(max) NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    [Task_To_Run] nvarchar(max) NOT NULL,
    [Start_In] nvarchar(max) NOT NULL,
    [Comment] nvarchar(max) NOT NULL,
    [Scheduled_Task_State] nvarchar(max) NOT NULL,
    [Idle_Time] nvarchar(max) NOT NULL,
    [Power_Management] nvarchar(max) NOT NULL,
    [Run_As_User] nvarchar(max) NOT NULL,
    [Delete_Task_If_Not_Rescheduled] nvarchar(max) NOT NULL,
    [Stop_Task_If_Runs_X_Hours_and_X_Mins] nvarchar(max) NOT NULL,
    [Schedule] nvarchar(max) NOT NULL,
    [Schedule_Type] nvarchar(max) NOT NULL,
    [Start_Time] nvarchar(max) NOT NULL,
    [Start_Date] nvarchar(max) NOT NULL,
    [End_Date] nvarchar(max) NOT NULL,
    [Days] nvarchar(max) NOT NULL,
    [Months] nvarchar(max) NOT NULL,
    [Repeat_Every] nvarchar(max) NOT NULL,
    [Repeat_Until_Time] nvarchar(max) NOT NULL,
    [Repeat_Until_Duration] nvarchar(max) NOT NULL,
    [Repeat_Stop_If_Still_Running] nvarchar(max) NOT NULL,
    [Modified] datetime2 NOT NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY ([HostName], [TaskName])
);
GO

CREATE TABLE [TaskChanges] (
    [Id] bigint NOT NULL IDENTITY,
    [TaskHistoryId] bigint NOT NULL,
    [Created] datetime2 NOT NULL,
    [HostName] nvarchar(200) NOT NULL,
    [TaskName] nvarchar(700) NOT NULL,
    [PropertyName] nvarchar(max) NOT NULL,
    [OldValue] nvarchar(max) NOT NULL,
    [NewValue] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TaskChanges] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TaskHistory] (
    [Id] bigint NOT NULL IDENTITY,
    [Created] datetime2 NOT NULL,
    [HostName] nvarchar(200) NOT NULL,
    [TaskName] nvarchar(700) NOT NULL,
    [Next_Run_Time] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [Logon_Mode] nvarchar(max) NOT NULL,
    [Last_Run_Time] nvarchar(max) NOT NULL,
    [Last_Result] nvarchar(max) NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    [Task_To_Run] nvarchar(max) NOT NULL,
    [Start_In] nvarchar(max) NOT NULL,
    [Comment] nvarchar(max) NOT NULL,
    [Scheduled_Task_State] nvarchar(max) NOT NULL,
    [Idle_Time] nvarchar(max) NOT NULL,
    [Power_Management] nvarchar(max) NOT NULL,
    [Run_As_User] nvarchar(max) NOT NULL,
    [Delete_Task_If_Not_Rescheduled] nvarchar(max) NOT NULL,
    [Stop_Task_If_Runs_X_Hours_and_X_Mins] nvarchar(max) NOT NULL,
    [Schedule] nvarchar(max) NOT NULL,
    [Schedule_Type] nvarchar(max) NOT NULL,
    [Start_Time] nvarchar(max) NOT NULL,
    [Start_Date] nvarchar(max) NOT NULL,
    [End_Date] nvarchar(max) NOT NULL,
    [Days] nvarchar(max) NOT NULL,
    [Months] nvarchar(max) NOT NULL,
    [Repeat_Every] nvarchar(max) NOT NULL,
    [Repeat_Until_Time] nvarchar(max) NOT NULL,
    [Repeat_Until_Duration] nvarchar(max) NOT NULL,
    [Repeat_Stop_If_Still_Running] nvarchar(max) NOT NULL,
    [Modified] datetime2 NOT NULL,
    CONSTRAINT [PK_TaskHistory] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Task_Modified] ON [Task] ([Modified]);
GO

CREATE INDEX [IX_TaskChanges_Created] ON [TaskChanges] ([Created]);
GO

CREATE INDEX [IX_TaskChanges_HostName] ON [TaskChanges] ([HostName]);
GO

CREATE INDEX [IX_TaskChanges_TaskName] ON [TaskChanges] ([TaskName]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230812090116_InitialCreate', N'7.0.10');
GO

COMMIT;
GO


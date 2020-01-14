//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xarial.XCad.Attributes;
using Xarial.XCad.Delegates;
using Xarial.XCad.Enums;
using Xarial.XCad.Extensions;
using Xarial.XCad.Reflection;
using Xarial.XCad.Structures;

namespace Xarial.XCad
{
    public static class IXCommandManagerExtension
    {
        internal class EnumCommandSpec<TEnum> : CommandSpec
            where TEnum : Enum
        {
            internal TEnum Value { get; }

            internal EnumCommandSpec(TEnum value)
            {
                Value = value;
            }
        }

        public static IEnumCommandBar<TCmdEnum> AddCommandGroup<TCmdEnum>(this IXCommandManager cmdMgr)
            where TCmdEnum : Enum
        {
            int GetNextAvailableGroupId()
            {
                if (cmdMgr.CommandBars.Any())
                {
                    return cmdMgr.CommandBars.Max(g => g.Spec.Id) + 1;
                }
                else
                {
                    return 0;
                }
            }

            var barSpec = CreateCommandBar<TCmdEnum>(GetNextAvailableGroupId(), cmdMgr.CommandBars.Select(c => c.Spec));

            var bar = cmdMgr.AddCommandBar(barSpec);

            return new EnumCommandBar<TCmdEnum>(bar);
        }

        private static EnumCommandSpec<TCmdEnum> CreateCommand<TCmdEnum>(TCmdEnum cmdEnum)
            where TCmdEnum : Enum
        {
            var cmd = new EnumCommandSpec<TCmdEnum>(cmdEnum);

            cmd.UserId = Convert.ToInt32(cmdEnum);

            if (!cmdEnum.TryGetAttribute<CommandItemInfoAttribute>(
                att =>
                {
                    cmd.HasMenu = att.HasMenu;
                    cmd.HasToolbar = att.HasToolbar;
                    cmd.SupportedWorkspace = att.SupportedWorkspaces;
                    cmd.HasTabBox = att.ShowInCommandTabBox;
                    cmd.TabBoxStyle = att.CommandTabBoxDisplayStyle;
                }))
            {
                cmd.HasMenu = true;
                cmd.HasToolbar = true;
                cmd.SupportedWorkspace = WorkspaceTypes_e.All;
                cmd.HasTabBox = false;
                cmd.TabBoxStyle = RibbonTabTextDisplay_e.TextBelow;
            }

            cmd.HasSpacer = cmdEnum.TryGetAttribute<CommandSpacerAttribute>() != null;

            if (!cmdEnum.TryGetAttribute<DisplayNameAttribute>(
                att => cmd.Title = att.DisplayName))
            {
                cmd.Title = cmd.ToString();
            }

            if (!cmdEnum.TryGetAttribute<DescriptionAttribute>(
                att => cmd.Tooltip = att.Description))
            {
                cmd.Tooltip = cmd.ToString();
            }

            if (!cmdEnum.TryGetAttribute<IconAttribute>(a => cmd.Icon = a.Icon))
            {
                //TODO: load default icon
                cmd.Icon = null;
            }

            return cmd;
        }

        private static EnumCommandBarSpec CreateCommandBar<TCmdEnum>(int nextGroupId, IEnumerable<CommandBarSpec> groups)
                                    where TCmdEnum : Enum
        {
            var cmdGroupType = typeof(TCmdEnum);

            var bar = new EnumCommandBarSpec(cmdGroupType);

            CommandBarInfoAttribute grpInfoAtt;

            if (cmdGroupType.TryGetAttribute(out grpInfoAtt))
            {
                if (grpInfoAtt.UserId != -1)
                {
                    bar.Id = grpInfoAtt.UserId;
                }
                else
                {
                    bar.Id = nextGroupId;
                }

                if (grpInfoAtt.ParentGroupType != null)
                {
                    var parentGrpSpec = groups.OfType<EnumCommandBarSpec>()
                        .FirstOrDefault(g => g.CmdGrpEnumType == grpInfoAtt.ParentGroupType);

                    if (parentGrpSpec == null)
                    {
                        //TODO: create a specific exception
                        throw new NullReferenceException("Parent group is not created");
                    }

                    if (grpInfoAtt.ParentGroupType == cmdGroupType)
                    {
                        throw new InvalidOperationException("Group cannot be a parent of itself");
                    }

                    bar.Parent = parentGrpSpec;
                }
            }
            else
            {
                bar.Id = nextGroupId;
            }

            if (!cmdGroupType.TryGetAttribute<IconAttribute>(a => bar.Icon = a.Icon))
            {
                //TODO: load default icon
                bar.Icon = null;
            }

            if (!cmdGroupType.TryGetAttribute<DisplayNameAttribute>(a => bar.Title = a.DisplayName))
            {
                bar.Title = cmdGroupType.ToString();
            }

            if (!cmdGroupType.TryGetAttribute<DescriptionAttribute>(a => bar.Tooltip = a.Description))
            {
                bar.Tooltip = cmdGroupType.ToString();
            }

            bar.Commands = Enum.GetValues(cmdGroupType).Cast<TCmdEnum>().Select(
                c => CreateCommand(c)).ToArray();

            return bar;
        }
    }
}
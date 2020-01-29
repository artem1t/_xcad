//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xarial.XCad.Delegates;
using Xarial.XCad.Structures;
using static Xarial.XCad.IXCommandManagerExtension;

namespace Xarial.XCad.Extensions
{
    public interface IEnumCommandBar<TCmdEnum> : IXCommandBar
        where TCmdEnum : Enum
    {
        new event CommandEnumClickDelegate<TCmdEnum> CommandClick;
        new event CommandEnumStateDelegate<TCmdEnum> CommandStateResolve;
    }

    internal class EnumCommandBar<TCmdEnum> : IEnumCommandBar<TCmdEnum>
                where TCmdEnum : Enum
    {
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event CommandClickDelegate CommandClick
        {
            add
            {
                m_CmdBar.CommandClick += value;
            }
            remove
            {
                m_CmdBar.CommandClick -= value;
            }
        }

        event CommandEnumClickDelegate<TCmdEnum> IEnumCommandBar<TCmdEnum>.CommandClick
        {
            add
            {
                m_CommandClick += value;
            }
            remove
            {
                m_CommandClick -= value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public event CommandStateDelegate CommandStateResolve
        {
            add
            {
                m_CmdBar.CommandStateResolve += value;
            }
            remove
            {
                m_CmdBar.CommandStateResolve -= value;
            }
        }

        event CommandEnumStateDelegate<TCmdEnum> IEnumCommandBar<TCmdEnum>.CommandStateResolve
        {
            add
            {
                m_CommandState += value;
            }
            remove
            {
                m_CommandState -= value;
            }
        }

        private readonly IXCommandBar m_CmdBar;
        private CommandEnumClickDelegate<TCmdEnum> m_CommandClick;
        private CommandEnumStateDelegate<TCmdEnum> m_CommandState;

        public CommandBarSpec Spec => m_CmdBar.Spec;

        internal EnumCommandBar(IXCommandBar cmdBar)
        {
            m_CmdBar = cmdBar;

            CommandClick += OnCommandClick;
            CommandStateResolve += OnCommandStateResolve;
        }

        private void OnCommandClick(CommandSpec spec)
        {
            if (spec is EnumCommandSpec<TCmdEnum>)
            {
                m_CommandClick?.Invoke((spec as EnumCommandSpec<TCmdEnum>).Value);
            }
        }

        private void OnCommandStateResolve(CommandSpec spec, ref CommandState state)
        {
            if (spec is EnumCommandSpec<TCmdEnum>)
            {
                m_CommandState?.Invoke((spec as EnumCommandSpec<TCmdEnum>).Value, ref state);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPSGame.GameModule;
using SPSGame.Tools;
using SPSGame.CsShare;
using SPSGame.CsShare.Data;


namespace SPSGame
{
    public class CMD_SC_MonsterInfo_List : NetAction
    {
        public override void SendParameterTcp(NetWriterTcp writer, ActionParam actionParam)
        {
            if (null == actionParam)
                return;
        }

        public override ActionParam DecodePackage(NetPackage package)
        {
            if (null == ActParam || null == package)
                return null;
            if (null == package.DataReader)
                return null;

            int sceneSeq = package.DataReader.getInt();
            List<MonsterInfo> listData = new List<MonsterInfo>();
            package.DataReader.Msg2NetDataList<MonsterInfo>(listData);

            Local.Instance.SceneMgr.OnRcvMonsterInfo(sceneSeq, listData);
            return ActParam;
        }

        //public override bool ProcessAction()
        //{
        //    try
        //    {
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        DebugMod.LogException(ex);
        //        return false;
        //    }
        //}
    }
}
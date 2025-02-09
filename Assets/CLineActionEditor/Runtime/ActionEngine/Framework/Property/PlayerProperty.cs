﻿/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2018 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\CLineActionEditor\ActionEngine\Framework\Property\PlayerProperty.cs
| AUTHOR     : https://supercline.com/
| PURPOSE    : 1. action base
|              2. non numerical property, such as 3D show UI, random animation etc.
|
| SPEC       : 
|
| MODIFICATION HISTORY
| 
| Ver	   Date			   By			   Details
| -----    -----------    -------------   ----------------------
| 1.0	   2019-4-11      SuperCLine           Created
|
+-----------------------------------------------------------------------------*/

namespace SuperCLine.ActionEngine
{
    using LitJson;
    using UnityEngine;
    using System;
    using System.Collections.Generic;

    public enum EPlayerSex
    {
        EPS_Man,
        EPS_Woman
    }

    public sealed class PlayerProperty : IProperty
    {
        [SerializeField] private string mID;
        [SerializeField] private string mName;
        [SerializeField] private string mDescription;
        [SerializeField] private string mPrefab;
        [SerializeField] private string mStartupAction;
        [SerializeField] private EPlayerSex mPlayerSex;
        [SerializeField] private List<string> mVictoryActionList = new List<string>();
        [SerializeField] private string mActionGroup;
        [SerializeField] private string mAnimatorTypeName;

        #region property
        [EditorProperty("ResID(资源ID)", EditorPropertyType.EEPT_String)]
        public string ID
        {
            get { return mID; }
            set { mID = value; }
        }
        [EditorProperty("名称", EditorPropertyType.EEPT_String)]
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        [EditorProperty("描述", EditorPropertyType.EEPT_String, Deprecated = "移至数值表")]
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        [EditorProperty("预制件", EditorPropertyType.EEPT_GameObject)]
        public string Prefab
        {
            get { return mPrefab; }
            set { mPrefab = value; }
        }
        [EditorProperty("启动Action", EditorPropertyType.EEPT_String)]
        public string StartupAction
        {
            get { return mStartupAction; }
            set { mStartupAction = value; }
        }
        [EditorProperty("性别", EditorPropertyType.EEPT_Enum)]
        public EPlayerSex PlayerSex
        {
            get { return mPlayerSex; }
            set { mPlayerSex = value; }
        }
        [EditorProperty("击杀Boss随机动画", EditorPropertyType.EEPT_List, LabelWidth = 110)]
        public List<string> VictoryActionList
        {
            get { return mVictoryActionList; }
            set { mVictoryActionList = value; }
        }
        [EditorProperty("Action组", EditorPropertyType.EEPT_String)]
        public string ActionGroup
        {
            get { return mActionGroup; }
            set { mActionGroup = value; }
        }
        [EditorProperty("动画控制器类名", EditorPropertyType.EEPT_AnimatorTypeName)]
        public string AnimatorTypeName
        {
            get { return mAnimatorTypeName; }
            set { mAnimatorTypeName = value; }
        }
        #endregion

        public string DebugName
        {
            get { return mName; }
        }

        public void Deserialize(JsonData jd)
        {
            mID = JsonHelper.ReadString(jd["ID"]);
            mName = JsonHelper.ReadString(jd["Name"]);
            mDescription = JsonHelper.ReadString(jd["Description"]);
            mPrefab = JsonHelper.ReadString(jd["Prefab"]);
            mStartupAction = JsonHelper.ReadString(jd["StartupAction"]);
            mPlayerSex = JsonHelper.ReadEnum<EPlayerSex>(jd["PlayerSex"]);
            mVictoryActionList = JsonHelper.ReadListString(jd["VictoryActionList"]);
            mActionGroup = JsonHelper.ReadString(jd["ActionGroup"]);
            mAnimatorTypeName = JsonHelper.ReadString(jd["AnimatorTypeName"]);
        }
        public JsonWriter Serialize(JsonWriter writer)
        {
            writer.WriteObjectStart();
            JsonHelper.WriteProperty(ref writer, "ID", mID);
            JsonHelper.WriteProperty(ref writer, "Name", mName);
            JsonHelper.WriteProperty(ref writer, "Description", mDescription);
            JsonHelper.WriteProperty(ref writer, "Prefab", mPrefab);
            JsonHelper.WriteProperty(ref writer, "StartupAction", mStartupAction);
            JsonHelper.WriteProperty(ref writer, "PlayerSex", mPlayerSex.ToString());
            JsonHelper.WriteProperty(ref writer, "VictoryActionList", mVictoryActionList);
            JsonHelper.WriteProperty(ref writer, "ActionGroup", mActionGroup);
            JsonHelper.WriteProperty(ref writer, "AnimatorTypeName", mAnimatorTypeName);
            writer.WriteObjectEnd();

            return writer;
        }

    }
}

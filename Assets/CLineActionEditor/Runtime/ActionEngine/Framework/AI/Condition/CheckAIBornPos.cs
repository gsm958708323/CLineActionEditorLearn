﻿/*------------------------------------------------------------------------------
|
| COPYRIGHT (C) 2018 - 2026 All Right Reserved
|
| FILE NAME  : \Assets\CLineActionEditor\ActionEngine\Framework\AI\Condition\CheckAIBornPos.cs
| AUTHOR     : https://supercline.com/
| PURPOSE    :
|
| SPEC       :
|
| MODIFICATION HISTORY
|
| Ver      Date            By              Details
| -----    -----------    -------------   ----------------------
| 1.0      2020-1-14      SuperCLine           Created
|
+-----------------------------------------------------------------------------*/

namespace SuperCLine.ActionEngine
{
    using LitJson;
    using UnityEngine;

    public sealed class CheckAIBornPos : AICondition, IProperty
    {
        [SerializeField] private ECompareType mCompareType = ECompareType.ECT_GreaterEqual;
        [SerializeField] private float mCompareVal = 20f;

        #region property
        [EditorProperty("比较条件", EditorPropertyType.EEPT_Enum)]
        public ECompareType CompareType
        {
            get { return mCompareType; }
            set { mCompareType = value; }
        }
        [EditorProperty("当前位置距出生点位置", EditorPropertyType.EEPT_Float)]
        public float CompareVal
        {
            get { return mCompareVal; }
            set { mCompareVal = value; }
        }
        #endregion property

        public EAIConditionType AIType
        {
            get { return EAIConditionType.EAT_CheckAIBornPos; }
        }

        public string DebugName
        {
            get { return GetType().Name; }
        }

        public void OnEvent(AIStatus ai, AISwitch owner, Message msg)
        {

        }

        public bool CheckAI(AIStatus ai, AISwitch owner)
        {
            float dist = Helper.Distance(ai.Owner.Position, ai.Owner.BornPosition, true) - 2 * ai.Owner.Radius;
            return CustomCompare<float>.Compare(mCompareType, dist, mCompareVal);
        }

        public void OnAIStart(AIStatus ai, AISwitch owner)
        {

        }

        public void OnAIEnd(AIStatus ai, AISwitch owner)
        {

        }

        public void OnAIChanging(AIStatus ai, AISwitch owner, AISwitch next)
        {

        }

        public void Update(AIStatus ai, AISwitch owner, float fTick)
        {

        }

        public AICondition Clone()
        {
            CheckAIBornPos ac = new CheckAIBornPos();
            ac.CompareType = this.CompareType;
            ac.CompareVal = this.CompareVal;

            return ac;
        }

        public void Deserialize(JsonData jd)
        {
            mCompareType = JsonHelper.ReadEnum<ECompareType>(jd["CompareType"]);
            mCompareVal = JsonHelper.ReadFloat(jd["CompareVal"]);
        }

        public JsonWriter Serialize(JsonWriter writer)
        {
            JsonHelper.WriteProperty(ref writer, "CompareType", mCompareType.ToString());
            JsonHelper.WriteProperty(ref writer, "CompareVal", mCompareVal);

            return writer;
        }
    }
}
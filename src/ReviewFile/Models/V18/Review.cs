﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using DensoCreate.LightningReview.ReviewFile.Models.V18.Definitions;

namespace DensoCreate.LightningReview.ReviewFile.Models.V18
{
    /// <summary>
    /// レビュー
    /// </summary>
    [XmlRoot]
    public class Review : EntityBase, IReview
    {
        #region プロパティ

        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// このレビューファイルに関連づく指摘の一覧
        /// </summary>
        public IEnumerable<IIssue> Issues
        {
            get
            {
                var issues = new List<IIssue>();

                // 各ドキュメントの指摘
                foreach (var doc in Documents.List)
                {
                    issues.AddRange(doc.AllIssues);
                }

                return issues;
            }
        }

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧
        /// </summary>
        IEnumerable<IDocument> IReview.Documents => Documents.List.OfType<IDocument>();

        #region 基本設定
        
        /// <summary>
        /// レビュー名
        /// </summary>
        [XmlElement]
        public string Name { get; set; }

        /// <summary>
        /// 目的
        /// </summary>
        [XmlElement]
        public string Goal { get; set; }

        /// <summary>
        /// 終了条件
        /// </summary>
        [XmlElement]
        public string EndCondition { get; set; }
        
        /// <summary>
        /// 場所
        /// </summary>
        [XmlElement]
        public string Place { get; set; }

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧
        /// </summary>
        [XmlElement]
        public Documents Documents { get; set; }

        /// <summary>
        /// プロジェクト
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// プロジェクトコード
        /// </summary>
        public string ProjectCode
        {
            get => Project.Code;
            set => Project.Code = value;
        }

        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string ProjectName
        {
            get => Project.Name;
            set => Project.Name = value;
        }

        /// <summary>
        /// 定義
        /// </summary>
        [XmlElement]
        public Definition Definition { get; set; }

        /// <summary>
        /// レビュー種別
        /// </summary>
        public string ReviewType => Definition.ReviewDefinition.ReviewType;

        /// <summary>
        /// ドメイン
        /// </summary>
        public string Domain => Definition.ReviewDefinition.Domain;

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string ReviewStatus => Definition.ReviewDefinition.Status;

        /// <summary>
        /// レビュ形式
        /// </summary>
        public string ReviewStyle => Definition.ReviewDefinition.ReviewStyle;

        #endregion

        #region 予実

        /// <summary>
        /// 計画実施日の文字列
        /// </summary>
        [XmlElement("PlannedDate")]
        public string PlannedDateString { get; set; }

        /// <summary>
        /// 計画実施日
        /// </summary>
        public DateTime? PlannedDate => string.IsNullOrEmpty(PlannedDateString) ? (DateTime?) null : DateTime.Parse(PlannedDateString);

        /// <summary>
        /// 実績実施日の文字列
        /// </summary>
        [XmlElement("ActualDate")]
        public string ActualDateString { get; set; }

        /// <summary>
        /// 実績実施日
        /// </summary>
        public DateTime? ActualDate => string.IsNullOrEmpty(ActualDateString) ? (DateTime?) null : DateTime.Parse(ActualDateString);

        /// <summary>
        /// 計画時間（分単位）
        /// </summary>
        [XmlElement]
        public string PlannedTime { get; set; }

        /// <summary>
        /// 実績時間(分単位)
        /// </summary>
        [XmlElement]
        public string ActualTime { get; set; }

        /// <summary>
        /// 成果物単位
        /// </summary>
        [XmlElement]
        public string Unit { get; set; }

        /// <summary>
        /// 予定規模
        /// </summary>
        [XmlElement]
        public string PlannedScale { get; set; }

        /// <summary>
        /// 実績規模
        /// </summary>
        [XmlElement]
        public string ActualScale { get; set; }

        /// <summary>
        /// 目標件数
        /// </summary>
        [XmlElement]
        public string IssueCountOfGoal { get; set; }

        /// <summary>
        /// 実績件数
        /// </summary>
        public string IssueCountOfActual
        {
            get
            {
                var issueCountOfActualCount = 0;
                foreach (var issue in Issues)
                {
                    // 指摘タイプがグッドポイントあるいは対策要否が否でない指摘の件数が実績件数
                    if ((issue.Type == "グッドポイント") || (issue.NeedToFix == "いいえ"))
                    {
                        continue;
                    }

                    issueCountOfActualCount++;
                }

                return issueCountOfActualCount.ToString();
            }
        }

        #endregion

        #endregion
    }
}

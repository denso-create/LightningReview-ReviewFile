using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Models
{
    /// <summary>
    /// レビューのインタフェース
    /// </summary>
    public interface IReview
    {
	    #region プロパティ

        /// <summary>
        /// グローバルID
        /// </summary>
        string GID { get; set; }

        /// <summary>
        /// レビューファイルの絶対パス
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// このレビューファイルに関連づく指摘の一覧
        /// </summary>
        IEnumerable<IIssue> Issues { get; }

        /// <summary>
        /// このレビューファイルに関連づくドキュメントの一覧
        /// </summary>
        IEnumerable<IDocument> Documents { get; }

        /// <summary>
        /// 作成者
        /// </summary>
        string CreatedBy { get; }
        
        /// <summary>
        /// 作成日時
        /// </summary>
        DateTime CreatedDateTime { get; }

        /// <summary>
        /// 最終更新者
        /// </summary>
        string LastUpdatedBy { get; set; }

        /// <summary>
        /// 最終更新日時
        /// </summary>
        DateTime LastUpdatedDateTime { get; }

	    #region 基本設定タブ

        /// <summary>
        /// レビュー名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// ステータス
        /// </summary>
        string Status { get; set; }

        /// <summary>
        /// 目的
        /// </summary>
        string Goal { get; set; }

        /// <summary>
        /// 終了条件
        /// </summary>
        string EndCondition { get; set; }

        /// <summary>
        /// ドメイン
        /// </summary>
        string Domain { get; set; }

        /// <summary>
        /// レビュー種別
        /// </summary>
        string ReviewType { get; set; }

        /// <summary>
        /// レビュー形式
        /// </summary>
        string ReviewStyle { get; set; }

        /// <summary>
        /// 場所
        /// </summary>
        string Place { get; set; }

        /// <summary>
        /// プロジェクトコード
        /// </summary>
        string ProjectCode { get; set; }

        /// <summary>
        /// プロジェクト名
        /// </summary>
        string ProjectName { get; set; }

        #endregion

        #region 予実タブ

        /// <summary>
        /// 計画実施日
        /// </summary>
        string PlannedDate { get; set; }

        /// <summary>
        /// 実績実施日
        /// </summary>
        string ActualDate { get; set; }

        /// <summary>
        /// 計画時間（分単位）
        /// </summary>
        string PlannedTime { get; set; }

        /// <summary>
        /// 実績時間(分単位)
        /// </summary>
        string ActualTime { get; set; }

        /// <summary>
        /// 成果物単位
        /// </summary>
        string Unit { get; set; }

        /// <summary>
        /// 予定規模
        /// </summary>
        string PlannedScale { get; set; }

        /// <summary>
        /// 実績規模
        /// </summary>
        string ActualScale { get; set; }

        /// <summary>
        /// 目標件数
        /// </summary>
        string IssueCountOfGoal { get; set; }

        /// <summary>
        /// 実績件数
        /// </summary>
        string IssueCountOfActual { get; }

        #endregion

        #endregion
    }
}

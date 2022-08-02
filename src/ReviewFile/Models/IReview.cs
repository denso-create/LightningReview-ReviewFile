using System;
using System.Collections.Generic;
using System.Text;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// レビューのインタフェース
    /// </summary>
    public interface IReview
    {
        #region 公開プロパティ

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
        DateTime? CreatedDateTime { get; }

        /// <summary>
        /// 最終更新者
        /// </summary>
        string LastUpdatedBy { get; set; }

        /// <summary>
        /// 最終更新日時
        /// </summary>
        DateTime? LastUpdatedDateTime { get; }

        #region 基本設定

        /// <summary>
        /// レビュー名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 目的
        /// </summary>
        string Goal { get; set; }

        /// <summary>
        /// 終了条件
        /// </summary>
        string EndCondition { get; set; }

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
        
        /// <summary>
        /// レビュー種別
        /// </summary>
        string ReviewType { get; }

        /// <summary>
        /// ドメイン
        /// </summary>
        string Domain { get; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        string ReviewStatus { get; }

        /// <summary>
        /// レビュ形式
        /// </summary>
        string ReviewStyle { get; }

        #endregion

        #region 予実

        /// <summary>
        /// 計画実施日
        /// </summary>
        DateTime? PlannedDate { get; }

        /// <summary>
        /// 実績実施日
        /// </summary>
        DateTime? ActualDate { get; }

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

        #region カスタムフィールド
        
        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        string CustomText1 { get; set; }

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        string CustomText2 { get; set; }

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        string CustomText3 { get; set; }

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        string CustomText4 { get; set; }

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        string CustomText5 { get; set; }

        /// <summary>
        /// カスタムテキスト6
        /// </summary>
        string CustomText6 { get; set; }

        /// <summary>
        /// カスタムテキスト7
        /// </summary>
        string CustomText7 { get; set; }

        /// <summary>
        /// カスタムテキスト8
        /// </summary>
        string CustomText8 { get; set; }

        /// <summary>
        /// カスタムテキスト9
        /// </summary>
        string CustomText9 { get; set; }

        /// <summary>
        /// カスタムテキスト10
        /// </summary>
        string CustomText10 { get; set; }

		/// <summary>
        /// カスタムテキスト11
        /// </summary>
        string CustomText11 { get; set; }

        /// <summary>
        /// カスタムテキスト12
        /// </summary>
        string CustomText12 { get; set; }

        /// <summary>
        /// カスタムテキスト13
        /// </summary>
        string CustomText13 { get; set; }

        /// <summary>
        /// カスタムテキスト14
        /// </summary>
        string CustomText14 { get; set; } 

        /// <summary>
        /// カスタムテキスト15
        /// </summary>
        string CustomText15 { get; set; } 

        /// <summary>
        /// カスタムテキスト16
        /// </summary>
        string CustomText16 { get; set; } 

        /// <summary>
        /// カスタムテキスト17
        /// </summary>
        string CustomText17 { get; set; } 

        /// <summary>
        /// カスタムテキスト18
        /// </summary>
        string CustomText18 { get; set; } 

        /// <summary>
        /// カスタムテキスト19
        /// </summary>
        string CustomText19 { get; set; } 

        /// <summary>
        /// カスタムテキスト20
        /// </summary>
        string CustomText20 { get; set; }

        #endregion

        #endregion
    }
}

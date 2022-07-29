using System;
using System.Collections.Generic;
using System.Text;
using DensoCreate.LightningReview.ReviewFile.Models;
using DensoCreate.LightningReview.ReviewFileToJsonService.Extensions;

namespace DensoCreate.LightningReview.ReviewFileToJsonService
{
    /// <summary>
    /// レビュー
    /// </summary>
    public class Review 
    {
        #region 構築

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Review() 
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="reviewModel"></param>
        public Review(IReview reviewModel)
        {
            // 同じ名前のフィールドをコピー
            this.CopyFieldsFrom(reviewModel);

            // 指摘をコピー
            foreach ( var issueModel in reviewModel.Issues)
            {
                var issue = new Issue(issueModel);
                Issues.Add(issue);
            }
        }

        #endregion

        #region 公開プロパティ

        /// <summary>
        /// グローバルID
        /// </summary>
        public string GID { get; set; }

        /// <summary>
        /// レビューファイルの絶対パス
        /// </summary>
        public string FilePath { get; set; }
        
        /// <summary>
        /// 作成者
        /// </summary>
        public string CreatedBy { get; set; }
        
        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// 最終更新者
        /// </summary>
        public string LastUpdatedBy { get; set; }

        /// <summary>
        /// 最終更新日時
        /// </summary>
        public DateTime? LastUpdatedDateTime { get; set; }

        #region 基本設定

        /// <summary>
        /// レビュー名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 目的
        /// </summary>
        public string Goal { get; set; }

        /// <summary>
        /// 終了条件
        /// </summary>
        public string EndCondition { get; set; }

        /// <summary>
        /// 場所
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// プロジェクトコード
        /// </summary>
        public string ProjectCode { get; set; }

        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// レビュー種別
        /// </summary>
        public string ReviewType { get; set; }

        /// <summary>
        /// ドメイン
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// レビューのステータス
        /// </summary>
        public string ReviewStatus { get; set; }

        /// <summary>
        /// レビュ形式
        /// </summary>
        public string ReviewStyle { get; set; }

        #endregion

        #region 予実

        /// <summary>
        /// 計画実施日
        /// </summary>
        public DateTime? PlannedDate { get; set; }

        /// <summary>
        /// 実績実施日
        /// </summary>
        public DateTime? ActualDate { get; set; }

        /// <summary>
        /// 計画時間（分単位）
        /// </summary>
        public string PlannedTime { get; set; }

        /// <summary>
        /// 実績時間(分単位)
        /// </summary>
        public string ActualTime { get; set; }

        /// <summary>
        /// 成果物単位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 予定規模
        /// </summary>
        public string PlannedScale { get; set; }

        /// <summary>
        /// 実績規模
        /// </summary>
        public string ActualScale { get; set; }

        /// <summary>
        /// 目標件数
        /// </summary>
        public string IssueCountOfGoal { get; set; }

        /// <summary>
        /// 実績件数
        /// </summary>
        public string IssueCountOfActual { get; set; }

        #endregion
        
        #region カスタムフィールド

        /// <summary>
        /// カスタムテキスト1
        /// </summary>
        public string CustomText1 { get; set; }

        /// <summary>
        /// カスタムテキスト2
        /// </summary>
        public string CustomText2 { get; set; }

        /// <summary>
        /// カスタムテキスト3
        /// </summary>
        public string CustomText3 { get; set; }

        /// <summary>
        /// カスタムテキスト4
        /// </summary>
        public string CustomText4 { get; set; }

        /// <summary>
        /// カスタムテキスト5
        /// </summary>
        public string CustomText5 { get; set; }

        /// <summary>
        /// カスタムテキスト6
        /// </summary>
        public string CustomText6 { get; set; }

        /// <summary>
        /// カスタムテキスト7
        /// </summary>
        public string CustomText7 { get; set; }

        /// <summary>
        /// カスタムテキスト8
        /// </summary>
        public string CustomText8 { get; set; }

        /// <summary>
        /// カスタムテキスト9
        /// </summary>
        public string CustomText9 { get; set; }

        /// <summary>
        /// カスタムテキスト10
        /// </summary>
        public string CustomText10 { get; set; }

        /// <summary>
        /// カスタムテキスト11
        /// </summary>
        public string CustomText11 { get; set; }

        /// <summary>
        /// カスタムテキスト12
        /// </summary>
        public string CustomText12 { get; set; }

        /// <summary>
        /// カスタムテキスト13
        /// </summary>
        public string CustomText13 { get; set; }

        /// <summary>
        /// カスタムテキスト14
        /// </summary>
        public string CustomText14 { get; set; }

        /// <summary>
        /// カスタムテキスト15
        /// </summary>
        public string CustomText15 { get; set; }

        /// <summary>
        /// カスタムテキスト16
        /// </summary>
        public string CustomText16 { get; set; }

        /// <summary>
        /// カスタムテキスト17
        /// </summary>
        public string CustomText17 { get; set; }

        /// <summary>
        /// カスタムテキスト18
        /// </summary>
        public string CustomText18 { get; set; }

        /// <summary>
        /// カスタムテキスト19
        /// </summary>
        public string CustomText19 { get; set; }

        /// <summary>
        /// カスタムテキスト20
        /// </summary>
        public string CustomText20 { get; set; }

        #endregion

        /// <summary>
        /// 指摘一覧
        /// </summary>
        public IList<Issue> Issues { get; } = new List<Issue>();

        #endregion
    }
}

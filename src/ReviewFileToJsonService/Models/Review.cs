using System;
using System.Collections.Generic;
using System.Text;
using LightningReview.ReviewFile.Models;
using ReviewFileToJsonService.Extensions;


namespace ReviewFileToJsonService.Models
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
        /// 指摘一覧
        /// </summary>
        public IList<Issue> Issues { get; } = new List<Issue>();

        /// <summary>
        /// 作成者
        /// </summary>
        public string CreatedBy { get; set; }
        
        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        /// 最終更新者
        /// </summary>
        public string LastUpdatedBy { get; set; }

        /// <summary>
        /// 最終更新日時
        /// </summary>
        public DateTime LastUpdatedDateTime { get; set; }

	    #region 基本設定タブ

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

        #endregion

        #region 予実タブ

        /// <summary>
        /// 計画実施日
        /// </summary>
        public string PlannedDate { get; set; }

        /// <summary>
        /// 実績実施日
        /// </summary>
        public string ActualDate { get; set; }

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

        #endregion
    }
}

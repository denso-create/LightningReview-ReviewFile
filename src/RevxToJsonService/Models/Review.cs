using System;
using System.Collections.Generic;
using System.Text;
using LightningReview.RevxFile.Models;
using RevxToJsonService.Extensions;


namespace RevxToJsonService.Models
{
	/// <summary>
	/// レビュー
	/// </summary>
    public class Review
    {
        #region コンストラクタ
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
			foreach ( var issueModel in reviewModel.AllIssues)
			{
				var issue = new Issue(issueModel);
				Issues.Add(issue);
            }
		}
        #endregion

        #region 公開プロパティ

        public string Name { get; set; }
        public string Goal { get; set; }
        public string Domain { get; set; }

        public string Place { get; set; }
        public string PlannedDate { get; set; }
        public string ActualDate { get; set; }
        public string Unit { get; set; }
        public string PlannedScale { get; set; }

        /// <summary>
        /// レビューファイルの絶対パスです
        /// </summary>
        public string FilePath { get; set; }

		/// <summary>
		/// 指摘一覧
		/// </summary>
		public IList<Issue> Issues { get; } = new List<Issue>();

        #endregion
    }
}

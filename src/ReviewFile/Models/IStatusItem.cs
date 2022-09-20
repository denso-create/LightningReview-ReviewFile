﻿using System;

namespace DensoCreate.LightningReview.ReviewFile.Models
{
    /// <summary>
    /// レビューのステータスのインターフェースです。
    /// </summary>
    public interface IStatusItem
    {
        #region 公開プロパティ

        /// <summary>
        /// ステータスの名前を取得します。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 設定日を取得します。
        /// </summary>
        DateTime? SelectedOn { get; }

        /// <summary>
        /// 設定者を取得します。
        /// </summary>
        string SelectedBy { get; }

        /// <summary>
        /// クローズを意味するステータスかを取得します。
        /// </summary>
        bool IsClosed { get; }

        /// <summary>
        /// このステータスが、現在のステータスとして設定されているかを取得します。
        /// </summary>
        bool IsSelected { get; }

        /// <summary>
        /// ステータスの色を取得します。
        /// </summary>
        /// <value>
        /// 色の種類の文字列。
        /// 本プロパティの値域を以下に示します。
        /// [値域]
        /// なし
        /// 赤
        /// 橙
        /// 黄
        /// 緑
        /// 青
        /// 紫
        /// 灰
        /// 薄い赤
        /// 薄い橙
        /// 薄い黄
        /// 薄い緑
        /// 薄い青
        /// 薄い紫
        /// 薄い灰
        /// </value>
        string Color { get; }

        #endregion
    }
}
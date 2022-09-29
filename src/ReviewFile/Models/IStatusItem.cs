using System;

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
        /// <value>ステータスの名前。</value>
        string Name { get; }

        /// <summary>
        /// 設定日を取得します。
        /// </summary>
        /// <value>
        /// 設定日。設定日が設定されていない時はnullです。
        /// レビューファイルがV1.8以前のフォーマットの場合は、nullです。
        /// </value>
        DateTime? SelectedOn { get; }

        /// <summary>
        /// 設定者を取得します。
        /// </summary>
        /// <value>
        /// 設定者。
        /// レビューファイルがV1.8以前のフォーマットの場合は、空文字列です。
        /// </value>
        string SelectedBy { get; }

        /// <summary>
        /// クローズを意味するステータスかを取得します。
        /// </summary>
        /// <value>
        /// クローズを意味するステータスか。
        /// レビューファイルがV1.8以前のフォーマットの場合は、falseです。
        /// </value>
        bool IsClosed { get; }

        /// <summary>
        /// このステータスが、現在のステータスとして設定されているかを取得します。
        /// </summary>
        /// <value>
        /// このステータスが、現在のステータスとして設定されているか。
        /// </value>
        bool IsSelected { get; }

        /// <summary>
        /// ステータスの色を取得します。
        /// </summary>
        /// <value>
        /// ステータスの色。
        /// レビューファイルがV1.8以前のフォーマットの場合は、"なし"です。
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
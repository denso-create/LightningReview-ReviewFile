using System;
using System.Collections.Generic;
using System.Text;

namespace LightningReview.ReviewFile.Exceptions
{
	/// <summary>
	/// ReviewFileで使用する例外クラス
	/// </summary>
	public class ReviewFileFormatException : Exception
	{
		/// <summary>
		/// エラーメッセージ、およびこの例外の原因である内部例外への参照を指定して
		/// ReviewFileFormatExceptionクラスの新しいインスタンスを初期化します
		/// </summary>
		/// <param name="message">例外の原因を説明するエラーメッセージ</param>
		/// <param name="innterException">現在の例外の原因である例外</param>
		public ReviewFileFormatException(string message = null, Exception innterException = null) 
			: base(message, innterException)
		{
		}
	}
}

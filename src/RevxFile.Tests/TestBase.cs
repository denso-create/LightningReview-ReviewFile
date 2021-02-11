using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace LightningReview.RevxFile.Tests
{
    public class TestBase
    {
        /// <summary>
        /// テストデータ格納フォルダ（ビルドしたDLLファイルからの相対パス）
        /// </summary>
        protected virtual string TestDataFolderName => @"TestData";


        /// <summary>
        /// テストデータのファイルパスを取得する
        /// </summary>
        /// <param name="fileName">テストデータのファイル名</param>
        /// <returns>テストデータのファイルパス</returns>
        protected string GetTestDataPath(string fileName = null)
        {
            var exePath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            var dir = Path.Combine(exePath, TestDataFolderName);

            if (string.IsNullOrEmpty(fileName))
            {
                return dir;
            }

            var path = Path.Combine(dir, fileName);
            Assert.IsTrue(File.Exists(path));
            return path;
        }

    }
}

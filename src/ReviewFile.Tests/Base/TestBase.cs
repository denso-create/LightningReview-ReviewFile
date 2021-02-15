using LightningReview.ReviewFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace LightningReview.ReviewFile.Tests
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
        protected string GetTestDataPath(string version="",string fileName = null)
        {
            var exePath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            var dir = Path.Combine(exePath, TestDataFolderName, version);

            if (string.IsNullOrEmpty(fileName))
            {
                return dir;
            }

            var path = Path.Combine(dir, fileName);
            Assert.IsTrue(File.Exists(path), $"テストデータのファイル{path}が存在しません");
            return path;
        }

        /// <summary>
        /// レビューファイルのロード
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        protected IReview ReadReviewFile(string version,string filePath)
        {
            var filepath = GetTestDataPath(version, filePath);
            var reader = new ReviewFileReader();
            var review = reader.Read(filepath);
            return review;
        }

        /// <summary>
        /// フォルダを作成する。すでにあればファイルを削除して再作成する
        /// </summary>
        /// <param name="directory"></param>
        protected void RecreateDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            else
            {
                Directory.CreateDirectory(directory);
            }
        }

        protected void RemoveDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
                Directory.Delete(directory);
            }

        }
    }
}

using LightningReview.ReviewFileToJsonService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ReviewFileToJsonService.Tests
{
    [TestClass]
    public class ReviewFileToJsonExporterTests
    {
        /// <summary>
        /// �e�X�g�f�[�^�i�[�t�H���_�i�r���h����DLL�t�@�C������̑��΃p�X�j
        /// </summary>
        protected virtual string TestDataFolderName => @"TestData";

        /// <summary>
        /// �e�X�g�f�[�^�̃t�@�C���p�X���擾����
        /// </summary>
        /// <param name="fileName">�e�X�g�f�[�^�̃t�@�C����</param>
        /// <returns>�e�X�g�f�[�^�̃t�@�C���p�X</returns>
        protected string GetTestDataPath(string fileName = null)
        {
            var exePath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            var dir = Path.Combine(exePath, TestDataFolderName);

            if (string.IsNullOrEmpty(fileName))
            {
                return dir;
            }

            var path = Path.Combine(dir, fileName);
            return path;
        }

        [TestMethod]
        public void ExportParamTest()
        {
            var revxFolder = GetTestDataPath("ExportParamTest");
            var outputPath = GetTestDataPath("output.json");
            var exporter = new ReviewFileToJsonExporter();

            // �����̃t�@�C��
            exporter.Export(revxFolder, outputPath);
            var json = File.ReadAllText(outputPath);
            dynamic jsonModel = JsonConvert.DeserializeObject(json);
            Assert.AreEqual(3, (int)jsonModel.TotalReviewCount);

            // �T�u�t�H���_���܂�
            exporter.Export(revxFolder, outputPath,true);
            json = File.ReadAllText(outputPath);
            jsonModel = JsonConvert.DeserializeObject(json);
            Assert.AreEqual(6, (int)jsonModel.TotalReviewCount);
        }

        [TestMethod]
        public void ExportTest()
        {
            var revxFolder = GetTestDataPath();
            var outputPath = GetTestDataPath("output.json");
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            // �G�N�X�|�[�g
            var exporter = new ReviewFileToJsonExporter();
            exporter.Export(revxFolder, outputPath);

            // �t�@�C���̓��e���e�X�g
            Assert.IsTrue(File.Exists(outputPath));

            var json = File.ReadAllText(outputPath);
            dynamic jsonModel = JsonConvert.DeserializeObject(json);

            // ���g���m�F
            Assert.IsNotNull(jsonModel.Reviews);
            Assert.AreEqual(3,jsonModel.Reviews.Count);
            Assert.AreEqual(3, jsonModel.Reviews[0].Issues.Count);
            Assert.AreEqual(3, jsonModel.Reviews[1].Issues.Count);
            Assert.AreEqual(3, jsonModel.Reviews[2].Issues.Count);
            var issue1 = jsonModel.Reviews[0].Issues[0];
            Assert.AreEqual("1", (string)issue1.LID);
            Assert.AreEqual("Member2", (string)issue1.AssignedTo);
            Assert.AreEqual("Member3", (string)issue1.ConfirmedBy);

        }

        [TestCategory("SkipWhenLiveUnitTesting")]
        [TestMethod]
        public void PerfomanceTest()
        {
            var revxFolder = GetTestDataPath();

            // �e�X�g�p�̃t�H���_���쐬����
            var peformanceTestFolder = Path.Combine(revxFolder, "PeformanceTestData");
            RecreateDirectory(peformanceTestFolder);

            #region �e�X�g�f�[�^�̍쐬

            // �w�肳�ꂽ�t�H���_�ȉ��̃��r���[�t�@�C���ɑ΂��āA���r���[�̃f�[�^���擾����
            var ReviewFile = Directory.GetFiles(revxFolder, "*.revx", SearchOption.AllDirectories).FirstOrDefault();

            // �e�X�g�t�@�C���̍쐬
            for ( var i=0;i<1000;i++)
            {
                var destFilePath = Path.Combine(peformanceTestFolder, $"PerformanceReviewFile{i}.revx");
                File.Copy(ReviewFile, destFilePath);
            }

            #endregion

            #region ���s���Ď��Ԃ��v������

            var stopwatch = new Stopwatch();

            var outputPath = Path.Combine(peformanceTestFolder, "output.json");
            var exporter = new ReviewFileToJsonExporter();
            exporter.Export(peformanceTestFolder, outputPath);
            stopwatch.Start();

            // ���s���Ԃ�5000ms�ȓ��ł��邱��
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 5000);
            #endregion
        }

        /// <summary>
        /// �t�H���_���쐬����B���łɂ���΃t�@�C�����폜���čč쐬����
        /// </summary>
        /// <param name="folder"></param>
        private void RecreateDirectory(string folder)
        {
            if (Directory.Exists(folder))
            {
                var files = Directory.GetFiles(folder);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            } else 
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}

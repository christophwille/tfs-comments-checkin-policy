using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using CCCPLib;
using Microsoft.Build.BuildEngine;
using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using Microsoft.Build.Utilities;
using NUnit.Framework;

namespace CCCPMSBuildTaskTests
{
    /// <summary>
    /// Tests the CheckCodeCommentsTask.targets file.
    /// </summary>
    [TestFixture]
    public class TaskTargetsFileTestFixture
    {
        UsingTask targetFileUsingTask;
        Target checkCodeCommentsTarget;
        BuildTask buildTask;
        BuildProperty buildDependsOnProperty;
        BuildProperty reportFileNameProperty;
        BuildProperty checkMethodsProperty;
        BuildProperty checkClassesProperty;
        BuildProperty checkFieldsProperty;
        BuildProperty checkEventsProperty;
        BuildProperty checkPropertiesProperty;
        BuildProperty checkPublicProperty;
        BuildProperty checkProtectedProperty;
        BuildProperty checkPrivateProperty;
        BuildProperty msbuildAllProjectsProperty;
        
        [SetUp]
        public void SetUpFixture()
        {
            Engine.GlobalEngine.BinPath = RuntimeEnvironment.GetRuntimeDirectory();
            Project project = new Project();
            project.LoadXml(GetProjectXml());
            
            foreach (UsingTask usingTask in project.UsingTasks) {
                targetFileUsingTask = usingTask;
            }
            
            foreach (Target target in project.Targets) {
                checkCodeCommentsTarget = target;
            }
            
            IEnumerator enumerator = checkCodeCommentsTarget.GetEnumerator();
            while (enumerator.MoveNext()) {
                buildTask = enumerator.Current as BuildTask;
            }
            
            foreach (BuildPropertyGroup group in project.PropertyGroups) {
                enumerator = group.GetEnumerator();
                while (enumerator.MoveNext()) {
                    BuildProperty property = enumerator.Current as BuildProperty;
                    if (property != null) {
                        if (property.Name == "BuildDependsOn") {
                            buildDependsOnProperty = property;
                        } else if (property.Name == "ReportFileName") {
                            reportFileNameProperty = property;
                        } else if (property.Name == "CheckMethods") {
                            checkMethodsProperty = property;
                        } else if (property.Name == "CheckClasses") {
                            checkClassesProperty = property;
                        } else if (property.Name == "CheckEvents") {
                            checkEventsProperty = property;
                        } else if (property.Name == "CheckFields") {
                            checkFieldsProperty = property;
                        } else if (property.Name == "CheckProperties") {
                            checkPropertiesProperty = property;
                        } else if (property.Name == "CheckPublic") {
                            checkPublicProperty = property;
                        } else if (property.Name == "CheckProtected") {
                            checkProtectedProperty = property;
                        } else if (property.Name == "CheckPrivate") {
                            checkPrivateProperty = property;
                        } else if (property.Name == "MSBuildAllProjects") {
                            msbuildAllProjectsProperty = property;
                        }
                    }
                }
            }
        }
                
        [Test]
        public void UsingTaskName()
        {
            Assert.AreEqual("CCCPMSBuildTask.CheckCodeCommentsTask", targetFileUsingTask.TaskName);
        }
        
        [Test]
        public void UsingTaskAssemblyFile()
        {
            Assert.AreEqual("$(CheckCodeCommentsMSBuildExtensionsPath)ICSharpCode.CCCPLib.dll", targetFileUsingTask.AssemblyFile);
        }
        
        [Test]
        public void CheckCodeCommentsTaskName()
        {
            Assert.AreEqual("CheckCodeComments", checkCodeCommentsTarget.Name);
        }
        
        [Test]
        public void BuildTaskName()
        {
            Assert.AreEqual("CheckCodeCommentsTask", buildTask.Name);
        }
        
        [Test]
        public void BuildTaskParameterNames()
        {
            string [] expectedNames = new string[] { 
                "TreatParserErrorsAsPolicyViolation",
                "Sources",
                "Language",
                "CheckMethods",
                "CheckProperties",
                "CheckFields",
                "CheckClasses",
                "CheckEvents",
                "CheckPublic",
                "CheckPrivate",
                "CheckProtected",
                "ReportFileName"
            };
            Assert.AreEqual(expectedNames, buildTask.GetParameterNames());
        }
        
        [Test]
        public void TreatParserErrorsAsPolicyViolationParameterValue()
        {
            Assert.AreEqual("$(TreatParserErrorsAsPolicyViolation)", buildTask.GetParameterValue("TreatParserErrorsAsPolicyViolation"));
        }
        
        [Test]
        public void SourcesParameterValue()
        {
            Assert.AreEqual("@(Compile)", buildTask.GetParameterValue("Sources"));
        }
                
        [Test]
        public void LanguageParameterValue()
        {
            Assert.AreEqual("$(Language)", buildTask.GetParameterValue("Language"));
        }

        [Test]
        public void CheckMethodsParameterValue()
        {
            Assert.AreEqual("$(CheckMethods)", buildTask.GetParameterValue("CheckMethods"));
        }
        
        [Test]
        public void CheckPropertiesParameterValue()
        {
            Assert.AreEqual("$(CheckProperties)", buildTask.GetParameterValue("CheckProperties"));
        }

        [Test]
        public void CheckEventsParameterValue()
        {
            Assert.AreEqual("$(CheckEvents)", buildTask.GetParameterValue("CheckEvents"));
        }
        
        [Test]
        public void CheckClassesParameterValue()
        {
            Assert.AreEqual("$(CheckClasses)", buildTask.GetParameterValue("CheckClasses"));
        }        
        
        [Test]
        public void CheckFieldsParameterValue()
        {
            Assert.AreEqual("$(CheckFields)", buildTask.GetParameterValue("CheckFields"));
        }

        [Test]
        public void CheckPublicParameterValue()
        {
            Assert.AreEqual("$(CheckPublic)", buildTask.GetParameterValue("CheckPublic"));
        }
        
        [Test]
        public void CheckPrivateParameterValue()
        {
            Assert.AreEqual("$(CheckPrivate)", buildTask.GetParameterValue("CheckPrivate"));
        }
        
        [Test]
        public void CheckProtectedParameterValue()
        {
            Assert.AreEqual("$(CheckProtected)", buildTask.GetParameterValue("CheckProtected"));
        }
                
        [Test]
        public void ReportFileNameParameterValue()
        {
            Assert.AreEqual("$(ReportFileName)", buildTask.GetParameterValue("ReportFileName"));
        }
        
        [Test]
        public void CheckCodeCommentsTargetDependsOnTargets()
        {
            Assert.AreEqual("Compile", checkCodeCommentsTarget.DependsOnTargets);
        }
        
        [Test]
        public void BuildDependsOn()
        {
            Assert.AreEqual("BeforeBuild;CoreBuild;AfterBuild;CheckCodeComments", buildDependsOnProperty.Value);
        }
        
        [Test]
        public void DefaultReportFileName()
        {
            Assert.AreEqual("$(OutputPath)CodeCommentsReport.xml", reportFileNameProperty.Value);
        }

        [Test]
        public void DefaultReportFileNameCondition()
        {
            Assert.AreEqual(" '$(ReportFileName)' == '' ", reportFileNameProperty.Condition);
        }
        
        [Test]
        public void DefaultCheckMethodsValue()
        {
            Assert.AreEqual("True", checkMethodsProperty.Value);
        }

        [Test]
        public void DefaultCheckMethodsCondition()
        {
            Assert.AreEqual(" '$(CheckMethods)' == '' ", checkMethodsProperty.Condition);
        }

        [Test]
        public void DefaultCheckClassesValue()
        {
            Assert.AreEqual("True", checkClassesProperty.Value);
        }

        [Test]
        public void DefaultCheckClassesCondition()
        {
            Assert.AreEqual(" '$(CheckClasses)' == '' ", checkClassesProperty.Condition);
        }

        [Test]
        public void DefaultCheckEventsValue()
        {
            Assert.AreEqual("True", checkEventsProperty.Value);
        }

        [Test]
        public void DefaultCheckEventsCondition()
        {
            Assert.AreEqual(" '$(CheckEvents)' == '' ", checkEventsProperty.Condition);
        }

        [Test]
        public void DefaultCheckFieldsValue()
        {
            Assert.AreEqual("True", checkFieldsProperty.Value);
        }

        [Test]
        public void DefaultCheckFieldsCondition()
        {
            Assert.AreEqual(" '$(CheckFields)' == '' ", checkFieldsProperty.Condition);
        }

        [Test]
        public void DefaultCheckPropertiesValue()
        {
            Assert.AreEqual("True", checkPropertiesProperty.Value);
        }

        [Test]
        public void DefaultCheckPropertiesCondition()
        {
            Assert.AreEqual(" '$(CheckProperties)' == '' ", checkPropertiesProperty.Condition);
        }

        [Test]
        public void DefaultCheckPublicValue()
        {
            Assert.AreEqual("True", checkPublicProperty.Value);
        }

        [Test]
        public void DefaultCheckPublicCondition()
        {
            Assert.AreEqual(" '$(CheckPublic)' == '' ", checkPublicProperty.Condition);
        }

        [Test]
        public void DefaultCheckProtectedValue()
        {
            Assert.AreEqual("True", checkProtectedProperty.Value);
        }

        [Test]
        public void DefaultCheckProtectedCondition()
        {
            Assert.AreEqual(" '$(CheckProtected)' == '' ", checkProtectedProperty.Condition);
        }        

        [Test]
        public void DefaultCheckPrivateValue()
        {
            Assert.AreEqual("True", checkPrivateProperty.Value);
        }

        [Test]
        public void DefaultCheckPrivateCondition()
        {
            Assert.AreEqual(" '$(CheckPrivate)' == '' ", checkPrivateProperty.Condition);
        }        

        [Test]
        public void MSBuildAllProjectsProperty()
        {
            Assert.AreEqual("$(MSBuildAllProjects);$(CheckCodeCommentsMSBuildExtensionsPath)CheckCodeComments.targets", msbuildAllProjectsProperty.Value);
        }
        
        static string GetProjectXml()
        {
            return "<Project DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n" +
                  "<Import Project=\"CheckCodeCommentsTask.targets\" />\r\n" +
                "</Project>";
        }
    }
}

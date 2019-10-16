using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_1;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void SchemaTesting()
        {
            Request_Alumno target = new Request_Alumno();

            //=== Schema input file for validation ===//
            string strSourcePO_XML = @"C:\Users\Josue\documents\visual studio 2015\Projects\Practice_1\UnitTestProject1\TestDir\Request_Alumno_output.xml";

            //=== Validate the XML Input message against the schema ===//
            Assert.IsTrue(target.ValidateInstance(strSourcePO_XML,
                       Microsoft.BizTalk.TestTools.Schema.OutputInstanceType.XML));
        }

        [TestMethod()]
        public void MapTesting()
        {
            /*********************************************************************************
            * There is a bug with Map Unit Test inside Microsoft.BizTalk.TestTools.dll 
            * Microsoft had missed on to upgrade TestableMapBase class. They still using the 
            * BTSXslTransform instead of using XslCompiledTransform witch will cause the 
            * TestMap() function to failed.
            * 
            * The following code was the expected code for BizTalk Map unit testing 
            *********************************************************************************/

            Map_Response_system map = new Map_Response_system();

            //=== Use the HelloWorld sample directory path for the message files ===//
            string strSourcePO_XML = @"C:\Users\Josue\documents\visual studio 2015\Projects\Practice_1\UnitTestProject1\TestDir\Request_Alumno_output.xml";
            string strDestInvoice_XML = @"C:\Users\Josue\documents\visual studio 2015\Projects\Practice_1\UnitTestProject1\TestDir\testig.xml";


            //=== Test the map by using the TestMap method of the TestableMapBase class ===//
            map.ValidateOutput = true;
            map.TestMap(strSourcePO_XML,
                                  Microsoft.BizTalk.TestTools.Schema.InputInstanceType.Xml,
                                  strDestInvoice_XML,
                                  Microsoft.BizTalk.TestTools.Schema.OutputInstanceType.XML);


            //=== Output file should be created as a result of testing the map ===//
            Assert.IsTrue(File.Exists(strDestInvoice_XML));
        }
    }
}

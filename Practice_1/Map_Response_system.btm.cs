namespace Practice_1 {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Practice_1.Request_Alumno", typeof(global::Practice_1.Request_Alumno))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"Practice_1.Response_Alumno", typeof(global::Practice_1.Response_Alumno))]
    public sealed class Map_Response_system : global::Microsoft.BizTalk.TestTools.Mapper.TestableMapBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""UTF-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0 userCSharp"" version=""1.0"" xmlns:s0=""http://Practice_1.Request_Alumno"" xmlns:ns0=""http://Practice_1.Response_Alumno"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:Request_system"" />
  </xsl:template>
  <xsl:template match=""/s0:Request_system"">
    <xsl:variable name=""var:v1"" select=""userCSharp:StringConcat(&quot;Hola &quot; , string(Nombre/text()) , &quot; &quot; , string(Apellidos/text()) , &quot;!, tu tienes &quot; , string(Edad/text()) , &quot; años.&quot;)"" />
    <ns0:Response_system>
      <result>
        <xsl:value-of select=""$var:v1"" />
      </result>
    </ns0:Response_system>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp""><![CDATA[
public string StringConcat(string param0, string param1, string param2, string param3, string param4, string param5, string param6)
{
   return param0 + param1 + param2 + param3 + param4 + param5 + param6;
}



]]></msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"Practice_1.Request_Alumno";
        
        private const global::Practice_1.Request_Alumno _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"Practice_1.Response_Alumno";
        
        private const global::Practice_1.Response_Alumno _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"Practice_1.Request_Alumno";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"Practice_1.Response_Alumno";
                return _TrgSchemas;
            }
        }
    }
}

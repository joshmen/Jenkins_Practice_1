namespace Practice_1 {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"http://Practice_1.Request_Alumno",@"Request_system")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"Request_system"})]
    public sealed class Request_Alumno : Microsoft.BizTalk.TestTools.Schema.TestableSchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://Practice_1.Request_Alumno"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""http://Practice_1.Request_Alumno"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""Request_system"">
    <xs:complexType>
      <xs:sequence>
        <xs:element name=""Nombre"" type=""xs:string"" />
        <xs:element name=""Apellidos"" type=""xs:string"" />
        <xs:element name=""Edad"" type=""xs:string"" />
        <xs:element minOccurs=""0"" maxOccurs=""unbounded"" name=""Contactos"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""Nombre"" type=""xs:string"" />
              <xs:element name=""Apellidos"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public Request_Alumno() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "Request_system";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
